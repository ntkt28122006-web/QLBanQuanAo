using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            loadParentCategoryComboBox();
            loadCategoryData();
        }

        private void loadParentCategoryComboBox()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();
            var listParent = db.categories
                .Where(c => c.parent_id == null)
                .Select(c => new { c.id, c.name })
                .ToList();

            var parentOptions = listParent.Select(c => new { Id = (int?)c.id, Name = c.name }).ToList();
            parentOptions.Insert(0, new { Id = (int?)null, Name = "-- Danh mục gốc (Không có cha) --" });

            if (cboParentCategory != null)
            {
                cboParentCategory.DataSource = parentOptions;
                cboParentCategory.DisplayMember = "Name";
                cboParentCategory.ValueMember = "Id";
            }
        }

        private void loadCategoryData()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();

            var categoryList = db.categories
                .Select(c => new
                {
                    MaDanhMuc = c.id,
                    TenDanhMuc = c.name,
                    Slug = c.slug,
                    MaCha = c.parent_id,
                    TenDanhMucCha = c.category1 != null ? c.category1.name : "Gốc",
                    TrangThai = c.is_active ? "Đang hoạt động" : "Tạm khóa"
                })
                .OrderBy(c => c.MaDanhMuc)
                .ToList();

            if (dgvCategories != null)
            {
                dgvCategories.DataSource = categoryList;
            }

            if (categoryList.Count > 0)
            {
                hienthiDuLieuDong(0);
            }
            else
            {
                clearCategoryForm();
            }
        }

        private void hienthiDuLieuDong(int idrow)
        {
            if (dgvCategories == null || idrow < 0 || idrow >= dgvCategories.Rows.Count) return;

            QLBanHangDataContext db = new QLBanHangDataContext();
            int id = Convert.ToInt32(dgvCategories.Rows[idrow].Cells[0].Value);

            var cat = db.categories.SingleOrDefault(c => c.id == id);
            if (cat != null)
            {
                if (txtCategoryId != null) txtCategoryId.Text = cat.id.ToString();
                if (txtCategoryName != null) txtCategoryName.Text = cat.name;
                if (txtCategorySlug != null) txtCategorySlug.Text = cat.slug;
                if (chkCategoryActive != null) chkCategoryActive.Checked = cat.is_active;

                if (cboParentCategory != null)
                {
                    if (cat.parent_id == null)
                        cboParentCategory.SelectedIndex = 0;
                    else
                        cboParentCategory.SelectedValue = cat.parent_id;
                }
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1) return;
            hienthiDuLieuDong(idrow);
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1) return;
            hienthiDuLieuDong(idrow);
        }

        // Chức năng Thêm danh mục
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtCategoryName == null || string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLBanHangDataContext db = new QLBanHangDataContext();

            string slug = (txtCategorySlug != null && !string.IsNullOrWhiteSpace(txtCategorySlug.Text))
                ? txtCategorySlug.Text.Trim().ToLower()
                : txtCategoryName.Text.Trim().ToLower().Replace(" ", "-");

            if (db.categories.Any(c => c.slug == slug))
            {
                MessageBox.Show("Slug này đã tồn tại, vui lòng đổi slug khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            category cat = new category();
            cat.name = txtCategoryName.Text.Trim();
            cat.slug = slug;
            if (cboParentCategory != null) cat.parent_id = (int?)cboParentCategory.SelectedValue;
            if (chkCategoryActive != null) cat.is_active = chkCategoryActive.Checked;

            db.categories.InsertOnSubmit(cat);
            db.SubmitChanges();

            MessageBox.Show("Thêm danh mục mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadParentCategoryComboBox();
            loadCategoryData();
        }

        // Chức năng Sửa danh mục
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (txtCategoryId == null || string.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtCategoryId.Text);
            QLBanHangDataContext db = new QLBanHangDataContext();
            var cat = db.categories.SingleOrDefault(c => c.id == id);

            if (cat != null)
            {
                string slug = (txtCategorySlug != null && !string.IsNullOrWhiteSpace(txtCategorySlug.Text))
                    ? txtCategorySlug.Text.Trim().ToLower()
                    : txtCategoryName.Text.Trim().ToLower().Replace(" ", "-");

                if (db.categories.Any(c => c.slug == slug && c.id != id))
                {
                    MessageBox.Show("Slug này bị trùng với danh mục khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? selectedParentId = cboParentCategory != null ? (int?)cboParentCategory.SelectedValue : null;
                if (selectedParentId == id)
                {
                    MessageBox.Show("Danh mục không thể làm cha của chính nó!", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtCategoryName != null) cat.name = txtCategoryName.Text.Trim();
                cat.slug = slug;
                cat.parent_id = selectedParentId;
                if (chkCategoryActive != null) cat.is_active = chkCategoryActive.Checked;

                db.SubmitChanges();
                MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadParentCategoryComboBox();
                loadCategoryData();
            }
        }

        // Chức năng Xóa danh mục
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (txtCategoryId == null || string.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtCategoryId.Text);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QLBanHangDataContext db = new QLBanHangDataContext();
                var cat = db.categories.SingleOrDefault(c => c.id == id);

                if (cat != null)
                {
                    if (db.categories.Any(c => c.parent_id == id))
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang chứa danh mục con!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (db.products.Any(p => p.category_id == id))
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang có sản phẩm thuộc danh mục!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.categories.DeleteOnSubmit(cat);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadParentCategoryComboBox();
                    loadCategoryData();
                }
            }
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            clearCategoryForm();
            loadCategoryData();
        }

        private void clearCategoryForm()
        {
            if (txtCategoryId != null) txtCategoryId.Clear();
            if (txtCategoryName != null) txtCategoryName.Clear();
            if (txtCategorySlug != null) txtCategorySlug.Clear();
            if (chkCategoryActive != null) chkCategoryActive.Checked = true;
            if (cboParentCategory != null && cboParentCategory.Items.Count > 0) cboParentCategory.SelectedIndex = 0;
        }

        private void lblCategoryDescription_Click(object sender, EventArgs e) { }
        private void txtCategoryId_TextChanged(object sender, EventArgs e) { }
        private void txtCategoryName_TextChanged(object sender, EventArgs e) { }
        private void txtCategorySlug_TextChanged(object sender, EventArgs e) { }
        private void cboParentCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkCategoryActive_CheckedChanged(object sender, EventArgs e) { }
    }
}