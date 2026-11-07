using System;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmAdminDashboard : Form
    {
        private bool _isBindingStatusFilter;
        private bool _isResettingControls;

        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.ClearSelection();

            btnLockCustomer.Enabled = false;
            btnUnlockCustomer.Enabled = false;

            loadFilterCustomerStatusComboBox();
            loadCustomerData();
        }

        // Đổ đầy đủ ba trạng thái có trong bảng users.
        private void loadFilterCustomerStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = "all", Text = "-- Tất cả trạng thái --" },
                new { Value = "active", Text = "Đang hoạt động" },
                new { Value = "inactive", Text = "Ngừng hoạt động" },
                new { Value = "banned", Text = "Đã khóa" }
            };

            _isBindingStatusFilter = true;
            try
            {
                cboFilterCustomerStatus.DataSource = statusList;
                cboFilterCustomerStatus.DisplayMember = "Text";
                cboFilterCustomerStatus.ValueMember = "Value";
                cboFilterCustomerStatus.SelectedValue = "all";
            }
            finally
            {
                _isBindingStatusFilter = false;
            }
        }

        // Chỉ lấy tài khoản có vai trò Customer; loại trừ tài khoản có vai trò Admin.
        private void loadCustomerData()
        {
            if (_isResettingControls) return;

            string keyword = txtSearchCustomer.Text.Trim().ToLower();
            string selectedStatus = cboFilterCustomerStatus.SelectedValue == null
                ? "all"
                : cboFilterCustomerStatus.SelectedValue.ToString();

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var query = db.users.Where(u =>
                        u.user_roles.Any(ur => ur.role.name == "Customer") &&
                        !u.user_roles.Any(ur => ur.role.name == "Admin"));

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query = query.Where(u =>
                            u.full_name.ToLower().Contains(keyword) ||
                            u.email.ToLower().Contains(keyword) ||
                            (u.phone != null && u.phone.Contains(keyword)));
                    }

                    if (selectedStatus != "all")
                    {
                        query = query.Where(u => u.status == selectedStatus);
                    }

                    var result = query
                        .OrderByDescending(u => u.created_at)
                        .Select(u => new
                        {
                            MaKH = u.id,
                            HoTen = u.full_name,
                            Email = u.email,
                            SoDienThoai = u.phone ?? "",
                            TrangThai = u.status == "active"
                                ? "Đang hoạt động"
                                : (u.status == "inactive" ? "Ngừng hoạt động" : "Đã khóa"),
                            NgayTao = u.created_at
                        })
                        .ToList();

                    dgvCustomers.DataSource = result;
                }

                if (dgvCustomers.Rows.Count > 0)
                {
                    hienthiDuLieuDong(0);
                }
                else
                {
                    clearCustomerDetails();
                }
            }
            catch (Exception ex)
            {
                dgvCustomers.DataSource = null;
                clearCustomerDetails();
                MessageBox.Show(
                    "Không thể tải danh sách khách hàng.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void hienthiDuLieuDong(int idrow)
        {
            if (idrow < 0 || idrow >= dgvCustomers.Rows.Count) return;

            object idValue = dgvCustomers.Rows[idrow].Cells["colCustomerId"].Value;
            if (idValue == null || idValue == DBNull.Value)
            {
                clearCustomerDetails();
                return;
            }

            int userId;
            if (!int.TryParse(idValue.ToString(), out userId))
            {
                clearCustomerDetails();
                return;
            }

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var usr = db.users.SingleOrDefault(u =>
                        u.id == userId &&
                        u.user_roles.Any(ur => ur.role.name == "Customer") &&
                        !u.user_roles.Any(ur => ur.role.name == "Admin"));

                    if (usr == null)
                    {
                        clearCustomerDetails();
                        return;
                    }

                    txtDetailCustomerId.Text = usr.id.ToString();
                    txtDetailCustomerName.Text = usr.full_name;
                    txtDetailCustomerEmail.Text = usr.email;
                    txtDetailCustomerPhone.Text = usr.phone ?? "";
                    lblCustomerStatus.Text = "Trạng thái: " + getCustomerStatusText(usr.status);

                    btnLockCustomer.Enabled = usr.status != "banned";
                    btnUnlockCustomer.Enabled = usr.status != "active";
                }
            }
            catch (Exception ex)
            {
                clearCustomerDetails();
                MessageBox.Show(
                    "Không thể tải thông tin tài khoản.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string getCustomerStatusText(string status)
        {
            switch (status)
            {
                case "active": return "Đang hoạt động";
                case "inactive": return "Ngừng hoạt động";
                case "banned": return "Đã khóa";
                default: return "Không xác định";
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                hienthiDuLieuDong(e.RowIndex);
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if (!_isResettingControls)
            {
                loadCustomerData();
            }
        }

        private void cboFilterCustomerStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isBindingStatusFilter && !_isResettingControls)
            {
                loadCustomerData();
            }
        }

        private void btnLockCustomer_Click(object sender, EventArgs e)
        {
            changeCustomerStatus("banned", "khóa");
        }

        private void btnUnlockCustomer_Click(object sender, EventArgs e)
        {
            changeCustomerStatus("active", "mở khóa");
        }

        private void changeCustomerStatus(string newStatus, string actionText)
        {
            int userId;
            if (!int.TryParse(txtDetailCustomerId.Text, out userId))
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản khách hàng cần thao tác!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn " + actionText + " tài khoản khách hàng này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var usr = db.users.SingleOrDefault(u =>
                        u.id == userId &&
                        u.user_roles.Any(ur => ur.role.name == "Customer") &&
                        !u.user_roles.Any(ur => ur.role.name == "Admin"));

                    if (usr == null)
                    {
                        MessageBox.Show(
                            "Tài khoản không còn thuộc nhóm khách hàng hoặc đã được thay đổi vai trò.",
                            "Không thể thực hiện",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        loadCustomerData();
                        return;
                    }

                    if (usr.status == newStatus)
                    {
                        MessageBox.Show(
                            "Tài khoản đang ở trạng thái này rồi.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        hienthiDuLieuDong(dgvCustomers.CurrentRow == null ? -1 : dgvCustomers.CurrentRow.Index);
                        return;
                    }

                    usr.status = newStatus;
                    usr.updated_at = DateTime.Now;
                    db.SubmitChanges();
                }

                MessageBox.Show(
                    "Đã " + actionText + " tài khoản khách hàng thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                loadCustomerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật trạng thái tài khoản.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            _isResettingControls = true;
            try
            {
                txtSearchCustomer.Clear();
                if (cboFilterCustomerStatus.Items.Count > 0)
                {
                    cboFilterCustomerStatus.SelectedValue = "all";
                }
            }
            finally
            {
                _isResettingControls = false;
            }

            loadCustomerData();
        }

        private void clearCustomerDetails()
        {
            txtDetailCustomerId.Clear();
            txtDetailCustomerName.Clear();
            txtDetailCustomerEmail.Clear();
            txtDetailCustomerPhone.Clear();
            lblCustomerStatus.Text = "Trạng thái: Chưa chọn tài khoản";
            btnLockCustomer.Enabled = false;
            btnUnlockCustomer.Enabled = false;
        }
    }
}
