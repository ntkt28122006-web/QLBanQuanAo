using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmAdminProduct : Form
    {
        public frmAdminProduct()
        {
            InitializeComponent();
        }

        private void frmAdminProduct_Load(object sender, EventArgs e)
        {
            loadFilterCategoryComboBox();
            loadFilterStatusComboBox();
            loadProductData();
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

        private void loadProductData()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();
            string keyword = txtSearchProduct != null ? txtSearchProduct.Text.Trim().ToLower() : "";

            var query = db.products.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.name.ToLower().Contains(keyword) || p.brand.ToLower().Contains(keyword));
            }

            if (cboFilterCategory != null && cboFilterCategory.SelectedValue != null && (int?)cboFilterCategory.SelectedValue > 0)
            {
                int catId = Convert.ToInt32(cboFilterCategory.SelectedValue);
                query = query.Where(p => p.category_id == catId);
            }

            string selectedStatus = (cboFilterStatus != null && cboFilterStatus.SelectedValue != null)
                ? cboFilterStatus.SelectedValue.ToString()
                : "all";
            if (selectedStatus != "all")
            {
                query = query.Where(p => p.status == selectedStatus);
            }

            var productList = query
                .Select(p => new
                {
                    MaSP = p.id,
                    TenSP = p.name,
                    DanhMuc = p.category != null ? p.category.name : "N/A",
                    GiaCoSo = p.price,
                    GiaKhuyenMai = p.sale_price,
                    ThuongHieu = p.brand,
                    TrangThai = p.status,
                    Hot = p.is_hot ? "Có" : "Không",
                    Sale = p.is_sale ? "Có" : "Không",
                    NgayTao = p.created_at
                })
                .OrderByDescending(p => p.MaSP)
                .ToList();

            if (dgvProducts != null)
            {
                dgvProducts.DataSource = productList;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1 || dgvProducts == null) return;
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

        private void btnChooseImage_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}