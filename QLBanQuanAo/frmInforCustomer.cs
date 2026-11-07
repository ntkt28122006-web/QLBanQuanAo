using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmInforCustomer : Form
    {
        private int currentUserId;
        private bool isLoading;

        public frmInforCustomer()
        {
            InitializeComponent();
            currentUserId = UserSession.CurrentUserId;
        }

        private void frmInforCustomer_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn || currentUserId <= 0)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            LoadCustomerInformation();
        }

        private void LoadCustomerInformation()
        {
            isLoading = true;
            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var customer = db.users.SingleOrDefault(u => u.id == currentUserId);
                    if (customer == null || customer.status != "active")
                    {
                        MessageBox.Show("Không tìm thấy tài khoản hoặc tài khoản không còn hoạt động.",
                            "Không thể mở hồ sơ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                        return;
                    }

                    txtCustomerId.Text = customer.id.ToString();
                    txtFullName.Text = customer.full_name ?? string.Empty;
                    txtEmail.Text = customer.email ?? string.Empty;
                    txtPhone.Text = customer.phone ?? string.Empty;
                    lblCreatedAtValue.Text = customer.created_at.ToString("dd/MM/yyyy");
                    lblStatusValue.Text = GetStatusText(customer.status);
                    lblEmailStatusValue.Text = customer.email_verified ? "Đã xác minh" : "Chưa xác minh";

                    var defaultAddress = db.addresses
                        .Where(a => a.user_id == currentUserId && a.is_default)
                        .OrderByDescending(a => a.created_at)
                        .FirstOrDefault();

                    if (defaultAddress != null)
                    {
                        txtRecipientName.Text = defaultAddress.recipient_name ?? string.Empty;
                        txtAddressPhone.Text = defaultAddress.phone ?? string.Empty;
                        txtStreet.Text = defaultAddress.street ?? string.Empty;
                        txtWard.Text = defaultAddress.ward ?? string.Empty;
                        txtDistrict.Text = defaultAddress.district ?? string.Empty;
                        txtCity.Text = defaultAddress.city ?? string.Empty;
                        txtPostalCode.Text = defaultAddress.postal_code ?? string.Empty;
                    }
                    else
                    {
                        txtRecipientName.Text = customer.full_name ?? string.Empty;
                        txtAddressPhone.Text = customer.phone ?? string.Empty;
                        txtStreet.Clear();
                        txtWard.Clear();
                        txtDistrict.Clear();
                        txtCity.Clear();
                        txtPostalCode.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải thông tin hồ sơ.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "active": return "Đang hoạt động";
                case "inactive": return "Ngừng hoạt động";
                case "banned": return "Đã khóa";
                default: return "Không xác định";
            }
        }

        private bool ValidateProfile()
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (fullName.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ và tên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (fullName.Length > 100)
            {
                MessageBox.Show("Họ và tên không được vượt quá 100 ký tự.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (email.Length == 0 || email.Length > 254)
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ (tối đa 254 ký tự).", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            try
            {
                var address = new MailAddress(email);
                if (!string.Equals(address.Address, email, StringComparison.OrdinalIgnoreCase))
                    throw new FormatException();
            }
            catch
            {
                MessageBox.Show("Địa chỉ email không đúng định dạng.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (phone.Length > 20 || (phone.Length > 0 && !Regex.IsMatch(phone, @"^[0-9+() .-]{8,20}$")))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số và các ký tự + ( ) . -, tối đa 20 ký tự.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            bool hasAddressInput = !string.IsNullOrWhiteSpace(txtStreet.Text)
                || !string.IsNullOrWhiteSpace(txtWard.Text)
                || !string.IsNullOrWhiteSpace(txtDistrict.Text)
                || !string.IsNullOrWhiteSpace(txtCity.Text)
                || !string.IsNullOrWhiteSpace(txtPostalCode.Text);

            if (hasAddressInput)
            {
                if (string.IsNullOrWhiteSpace(txtRecipientName.Text) || txtRecipientName.Text.Trim().Length > 100)
                {
                    MessageBox.Show("Vui lòng nhập tên người nhận (tối đa 100 ký tự).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecipientName.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtAddressPhone.Text) || txtAddressPhone.Text.Trim().Length > 20
                    || !Regex.IsMatch(txtAddressPhone.Text.Trim(), @"^[0-9+() .-]{8,20}$"))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại người nhận hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddressPhone.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtStreet.Text) || txtStreet.Text.Trim().Length > 200)
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ đường/số nhà (tối đa 200 ký tự).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStreet.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtCity.Text) || txtCity.Text.Trim().Length > 100)
                {
                    MessageBox.Show("Vui lòng nhập tỉnh/thành phố (tối đa 100 ký tự).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCity.Focus();
                    return false;
                }

                if (txtWard.Text.Trim().Length > 100 || txtDistrict.Text.Trim().Length > 100 || txtPostalCode.Text.Trim().Length > 20)
                {
                    MessageBox.Show("Phường/xã, quận/huyện hoặc mã bưu chính vượt quá độ dài cho phép.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isLoading || !ValidateProfile()) return;

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            bool hasAddressInput = !string.IsNullOrWhiteSpace(txtStreet.Text)
                || !string.IsNullOrWhiteSpace(txtWard.Text)
                || !string.IsNullOrWhiteSpace(txtDistrict.Text)
                || !string.IsNullOrWhiteSpace(txtCity.Text)
                || !string.IsNullOrWhiteSpace(txtPostalCode.Text);

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn lưu các thay đổi trong hồ sơ không?",
                "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    if (db.Connection.State != System.Data.ConnectionState.Open)
                        db.Connection.Open();

                    using (var transaction = db.Connection.BeginTransaction())
                    {
                        db.Transaction = transaction;
                        try
                        {
                            var customer = db.users.SingleOrDefault(u => u.id == currentUserId && u.status == "active");
                            if (customer == null)
                                throw new InvalidOperationException("Tài khoản không tồn tại hoặc đã bị vô hiệu hóa.");

                            bool emailChanged = !string.Equals(customer.email, email, StringComparison.OrdinalIgnoreCase);
                            bool emailExists = db.users.Any(u => u.id != currentUserId && u.email == email);
                            if (emailExists)
                                throw new InvalidOperationException("Email này đã được sử dụng bởi tài khoản khác.");

                            customer.full_name = fullName;
                            customer.email = email;
                            customer.phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
                            customer.updated_at = DateTime.Now;

                            // Email thay đổi thì phải xác minh lại, không giữ trạng thái xác minh của email cũ.
                            if (emailChanged)
                            {
                                customer.email_verified = false;
                                customer.email_verified_at = null;
                                customer.email_verification_otp_hash = null;
                                customer.email_verification_otp_expires_at = null;
                            }

                            if (hasAddressInput)
                            {
                                var defaultAddresses = db.addresses
                                    .Where(a => a.user_id == currentUserId && a.is_default)
                                    .OrderByDescending(a => a.created_at)
                                    .ToList();

                                address targetAddress = defaultAddresses.FirstOrDefault();
                                foreach (var oldDefault in defaultAddresses)
                                    oldDefault.is_default = false;

                                if (targetAddress == null)
                                {
                                    targetAddress = new address
                                    {
                                        user_id = currentUserId,
                                        created_at = DateTime.Now
                                    };
                                    db.addresses.InsertOnSubmit(targetAddress);
                                }

                                targetAddress.recipient_name = txtRecipientName.Text.Trim();
                                targetAddress.phone = txtAddressPhone.Text.Trim();
                                targetAddress.street = txtStreet.Text.Trim();
                                targetAddress.ward = string.IsNullOrWhiteSpace(txtWard.Text) ? null : txtWard.Text.Trim();
                                targetAddress.district = string.IsNullOrWhiteSpace(txtDistrict.Text) ? null : txtDistrict.Text.Trim();
                                targetAddress.city = txtCity.Text.Trim();
                                targetAddress.postal_code = string.IsNullOrWhiteSpace(txtPostalCode.Text) ? null : txtPostalCode.Text.Trim();
                                targetAddress.is_default = true;
                            }

                            db.SubmitChanges();
                            transaction.Commit();
                            UserSession.SetCurrentUser(customer);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                        finally
                        {
                            db.Transaction = null;
                        }
                    }
                }

                MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật hồ sơ.\nChi tiết: " + ex.Message,
                    "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadCustomerInformation();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
