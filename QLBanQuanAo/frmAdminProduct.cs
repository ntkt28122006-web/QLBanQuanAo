using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmAdminProduct : Form
    {
        private string selectedRelativeImagePath = "";
        private int selectedVariantId = 0;

        public frmAdminProduct()
        {
            InitializeComponent();
        }

        private void frmAdminProduct_Load(object sender, EventArgs e)
        {

            dgvProducts.AutoGenerateColumns = false;

            loadFilterCategoryComboBox();
            loadFilterStatusComboBox();
            loadDetailCategoryComboBox();
            loadDetailStatusComboBox();
            loadVariantLookups();
            ResetVariantEditor();
            loadProductData();
        }

        private string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return "san-pham-" + DateTime.Now.Ticks;

            string str = title.ToLower().Trim();
            // Thay thế tiếng Việt có dấu thành không dấu
            str = Regex.Replace(str, @"[áàảãạâấầẩẫậăắằẳẵặ]", "a");
            str = Regex.Replace(str, @"[éèẻẽẹêếềểễệ]", "e");
            str = Regex.Replace(str, @"[iíìỉĩị]", "i");
            str = Regex.Replace(str, @"[óòỏõọôốồổỗộơớờởỡợ]", "o");
            str = Regex.Replace(str, @"[úùủũụưứừửữự]", "u");
            str = Regex.Replace(str, @"[ýỳỷỹỵ]", "y");
            str = Regex.Replace(str, @"[đ]", "d");
            // Xóa ký tự đặc biệt và khoảng trắng
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", "-").Trim('-');
            return str;
        }

        private void loadFilterCategoryComboBox()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();
            var listCategory = db.categories
                .Where(c => c.is_active)
                .Select(c => new { c.id, c.name })
                .ToList();

            var filterOptions = listCategory.Select(c => new { Id = (int?)c.id, Name = c.name }).ToList();
            filterOptions.Insert(0, new { Id = (int?)null, Name = "-- Tất cả danh mục --" });

            if (cboFilterCategory != null)
            {
                cboFilterCategory.DataSource = filterOptions;
                cboFilterCategory.DisplayMember = "Name";
                cboFilterCategory.ValueMember = "Id";
            }
        }

        private void loadFilterStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = "all", Text = "-- Tất cả trạng thái --" },
                new { Value = "active", Text = "Đang kinh doanh (active)" },
                new { Value = "inactive", Text = "Ngừng kinh doanh (inactive)" },
                new { Value = "out_of_stock", Text = "Hết hàng (out_of_stock)" }
            };

            if (cboFilterStatus != null)
            {
                cboFilterStatus.DataSource = statusList.ToList();
                cboFilterStatus.DisplayMember = "Text";
                cboFilterStatus.ValueMember = "Value";
            }
        }
        private void loadDetailCategoryComboBox()
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var listCategory = db.categories
                    .Where(c => c.is_active)
                    .Select(c => new { c.id, c.name })
                    .ToList();

                // Gán tên hiển thị và giá trị trước khi gán DataSource
                cboCategory.DisplayMember = "name";
                cboCategory.ValueMember = "id";
                cboCategory.DataSource = listCategory;
            }
        }
        private void loadDetailStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = "active", Text = "Đang kinh doanh (active)" },
                new { Value = "inactive", Text = "Ngừng kinh doanh (inactive)" },
                new { Value = "out_of_stock", Text = "Hết hàng (out_of_stock)" }
            };

            cboProductStatus.DataSource = statusList.ToList();
            cboProductStatus.DisplayMember = "Text";
            cboProductStatus.ValueMember = "Value";
        }
        private void loadProductData()
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                string keyword = txtSearchProduct != null ? txtSearchProduct.Text.Trim().ToLower() : "";
                if (keyword == "tìm kiếm sản phẩm...") keyword = "";

                var query = db.products.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p => p.name.ToLower().Contains(keyword) ||
                                            (p.brand != null && p.brand.ToLower().Contains(keyword)));
                }

                if (cboFilterCategory?.SelectedValue != null && int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int catId) && catId > 0)
                {
                    query = query.Where(p => p.category_id == catId);
                }

                string selectedStatus = (cboFilterStatus != null && cboFilterStatus.SelectedValue != null)
                    ? cboFilterStatus.SelectedValue.ToString()
                    : "all";
                if (selectedStatus != "all")
                {
                    query = query.Where(p => p.status == selectedStatus);
                }

                var rawList = query
                    .Select(p => new
                    {
                        id = p.id,
                        name = p.name,
                        CategoryName = p.category != null ? p.category.name : "N/A",
                        price = p.price,
                        sale_price = p.sale_price,
                        StockQuantity = p.product_variants.SelectMany(v => v.inventories).Sum(i => (int?)i.stock_quantity) ?? 0,
                        status = p.status
                    })
                    .OrderByDescending(p => p.id)
                    .ToList();
                var productList = rawList
                    .Select(p => new
                    {
                        id = p.id,
                        name = p.name,
                        CategoryName = p.CategoryName,
                        price = string.Format("{0:N0} VNĐ", p.price),
                        sale_price = p.sale_price.HasValue ? string.Format("{0:N0} VNĐ", p.sale_price.Value) : "",
                        StockQuantity = p.StockQuantity,
                        status = p.status
                    })
                    .ToList();

                if (dgvProducts != null)
                {
                    dgvProducts.DataSource = productList;
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cellValue = dgvProducts.Rows[e.RowIndex].Cells["colProductId"].Value;
            if (cellValue == null) return;

            int productId = Convert.ToInt32(cellValue);

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var p = db.products.FirstOrDefault(x => x.id == productId);
                if (p != null)
                {
                    txtProductId.Text = p.id.ToString();
                    txtProductName.Text = p.name;
                    txtProductBrand.Text = p.brand;
                    numProductPrice.Value = p.price;
                    numProductSalePrice.Value = p.sale_price ?? 0;
                    txtProductDescription.Text = p.description;
                    chkIsHot.Checked = p.is_hot;
                    chkIsSale.Checked = p.is_sale;

                    if (p.category_id.HasValue) cboCategory.SelectedValue = p.category_id.Value;
                    if (!string.IsNullOrEmpty(p.status)) cboProductStatus.SelectedValue = p.status;

                    // Đọc ảnh sản phẩm từ bảng product_images
                    var imgObj = db.product_images.FirstOrDefault(img => img.product_id == p.id);
                    if (imgObj != null && !string.IsNullOrEmpty(imgObj.image_url))
                    {
                        selectedRelativeImagePath = imgObj.image_url;
                        DisplayImageToPictureBox(imgObj.image_url);
                    }
                    else
                    {
                        selectedRelativeImagePath = "";
                        picProductImage.Image = null;
                    }

                    loadVariantData(productId);
                    ResetVariantEditor();
                }
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1 || dgvProducts == null) return;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            loadProductData();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            loadProductData();
        }

        private void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProductData();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProductData();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {

            if (txtSearchProduct != null) txtSearchProduct.Clear();
            if (cboFilterCategory != null && cboFilterCategory.Items.Count > 0) cboFilterCategory.SelectedIndex = 0;
            if (cboFilterStatus != null && cboFilterStatus.Items.Count > 0) cboFilterStatus.SelectedIndex = 0;

            loadProductData();
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProductSalePrice_Click(object sender, EventArgs e)
        {

        }

        private void numProductPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numProductSalePrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblProductStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtProductDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void picProductImage_Click(object sender, EventArgs e)
        {

        }
        private string GetProjectFolder()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(baseDir);
            while (dir != null && !dir.GetFiles("*.csproj").Any())
            {
                dir = dir.Parent;
            }
            return dir != null ? dir.FullName : baseDir;
        }
        private void DisplayImageToPictureBox(string relativeOrAbsolutePath)
        {
            if (string.IsNullOrEmpty(relativeOrAbsolutePath))
            {
                picProductImage.Image = null;
                return;
            }

            if (Path.IsPathRooted(relativeOrAbsolutePath) && File.Exists(relativeOrAbsolutePath))
            {
                using (FileStream fs = new FileStream(relativeOrAbsolutePath, FileMode.Open, FileAccess.Read))
                {
                    picProductImage.Image = Image.FromStream(fs);
                }
                return;
            }

            string cleanRelativePath = relativeOrAbsolutePath.TrimStart('/', '\\').Replace('/', '\\');

            string fullPath = Path.Combine(Application.StartupPath, cleanRelativePath);

            if (!File.Exists(fullPath))
            {
                fullPath = Path.Combine(GetProjectFolder(), cleanRelativePath);
            }

            if (File.Exists(fullPath))
            {
                using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    picProductImage.Image = Image.FromStream(fs);
                }
            }
            else
            {
                picProductImage.Image = null;
            }
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh sản phẩm";
                dialog.Filter = "File ảnh (*.jpg; *.jpeg; *.png; *.webp)|*.jpg; *.jpeg; *.png; *.webp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string relFolder = Path.Combine("uploads", "products");
                    string fileName = "prod_" + DateTime.Now.Ticks + Path.GetExtension(dialog.FileName);

                    string binFolder = Path.Combine(Application.StartupPath, relFolder);
                    if (!Directory.Exists(binFolder)) Directory.CreateDirectory(binFolder);
                    string binFilePath = Path.Combine(binFolder, fileName);
                    File.Copy(dialog.FileName, binFilePath, true);

                    string projectFolder = Path.Combine(GetProjectFolder(), relFolder);
                    if (!Directory.Exists(projectFolder)) Directory.CreateDirectory(projectFolder);
                    string projectFilePath = Path.Combine(projectFolder, fileName);

                    if (binFilePath != projectFilePath)
                    {
                        File.Copy(dialog.FileName, projectFilePath, true);
                    }

                    selectedRelativeImagePath = relFolder.Replace("\\", "/") + "/" + fileName;

                    DisplayImageToPictureBox(binFilePath);
                }
            }
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSale = chkIsSale.Checked;
            decimal? salePrice = null;

            if (isSale)
            {
                if (numProductSalePrice.Value <= 0 || numProductSalePrice.Value >= numProductPrice.Value)
                {
                    MessageBox.Show("Giá khuyến mãi phải lớn hơn 0 và nhỏ hơn giá bán gốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                salePrice = numProductSalePrice.Value;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                // 1. Lưu sản phẩm
                product newProduct = new product
                {
                    name = txtProductName.Text.Trim(),
                    slug = GenerateSlug(txtProductName.Text.Trim()),
                    category_id = Convert.ToInt32(cboCategory.SelectedValue),
                    brand = txtProductBrand.Text.Trim(),
                    price = numProductPrice.Value,
                    sale_price = salePrice,
                    description = txtProductDescription.Text.Trim(),
                    status = cboProductStatus.SelectedValue?.ToString() ?? "active",
                    is_hot = chkIsHot.Checked,
                    is_sale = isSale,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                db.products.InsertOnSubmit(newProduct);
                db.SubmitChanges(); // SQL tự cấp ID sản phẩm

                if (!string.IsNullOrEmpty(selectedRelativeImagePath))
                {
                    product_image newImg = new product_image
                    {
                        product_id = newProduct.id,
                        image_url = selectedRelativeImagePath,
                        alt_text = newProduct.name,
                        sort_order = 1,
                        is_primary = true,
                        created_at = DateTime.Now
                    };
                    db.product_images.InsertOnSubmit(newImg);
                    db.SubmitChanges();
                }

                product_variant defaultVariant = new product_variant
                {
                    product_id = newProduct.id,
                    sku = "SKU-" + newProduct.id + "-" + DateTime.Now.Ticks.ToString().Substring(10),
                    is_active = true
                };
                db.product_variants.InsertOnSubmit(defaultVariant);
                db.SubmitChanges();

                db.inventories.InsertOnSubmit(new inventory
                {
                    variant_id = defaultVariant.id,
                    stock_quantity = (newProduct.status == "out_of_stock") ? 0 : 50,
                    updated_at = DateTime.Now
                });
                db.SubmitChanges();

                MessageBox.Show("Thêm sản phẩm và lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadProductData();
                btnClearProduct_Click(sender, e);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần ngừng kinh doanh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(txtProductId.Text);
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn NGỪNG KINH DOANH sản phẩm này không?\nSản phẩm và các biến thể sẽ được ẩn khỏi hoạt động mua bán, nhưng lịch sử đơn hàng vẫn được giữ lại.",
                                          "Xác nhận ngừng kinh doanh", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var p = db.products.FirstOrDefault(x => x.id == productId);
                    if (p != null)
                    {
                        try
                        {
                            // Không xóa vật lý để giữ lịch sử đơn hàng và dữ liệu liên quan.
                            p.status = "inactive";
                            p.updated_at = DateTime.Now;

                            foreach (var variant in db.product_variants.Where(v => v.product_id == productId))
                            {
                                variant.is_active = false;
                            }

                            db.SubmitChanges();

                            MessageBox.Show("Đã ngừng kinh doanh sản phẩm và các biến thể liên quan.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadProductData();
                            btnClearProduct_Click(sender, e);
                        }
                        catch (Exception ex)
                        {
                            // Tránh văng ứng dụng nếu sản phẩm bị dính khóa ngoại (đã có trong Đơn hàng/Đánh giá)
                            MessageBox.Show("Không thể cập nhật trạng thái sản phẩm. Chi tiết: " + ex.Message,
                                            "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(txtProductId.Text);

            bool isSale = chkIsSale.Checked;
            decimal? salePrice = null;
            if (isSale)
            {
                if (numProductSalePrice.Value <= 0 || numProductSalePrice.Value >= numProductPrice.Value)
                {
                    MessageBox.Show("Giá khuyến mãi phải lớn hơn 0 và nhỏ hơn giá bán gốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                salePrice = numProductSalePrice.Value;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text) || cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm và chọn danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var p = db.products.FirstOrDefault(x => x.id == productId);
                if (p != null)
                {
                    p.name = txtProductName.Text.Trim();
                    p.slug = GenerateSlug(txtProductName.Text.Trim());
                    p.category_id = Convert.ToInt32(cboCategory.SelectedValue);
                    p.brand = txtProductBrand.Text.Trim();
                    p.price = numProductPrice.Value;
                    p.sale_price = salePrice;
                    p.description = txtProductDescription.Text.Trim();
                    p.status = cboProductStatus.SelectedValue?.ToString();
                    p.is_hot = chkIsHot.Checked;
                    p.is_sale = isSale;
                    p.updated_at = DateTime.Now;

                    // Cập nhật hoặc chèn mới ảnh vào DB
                    if (!string.IsNullOrEmpty(selectedRelativeImagePath))
                    {
                        var imgObj = db.product_images.FirstOrDefault(img => img.product_id == p.id);
                        if (imgObj != null)
                        {
                            imgObj.image_url = selectedRelativeImagePath;
                            imgObj.is_primary = true;
                        }
                        else
                        {
                            db.product_images.InsertOnSubmit(new product_image
                            {
                                product_id = p.id,
                                image_url = selectedRelativeImagePath,
                                alt_text = p.name,
                                sort_order = 1,
                                is_primary = true,
                                created_at = DateTime.Now
                            });
                        }
                    }

                    var variants = db.product_variants.Where(v => v.product_id == p.id).ToList();
                    if (p.status == "out_of_stock")
                    {
                        foreach (var v in variants)
                        {
                            var inv = db.inventories.FirstOrDefault(i => i.variant_id == v.id);
                            if (inv != null) inv.stock_quantity = 0;
                        }
                    }
                    else if (p.status == "active")
                    {
                        foreach (var v in variants)
                        {
                            var inv = db.inventories.FirstOrDefault(i => i.variant_id == v.id);
                            if (inv != null && inv.stock_quantity == 0) inv.stock_quantity = 50;
                        }
                    }

                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thông tin và ảnh sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadProductData();
                }
            }
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductBrand.Clear();
            txtProductDescription.Clear();
            numProductPrice.Value = 0;
            numProductSalePrice.Value = 0;
            chkIsHot.Checked = false;
            chkIsSale.Checked = false;
            selectedRelativeImagePath = "";
            picProductImage.Image = null;

            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            if (cboProductStatus.Items.Count > 0) cboProductStatus.SelectedIndex = 0;

            dgvVariants.DataSource = null;
            ResetVariantEditor();
            txtProductName.Focus();
        }

        private void loadVariantLookups()
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var colorOptions = db.product_colors
                    .OrderBy(c => c.name)
                    .Select(c => new { Id = (int?)c.id, Name = c.name })
                    .ToList();
                colorOptions.Insert(0, new { Id = (int?)null, Name = "-- Không phân loại --" });

                cboVariantColor.DisplayMember = "Name";
                cboVariantColor.ValueMember = "Id";
                cboVariantColor.DataSource = colorOptions;

                var sizeOptions = db.product_sizes
                    .OrderBy(z => z.sort_order)
                    .ThenBy(z => z.name)
                    .Select(z => new { Id = (int?)z.id, Name = z.name })
                    .ToList();
                sizeOptions.Insert(0, new { Id = (int?)null, Name = "-- Không phân loại --" });

                cboVariantSize.DisplayMember = "Name";
                cboVariantSize.ValueMember = "Id";
                cboVariantSize.DataSource = sizeOptions;
            }
        }

        private int? GetNullableComboValue(ComboBox combo)
        {
            if (combo.SelectedValue == null || combo.SelectedValue == DBNull.Value)
                return null;

            int value;
            if (int.TryParse(combo.SelectedValue.ToString(), out value))
                return value;

            return null;
        }

        private void loadVariantData(int productId)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var rawVariants = db.product_variants
                    .Where(v => v.product_id == productId)
                    .OrderBy(v => v.id)
                    .Select(v => new
                    {
                        id = v.id,
                        sku = v.sku,
                        ColorName = v.product_color != null ? v.product_color.name : "Không phân loại",
                        SizeName = v.product_size != null ? v.product_size.name : "Không phân loại",
                        price_override = v.price_override,
                        StockQuantity = v.inventories.Select(i => (int?)i.stock_quantity).FirstOrDefault() ?? 0,
                        is_active = v.is_active
                    })
                    .ToList();

                var variantList = rawVariants
                    .Select(v => new
                    {
                        id = v.id,
                        sku = v.sku,
                        ColorName = v.ColorName,
                        SizeName = v.SizeName,
                        PriceOverride = v.price_override.HasValue ? string.Format("{0:N0} VNĐ", v.price_override.Value) : "Theo giá SP",
                        StockQuantity = v.StockQuantity,
                        Status = v.is_active ? "Đang kinh doanh" : "Ngừng kinh doanh"
                    })
                    .ToList();

                dgvVariants.DataSource = variantList;
            }
        }

        private bool TryGetSelectedProductId(out int productId)
        {
            return int.TryParse(txtProductId.Text, out productId) && productId > 0;
        }

        private string BuildVariantSku(int productId, int? colorId, int? sizeId, QLBanHangDataContext db)
        {
            string baseSku = "SP" + productId.ToString("D4") +
                             "-C" + (colorId.HasValue ? colorId.Value.ToString() : "0") +
                             "-S" + (sizeId.HasValue ? sizeId.Value.ToString() : "0");
            string candidate = baseSku;
            int suffix = 1;

            while (db.product_variants.Any(v => v.sku == candidate))
            {
                candidate = baseSku + "-" + suffix.ToString();
                suffix++;
            }

            return candidate;
        }

        private void SetVariantButtons()
        {
            int productId;
            bool hasProduct = TryGetSelectedProductId(out productId);
            btnAddVariant.Enabled = hasProduct && selectedVariantId == 0;
            btnUpdateVariant.Enabled = hasProduct && selectedVariantId > 0;
            btnDisableVariant.Enabled = hasProduct && selectedVariantId > 0;
            btnClearVariant.Enabled = hasProduct;

            cboVariantColor.Enabled = hasProduct && selectedVariantId == 0;
            cboVariantSize.Enabled = hasProduct && selectedVariantId == 0;
            txtVariantSku.Enabled = hasProduct && selectedVariantId == 0;
            numVariantPrice.Enabled = hasProduct;
            numVariantStock.Enabled = hasProduct;
            chkVariantActive.Enabled = hasProduct;

            lblVariantHint.Text = hasProduct
                ? "Đang quản lý biến thể của sản phẩm mã " + productId + ". Chọn một dòng để cập nhật tồn kho hoặc trạng thái."
                : "Chọn một sản phẩm ở danh sách bên trái trước khi thêm hoặc cập nhật biến thể.";
        }

        private void ResetVariantEditor()
        {
            selectedVariantId = 0;
            txtVariantSku.Clear();
            numVariantPrice.Value = 0;
            numVariantStock.Value = 0;
            chkVariantActive.Checked = true;

            cboVariantColor.Enabled = true;
            cboVariantSize.Enabled = true;
            txtVariantSku.Enabled = true;

            if (cboVariantColor.Items.Count > 0) cboVariantColor.SelectedIndex = 0;
            if (cboVariantSize.Items.Count > 0) cboVariantSize.SelectedIndex = 0;

            SetVariantButtons();
        }

        private void dgvVariants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvVariants.Rows[e.RowIndex].IsNewRow)
                return;

            var row = dgvVariants.Rows[e.RowIndex];
            object idValue = null;

            if (dgvVariants.Columns.Contains("colVariantId"))
                idValue = row.Cells["colVariantId"].Value;
            else if (dgvVariants.Columns.Contains("VariantId"))
                idValue = row.Cells["VariantId"].Value;
            else if (dgvVariants.Columns.Contains("Id"))
                idValue = row.Cells["Id"].Value;
            else if (dgvVariants.Columns.Contains("id"))
                idValue = row.Cells["id"].Value;
            else if (row.Cells.Count > 0)
                idValue = row.Cells[0].Value;

            if (idValue == null || idValue == DBNull.Value)
                return;

            int variantId = Convert.ToInt32(idValue);
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var variant = db.product_variants.FirstOrDefault(v => v.id == variantId);
                if (variant == null) return;

                selectedVariantId = variant.id;
                txtVariantSku.Text = variant.sku;
                if (variant.color_id.HasValue)
                    cboVariantColor.SelectedValue = variant.color_id.Value;
                else if (cboVariantColor.Items.Count > 0)
                    cboVariantColor.SelectedIndex = 0;

                if (variant.size_id.HasValue)
                    cboVariantSize.SelectedValue = variant.size_id.Value;
                else if (cboVariantSize.Items.Count > 0)
                    cboVariantSize.SelectedIndex = 0;
                numVariantPrice.Value = variant.price_override.HasValue ? variant.price_override.Value : 0;
                chkVariantActive.Checked = variant.is_active;

                var stock = variant.inventories.FirstOrDefault();
                numVariantStock.Value = stock != null ? stock.stock_quantity : 0;

                // Không đổi tổ hợp màu/size của biến thể đã tạo; tránh làm sai dữ liệu giỏ hàng.
                cboVariantColor.Enabled = false;
                cboVariantSize.Enabled = false;
                txtVariantSku.Enabled = false;
                SetVariantButtons();
            }
        }

        private void btnAddVariant_Click(object sender, EventArgs e)
        {
            int productId;
            if (!TryGetSelectedProductId(out productId))
            {
                MessageBox.Show("Vui lòng chọn hoặc lưu sản phẩm trước khi thêm biến thể.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? colorId = GetNullableComboValue(cboVariantColor);
            int? sizeId = GetNullableComboValue(cboVariantSize);
            string sku = txtVariantSku.Text.Trim();

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                bool duplicatedCombination = db.product_variants.Any(v =>
                    v.product_id == productId && v.color_id == colorId && v.size_id == sizeId);

                if (duplicatedCombination)
                {
                    MessageBox.Show("Tổ hợp màu sắc và kích thước này đã tồn tại. Hãy chọn biến thể đó trong danh sách để cập nhật.",
                                    "Trùng biến thể", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sku))
                    sku = BuildVariantSku(productId, colorId, sizeId, db);

                if (db.product_variants.Any(v => v.sku == sku))
                {
                    MessageBox.Show("Mã SKU đã tồn tại. Vui lòng nhập mã khác.", "Trùng SKU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVariantSku.Focus();
                    return;
                }

                product_variant newVariant = new product_variant
                {
                    product_id = productId,
                    sku = sku,
                    color_id = colorId,
                    size_id = sizeId,
                    price_override = numVariantPrice.Value > 0 ? (decimal?)numVariantPrice.Value : null,
                    is_active = chkVariantActive.Checked,
                    created_at = DateTime.Now
                };

                // Thêm inventory qua quan hệ LINQ to SQL để variant và tồn kho được lưu cùng SubmitChanges.
                newVariant.inventories.Add(new inventory
                {
                    stock_quantity = (int)numVariantStock.Value,
                    updated_at = DateTime.Now
                });

                db.product_variants.InsertOnSubmit(newVariant);
                db.SubmitChanges();
            }

            loadVariantData(productId);
            loadProductData();
            ResetVariantEditor();
            MessageBox.Show("Đã thêm biến thể và khởi tạo tồn kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateVariant_Click(object sender, EventArgs e)
        {
            int productId;
            if (!TryGetSelectedProductId(out productId) || selectedVariantId <= 0)
            {
                MessageBox.Show("Vui lòng chọn biến thể cần cập nhật trong danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var variant = db.product_variants.FirstOrDefault(v => v.id == selectedVariantId && v.product_id == productId);
                if (variant == null)
                {
                    MessageBox.Show("Không tìm thấy biến thể cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadVariantData(productId);
                    ResetVariantEditor();
                    return;
                }

                variant.price_override = numVariantPrice.Value > 0 ? (decimal?)numVariantPrice.Value : null;
                variant.is_active = chkVariantActive.Checked;

                var stock = variant.inventories.FirstOrDefault();
                if (stock == null)
                {
                    variant.inventories.Add(new inventory
                    {
                        stock_quantity = (int)numVariantStock.Value,
                        updated_at = DateTime.Now
                    });
                }
                else
                {
                    stock.stock_quantity = (int)numVariantStock.Value;
                    stock.updated_at = DateTime.Now;
                }

                db.SubmitChanges();
            }

            loadVariantData(productId);
            loadProductData();
            ResetVariantEditor();
            MessageBox.Show("Đã cập nhật giá riêng, tồn kho và trạng thái biến thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisableVariant_Click(object sender, EventArgs e)
        {
            int productId;
            if (!TryGetSelectedProductId(out productId) || selectedVariantId <= 0)
            {
                MessageBox.Show("Vui lòng chọn biến thể cần ngừng kinh doanh.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Ngừng kinh doanh biến thể này? Dữ liệu đơn hàng cũ và tồn kho vẫn được giữ lại.",
                "Xác nhận ngừng bán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var variant = db.product_variants.FirstOrDefault(v => v.id == selectedVariantId && v.product_id == productId);
                if (variant == null) return;

                variant.is_active = false;
                db.SubmitChanges();
            }

            loadVariantData(productId);
            loadProductData();
            ResetVariantEditor();
            MessageBox.Show("Đã ngừng kinh doanh biến thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearVariant_Click(object sender, EventArgs e)
        {
            ResetVariantEditor();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void pnlProductInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPageTitle_Click(object sender, EventArgs e)
        {

        }
    }
}