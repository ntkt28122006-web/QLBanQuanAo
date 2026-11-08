
IF DB_ID(N'QLBANHANG') IS NULL
    CREATE DATABASE QLBANHANG;
GO
USE QLBANHANG;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

/* 0. Xoa schema cu theo thu tu phu thuoc. Chi xoa cac bang cua do an nay. */
DROP TABLE IF EXISTS dbo.reviews;
DROP TABLE IF EXISTS dbo.order_items;
DROP TABLE IF EXISTS dbo.orders;
DROP TABLE IF EXISTS dbo.cart_items;
DROP TABLE IF EXISTS dbo.carts;
DROP TABLE IF EXISTS dbo.inventory;
DROP TABLE IF EXISTS dbo.product_images;
DROP TABLE IF EXISTS dbo.product_variants;
DROP TABLE IF EXISTS dbo.product_sizes;
DROP TABLE IF EXISTS dbo.product_colors;
DROP TABLE IF EXISTS dbo.products;
DROP TABLE IF EXISTS dbo.categories;
DROP TABLE IF EXISTS dbo.addresses;
DROP TABLE IF EXISTS dbo.role_permissions;
DROP TABLE IF EXISTS dbo.user_roles;
DROP TABLE IF EXISTS dbo.permissions;
DROP TABLE IF EXISTS dbo.roles;
DROP TABLE IF EXISTS dbo.users;
GO

/* 1. Tai khoan va phan quyen RBAC */
CREATE TABLE dbo.users (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_users PRIMARY KEY,
    full_name NVARCHAR(100) NOT NULL,
    email VARCHAR(254) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NULL,
    -- Xac minh email/tai khoan bang OTP: chi luu ma OTP da bam hash, khong luu OTP thuan.
    email_verified BIT NOT NULL CONSTRAINT DF_users_email_verified DEFAULT (0),
    email_verified_at DATETIME2(0) NULL,
    email_verification_otp_hash VARCHAR(255) NULL,
    email_verification_otp_expires_at DATETIME2(0) NULL,
    -- Quen mat khau: OTP rieng, khong dung chung voi OTP xac minh tai khoan.
    password_reset_otp_hash VARCHAR(255) NULL,
    password_reset_otp_expires_at DATETIME2(0) NULL,
    status VARCHAR(20) NOT NULL CONSTRAINT DF_users_status DEFAULT ('active'),
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_users_created_at DEFAULT (SYSDATETIME()),
    updated_at DATETIME2(0) NOT NULL CONSTRAINT DF_users_updated_at DEFAULT (SYSDATETIME()),
    CONSTRAINT UQ_users_email UNIQUE (email),
    CONSTRAINT CK_users_status CHECK (status IN ('active','inactive','banned'))
);

CREATE TABLE dbo.roles (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_roles PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description NVARCHAR(255) NULL,
    CONSTRAINT UQ_roles_name UNIQUE (name)
);

CREATE TABLE dbo.permissions (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_permissions PRIMARY KEY,
    code VARCHAR(100) NOT NULL,
    description NVARCHAR(255) NULL,
    CONSTRAINT UQ_permissions_code UNIQUE (code)
);

CREATE TABLE dbo.user_roles (
    user_id INT NOT NULL,
    role_id INT NOT NULL,
    CONSTRAINT PK_user_roles PRIMARY KEY (user_id, role_id),
    CONSTRAINT FK_user_roles_users FOREIGN KEY (user_id) REFERENCES dbo.users(id) ON DELETE CASCADE,
    CONSTRAINT FK_user_roles_roles FOREIGN KEY (role_id) REFERENCES dbo.roles(id) ON DELETE CASCADE
);

CREATE TABLE dbo.role_permissions (
    role_id INT NOT NULL,
    permission_id INT NOT NULL,
    CONSTRAINT PK_role_permissions PRIMARY KEY (role_id, permission_id),
    CONSTRAINT FK_role_permissions_roles FOREIGN KEY (role_id) REFERENCES dbo.roles(id) ON DELETE CASCADE,
    CONSTRAINT FK_role_permissions_permissions FOREIGN KEY (permission_id) REFERENCES dbo.permissions(id) ON DELETE CASCADE
);

/* 2. Dia chi giao hang */
CREATE TABLE dbo.addresses (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_addresses PRIMARY KEY,
    user_id INT NOT NULL,
    recipient_name NVARCHAR(100) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    street NVARCHAR(200) NOT NULL,
    ward NVARCHAR(100) NULL,
    district NVARCHAR(100) NULL,
    city NVARCHAR(100) NOT NULL,
    postal_code VARCHAR(20) NULL,
    is_default BIT NOT NULL CONSTRAINT DF_addresses_is_default DEFAULT (0),
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_addresses_created_at DEFAULT (SYSDATETIME()),
    CONSTRAINT FK_addresses_users FOREIGN KEY (user_id) REFERENCES dbo.users(id) ON DELETE CASCADE
);

/* 3. Danh muc va san pham */
CREATE TABLE dbo.categories (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_categories PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    slug VARCHAR(120) NOT NULL,
    parent_id INT NULL,
    is_active BIT NOT NULL CONSTRAINT DF_categories_is_active DEFAULT (1),
    CONSTRAINT UQ_categories_slug UNIQUE (slug),
    CONSTRAINT CK_categories_not_self CHECK (parent_id IS NULL OR parent_id <> id),
    CONSTRAINT FK_categories_parent FOREIGN KEY (parent_id) REFERENCES dbo.categories(id)
);

CREATE TABLE dbo.products (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_products PRIMARY KEY,
    category_id INT NULL,
    name NVARCHAR(200) NOT NULL,
    slug VARCHAR(220) NOT NULL,
    description NVARCHAR(MAX) NULL,
    price DECIMAL(12,2) NOT NULL,
    sale_price DECIMAL(12,2) NULL,
    brand NVARCHAR(100) NULL,
    status VARCHAR(20) NOT NULL CONSTRAINT DF_products_status DEFAULT ('active'),
    is_hot BIT NOT NULL CONSTRAINT DF_products_is_hot DEFAULT (0),
    is_sale BIT NOT NULL CONSTRAINT DF_products_is_sale DEFAULT (0),
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_products_created_at DEFAULT (SYSDATETIME()),
    updated_at DATETIME2(0) NOT NULL CONSTRAINT DF_products_updated_at DEFAULT (SYSDATETIME()),
    CONSTRAINT UQ_products_slug UNIQUE (slug),
    CONSTRAINT CK_products_price CHECK (price >= 0),
    CONSTRAINT CK_products_sale_price CHECK (sale_price IS NULL OR (sale_price >= 0 AND sale_price < price)),
    CONSTRAINT CK_products_sale_flag CHECK (
        (is_sale = 0 AND sale_price IS NULL) OR
        (is_sale = 1 AND sale_price IS NOT NULL AND sale_price < price)
    ),
    CONSTRAINT CK_products_status CHECK (status IN ('active','inactive','out_of_stock')),
    CONSTRAINT FK_products_categories FOREIGN KEY (category_id) REFERENCES dbo.categories(id) ON DELETE SET NULL
);

/* Danh muc gia tri mau/size duoc chuan hoa, tranh danh sach phan cach dau phay. */
CREATE TABLE dbo.product_colors (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_product_colors PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    hex_code CHAR(7) NULL,
    CONSTRAINT UQ_product_colors_name UNIQUE (name),
    CONSTRAINT CK_product_colors_hex CHECK (hex_code IS NULL OR hex_code LIKE '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]')
);

CREATE TABLE dbo.product_sizes (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_product_sizes PRIMARY KEY,
    name NVARCHAR(20) NOT NULL,
    sort_order INT NOT NULL CONSTRAINT DF_product_sizes_sort DEFAULT (0),
    CONSTRAINT UQ_product_sizes_name UNIQUE (name),
    CONSTRAINT CK_product_sizes_sort CHECK (sort_order >= 0)
);

/* Moi SKU la mot to hop san pham + mau + size. Mau/size co the NULL cho phu kien
   khong phan loai; filtered unique index ben duoi cho phep truong hop nay. */
