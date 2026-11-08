using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmFogotPassword : Form
    {
        // ====== Cấu hình bảo mật ======
        private const int OtpValidMinutes = 3;
        private const int MaxOtpAttempts = 5;        // Sai quá 5 lần -> hủy OTP
        private const int ResendCooldownSeconds = 60; // Giãn cách giữa 2 lần gửi OTP
        private const int MinPasswordLength = 8;

        // ====== Cấu hình Email: KHÔNG hard-code mật khẩu trong code ======
        private const string SenderEmail = "Ktho.28122006@gmail.com";
        private const string SmtpPasswordEnvVar = "FASHION_SMTP_PASSWORD";

        // ====== Trạng thái tạm thời của quy trình ======
        private string targetEmail = "";
        private string verifiedOtp = "";     // OTP đã qua bước 2, dùng để verify lại ở bước 3
        private bool otpVerified = false;
        private DateTime lastSendTimeUtc = DateTime.MinValue;

        public frmFogotPassword()
        {
            InitializeComponent();
            ShowStep(1);
        }

        private void ShowStep(int step)
        {
            pnlEmail.Visible = (step == 1);
            pnlOTP.Visible = (step == 2);
            pnlNewPassword.Visible = (step == 3);
        }

        // ================= BƯỚC 1: NHẬP EMAIL =================
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string emailInput = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(emailInput))
            {
                MessageBox.Show("Vui lòng nhập Email đã đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            targetEmail = emailInput;
            otpVerified = false;
            verifiedOtp = "";

            SendOtpProcess();
        }

        private void SendOtpProcess()
        {
            // Chống spam: giới hạn tần suất gửi
            double secondsSinceLast = (DateTime.UtcNow - lastSendTimeUtc).TotalSeconds;
            if (secondsSinceLast < ResendCooldownSeconds)
            {
                int wait = (int)Math.Ceiling(ResendCooldownSeconds - secondsSinceLast);
                MessageBox.Show($"Vui lòng đợi {wait} giây trước khi yêu cầu mã mới.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lastSendTimeUtc = DateTime.UtcNow;

            try
            {
                string otp = null;

                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var userObj = db.users.FirstOrDefault(u => u.email == targetEmail && u.status == "active");
                    if (userObj != null)
                    {
                        otp = GenerateOtp();
                        userObj.password_reset_otp_hash = BCrypt.Net.BCrypt.HashPassword(otp);
                        userObj.password_reset_otp_expires_at = DateTime.UtcNow.AddMinutes(OtpValidMinutes);
                        userObj.password_reset_attempts = 0; // reset bộ đếm nhập sai
                        db.SubmitChanges();
                    }
                }

                // Chỉ gửi mail khi tài khoản tồn tại, nhưng thông báo cho người dùng luôn giống nhau
                if (otp != null)
                {
                    SendEmailSmtp(targetEmail, otp);
                    otp = null; // không giữ OTP thô trong bộ nhớ
                }

                MessageBox.Show("Mã OTP đã được gửi. Vui lòng kiểm tra hộp thư!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOTP.Text = "";
                ShowStep(2);
            }
            catch (Exception ex)
            {
                // TODO: ghi log ex ra file / hệ thống log, KHÔNG hiển thị chi tiết cho người dùng
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Không thể gửi email lúc này. Vui lòng thử lại sau.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sinh OTP 6 chữ số bằng bộ sinh số ngẫu nhiên an toàn mật mã
        private static string GenerateOtp()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[4];
                uint max = uint.MaxValue - (uint.MaxValue % 1000000); // tránh lệch phân phối
                uint value;
                do
                {
                    rng.GetBytes(bytes);
                    value = BitConverter.ToUInt32(bytes, 0);
                } while (value >= max);

                return (value % 1000000).ToString("D6");
            }
        }

        private void SendEmailSmtp(string toEmail, string otpCode)
        {
            // Đọc mật khẩu ứng dụng từ biến môi trường, không để trong source code
            string appPassword = Environment.GetEnvironmentVariable(SmtpPasswordEnvVar, EnvironmentVariableTarget.User)
                                 ?? Environment.GetEnvironmentVariable(SmtpPasswordEnvVar);

            if (string.IsNullOrEmpty(appPassword))
                throw new InvalidOperationException($"Chưa cấu hình biến môi trường {SmtpPasswordEnvVar}.");

            var fromAddress = new MailAddress(SenderEmail, "FASHION STORE");
            var toAddress = new MailAddress(toEmail);

            string subject = "[FASHION STORE] Mã xác minh đặt lại mật khẩu";
            string body = $@"
                <h3>Xin chào,</h3>
                <p>Mã OTP để đặt lại mật khẩu tài khoản của bạn là: <b style='font-size: 20px; color: red;'>{otpCode}</b></p>
                <p>Mã này có hiệu lực trong <b>{OtpValidMinutes} phút</b>. Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>
                <p>Nếu bạn không yêu cầu đặt lại mật khẩu, hãy bỏ qua email này.</p>
                <br/>
                <p>Trân trọng,<br/>FASHION STORE Team</p>";

            using (SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, appPassword)
            })
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

        // ================= BƯỚC 2: XÁC MINH OTP =================

        /// <summary>
        /// Kiểm tra OTP cho user. Có đếm số lần sai, tự hủy OTP khi vượt giới hạn.
        /// Dùng chung cho cả bước 2 và bước 3.
        /// </summary>
        private bool ValidateOtp(QLBanHangDataContext db, user userObj, string otpInput, out string error)
        {
            error = null;

            if (userObj == null
                || string.IsNullOrEmpty(userObj.password_reset_otp_hash)
                || userObj.password_reset_otp_expires_at == null)
            {
                error = "Mã OTP không hợp lệ. Vui lòng yêu cầu gửi lại mã.";
                return false;
            }

            if (DateTime.UtcNow > userObj.password_reset_otp_expires_at)
            {
                error = "Mã OTP đã hết hạn! Vui lòng nhấn 'Gửi lại mã OTP'.";
                return false;
            }

            if (userObj.password_reset_attempts >= MaxOtpAttempts)
            {
                userObj.password_reset_otp_hash = null;
                userObj.password_reset_otp_expires_at = null;
                db.SubmitChanges();
                error = "Bạn đã nhập sai quá nhiều lần. Vui lòng yêu cầu mã OTP mới.";
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(otpInput, userObj.password_reset_otp_hash))
            {
                userObj.password_reset_attempts++;
                int remaining = MaxOtpAttempts - userObj.password_reset_attempts;

                if (remaining <= 0)
                {
                    userObj.password_reset_otp_hash = null;
                    userObj.password_reset_otp_expires_at = null;
                    error = "Bạn đã nhập sai quá nhiều lần. Vui lòng yêu cầu mã OTP mới.";
                }
                else
                {
                    error = $"Mã OTP không chính xác! Bạn còn {remaining} lần thử.";
                }

                db.SubmitChanges();
                return false;
            }

            return true;
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

            if (string.IsNullOrEmpty(targetEmail))
            {
                ShowStep(1);
                return;
            }

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var userObj = db.users.FirstOrDefault(u => u.email == targetEmail && u.status == "active");

                if (!ValidateOtp(db, userObj, otpInput, out string error))
                {
                    MessageBox.Show(error, "Lỗi xác minh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            otpVerified = true;
            verifiedOtp = otpInput;

            MessageBox.Show("Xác minh OTP thành công! Vui lòng nhập mật khẩu mới.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            ShowStep(3);
        }

        private void lnkResendOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(targetEmail))
            {
                ShowStep(1);
                return;
            }

            otpVerified = false;
            verifiedOtp = "";
            SendOtpProcess();
        }

        private void lnkBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================= BƯỚC 3: ĐẶT MẬT KHẨU MỚI =================
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            // Chặn việc nhảy thẳng vào bước 3 mà chưa qua xác minh OTP
            if (!otpVerified || string.IsNullOrEmpty(targetEmail) || string.IsNullOrEmpty(verifiedOtp))
            {
                MessageBox.Show("Phiên xác minh không hợp lệ. Vui lòng thực hiện lại từ đầu.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowStep(1);
                return;
            }

            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (!IsStrongPassword(newPass, out string passError))
            {
                MessageBox.Show(passError, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
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
                // Chỉ cho phép tài khoản đang active, giống các bước trước
                var userObj = db.users.FirstOrDefault(u => u.email == targetEmail && u.status == "active");

                // Verify OTP lại một lần nữa ngay tại bước đổi mật khẩu
                if (!ValidateOtp(db, userObj, verifiedOtp, out string error))
                {
                    otpVerified = false;
                    verifiedOtp = "";
                    MessageBox.Show(error, "Lỗi xác minh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowStep(1);
                    return;
                }

                userObj.password_hash = BCrypt.Net.BCrypt.HashPassword(newPass);
                userObj.updated_at = DateTime.Now;

                // Vô hiệu hóa OTP ngay sau khi dùng (one-time)
                userObj.password_reset_otp_hash = null;
                userObj.password_reset_otp_expires_at = null;
                userObj.password_reset_attempts = 0;

                db.SubmitChanges();
            }

            // Xóa dữ liệu nhạy cảm trong bộ nhớ
            otpVerified = false;
            verifiedOtp = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";

            MessageBox.Show("Đặt lại mật khẩu thành công! Bạn có thể đăng nhập ngay bây giờ.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lnkBackToLogin_Click(sender, e);
        }

        private bool IsStrongPassword(string password, out string error)
        {
            error = null;

            if (password.Length < MinPasswordLength)
            {
                error = $"Mật khẩu phải có độ dài tối thiểu {MinPasswordLength} ký tự!";
                return false;
            }
            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                error = "Mật khẩu phải bao gồm cả chữ và số!";
                return false;
            }
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void foxLinkLabel1_Click(object sender, EventArgs e)
        {
        }
    }


}