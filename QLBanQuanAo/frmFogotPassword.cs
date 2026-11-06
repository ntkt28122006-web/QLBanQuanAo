using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmFogotPassword : Form
    {
        // 1. Biến lưu trữ thông tin tạm thời cho quá trình xác thực OTP
        private string generatedOtp = "";
        private DateTime otpExpiryTime;
        private string targetEmail = "";

        // Cấu hình Email gửi OTP 
        private const string SenderEmail = "Ktho.28122006@gmail.com";
        private const string SenderAppPassword = "dvvd lzgd tsdj oltr"; // Mật khẩu ứng dụng 16 ký tự của Gmail
        public frmFogotPassword()
        {
            InitializeComponent();
            ShowStep(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ShowStep(int step)
        {
            pnlEmail.Visible = (step == 1);
            pnlOTP.Visible = (step == 2);
            pnlNewPassword.Visible = (step == 3);
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string emailInput = txtEmail.Text.Trim();

            if(string.IsNullOrEmpty(emailInput))
            {
                MessageBox.Show("Vui lòng nhập Email đã đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var user = db.users.FirstOrDefault(u => u.email == emailInput && u.status=="active");
                if (user == null)
                {
                    MessageBox.Show("Email không tồn tại trong hệ thống hoặc tài khoản không hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                targetEmail = emailInput; // Lưu email để sử dụng trong bước xác thực OTP
                SendOtpProcess();
            }
        }

        private void SendOtpProcess()
        {
            try
            {
                // 1. Sinh mã OTP ngẫu nhiên 6 chữ số
                Random random = new Random();
                generatedOtp = random.Next(100000, 999999).ToString();
                otpExpiryTime = DateTime.Now.AddMinutes(3);

                // 2. LƯU HASH CỦA OTP VÀ HẠN DÙNG VÀO DATABASE
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var userObj = db.users.FirstOrDefault(u => u.email == targetEmail && u.status == "active");
                    if (userObj != null)
                    {
                        // Mã hóa OTP bằng BCrypt trước khi lưu xuống DB
                        userObj.password_reset_otp_hash = BCrypt.Net.BCrypt.HashPassword(generatedOtp);
                        userObj.password_reset_otp_expires_at = otpExpiryTime;

                        db.SubmitChanges(); // Lưu thay đổi xuống SQL Server
                    }
                }

                // 3. Gửi Email chứa mã OTP thô cho người dùng
                SendEmailSmtp(targetEmail, generatedOtp);

                MessageBox.Show($"Mã OTP đã được gửi đến email {targetEmail}. Vui lòng kiểm tra hộp thư!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOTP.Text = "";
                ShowStep(2);
            }
            catch (Exception ex)
            {
                string errorDetails = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Gửi Email thất bại! Lỗi chi tiết: " + errorDetails,
                                "Lỗi kết nối Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmailSmtp(string toEmail, string otpCode)
        {
            var fromAddress = new MailAddress(SenderEmail, "FASHION STORE");
            var toAddress = new MailAddress(toEmail);

            string subject = "[FASHION STORE] Mã xác minh đặt lại mật khẩu";
            string body = $@"
                <h3>Xin chào,</h3>
                <p>Mã OTP để đặt lại mật khẩu tài khoản của bạn là: <b style='font-size: 20px; color: red;'>{otpCode}</b></p>
                <p>Mã này có hiệu lực trong <b>3 phút</b>. Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>
                <br/>
                <p>Trân trọng,<br/>FASHION STORE Team</p>";

            using (SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, SenderAppPassword)
            })
            {
                using (MailMessage message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }
        }

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string otpInput = txtOTP.Text.Trim();

            if (string.IsNullOrWhiteSpace(otpInput))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOTP.Focus();
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                // Lấy thông tin user từ DB theo email đã xác minh ở Bước 1
                var userObj = db.users.FirstOrDefault(u => u.email == targetEmail && u.status == "active");

                if (userObj == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 1. Kiểm tra OTP có bị trống hoặc đã hết hạn trong DB chưa
                if (userObj.password_reset_otp_expires_at == null || DateTime.Now > userObj.password_reset_otp_expires_at)
                {
                    MessageBox.Show("Mã OTP đã hết hạn! Vui lòng nhấn 'Gửi lại mã OTP'.", "Hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. So sánh mã OTP người dùng nhập với chuỗi Hash BCrypt trong DB
                if (string.IsNullOrEmpty(userObj.password_reset_otp_hash) ||
                    !BCrypt.Net.BCrypt.Verify(otpInput, userObj.password_reset_otp_hash))
                {
                    MessageBox.Show("Mã OTP không chính xác! Vui lòng kiểm tra lại.", "Lỗi xác minh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Xác minh OTP thành công! Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                ShowStep(3); // Chuyển sang Panel đặt mật khẩu mới
            }

        }

        private void foxLinkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();

            this.Close();
        }

        private void lnkResendOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(targetEmail))
            {
                ShowStep(1);
                return;
            }

            SendOtpProcess(); // Gửi lại OTP mới
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có độ dài tối thiểu 6 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var userObj = db.users.FirstOrDefault(u => u.email == targetEmail);

                if (userObj != null)
                {
                    // Mã hóa mật khẩu mới bằng thuật toán BCrypt
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPass);

                    // Cập nhật thông tin vào Database
                    userObj.password_hash = hashedPassword;
                    userObj.updated_at = DateTime.Now;

                    // LINQ to SQL: Lưu thay đổi
                    db.SubmitChanges();

                    MessageBox.Show("Đặt lại mật khẩu thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay lại màn hình đăng nhập
                    lnkBackToLogin_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
