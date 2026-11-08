using ReaLTaiizor;
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
    public partial class frmSignIn : Form
    {
        private QLBanHangDataContext db = new QLBanHangDataContext();
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void dungeonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void foxLinkLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 1. Kiểm tra dữ liệu nhập
            if (fullName == "" || email == "" || phone == "" ||
                password == "" || confirmPassword == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự!");
                return;
            }

            try
            {
               
                    // 3. Kiểm tra email đã tồn tại
                    bool emailExists = db.users.Any(u => u.email == email);

                    if (emailExists)
                    {
                        MessageBox.Show("Email này đã được đăng ký!");
                        return;
                    }

                    // 4. Mã hóa mật khẩu
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                    // 5. Tạo tài khoản mới
                    user newUser = new user
                    {
                        full_name = fullName,
                        email = email,
                        phone = phone,
                        password_hash = passwordHash,
                        email_verified = false,
                        status = "active",
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };

                    db.users.InsertOnSubmit(newUser);
                    db.SubmitChanges();

                    // 6. Gán vai trò Customer (role_id = 2)
                    user_role newUserRole = new user_role
                    {
                        user_id = newUser.id,
                        role_id = 2
                    };

                    db.user_roles.InsertOnSubmit(newUserRole);
                    db.SubmitChanges();

                    MessageBox.Show("Đăng ký tài khoản thành công!");

                    // Xóa dữ liệu trên form
                    txtFullName.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại:\n" + ex.Message);
            }
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
