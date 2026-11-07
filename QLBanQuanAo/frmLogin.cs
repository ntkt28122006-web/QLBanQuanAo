using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmLogin : Form
    {
        private QLBanHangDataContext db = new QLBanHangDataContext();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            frmFogotPassword forgotPasswordForm = new frmFogotPassword();
            forgotPasswordForm.Show();
            this.Hide();
        }



        private void lnkSignin_Click(object sender, EventArgs e)
        {
            frmSignIn frmSignIn = new frmSignIn();
            frmSignIn.Show();
            this.Hide();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {

                // 2. Truy vấn LINQ to SQL lấy thông tin tài khoản theo Email
                var u = db.users.FirstOrDefault(x => x.email == email);

                if (u == null)
                {
                    MessageBox.Show("Email không tồn tại trong hệ thống!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                // 3. Kiểm tra trạng thái tài khoản
                if (u.status == "banned" || u.status == "inactive")
                {
                    MessageBox.Show("Tài khoản của bạn đã bị khóa hoặc chưa kích hoạt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Kiểm tra Mật khẩu


                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, u.password_hash);

                if (!isPasswordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }

                // 5. Kiểm tra vai trò theo tên, không phụ thuộc thứ tự bản ghi user_roles.
                var userRoles = u.user_roles
                    .Select(ur => ur.role.name)
                    .ToList();

                bool isAdmin = userRoles.Contains("Admin");
                bool isCustomer = userRoles.Contains("Customer");

                if (!isAdmin && !isCustomer)
                {
                    UserSession.Clear();
                    MessageBox.Show(
                        "Tài khoản chưa được gán quyền truy cập hợp lệ.",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Lưu đúng tài khoản vừa xác thực để các form giỏ hàng/đơn hàng dùng chung.
                UserSession.SetCurrentUser(u);

                MessageBox.Show($"Đăng nhập thành công! Chào mừng {u.full_name}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nếu tài khoản có cả hai vai trò thì ưu tiên mở khu vực quản trị.
                if (isAdmin)
                {
                    frmMainAdmin adminForm = new frmMainAdmin(u);
                    adminForm.Show();
                }
                else
                {
                    FrmCustomerHome frmCustomerHome = new FrmCustomerHome(u);
                    frmCustomerHome.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