CREATE TABLE dbo.product_variants (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_product_variants PRIMARY KEY,
    product_id INT NOT NULL,
    sku VARCHAR(64) NOT NULL,
    color_id INT NULL,
    size_id INT NULL,
    price_override DECIMAL(12,2) NULL,
    is_active BIT NOT NULL CONSTRAINT DF_product_variants_is_active DEFAULT (1),
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_product_variants_created_at DEFAULT (SYSDATETIME()),
    CONSTRAINT UQ_product_variants_sku UNIQUE (sku),
    CONSTRAINT CK_product_variants_price CHECK (price_override IS NULL OR price_override >= 0),
    CONSTRAINT FK_product_variants_products FOREIGN KEY (product_id) REFERENCES dbo.products(id) ON DELETE CASCADE,
    CONSTRAINT FK_product_variants_colors FOREIGN KEY (color_id) REFERENCES dbo.product_colors(id),
    CONSTRAINT FK_product_variants_sizes FOREIGN KEY (size_id) REFERENCES dbo.product_sizes(id)
);
CREATE UNIQUE INDEX UX_product_variants_product_color_size
ON dbo.product_variants(product_id, color_id, size_id)
WHERE color_id IS NOT NULL AND size_id IS NOT NULL;
CREATE UNIQUE INDEX UX_product_variants_product_color_no_size
ON dbo.product_variants(product_id, color_id)
WHERE color_id IS NOT NULL AND size_id IS NULL;
CREATE UNIQUE INDEX UX_product_variants_product_size_no_color
ON dbo.product_variants(product_id, size_id)
WHERE color_id IS NULL AND size_id IS NOT NULL;
CREATE UNIQUE INDEX UX_product_variants_product_no_color_size
ON dbo.product_variants(product_id)
WHERE color_id IS NULL AND size_id IS NULL;

/* Anh co the gan vao ca san pham (variant_id NULL) hoac rieng mot bien the/mau. */
CREATE TABLE dbo.product_images (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_product_images PRIMARY KEY,
    product_id INT NOT NULL,
    variant_id INT NULL,
    image_url NVARCHAR(1000) NOT NULL,
    alt_text NVARCHAR(200) NULL,
    sort_order INT NOT NULL CONSTRAINT DF_product_images_sort DEFAULT (0),
    is_primary BIT NOT NULL CONSTRAINT DF_product_images_primary DEFAULT (0),
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_product_images_created DEFAULT (SYSDATETIME()),
    CONSTRAINT CK_product_images_sort CHECK (sort_order >= 0),
    CONSTRAINT FK_product_images_products FOREIGN KEY (product_id) REFERENCES dbo.products(id) ON DELETE CASCADE,
    CONSTRAINT FK_product_images_variants FOREIGN KEY (variant_id) REFERENCES dbo.product_variants(id)
);
CREATE INDEX IX_product_images_product_sort ON dbo.product_images(product_id, sort_order);

/* Ton kho 1-1 voi bien the, khong con UNIQUE(product_id) nhu schema cu. */
CREATE TABLE dbo.inventory (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_inventory PRIMARY KEY,
    variant_id INT NOT NULL,
    stock_quantity INT NOT NULL CONSTRAINT DF_inventory_quantity DEFAULT (0),
    updated_at DATETIME2(0) NOT NULL CONSTRAINT DF_inventory_updated DEFAULT (SYSDATETIME()),
    CONSTRAINT UQ_inventory_variant UNIQUE (variant_id),
    CONSTRAINT CK_inventory_quantity CHECK (stock_quantity >= 0),
    CONSTRAINT FK_inventory_variant FOREIGN KEY (variant_id) REFERENCES dbo.product_variants(id) ON DELETE CASCADE
);

/* 4. Gio hang */
CREATE TABLE dbo.carts (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_carts PRIMARY KEY,
    user_id INT NOT NULL,
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_carts_created DEFAULT (SYSDATETIME()),
    updated_at DATETIME2(0) NOT NULL CONSTRAINT DF_carts_updated DEFAULT (SYSDATETIME()),
    CONSTRAINT UQ_carts_user UNIQUE (user_id),
    CONSTRAINT FK_carts_users FOREIGN KEY (user_id) REFERENCES dbo.users(id) ON DELETE CASCADE
);

CREATE TABLE dbo.cart_items (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_cart_items PRIMARY KEY,
    cart_id INT NOT NULL,
    variant_id INT NOT NULL,
    quantity INT NOT NULL CONSTRAINT DF_cart_items_quantity DEFAULT (1),
    added_at DATETIME2(0) NOT NULL CONSTRAINT DF_cart_items_added DEFAULT (SYSDATETIME()),
    CONSTRAINT CK_cart_items_quantity CHECK (quantity > 0),
    CONSTRAINT UQ_cart_items_cart_variant UNIQUE (cart_id, variant_id),
    CONSTRAINT FK_cart_items_carts FOREIGN KEY (cart_id) REFERENCES dbo.carts(id) ON DELETE CASCADE,
    CONSTRAINT FK_cart_items_variants FOREIGN KEY (variant_id) REFERENCES dbo.product_variants(id)
);

/* 5. Don hang va chi tiet don hang.
   product_name/sku/color_name/size_name la snapshot lich su tai thoi diem dat. */
CREATE TABLE dbo.orders (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_orders PRIMARY KEY,
    user_id INT NOT NULL,
    address_id INT NULL,
    recipient_name NVARCHAR(100) NOT NULL,
    recipient_phone VARCHAR(20) NOT NULL,
    shipping_address NVARCHAR(500) NOT NULL,
    subtotal DECIMAL(12,2) NOT NULL,
    shipping_fee DECIMAL(12,2) NOT NULL CONSTRAINT DF_orders_shipping_fee DEFAULT (0),
    discount_amount DECIMAL(12,2) NOT NULL CONSTRAINT DF_orders_discount DEFAULT (0),
    total_amount DECIMAL(12,2) NOT NULL,
    status VARCHAR(30) NOT NULL CONSTRAINT DF_orders_status DEFAULT ('pending'),
    payment_status VARCHAR(20) NOT NULL CONSTRAINT DF_orders_payment_status DEFAULT ('unpaid'),
    note NVARCHAR(500) NULL,
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_orders_created DEFAULT (SYSDATETIME()),
    updated_at DATETIME2(0) NOT NULL CONSTRAINT DF_orders_updated DEFAULT (SYSDATETIME()),
    CONSTRAINT CK_orders_amounts CHECK (
        subtotal >= 0 AND shipping_fee >= 0 AND discount_amount >= 0 AND
        discount_amount <= subtotal AND total_amount = subtotal + shipping_fee - discount_amount
    ),
    CONSTRAINT CK_orders_status CHECK (status IN ('pending','confirmed','processing','shipping','completed','cancelled','returned')),
    CONSTRAINT CK_orders_payment_status CHECK (payment_status IN ('unpaid','pending','paid','refunded','failed')),
    CONSTRAINT FK_orders_users FOREIGN KEY (user_id) REFERENCES dbo.users(id),
    CONSTRAINT FK_orders_addresses FOREIGN KEY (address_id) REFERENCES dbo.addresses(id) ON DELETE SET NULL
);

CREATE TABLE dbo.order_items (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_order_items PRIMARY KEY,
    order_id INT NOT NULL,
    variant_id INT NULL,
    product_name NVARCHAR(200) NOT NULL,
    sku VARCHAR(64) NOT NULL,
    color_name NVARCHAR(50) NULL,
    size_name NVARCHAR(20) NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(12,2) NOT NULL,
    line_total AS (CONVERT(DECIMAL(12,2), quantity * unit_price)) PERSISTED,
    CONSTRAINT CK_order_items_quantity CHECK (quantity > 0),
    CONSTRAINT CK_order_items_unit_price CHECK (unit_price >= 0),
    CONSTRAINT FK_order_items_orders FOREIGN KEY (order_id) REFERENCES dbo.orders(id) ON DELETE CASCADE,
    CONSTRAINT FK_order_items_variants FOREIGN KEY (variant_id) REFERENCES dbo.product_variants(id) ON DELETE SET NULL
);
CREATE INDEX IX_order_items_order_id ON dbo.order_items(order_id);
CREATE INDEX IX_orders_user_created ON dbo.orders(user_id, created_at DESC);
CREATE INDEX IX_products_category_status ON dbo.products(category_id, status);
CREATE INDEX IX_variants_product ON dbo.product_variants(product_id);

