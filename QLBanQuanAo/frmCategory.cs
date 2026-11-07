using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmCategory : Form
    {
        private bool _isBindingCategory;

        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dgvCategories.AutoGenerateColumns = false;
            loadParentCategoryComboBox(null, null);
            loadCategoryData(null, true);
        }

        private void loadParentCategoryComboBox(int? excludeCategoryId, int? selectedParentId)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                // Tach dieu kien nullable ra khoi IQueryable de LINQ to SQL
                // khong phai danh gia excludeCategoryId.Value khi gia tri dang null.
                IQueryable<category> categoryQuery = db.categories;

                if (excludeCategoryId.HasValue)
                {
                    int excludedId = excludeCategoryId.Value;
                    categoryQuery = categoryQuery.Where(c => c.id != excludedId);
                }

                // Lay du lieu tho tu SQL truoc; tao chuoi hien thi o bo nho ung dung.
                var categoryRows = categoryQuery
                    .OrderBy(c => c.parent_id)
                    .ThenBy(c => c.id)
                    .Select(c => new
                    {
                        Id = c.id,
                        ParentId = c.parent_id,
                        Name = c.name
                    })
                    .ToList();

                var parentOptions = categoryRows
                    .Select(c => new
                    {
                        Id = (int?)c.Id,
                        Name = c.ParentId == null ? c.Name : "↳ " + c.Name
                    })
                    .ToList();

                parentOptions.Insert(0, new
                {
                    Id = (int?)null,
                    Name = "-- Danh mục gốc (Không có cha) --"
                });

                bool oldBindingState = _isBindingCategory;
                _isBindingCategory = true;
                try
                {
                    cboParentCategory.DataSource = null;
                    cboParentCategory.DisplayMember = "Name";
                    cboParentCategory.ValueMember = "Id";
                    cboParentCategory.DataSource = parentOptions;

                    if (selectedParentId.HasValue)
                        cboParentCategory.SelectedValue = selectedParentId.Value;
                    else
                        cboParentCategory.SelectedIndex = 0;
                }
                finally
                {
                    _isBindingCategory = oldBindingState;
                }
            }
        }

        private void loadCategoryData(int? selectedCategoryId, bool selectFirstIfNotFound)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                string keyword = txtSearchCategory.Text.Trim();
                IQueryable<category> categoryQuery = db.categories;
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    categoryQuery = categoryQuery.Where(c =>
                        c.name.Contains(keyword) || c.slug.Contains(keyword));
                }

                var categoryList = categoryQuery
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

                _isBindingCategory = true;
                try
                {
                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = categoryList;
                    dgvCategories.ClearSelection();
                    dgvCategories.CurrentCell = null;
                }
                finally
                {
                    _isBindingCategory = false;
                }

                if (categoryList.Count == 0)
                {
                    clearCategoryForm();
                    return;
                }

                int selectedRowIndex = -1;
                if (selectedCategoryId.HasValue)
                {
                    for (int i = 0; i < dgvCategories.Rows.Count; i++)
                    {
                        object value = dgvCategories.Rows[i].Cells["colCategoryId"].Value;
                        if (value != null && Convert.ToInt32(value) == selectedCategoryId.Value)
                        {
                            selectedRowIndex = i;
                            break;
                        }
                    }
                }

                if (selectedRowIndex < 0 && selectFirstIfNotFound)
                    selectedRowIndex = 0;

                if (selectedRowIndex >= 0)
                {
                    dgvCategories.Rows[selectedRowIndex].Selected = true;
                    dgvCategories.CurrentCell = dgvCategories.Rows[selectedRowIndex].Cells["colCategoryId"];
                    hienthiDuLieuDong(selectedRowIndex);
                }
                else
                {
                    clearCategoryForm();
                }
            }
        }

        private void hienthiDuLieuDong(int idrow)
        {
            if (_isBindingCategory || idrow < 0 || idrow >= dgvCategories.Rows.Count)
                return;

            object idValue = dgvCategories.Rows[idrow].Cells["colCategoryId"].Value;
            int id;
            if (idValue == null || !int.TryParse(idValue.ToString(), out id))
                return;

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var cat = db.categories.SingleOrDefault(c => c.id == id);
                if (cat == null)
                    return;

                _isBindingCategory = true;
                try
                {
                    txtCategoryId.Text = cat.id.ToString();
                    txtCategoryName.Text = cat.name;
                    txtCategorySlug.Text = cat.slug;
                    chkCategoryActive.Checked = cat.is_active;
                    loadParentCategoryComboBox(cat.id, cat.parent_id);
                }
                finally
                {
                    _isBindingCategory = false;
                }
            }

            updateCategoryActionButtons();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                hienthiDuLieuDong(e.RowIndex);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show("Vui lòng nhấn Làm mới trước khi thêm một danh mục mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = txtCategoryName.Text.Trim();
            if (!validateCategoryName(name))
                return;

            string slug = generateSlug(name);
            if (string.IsNullOrWhiteSpace(slug))
            {
                MessageBox.Show("Tên danh mục không tạo được slug hợp lệ. Vui lòng nhập tên khác.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    if (db.categories.Any(c => c.slug == slug))
                    {
                        MessageBox.Show("Slug đã tồn tại. Vui lòng thay đổi tên danh mục.",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int? parentId = getSelectedParentId();
                    if (parentId.HasValue && !db.categories.Any(c => c.id == parentId.Value))
                    {
                        MessageBox.Show("Danh mục cha không còn tồn tại. Vui lòng chọn lại.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadParentCategoryComboBox(null, null);
                        return;
                    }

                    category cat = new category
                    {
                        name = name,
                        slug = slug,
                        parent_id = parentId,
                        is_active = chkCategoryActive.Checked
                    };

                    db.categories.InsertOnSubmit(cat);
                    db.SubmitChanges();

                    int newCategoryId = cat.id;
                    MessageBox.Show("Thêm danh mục mới thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategoryData(newCategoryId, false);
                }
            }
            catch (Exception ex)
            {
                showCategoryError("thêm danh mục", ex);
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtCategoryId.Text, out id))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCategoryName.Text.Trim();
            if (!validateCategoryName(name))
                return;

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    category cat = db.categories.SingleOrDefault(c => c.id == id);
                    if (cat == null)
                    {
                        MessageBox.Show("Danh mục không còn tồn tại. Danh sách sẽ được tải lại.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadCategoryData(null, true);
                        return;
                    }

                    int? parentId = getSelectedParentId();
                    if (parentId.HasValue && !db.categories.Any(c => c.id == parentId.Value))
                    {
                        MessageBox.Show("Danh mục cha không còn tồn tại. Vui lòng chọn lại.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadParentCategoryComboBox(id, cat.parent_id);
                        return;
                    }

                    if (parentId.HasValue && wouldCreateCategoryCycle(db, id, parentId.Value))
                    {
                        MessageBox.Show("Không thể chọn danh mục hiện tại hoặc danh mục con của nó làm danh mục cha.",
                            "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string slug = string.Equals(cat.name, name, StringComparison.Ordinal)
                        ? cat.slug
                        : generateSlug(name);

                    if (string.IsNullOrWhiteSpace(slug))
                    {
                        MessageBox.Show("Tên danh mục không tạo được slug hợp lệ.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (db.categories.Any(c => c.slug == slug && c.id != id))
                    {
                        MessageBox.Show("Slug đã tồn tại ở một danh mục khác. Vui lòng đổi tên danh mục.",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cat.name = name;
                    cat.slug = slug;
                    cat.parent_id = parentId;
                    cat.is_active = chkCategoryActive.Checked;
                    db.SubmitChanges();

                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategoryData(id, false);
                }
            }
            catch (Exception ex)
            {
                showCategoryError("cập nhật danh mục", ex);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtCategoryId.Text, out id))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa danh mục này?\nChỉ danh mục không có danh mục con và không có sản phẩm mới được xóa.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    category cat = db.categories.SingleOrDefault(c => c.id == id);
                    if (cat == null)
                    {
                        MessageBox.Show("Danh mục không còn tồn tại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadCategoryData(null, true);
                        return;
                    }

                    if (db.categories.Any(c => c.parent_id == id))
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang có danh mục con. Hãy chuyển hoặc xóa danh mục con trước.",
                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (db.products.Any(p => p.category_id == id))
                    {
                        MessageBox.Show("Không thể xóa danh mục này vì đang có sản phẩm. Hãy chuyển sản phẩm sang danh mục khác hoặc tạm khóa danh mục.",
                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    db.categories.DeleteOnSubmit(cat);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategoryData(null, true);
                }
            }
            catch (Exception ex)
            {
                showCategoryError("xóa danh mục", ex);
            }
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            _isBindingCategory = true;
            try
            {
                txtSearchCategory.Clear();
                dgvCategories.ClearSelection();
                dgvCategories.CurrentCell = null;
                clearCategoryForm();
                loadParentCategoryComboBox(null, null);
            }
            finally
            {
                _isBindingCategory = false;
            }

            // Lam moi dua form ve che do them moi, khong khoa cac o nhap.
            loadCategoryData(null, false);
            txtCategoryName.ReadOnly = false;
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            loadCategoryData(null, true);
        }

        private void txtSearchCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadCategoryData(null, true);
            }
        }

        private void clearCategoryForm()
        {
            bool oldBindingState = _isBindingCategory;
            _isBindingCategory = true;
            try
            {
                txtCategoryId.Clear();
                txtCategoryName.Clear();
                txtCategoryName.Enabled = true;
                txtCategoryName.ReadOnly = false;
                txtCategorySlug.Clear();
                txtCategorySlug.ReadOnly = true;
                chkCategoryActive.Checked = true;
                if (cboParentCategory.Items.Count > 0)
                    cboParentCategory.SelectedIndex = 0;
            }
            finally
            {
                _isBindingCategory = oldBindingState;
            }

            updateCategoryActionButtons();
        }

        private void updateCategoryActionButtons()
        {
            bool hasSelectedCategory = !string.IsNullOrWhiteSpace(txtCategoryId.Text);
            btnUpdateCategory.Enabled = hasSelectedCategory;
            btnDeleteCategory.Enabled = hasSelectedCategory;
        }

        private int? getSelectedParentId()
        {
            object selectedValue = cboParentCategory.SelectedValue;
            if (selectedValue == null || selectedValue == DBNull.Value)
                return null;

            int parentId;
            return int.TryParse(selectedValue.ToString(), out parentId)
                ? (int?)parentId
                : null;
        }

        private bool validateCategoryName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }

            if (name.Length > 100)
            {
                MessageBox.Show("Tên danh mục không được vượt quá 100 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }

            return true;
        }

        private string generateSlug(string value)
        {
            string normalized = (value ?? string.Empty).Trim().ToLowerInvariant().Replace('đ', 'd');
            string decomposed = normalized.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            foreach (char ch in decomposed)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) == UnicodeCategory.NonSpacingMark)
                    continue;

                if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'))
                {
                    builder.Append(ch);
                }
                else if (builder.Length > 0 && builder[builder.Length - 1] != '-')
                {
                    builder.Append('-');
                }
            }

            string slug = builder.ToString().Trim('-');
            if (slug.Length > 120)
                slug = slug.Substring(0, 120).TrimEnd('-');

            return slug;
        }

        private bool wouldCreateCategoryCycle(QLBanHangDataContext db, int categoryId, int proposedParentId)
        {
            int? currentId = proposedParentId;
            System.Collections.Generic.HashSet<int> visited = new System.Collections.Generic.HashSet<int>();

            while (currentId.HasValue)
            {
                if (currentId.Value == categoryId)
                    return true;

                if (!visited.Add(currentId.Value))
                    return true;

                category parent = db.categories.SingleOrDefault(c => c.id == currentId.Value);
                if (parent == null)
                    return false;

                currentId = parent.parent_id;
            }

            return false;
        }

        private void showCategoryError(string action, Exception ex)
        {
            MessageBox.Show("Không thể " + action + ".\nChi tiết: " + ex.Message,
                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblCategoryDescription_Click(object sender, EventArgs e) { }
        private void txtCategoryId_TextChanged(object sender, EventArgs e) { }
        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (!_isBindingCategory && string.IsNullOrWhiteSpace(txtCategoryId.Text))
                txtCategorySlug.Text = generateSlug(txtCategoryName.Text);
        }
        private void txtCategorySlug_TextChanged(object sender, EventArgs e) { }
        private void cboParentCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkCategoryActive_CheckedChanged(object sender, EventArgs e) { }
    }
}
