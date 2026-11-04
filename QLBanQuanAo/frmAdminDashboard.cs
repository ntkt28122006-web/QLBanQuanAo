using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            loadFilterCustomerStatusComboBox();
            loadCustomerData();
        }

        // Đổ danh sách trạng thái tài khoản vào ComboBox lọc
        private void loadFilterCustomerStatusComboBox()
        {
            var statusList = new[]
            {
                new { Value = "all", Text = "-- Tất cả trạng thái --" },
                new { Value = "active", Text = "Đang hoạt động (active)" },
                new { Value = "locked", Text = "Tạm khóa (locked)" }
            };

            if (cboFilterCustomerStatus != null)
            {
                cboFilterCustomerStatus.DataSource = statusList.ToList();
                cboFilterCustomerStatus.DisplayMember = "Text";
                cboFilterCustomerStatus.ValueMember = "Value";
            }
        }

        // Truy vấn danh sách khách hàng bằng LINQ to SQL Lambda
        private void loadCustomerData()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();
            string keyword = txtSearchCustomer != null ? txtSearchCustomer.Text.Trim().ToLower() : "";
            string selectedStatus = (cboFilterCustomerStatus != null && cboFilterCustomerStatus.SelectedValue != null)
                ? cboFilterCustomerStatus.SelectedValue.ToString()
                : "all";

            var query = db.users.AsQueryable();

            // Tìm kiếm theo Họ tên, Email hoặc Số điện thoại
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(u => u.full_name.ToLower().Contains(keyword) ||
                                         u.email.ToLower().Contains(keyword) ||
                                         u.phone.Contains(keyword));
            }

            // Lọc theo trạng thái tài khoản
            if (selectedStatus != "all")
            {
                query = query.Where(u => u.status == selectedStatus);
            }

            var result = query
                .Select(u => new
                {
                    MaKH = u.id,
                    HoTen = u.full_name,
                    Email = u.email,
                    SoDienThoai = u.phone,
                    TrangThai = u.status == "active" ? "Hoạt động" : "Tạm khóa",
                    NgayTao = u.created_at
                })
                .OrderByDescending(u => u.MaKH)
                .ToList();

            if (dgvCustomers != null)
            {
                dgvCustomers.DataSource = result;
            }

            if (result.Count > 0)
            {
                hienthiDuLieuDong(0);
            }
            else
            {
                clearCustomerForm();
            }
        }

        private void hienthiDuLieuDong(int idrow)
        {
            if (dgvCustomers == null || idrow < 0 || idrow >= dgvCustomers.Rows.Count) return;

            QLBanHangDataContext db = new QLBanHangDataContext();
            int id = Convert.ToInt32(dgvCustomers.Rows[idrow].Cells[0].Value);

            var usr = db.users.SingleOrDefault(u => u.id == id);
            if (usr != null)
            {
                if (txtDetailCustomerId != null) txtDetailCustomerId.Text = usr.id.ToString();
                if (txtDetailCustomerName != null) txtDetailCustomerName.Text = usr.full_name;
                if (txtDetailCustomerEmail != null) txtDetailCustomerEmail.Text = usr.email;
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1) return;
            hienthiDuLieuDong(idrow);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void cboFilterCustomerStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        // Khóa tài khoản khách hàng
        private void btnLockCustomer_Click(object sender, EventArgs e)
        {
            if (txtDetailCustomerId == null || string.IsNullOrEmpty(txtDetailCustomerId.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản khách hàng cần khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(txtDetailCustomerId.Text);
            QLBanHangDataContext db = new QLBanHangDataContext();
            var usr = db.users.SingleOrDefault(u => u.id == userId);

            if (usr != null)
            {
                usr.status = "locked";
                db.SubmitChanges();
                MessageBox.Show("Đã khóa tài khoản khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCustomerData();
            }
        }

        // Mở khóa tài khoản khách hàng
        private void btnUnlockCustomer_Click(object sender, EventArgs e)
        {
            if (txtDetailCustomerId == null || string.IsNullOrEmpty(txtDetailCustomerId.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản khách hàng cần mở khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(txtDetailCustomerId.Text);
            QLBanHangDataContext db = new QLBanHangDataContext();
            var usr = db.users.SingleOrDefault(u => u.id == userId);

            if (usr != null)
            {
                usr.status = "active";
                db.SubmitChanges();
                MessageBox.Show("Đã mở khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCustomerData();
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            clearCustomerForm();
            loadCustomerData();
        }

        private void clearCustomerForm()
        {
            if (txtSearchCustomer != null) txtSearchCustomer.Clear();
            if (txtDetailCustomerId != null) txtDetailCustomerId.Clear();
            if (txtDetailCustomerName != null) txtDetailCustomerName.Clear();
            if (txtDetailCustomerEmail != null) txtDetailCustomerEmail.Clear();
            if (cboFilterCustomerStatus != null && cboFilterCustomerStatus.Items.Count > 0)
                cboFilterCustomerStatus.SelectedIndex = 0;
        }

        private void lblCustomerManagementTitle_Click(object sender, EventArgs e) { }
        private void txtDetailCustomerEmail_TextChanged(object sender, EventArgs e) { }
        private void lblDetailCustomerPhone_Click(object sender, EventArgs e) { }
        private void txtDetailCustomerId_TextChanged(object sender, EventArgs e) { }
        private void lblDetailCustomerName_Click(object sender, EventArgs e) { }
        private void pnlCustomerList_Paint(object sender, PaintEventArgs e) { }
    }
}