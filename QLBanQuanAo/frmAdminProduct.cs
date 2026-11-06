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

                // 1. Khắc phục lỗi NULL ở p.brand
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p => p.name.ToLower().Contains(keyword) ||
                                            (p.brand != null && p.brand.ToLower().Contains(keyword)));
                }

                // 2. Lọc theo Danh mục
                if (cboFilterCategory?.SelectedValue != null && int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int catId) && catId > 0)
                {
                    query = query.Where(p => p.category_id == catId);
                }

                // 3. Lọc theo Trạng thái
                string selectedStatus = (cboFilterStatus != null && cboFilterStatus.SelectedValue != null)
                    ? cboFilterStatus.SelectedValue.ToString()
                    : "all";
                if (selectedStatus != "all")
                {
                    query = query.Where(p => p.status == selectedStatus);
                }

                // 4. Đặt tên thuộc tính KHỚP 100% với DataPropertyName trong Designer.cs
                var productList = query
                    .Select(p => new
                    {
                        id = p.id,
                        name = p.name,
                        CategoryName = p.category != null ? p.category.name : "N/A",
                        price = p.price,
                        sale_price = p.sale_price,
                        // Tính tổng tồn kho từ các biến thể sản phẩm (khớp với DB WIN_FASHION_v2)
                        StockQuantity = p.product_variants.SelectMany(v => v.inventories).Sum(i => (int?)i.stock_quantity) ?? 0,
                        status = p.status
                    })
                    .OrderByDescending(p => p.id)
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

            // Nếu là đường dẫn tuyệt đối (VD: C:\...)
            if (Path.IsPathRooted(relativeOrAbsolutePath) && File.Exists(relativeOrAbsolutePath))
            {
                using (FileStream fs = new FileStream(relativeOrAbsolutePath, FileMode.Open, FileAccess.Read))
                {
                    picProductImage.Image = Image.FromStream(fs);
                }
                return;
            }

            // Nếu là đường dẫn tương đối: CẮT BỎ tất cả dấu / hoặc \ ở đầu chuỗi
            string cleanRelativePath = relativeOrAbsolutePath.TrimStart('/', '\\').Replace('/', '\\');

            // Tìm ảnh trong thư mục bin/Debug
            string fullPath = Path.Combine(Application.StartupPath, cleanRelativePath);

            // Nếu không thấy trong bin/Debug thì tìm tiếp trong thư mục Project gốc
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

                    // Copy vào thư mục bin/Debug lúc ứng dụng đang chạy
                    string binFolder = Path.Combine(Application.StartupPath, relFolder);
                    if (!Directory.Exists(binFolder)) Directory.CreateDirectory(binFolder);
                    string binFilePath = Path.Combine(binFolder, fileName);
                    File.Copy(dialog.FileName, binFilePath, true);

                    // Copy vào thư mục Project gốc trong Visual Studio
                    string projectFolder = Path.Combine(GetProjectFolder(), relFolder);
                    if (!Directory.Exists(projectFolder)) Directory.CreateDirectory(projectFolder);
                    string projectFilePath = Path.Combine(projectFolder, fileName);

                    if (binFilePath != projectFilePath)
                    {
                        File.Copy(dialog.FileName, projectFilePath, true);
                    }

                    // Gán đường dẫn tương đối chuẩn: uploads/products/prod_123.jpg
                    selectedRelativeImagePath = relFolder.Replace("\\", "/") + "/" + fileName;

                    // Hiển thị ảnh
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

                // 2. Lưu đường dẫn ảnh vào bảng product_images trong SQL Server
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

                MessageBox.Show("Thêm sản phẩm và lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadProductData();
                btnClearProduct_Click(sender, e);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(txtProductId.Text);
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn XÓA VĨNH VIỄN sản phẩm này khỏi cơ sở dữ liệu không?\n(Lưu ý: Hành động này không thể hoàn tác!)",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var p = db.products.FirstOrDefault(x => x.id == productId);
                    if (p != null)
                    {
                        try
                        {
                            // LINQ to SQL: Xóa sản phẩm trực tiếp khỏi Database
                            db.products.DeleteOnSubmit(p);
                            db.SubmitChanges();

                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadProductData();
                            btnClearProduct_Click(sender, e);
                        }
                        catch (Exception ex)
                        {
                            // Tránh văng ứng dụng nếu sản phẩm bị dính khóa ngoại (đã có trong Đơn hàng/Đánh giá)
                            MessageBox.Show("Không thể xóa sản phẩm này vì đã có dữ liệu liên quan (Đơn hàng hoặc Đánh giá) trong hệ thống!",
                                            "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            decimal? salePrice = isSale ? (decimal?)numProductSalePrice.Value : null;

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

            txtProductName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}