/* 6. Danh gia */
CREATE TABLE dbo.reviews (
    id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_reviews PRIMARY KEY,
    product_id INT NOT NULL,
    user_id INT NOT NULL,
    rating TINYINT NOT NULL,
    comment NVARCHAR(1000) NULL,
    created_at DATETIME2(0) NOT NULL CONSTRAINT DF_reviews_created DEFAULT (SYSDATETIME()),
    CONSTRAINT CK_reviews_rating CHECK (rating BETWEEN 1 AND 5),
    CONSTRAINT UQ_reviews_user_product UNIQUE (user_id, product_id),
    CONSTRAINT FK_reviews_products FOREIGN KEY (product_id) REFERENCES dbo.products(id),
    CONSTRAINT FK_reviews_users FOREIGN KEY (user_id) REFERENCES dbo.users(id)
);
GO

ALTER TABLE users ADD password_reset_attempts INT NOT NULL DEFAULT 0;
GO

/* 7. Du lieu mau. IDENTITY_INSERT duoc bat/tat tuong minh de ID mau co the doc. */
SET IDENTITY_INSERT dbo.roles ON;
INSERT INTO dbo.roles (id, name, description) VALUES
(1, N'Admin', N'Quan tri vien he thong'),
(2, N'Customer', N'Khach hang mua san pham'),
(3, N'Shipper', N'Nhan vien giao hang'),
(4, N'InventoryManager', N'Quan ly san pham va ton kho');
SET IDENTITY_INSERT dbo.roles OFF;

SET IDENTITY_INSERT dbo.permissions ON;
INSERT INTO dbo.permissions (id, code, description) VALUES
(1, 'product:create', N'Them san pham'),
(2, 'product:update', N'Cap nhat san pham'),
(3, 'product:delete', N'Xoa san pham'),
(4, 'product:view', N'Xem san pham'),
(5, 'inventory:manage', N'Quan ly ton kho'),
(6, 'order:manage', N'Quan ly don hang'),
(7, 'order:view_own', N'Xem don hang cua minh'),
(8, 'user:manage', N'Quan ly tai khoan'),
(9, 'review:create', N'Tao danh gia'),
(10, 'report:view', N'Xem bao cao');
SET IDENTITY_INSERT dbo.permissions OFF;

INSERT INTO dbo.role_permissions (role_id, permission_id) VALUES
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),
(2,4),(2,7),(2,9),
(3,6),
(4,1),(4,2),(4,4),(4,5),(4,10);

SET IDENTITY_INSERT dbo.users ON;
INSERT INTO dbo.users (id, full_name, email, password_hash, phone, status) VALUES
(1, N'Nguyen Van Quan Tri', 'admin@store.com', 'REPLACE_WITH_VALID_BCRYPT_HASH', '0901234567', 'active'),
(2, N'Tran Thi Khach Hang', 'khachhang@gmail.com', 'REPLACE_WITH_VALID_BCRYPT_HASH', '0987654321', 'active'),
(3, N'Le Minh Anh', 'minhanh@example.com', 'REPLACE_WITH_VALID_BCRYPT_HASH', '0912345678', 'active');
SET IDENTITY_INSERT dbo.users OFF;
INSERT INTO dbo.user_roles (user_id, role_id) VALUES (1,1),(2,2),(3,2);

SET IDENTITY_INSERT dbo.addresses ON;
INSERT INTO dbo.addresses (id, user_id, recipient_name, phone, street, ward, district, city, postal_code, is_default) VALUES
(1,2,N'Tran Thi Khach Hang', '0987654321', N'123 Nguyen Trai', N'Ben Thanh', N'Quan 1', N'TP. Ho Chi Minh', '700000', 1),
(2,3,N'Le Minh Anh', '0912345678', N'45 Le Loi', N'Ben Nghe', N'Quan 1', N'TP. Ho Chi Minh', '700000', 1);
SET IDENTITY_INSERT dbo.addresses OFF;

SET IDENTITY_INSERT dbo.categories ON;
INSERT INTO dbo.categories (id, name, slug, parent_id, is_active) VALUES
(1,N'Ao', 'ao', NULL, 1),
(2,N'Quan', 'quan', NULL, 1),
(3,N'Vay va dam', 'vay-dam', NULL, 1),
(4,N'Phu kien', 'phu-kien', NULL, 1),
(5,N'Ao thun', 'ao-thun', 1, 1),
(6,N'Ao so mi', 'ao-so-mi', 1, 1),
(7,N'Ao khoac va hoodie', 'ao-khoac-hoodie', 1, 1),
(8,N'Quan jeans', 'quan-jeans', 2, 1),
(9,N'Quan tay', 'quan-tay', 2, 1);
SET IDENTITY_INSERT dbo.categories OFF;

SET IDENTITY_INSERT dbo.product_colors ON;
INSERT INTO dbo.product_colors (id, name, hex_code) VALUES
(1,N'Den','#000000'),(2,N'Trang','#FFFFFF'),(3,N'Xanh navy','#1F2A44'),
(4,N'Be','#D8C3A5'),(5,N'Xam','#808080'),(6,N'Xanh la','#228B22');
SET IDENTITY_INSERT dbo.product_colors OFF;

SET IDENTITY_INSERT dbo.product_sizes ON;
INSERT INTO dbo.product_sizes (id, name, sort_order) VALUES
(1,N'XS',1),(2,N'S',2),(3,N'M',3),(4,N'L',4),(5,N'XL',5),(6,N'XXL',6),(7,N'Free size',7);
SET IDENTITY_INSERT dbo.product_sizes OFF;

SET IDENTITY_INSERT dbo.products ON;
INSERT INTO dbo.products (id, category_id, name, slug, description, price, sale_price, brand, status, is_hot, is_sale) VALUES
(1,5,N'Ao thun cotton basic', 'ao-thun-cotton-basic', N'Ao thun cotton mac hang ngay, form regular.', 199000, 159000, N'Everyday', 'active', 1, 1),
(2,6,N'Ao so mi Oxford', 'ao-so-mi-oxford', N'Ao so mi Oxford phu hop di hoc va di lam.', 329000, NULL, N'Everyday', 'active', 1, 0),
(3,7,N'Hoodie ni bong', 'hoodie-ni-bong', N'Hoodie vai ni mem, phong cach tre trung.', 459000, 399000, N'Streetwear', 'active', 0, 1),
(4,8,N'Quan jeans straight fit', 'quan-jeans-straight-fit', N'Quan jeans ong dung, de phoi do.', 499000, NULL, N'Denim Lab', 'active', 1, 0),
(5,3,N'Dam midi toi gian', 'dam-midi-toi-gian', N'Dam midi phong cach toi gian.', 589000, 529000, N'Modern Muse', 'active', 0, 1),
(6,4,N'Tui tote canvas', 'tui-tote-canvas', N'Tui tote canvas dung phu kien hang ngay.', 129000, NULL, N'Everyday', 'active', 0, 0);
SET IDENTITY_INSERT dbo.products OFF;

SET IDENTITY_INSERT dbo.product_variants ON;
INSERT INTO dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active) VALUES
(1,1,'TSH-BLK-S',1,2,NULL,1),(2,1,'TSH-BLK-M',1,3,NULL,1),(3,1,'TSH-BLK-L',1,4,NULL,1),
(4,1,'TSH-WHT-S',2,2,NULL,1),(5,1,'TSH-WHT-M',2,3,NULL,1),(6,1,'TSH-WHT-L',2,4,NULL,1),
(7,1,'TSH-NVY-M',3,3,NULL,1),(8,1,'TSH-NVY-L',3,4,NULL,1),
(9,2,'OXF-WHT-M',2,3,NULL,1),(10,2,'OXF-WHT-L',2,4,NULL,1),(11,2,'OXF-NVY-M',3,3,NULL,1),
(12,3,'HOD-GRY-M',5,3,NULL,1),(13,3,'HOD-GRY-L',5,4,NULL,1),(14,3,'HOD-BLK-XL',1,5,NULL,1),
(15,4,'JNS-BLU-M',3,3,519000,1),(16,4,'JNS-BLU-L',3,4,519000,1),
(17,5,'DRS-BEG-S',4,2,NULL,1),(18,5,'DRS-BEG-M',4,3,NULL,1),
(19,6,'TOTE-NAT-FS',4,7,NULL,1);
SET IDENTITY_INSERT dbo.product_variants OFF;

SET IDENTITY_INSERT dbo.product_images ON;
INSERT INTO dbo.product_images (id, product_id, variant_id, image_url, alt_text, sort_order, is_primary) VALUES
(1,1,NULL,N'/uploads/products/ao-thun-basic-front.jpg',N'Ao thun cotton basic mat truoc',1,1),
(2,1,NULL,N'/uploads/products/ao-thun-basic-back.jpg',N'Ao thun cotton basic mat sau',2,0),
(3,1,1,N'/uploads/products/ao-thun-basic-black.jpg',N'Ao thun mau den',3,0),
(4,1,4,N'/uploads/products/ao-thun-basic-white.jpg',N'Ao thun mau trang',4,0),
(5,2,NULL,N'/uploads/products/ao-so-mi-oxford.jpg',N'Ao so mi Oxford',1,1),
(6,3,NULL,N'/uploads/products/hoodie-ni-bong.jpg',N'Hoodie ni bong',1,1),
(7,4,NULL,N'/uploads/products/quan-jeans-straight.jpg',N'Quan jeans straight fit',1,1),
(8,5,NULL,N'/uploads/products/dam-midi.jpg',N'Dam midi toi gian',1,1),
(9,6,NULL,N'/uploads/products/tui-tote.jpg',N'Tui tote canvas',1,1);
SET IDENTITY_INSERT dbo.product_images OFF;

SET IDENTITY_INSERT dbo.inventory ON;
INSERT INTO dbo.inventory (id, variant_id, stock_quantity) VALUES
(1,1,12),(2,2,25),(3,3,7),(4,4,18),(5,5,0),(6,6,9),(7,7,14),(8,8,5),
(9,9,8),(10,10,6),(11,11,4),(12,12,11),(13,13,3),(14,14,2),
(15,15,10),(16,16,8),(17,17,6),(18,18,4),(19,19,20);
SET IDENTITY_INSERT dbo.inventory OFF;

SET IDENTITY_INSERT dbo.carts ON;
INSERT INTO dbo.carts (id, user_id) VALUES (1,2),(2,3);
SET IDENTITY_INSERT dbo.carts OFF;

SET IDENTITY_INSERT dbo.cart_items ON;
INSERT INTO dbo.cart_items (id, cart_id, variant_id, quantity) VALUES (1,1,2,2),(2,1,4,1),(3,2,9,1);
SET IDENTITY_INSERT dbo.cart_items OFF;

SET IDENTITY_INSERT dbo.orders ON;
INSERT INTO dbo.orders
(id, user_id, address_id, recipient_name, recipient_phone, shipping_address, subtotal, shipping_fee, discount_amount, total_amount, status, payment_status, note)
VALUES
(1,2,1,N'Tran Thi Khach Hang','0987654321',N'123 Nguyen Trai, Ben Thanh, Quan 1, TP. Ho Chi Minh',477000,30000,0,507000,'processing','unpaid',N'Giao gio hanh chinh'),
(2,3,2,N'Le Minh Anh','0912345678',N'45 Le Loi, Ben Nghe, Quan 1, TP. Ho Chi Minh',399000,0,0,399000,'completed','paid',NULL);
SET IDENTITY_INSERT dbo.orders OFF;

SET IDENTITY_INSERT dbo.order_items ON;
INSERT INTO dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES
(1,1,2,N'Ao thun cotton basic','TSH-BLK-M',N'Den',N'M',2,159000),
(2,1,4,N'Ao thun cotton basic','TSH-WHT-S',N'Trang',N'S',1,159000),
(3,2,12,N'Hoodie ni bong','HOD-GRY-M',N'Xam',N'M',1,399000);
SET IDENTITY_INSERT dbo.order_items OFF;

SET IDENTITY_INSERT dbo.reviews ON;
INSERT INTO dbo.reviews (id, product_id, user_id, rating, comment) VALUES
(1,1,2,5,N'Ao mac thoai mai, chat vai tot.'),
(2,3,3,4,N'Form dep, nen xem bang size truoc khi dat.');
SET IDENTITY_INSERT dbo.reviews OFF;
GO

/* 8. TRUY VAN KIEM THU - co the chay rieng sau khi script tao schema thanh cong. */

-- Kiem thu 1: mot san pham co nhieu mau/size va SKU
SELECT p.name, v.sku, c.name AS color_name, s.name AS size_name
FROM dbo.products p
JOIN dbo.product_variants v ON v.product_id = p.id
LEFT JOIN dbo.product_colors c ON c.id = v.color_id
LEFT JOIN dbo.product_sizes s ON s.id = v.size_id
WHERE p.id = 1
ORDER BY c.name, s.sort_order;

-- Kiem thu 2: ton kho rieng tung bien the
SELECT p.name, v.sku, c.name AS color_name, s.name AS size_name, i.stock_quantity
FROM dbo.product_variants v
JOIN dbo.products p ON p.id = v.product_id
LEFT JOIN dbo.product_colors c ON c.id = v.color_id
LEFT JOIN dbo.product_sizes s ON s.id = v.size_id
JOIN dbo.inventory i ON i.variant_id = v.id
WHERE p.id = 1
ORDER BY v.sku;

-- Kiem thu 3: cung mot mau ao, hai size khac nhau trong gio hang
SELECT ca.id AS cart_id, p.name, v.sku, c.name AS color_name, s.name AS size_name, ci.quantity
FROM dbo.cart_items ci
JOIN dbo.carts ca ON ca.id = ci.cart_id
JOIN dbo.product_variants v ON v.id = ci.variant_id
JOIN dbo.products p ON p.id = v.product_id
LEFT JOIN dbo.product_colors c ON c.id = v.color_id
LEFT JOIN dbo.product_sizes s ON s.id = v.size_id
WHERE ca.id = 1;

-- Kiem thu 4 va 5: cac dong don hang giu SKU, mau, size, don gia tai luc mua
SELECT oi.order_id, oi.product_name, oi.sku, oi.color_name, oi.size_name,
       oi.quantity, oi.unit_price, oi.line_total
FROM dbo.order_items oi
WHERE oi.order_id = 1;

-- Kiem thu 6a: SKU trung se bi tu choi (bo comment de tu kiem thu trong transaction)
-- BEGIN TRAN;
-- INSERT INTO dbo.product_variants(product_id, sku, color_id, size_id) VALUES (1,'TSH-BLK-S',1,2);
-- ROLLBACK;

-- Kiem thu 6b: ton kho am se bi tu choi (bo comment de tu kiem thu trong transaction)
-- BEGIN TRAN;
-- UPDATE dbo.inventory SET stock_quantity = -1 WHERE variant_id = 1;
-- ROLLBACK;

-- Kiem thu 7a: bien the khong co ton kho - ket qua mong doi: 0 dong
SELECT v.id, v.sku
FROM dbo.product_variants v
LEFT JOIN dbo.inventory i ON i.variant_id = v.id
WHERE i.variant_id IS NULL;

-- Kiem thu 7b: tong chi tiet don hang va tong don hang de doi chieu.
-- Don hang mau 1 co subtotal 477000 = 2*159000 + 1*159000.
SELECT o.id AS order_id, o.subtotal,
       SUM(oi.line_total) AS detail_total,
       o.total_amount
FROM dbo.orders o
JOIN dbo.order_items oi ON oi.order_id = o.id
GROUP BY o.id, o.subtotal, o.total_amount;

-- 9. Kiem tra nhanh du lieu orphan / ton kho khong hop le (ket qua mong doi: khong co dong)
SELECT i.* FROM dbo.inventory i
LEFT JOIN dbo.product_variants v ON v.id = i.variant_id
WHERE v.id IS NULL OR i.stock_quantity < 0;
GO

-- Them du lieu moi vao dbo.products
SET IDENTITY_INSERT dbo.products ON;
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (8, 6, N'Áo khoác Cardigan Calem', N'ao-khoac-cardigan-calem', N'Áo khoác', CAST(380000.00 AS Decimal(12, 2)), CAST(300000.00 AS Decimal(12, 2)), N'Calem', N'active', 1, 1, CAST(N'2026-11-04T14:33:29.0000000' AS DateTime2), CAST(N'2026-11-04T14:59:12.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (9, 2, N'Quần', N'quan', N'', CAST(250000.00 AS Decimal(12, 2)), NULL, N'Calem', N'active', 1, 0, CAST(N'2026-11-04T15:00:52.0000000' AS DateTime2), CAST(N'2026-11-04T15:00:52.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (10, 7, N'Áo khoác Cardigan SIMPLE Ver 1', N'ao-khoac-cardigan-simple-ver-1', N'Áo khoác Cardigan SIMPLE Ver 1 chất len mịn Premium form unisex nam nữ thu đông phong cách hàn quốc', CAST(300000.00 AS Decimal(12, 2)), CAST(252000.00 AS Decimal(12, 2)), N'CALEM', N'active', 1, 1, CAST(N'2026-11-05T01:50:08.0000000' AS DateTime2), CAST(N'2026-11-05T01:50:08.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (11, 8, N'Quần Short Jean Lửng ống rộng', N'quan-short-jean-lung-ong-rong', N'form unisex nam nữ Menswear quần short nữ', CAST(320000.00 AS Decimal(12, 2)), NULL, N'CALEM', N'active', 1, 0, CAST(N'2026-11-05T01:51:21.0000000' AS DateTime2), CAST(N'2026-11-05T01:51:21.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (12, 3, N'Đầm xòe cổ sơ mi tay ngắn', N'dam-xoe-co-so-mi-tay-ngan', N'váy liền dáng xòe kèm khăn choàng - Wrenna Dress', CAST(545000.00 AS Decimal(12, 2)), CAST(500000.00 AS Decimal(12, 2)), N'THE C.I.U', N'active', 0, 1, CAST(N'2026-11-05T01:52:18.0000000' AS DateTime2), CAST(N'2026-11-05T01:52:18.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (13, 6, N'Sơ mi xếp ly đính nơ tay ngắn', N'so-mi-xep-ly-dinh-no-tay-ngan', N'*THÔNG TIN SẢN PHẨM
- Chi tiết sản phẩm: Sơ mi xếp ly đính nơ tay ngắn
- Chất liệu:
+ Trắng, Đen (Lụa Mango)
+ Trắng Sọc, Đen Sọc, Xanh Dương Sọc (Kaki mềm)
+ Nâu Sọc (Linen),
- Độ dày vải: trung bình, 1 lớp, không co giãn
- Phom dáng: ôm', CAST(245000.00 AS Decimal(12, 2)), CAST(149000.00 AS Decimal(12, 2)), N'DALLA', N'active', 1, 1, CAST(N'2026-11-05T01:53:31.0000000' AS DateTime2), CAST(N'2026-11-05T01:53:31.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (14, 9, N'Quần tây ống rộng Hari chất gold hàn cao cấp Mềm dày dặn mát lên chuẩn dáng', N'quan-tay-ong-rong-hari-chat-gold-han-cao-cap-mem-day-dan-mat-len-chuan-dang', N'Quần tây  suông chất gold hàn cao cấp
Mềm dày dặn mát lên chuẩn dáng
Mã 348
Size SML
Kích cỡ: S dưới 48kg M dưới 55kg, L dưới 60kg
S: Eo 65cm, Mông 100cm, Dài 104cm, Ống 58cm
M: Eo 68cm, Mông 104cm, Dài 104cm, Ống 59cm
L: Eo 72cm, Mông 108cm, Dài 105cm, Ống 60cm
Số đo có thể chênh lệc 2-3 cm', CAST(200000.00 AS Decimal(12, 2)), NULL, N'HARI CLOTHES', N'active', 0, 0, CAST(N'2026-11-05T01:55:22.0000000' AS DateTime2), CAST(N'2026-11-05T01:55:22.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (15, 5, N'Áo Thun Boxy Form Rộng URBAN THREADS Thoải Mái Thời Trang Nam Nữ Chất Liệu Cotton', N'ao-thun-boxy-form-rong-urban-threads-thoai-mai-thoi-trang-nam-nu-chat-lieu-cotton', N'ÍNH NĂNG
- Chất liệu cotton thoáng mát, thấm hút mồ hôi tốt, phù hợp mặc hằng ngày, đi học, đi làm, đi tập thể dục thể thao hoặc đi chơi.
- Form boxy dáng suông rộng, thân áo gọn, tạo cảm giác thoải mái khi vận động và không ôm sát cơ thể.
- Form áo rộng mang đến vẻ ngoài trẻ trung, năng động, dễ phối cùng quần jeans, quần short, quần ống rộng hoặc chân váy.
- Thiết kế cổ tròn, tay ngắn đơn giản, dễ mặc riêng hoặc phối cùng áo khoác để tạo nhiều phong cách', CAST(299000.00 AS Decimal(12, 2)), CAST(249000.00 AS Decimal(12, 2)), N'MIDORI STUDIO', N'active', 1, 1, CAST(N'2026-11-05T01:56:35.0000000' AS DateTime2), CAST(N'2026-11-05T01:56:35.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (16, 5, N'Áo baby tee form body siêu tôn dáng IU', N'ao-baby-tee-form-body-sieu-ton-dang-iu', N'Kill System mong muốn đem đến bạn những trải nghiệm mua sắm tốt nhất với giá cả phải chăng, chất lượng và mẫu mã sản phẩm luôn được cập nhật theo xu hướng.
* Chi tiết sản phẩm: Áo thun trơn form ôm body IU
   Chất  liệu: Borip Premium co giãn thoáng mát.
   Thích hợp mặc hằng ngày, tiện lợi dễ dàng mix cùng các loại trang phục.
  Chi tiết: form ôm body baby tee, tay nhỏ, cổ trò.', CAST(185000.00 AS Decimal(12, 2)), NULL, N'𝐊𝐈𝐋𝐋 𝐒𝐘𝐒𝐓𝐄𝐌', N'active', 1, 0, CAST(N'2026-11-05T01:57:39.0000000' AS DateTime2), CAST(N'2026-11-05T01:57:39.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (17, 9, N'Quần tây ống rộng phối ren kèm dây đeo CABY', N'quan-tay-ong-rong-phoi-ren-kem-day-deo-caby', N'Kill System mong muốn đem đến bạn những trải nghiệm mua sắm tốt với giá cả phải chăng, chất lượng và mẫu mã sản phẩm luôn được cập nhật theo xu hướng.
* Chi tiết sản phẩm:
- Chất liệu: cotton hàn
- Thiết kế: quần tây ông rộng phối ren
- Màu sắc: đen, nâu
- Size: S - M - L', CAST(365000.00 AS Decimal(12, 2)), NULL, N'𝐊𝐈𝐋𝐋 𝐒𝐘𝐒𝐓𝐄𝐌', N'out_of_stock', 0, 0, CAST(N'2026-11-05T01:59:08.0000000' AS DateTime2), CAST(N'2026-11-05T01:59:08.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (18, 1, N'Dây chuyền bạc nữ TLEE Princess Tears hình giọt nước lấp lánh D0129', N'day-chuyen-bac-nu-tlee-princess-tears-hinh-giot-nuoc-lap-lanh-d0129', N'THÔNG TIN SẢN PHẨM DÂY CHUYỀN BẠC TLEE JEWELRY
- Chất liệu: Bạc S925 (92,5% Bạc và 7,5% kim loại khác sản xuất theo công nghệ Bạc Ý) hàng gia công kĩ bóng đẹp, không han gỉ, không dị ứng, dễ làm sáng và bảo quản
- Kiểu cách: Thiết kế thanh lịch, trẻ trung, tinh tế, sắc sảo
- Sản xuất: được thiết kế bởi TLEE JEWELRY
- Dây chuyền bạc TLEE JEWELRY được thiết kế thanh lịch, trẻ trung theo xu hướng mới nhất của ngành phụ kiện trang sức
- Dây chuyền được gia công vô cùng kĩ lưỡng, tỉ mỉ tạo nên một sản phẩm trang sức hoàn hảo
HƯỚNG DẪN SỬ DỤNG VÀ BẢO QUẢN DÂY CHUYỀN BẠC TLEE JEWELRY
- Tránh để trang sức tiếp xúc với hoá chất, chất tẩy rửa mạnh, có thể làm sáng trang sức bằng cách chà kem đánh răng, nước rửa bát, nước chanh...
- Thường xuyên vệ sinh trang sức băng khăn làm sáng, que làm sáng (phụ kiện vệ sinh sản phẩm của shop) nên vệ sinh nhẫn bạc thường xuyên bằng nước rửa bạc 1-3 tháng/lần để đảm bảo sản phẩm luôn được sáng bóng.
- Khi không đeo, bảo quản trang sức nơi khô ráo, tránh ánh nắng trực tiếp, nơi có nhiệt độ cao hoặc ẩm thấp.
- Nên để trang sức trong túi zip, thêm 1 miếng bông gòn nhỏ để hút ẩm giúp bảo quản tốt hơn.
CAM KẾT TRANG SỨC TLEE JEWELRY
- Sản phẩm giống ảnh, giống mô tả 100%.
- Hình ảnh, video đều là ảnh thật, video quay lại những góc độ chân thật nhất của sản phẩm.
- Tư vấn hỗ trợ khách hàng nhiệt tình 24/24.', CAST(960000.00 AS Decimal(12, 2)), CAST(699000.00 AS Decimal(12, 2)), N'TLEE', N'active', 1, 1, CAST(N'2026-11-05T02:00:41.0000000' AS DateTime2), CAST(N'2026-11-05T02:00:41.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (19, 5, N'Áo Thun Cổ Tàu WAYNE Cotton 250GSM Form Slimfit Co Giãn Tốt Mềm Mát Không Xù Không Nhăn AT15', N'ao-thun-co-tau-wayne-cotton-250gsm-form-slimfit-co-gian-tot-mem-mat-khong-xu-khong-nhan-at15', N'* ĐIỂM NỔI BẬT
- Chất vải Cotton 250GSM dày dặn vừa phải, đứng form nhưng vẫn mềm mại, thoải mái khi mặc.
- Co giãn tốt, giúp vận động thoải mái.
- Thấm hút mồ hôi hiệu quả, hạn chế bí nóng khi mặc cả ngày.
- Bề mặt vải mềm mịn, hạn chế xù lông và ít nhăn sau khi giặt đúng cách.
- Thiết kế cổ tàu trẻ trung, tạo điểm nhấn khác biệt so với áo thun cổ tròn thông thường.
- Form Slimfit tôn dáng, phù hợp nhiều vóc dáng nam giới.
- Đường may tỉ mỉ, chắc chắn, bền đẹp theo thời gian.', CAST(300000.00 AS Decimal(12, 2)), NULL, N'WAYNE', N'active', 0, 0, CAST(N'2026-11-05T02:02:14.0000000' AS DateTime2), CAST(N'2026-11-05T02:02:14.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (20, 7, N'Hoodie boxy zip vải 2 da áo khoác nỉ hai lớp khoá kéo chống nắng form rộng ngắn nam nữ unisex', N'hoodie-boxy-zip-vai-2-da-ao-khoac-ni-hai-lop-khoa-keo-chong-nang-form-rong-ngan-nam-nu-unisex', N'A. MÔ TẢ SẢN PHẨM
1. KIỂU DÁNG
- Unisex, form Boxy ngắn
- Chất lượng hình thêu chắc chắn sắc nét, công nghê thêu đắp 100% không bong tróc khi giặt
- Bo chun ở phần tay, hông dày dặn
2. CHẤT LIỆU
chống nắng form rộng ngắn nam nữ unisex local brand pandax polime
- Chất liệu :
==>> Nỉ 2 Da Cao Cấp : định lượng 320gsm, nỉ cotton
dày dặn, full wax lông bề mặt chống xù
Mặt ngoài vải nỉ mềm mịn
- Mặt nền là 100% Cotton
- Nặng 800-900g
- Công dụng: mặc ở nhà, mặc đi học, đi chơi hoặc khi vận động thể thao, chống nắng tốt
- Thiết kế hiện đại, trẻ trung, năng động, dễ phối đồ
- Đủ size: M - L - XL', CAST(500000.00 AS Decimal(12, 2)), CAST(399000.00 AS Decimal(12, 2)), N'PANDAX', N'active', 1, 1, CAST(N'2026-11-05T02:04:33.0000000' AS DateTime2), CAST(N'2026-11-05T02:04:33.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (21, 6, N'Áo sơ mi ngắn tay kẻ sọc nam nữ DWIN chất vải oxford cộc basic unisex đứng form không nhăn cao cấp SM04A', N'ao-so-mi-ngan-tay-ke-soc-nam-nu-dwin-chat-vai-oxford-coc-basic-unisex-dung-form-khong-nhan-cao-cap-sm04a', N'- áo sơ mi ngắn tay kẻ sọc nam nữ DWIN được thiết kế theo đúng form chuẩn của nam giới Việt Nam
- Sản phẩm áo sơ mi ngắn tay kẻ sọc nam nữ DWIN chính là mẫu thiết kế mới nhất của DWIN
- Chất liệu vải oxford dày dặn, mềm mịn, co dãn
- Đem lại sự thoải mái tiện lợi nhất cho người mặc', CAST(349000.00 AS Decimal(12, 2)), CAST(299000.00 AS Decimal(12, 2)), N'Dwin', N'active', 0, 1, CAST(N'2026-11-05T02:05:36.0000000' AS DateTime2), CAST(N'2026-11-05T02:05:36.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (22, 1, N'Áo polo nam nữ brand in Dwin SIGNATURE cổ bẻ vải cá sấu basic form rộng tay lỡ unisex oversize PL01C', N'ao-polo-nam-nu-brand-in-dwin-signature-co-be-vai-ca-sau-basic-form-rong-tay-lo-unisex-oversize-pl01c', N'- Áo polo nam nữ brand Dwin được thiết kế theo đúng form chuẩn của nam giới Việt Nam
- Sản phẩm áo polo nam nữ brand Dwin chính là mẫu thiết kế mới nhất của DWIN
- Chất liệu vải poly dày dặn, mềm mịn, co dãn
- Đem lại sự thoải mái tiện lợi nhất cho người mặc', CAST(256000.00 AS Decimal(12, 2)), NULL, N'Dwin', N'active', 1, 0, CAST(N'2026-11-05T02:08:37.0000000' AS DateTime2), CAST(N'2026-11-05T02:08:37.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (23, 1, N'Áo thun lệch vai in nhũ bạc metalic BLESSED', N'ao-thun-lech-vai-in-nhu-bac-metalic-blessed', N'Kill System mong muốn đem đến bạn những trải nghiệm mua sắm tốt với giá cả phải chăng, chất lượng và mẫu mã sản phẩm luôn được cập nhật theo xu hướng.', CAST(300000.00 AS Decimal(12, 2)), NULL, N'𝐊𝐈𝐋𝐋 𝐒𝐘𝐒𝐓𝐄𝐌', N'active', 0, 0, CAST(N'2026-11-05T02:09:36.0000000' AS DateTime2), CAST(N'2026-11-05T02:09:36.0000000' AS DateTime2));
INSERT [dbo].[products] ([id], [category_id], [name], [slug], [description], [price], [sale_price], [brand], [status], [is_hot], [is_sale], [created_at], [updated_at]) VALUES (24, 5, N'Áo Thun Boxy 280GSM “STAR” Thêu Len GUPO Unisex Nam Nữ Cotton Local Brand - TSS01', N'ao-thun-boxy-280gsm-star-theu-len-gupo-unisex-nam-nu-cotton-local-brand---tss01', N'Điểm nổi bật của sản phẩm:
Form Boxy rộng rãi: Chuẩn unisex, phù hợp cho cả nam và nữ.
Chất liệu cao cấp:
100% Cotton, định lượng vải 280GSM.
Dày dặn, mềm mại, thoáng mát, co giãn tốt.
Đã xử lý co rút, không sợ bai nhão sau nhiều lần giặt.
Thiết kế ấn tượng:
Họa tiết THÊU LEN trước và sau áo, bền màu, không bong tróc.
Công nghệ thêu len hiện đại, mang phong cách trẻ trung, độc đáo.
Dễ phối đồ: Hoàn hảo khi kết hợp với quần jean, short, hoặc chân váy, phù hợp mọi phong cách.', CAST(299000.00 AS Decimal(12, 2)), CAST(255000.00 AS Decimal(12, 2)), N'GUPO.STU', N'active', 1, 1, CAST(N'2026-11-05T02:10:36.0000000' AS DateTime2), CAST(N'2026-11-05T02:10:36.0000000' AS DateTime2));
SET IDENTITY_INSERT dbo.products OFF;

-- Them du lieu moi vao dbo.product_images
SET IDENTITY_INSERT dbo.product_images ON;
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (11, 8, NULL, N'uploads/products/prod_639294011513158627.jpg', N'Áo khoác Cardigan Calem', 1, 1, CAST(N'2026-11-04T14:33:29.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (12, 9, NULL, N'uploads/products/prod_639294012513396752.jpg', N'Quần', 1, 1, CAST(N'2026-11-04T15:00:52.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (13, 10, NULL, N'uploads/products/prod_639294402058670324.jpg', N'Áo khoác Cardigan SIMPLE Ver 1', 1, 1, CAST(N'2026-11-05T01:50:08.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (14, 11, NULL, N'uploads/products/prod_639294402753276846.jpg', N'Quần Short Jean Lửng ống rộng', 1, 1, CAST(N'2026-11-05T01:51:21.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (15, 12, NULL, N'uploads/products/prod_639294403351495064.jpg', N'Đầm xòe cổ sơ mi tay ngắn', 1, 1, CAST(N'2026-11-05T01:52:18.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (16, 13, NULL, N'uploads/products/prod_639294404090032016.jpg', N'Sơ mi xếp ly đính nơ tay ngắn', 1, 1, CAST(N'2026-11-05T01:53:31.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (17, 14, NULL, N'uploads/products/prod_639294405206153546.jpg', N'Quần tây ống rộng Hari chất gold hàn cao cấp Mềm dày dặn mát lên chuẩn dáng', 1, 1, CAST(N'2026-11-05T01:55:22.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (18, 15, NULL, N'uploads/products/prod_639294405886649838.jpg', N'Áo Thun Boxy Form Rộng URBAN THREADS Thoải Mái Thời Trang Nam Nữ Chất Liệu Cotton', 1, 1, CAST(N'2026-11-05T01:56:35.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (19, 16, NULL, N'uploads/products/prod_639294406568277843.jpg', N'Áo baby tee form body siêu tôn dáng IU', 1, 1, CAST(N'2026-11-05T01:57:39.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (20, 17, NULL, N'uploads/products/prod_639294407304867326.jpg', N'Quần tây ống rộng phối ren kèm dây đeo CABY', 1, 1, CAST(N'2026-11-05T01:59:08.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (21, 18, NULL, N'uploads/products/prod_639294408373871643.jpg', N'Dây chuyền bạc nữ TLEE Princess Tears hình giọt nước lấp lánh D0129', 1, 1, CAST(N'2026-11-05T02:00:41.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (22, 19, NULL, N'uploads/products/prod_639294409299681225.jpg', N'Áo Thun Cổ Tàu WAYNE Cotton 250GSM Form Slimfit Co Giãn Tốt Mềm Mát Không Xù Không Nhăn AT15', 1, 1, CAST(N'2026-11-05T02:02:14.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (23, 20, NULL, N'uploads/products/prod_639294410702808658.jpg', N'Hoodie boxy zip vải 2 da áo khoác nỉ hai lớp khoá kéo chống nắng form rộng ngắn nam nữ unisex', 1, 1, CAST(N'2026-11-05T02:04:33.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (24, 21, NULL, N'uploads/products/prod_639294411333066929.jpg', N'Áo sơ mi ngắn tay kẻ sọc nam nữ DWIN chất vải oxford cộc basic unisex đứng form không nhăn cao cấp SM04A', 1, 1, CAST(N'2026-11-05T02:05:36.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (25, 22, NULL, N'uploads/products/prod_639294413145677098.jpg', N'Áo polo nam nữ brand in Dwin SIGNATURE cổ bẻ vải cá sấu basic form rộng tay lỡ unisex oversize PL01C', 1, 1, CAST(N'2026-11-05T02:08:37.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (26, 23, NULL, N'uploads/products/prod_639294413741279875.jpg', N'Áo thun lệch vai in nhũ bạc metalic BLESSED', 1, 1, CAST(N'2026-11-05T02:09:36.0000000' AS DateTime2));
INSERT [dbo].[product_images] ([id], [product_id], [variant_id], [image_url], [alt_text], [sort_order], [is_primary], [created_at]) VALUES (27, 24, NULL, N'uploads/products/prod_639294414325983014.jpg', N'Áo Thun Boxy 280GSM “STAR” Thêu Len GUPO Unisex Nam Nữ Cotton Local Brand - TSS01', 1, 1, CAST(N'2026-11-05T02:10:36.0000000' AS DateTime2));
SET IDENTITY_INSERT dbo.product_images OFF;

/* ============ A. THEM DU LIEU MOI ============ */

-- users: 3 tai khoan moi (id 4,5,6)
SET IDENTITY_INSERT dbo.users ON;
INSERT dbo.users (id, full_name, email, password_hash, phone, email_verified, email_verified_at, email_verification_otp_hash, email_verification_otp_expires_at, password_reset_otp_hash, password_reset_otp_expires_at, status, created_at, updated_at) VALUES (4, N'Nguyễn Thị Kim Thoa', N'ntkt.28122006@gmail.com', N'$2a$11$VsU7r29Ql74l3fiB9dKYUON4BknphduxQwbJFZsUnPObetqSkc13i', N'0123456789', 0, NULL, NULL, NULL, N'$2a$11$1mn8WEGTj4JmrS4A9Rxstu1fUZrSKLVuSQg1Ds9TKNZRJh516h9Y2', N'2026-11-08 08:51:16', N'active', N'2026-11-06 23:26:11', N'2026-11-08 08:49:11');
INSERT dbo.users (id, full_name, email, password_hash, phone, email_verified, email_verified_at, email_verification_otp_hash, email_verification_otp_expires_at, password_reset_otp_hash, password_reset_otp_expires_at, status, created_at, updated_at) VALUES (5, N'khôi', N'k123@gmail.com', N'$2a$11$EviFGIGYzRy/uKJiJGB3Ou9zf71UFpK1HkGHcPml/CTJC9r/QnR2K', N'01213644966', 0, NULL, NULL, NULL, NULL, NULL, N'active', N'2026-11-07 00:42:19', N'2026-11-07 00:42:19');
INSERT dbo.users (id, full_name, email, password_hash, phone, email_verified, email_verified_at, email_verification_otp_hash, email_verification_otp_expires_at, password_reset_otp_hash, password_reset_otp_expires_at, status, created_at, updated_at) VALUES (6, N'admin', N'admin123@gmail.com', N'$2a$11$0C7nDwsHzgURhhRIKb7Fhuyd63sGCeHHEyhmuppuFc49mexKQc.Xi', N'00021456460', 0, NULL, NULL, NULL, NULL, NULL, N'active', N'2026-11-07 02:06:42', N'2026-11-07 02:06:42');
SET IDENTITY_INSERT dbo.users OFF;
GO

-- user_roles: phan quyen cho 3 tai khoan moi (6 = Admin, 4 va 5 = Customer)
INSERT dbo.user_roles (user_id, role_id) VALUES (4, 2);
INSERT dbo.user_roles (user_id, role_id) VALUES (5, 2);
INSERT dbo.user_roles (user_id, role_id) VALUES (6, 1);
GO

-- carts: gio hang cua user 4
SET IDENTITY_INSERT dbo.carts ON;
INSERT dbo.carts (id, user_id, created_at, updated_at) VALUES (3, 4, N'2026-11-08 08:50:01', N'2026-11-08 08:50:01');
SET IDENTITY_INSERT dbo.carts OFF;
GO

-- products: san pham moi id 25
SET IDENTITY_INSERT dbo.products ON;
INSERT dbo.products (id, category_id, name, slug, description, price, sale_price, brand, status, is_hot, is_sale, created_at, updated_at) VALUES (25, 7, N'Áo khoác cardigan nữ xám', N'ao-khoac-cardigan-nu-xam', N'', 350000.00, NULL, N'Noiree', N'active', 0, 0, N'2026-11-07 01:43:08', N'2026-11-07 01:43:08');
SET IDENTITY_INSERT dbo.products OFF;
GO

-- product_variants: 17 bien the moi (id 20,21,23..37)
SET IDENTITY_INSERT dbo.product_variants ON;
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (20, 18, N'SKU-18-06099057', NULL, NULL, NULL, 1, N'0001-01-01 00:00:00');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (21, 23, N'SKU-23-70052045', NULL, NULL, NULL, 1, N'0001-01-01 00:00:00');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (23, 24, N'AT_BX_White_M', 2, 3, NULL, 1, N'2026-11-08 08:57:54');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (24, 24, N'AT_BX_Black_S', 1, 2, NULL, 1, N'2026-11-08 09:00:08');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (25, 24, N'AT_BX_White_S', 2, 2, NULL, 1, N'2026-11-08 09:01:26');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (26, 8, N'AK_CA_Be_M', 4, 3, NULL, 0, N'2026-11-08 09:02:59');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (27, 9, N'QJ_M', NULL, 3, NULL, 1, N'2026-11-08 09:14:18');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (28, 10, N'AK_CA_M', 1, 3, NULL, 1, N'2026-11-08 09:15:29');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (29, 11, N'SJ_L', NULL, 4, NULL, 1, N'2026-11-08 09:18:09');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (30, 12, N'DXCSM_Black_M', 1, 3, NULL, 1, N'2026-11-08 09:19:07');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (31, 13, N'ASM_White_S', 2, 2, NULL, 1, N'2026-11-08 09:20:45');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (32, 13, N'ASM_Black_M', 1, 3, NULL, 1, N'2026-11-08 09:21:12');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (33, 14, N'QT_Gray_XS', 5, 1, NULL, 1, N'2026-11-08 09:26:47');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (34, 14, N'QT_Black_XL', 1, 5, NULL, 1, N'2026-11-08 09:27:11');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (35, 15, N'ATBX_Black_XXL', 1, 6, NULL, 1, N'2026-11-08 09:27:46');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (36, 16, N'BBT_White_L', 2, 4, NULL, 1, N'2026-11-08 09:28:52');
INSERT dbo.product_variants (id, product_id, sku, color_id, size_id, price_override, is_active, created_at) VALUES (37, 17, N'QTOR_Black_M', 1, 3, NULL, 1, N'2026-11-08 09:29:30');
SET IDENTITY_INSERT dbo.product_variants OFF;
GO

-- inventory: ton kho cho 17 bien the moi (id 20..36)
SET IDENTITY_INSERT dbo.inventory ON;
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (20, 20, 98, N'2026-11-08 08:50:36');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (21, 21, 99, N'2026-11-08 08:50:36');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (22, 23, 40, N'2026-11-08 08:57:54');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (23, 24, 15, N'2026-11-08 09:00:08');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (24, 25, 20, N'2026-11-08 09:01:26');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (25, 26, 25, N'2026-11-08 09:02:59');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (26, 27, 35, N'2026-11-08 09:14:18');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (27, 28, 35, N'2026-11-08 09:15:29');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (28, 29, 150, N'2026-11-08 09:18:09');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (29, 30, 122, N'2026-11-08 09:19:07');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (30, 31, 50, N'2026-11-08 09:20:45');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (31, 32, 28, N'2026-11-08 09:21:12');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (32, 33, 321, N'2026-11-08 09:26:47');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (33, 34, 32, N'2026-11-08 09:27:11');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (34, 35, 39, N'2026-11-08 09:27:46');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (35, 36, 1, N'2026-11-08 09:28:52');
INSERT dbo.inventory (id, variant_id, stock_quantity, updated_at) VALUES (36, 37, 39, N'2026-11-08 09:29:30');
SET IDENTITY_INSERT dbo.inventory OFF;
GO

-- product_images: anh cho san pham 25
SET IDENTITY_INSERT dbo.product_images ON;
INSERT dbo.product_images (id, product_id, variant_id, image_url, alt_text, sort_order, is_primary, created_at) VALUES (28, 25, NULL, N'uploads/products/prod_639296125854403569.png', N'Áo khoác cardigan nữ xám', 1, 1, N'2026-11-07 01:43:08');
SET IDENTITY_INSERT dbo.product_images OFF;
GO

-- orders: 2 don hang moi (id 3,4)
SET IDENTITY_INSERT dbo.orders ON;
INSERT dbo.orders (id, user_id, address_id, recipient_name, recipient_phone, shipping_address, subtotal, shipping_fee, discount_amount, total_amount, status, payment_status, note, created_at, updated_at) VALUES (3, 2, NULL, N'Tran Thi Khach Hang', N'0987654321', N'123 Nguyen Trai, Ben Thanh, Quan 1, TP. Ho Chi Minh', 1205000.00, 0.00, 0.00, 1205000.00, N'pending', N'unpaid', N'Thanh toán khi nhận hàng (COD)', N'2026-11-07 00:45:45', N'2026-11-07 02:23:27');
INSERT dbo.orders (id, user_id, address_id, recipient_name, recipient_phone, shipping_address, subtotal, shipping_fee, discount_amount, total_amount, status, payment_status, note, created_at, updated_at) VALUES (4, 4, NULL, N'Thoa', N'033232626116', N'Mạc Thanh Đạm', 1698000.00, 0.00, 0.00, 1698000.00, N'confirmed', N'unpaid', N'Thanh toán khi nhận hàng (COD)', N'2026-11-08 08:50:36', N'2026-11-08 08:53:15');
SET IDENTITY_INSERT dbo.orders OFF;
GO

-- order_items: 6 dong chi tiet moi (line_total la cot tinh toan nen khong insert)
SET IDENTITY_INSERT dbo.order_items ON;
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (4, 3, 2, N'Ao thun cotton basic', N'TSH-BLK-M', N'Den', N'M', 2, 159000.00);
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (5, 3, 4, N'Ao thun cotton basic', N'TSH-WHT-S', N'Trang', N'S', 1, 159000.00);
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (6, 3, 12, N'Hoodie ni bong', N'HOD-GRY-M', N'Xam', N'M', 1, 399000.00);
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (7, 3, 9, N'Ao so mi Oxford', N'OXF-WHT-M', N'Trang', N'M', 1, 329000.00);
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (8, 4, 20, N'Dây chuyền bạc nữ TLEE Princess Tears hình giọt nước lấp lánh D0129', N'SKU-18-06099057', N'Mặc định', N'Free Size', 2, 699000.00);
INSERT dbo.order_items (id, order_id, variant_id, product_name, sku, color_name, size_name, quantity, unit_price) VALUES (9, 4, 21, N'Áo thun lệch vai in nhũ bạc metalic BLESSED', N'SKU-23-70052045', N'Mặc định', N'Free Size', 1, 300000.00);
SET IDENTITY_INSERT dbo.order_items OFF;
GO

/* ============ B. SUA DU LIEU DA THAY DOI ============ */

-- users: khoa tai khoan id 3 (Le Minh Anh)
UPDATE dbo.users SET status = 'banned' WHERE id = 3;

-- products: doi trang thai / gia / danh muc / mo ta
UPDATE dbo.products SET status = 'out_of_stock' WHERE id = 5;
UPDATE dbo.products SET price = 350000.00, is_hot = 1 WHERE id = 6;
UPDATE dbo.products SET category_id = 7, status = 'inactive', updated_at = '2026-11-08 09:26:07' WHERE id = 8;
UPDATE dbo.products SET updated_at = '2026-11-08 09:13:30' WHERE id = 9;
-- id 14: chi them ky tu dau tich xanh (U+2705) truoc dong "Kich co"
UPDATE dbo.products
SET description = REPLACE(description, N'Kích cỡ: S dưới 48kg', NCHAR(9989) + N'Kích cỡ: S dưới 48kg')
WHERE id = 14;
UPDATE dbo.products SET category_id = 4, price = 957000.00, updated_at = '2026-11-08 08:54:33' WHERE id = 18;

-- product_images: doi duong dan anh
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297256389057283.jpg' WHERE id = 5;
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297265510847676.png' WHERE id = 6;
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297257935381629.png' WHERE id = 7;
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297266133207894.png' WHERE id = 8;
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297266947523646.png' WHERE id = 9;
UPDATE dbo.product_images SET image_url = N'uploads/products/prod_639297260082600997.png' WHERE id = 12;

-- inventory: dieu chinh ton kho
UPDATE dbo.inventory SET stock_quantity = 9  WHERE id = 1;
UPDATE dbo.inventory SET stock_quantity = 24 WHERE id = 2;
UPDATE dbo.inventory SET stock_quantity = 6  WHERE id = 3;
UPDATE dbo.inventory SET stock_quantity = 37 WHERE id = 17;
UPDATE dbo.inventory SET stock_quantity = 20 WHERE id = 18;
GO

/* ============ C. XOA DU LIEU ============ */

-- cart_items: 2 dong cua gio hang mau (cart 1) da bi xoa
DELETE FROM dbo.cart_items WHERE id IN (1, 2);
GO

COMMIT TRANSACTION;
GO
