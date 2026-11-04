using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmMainAdmin : Form
    {
        // Biến lưu trữ form con hiện tại
        private Form activeForm;
        // Biến lưu trữ nút đang được chọn
        private Button currentButton;

        public frmMainAdmin()
        {
            InitializeComponent();
        }

        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            // Mở mặc định form Dashboard khi trang chủ tải lên
            btnDashboard.PerformClick();
        }

        #region Xử lý Giao Diện (Đổi màu nút đang chọn)
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton(); // Trả lại màu cũ cho nút vừa tắt

                    // Highlight nút mới
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(52, 73, 94); // Sáng hơn
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);

                    
                }
            }
        }

        private void DisableButton()
        {
            // Đặt lại trạng thái mặc định của nút khi không được chọn
            foreach (Control previousBtn in pnlSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button) && previousBtn.Name != "btnLogout")
                {
                    previousBtn.BackColor = Color.FromArgb(34, 36, 49); // Màu nền mặc định
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }
        }
        #endregion

        #region Xử lý Nhúng Form Con vào Panel (Không dùng MDI kiểu cũ)
        private void OpenChildForm(Form childForm, object btnSender)
        {
            // 1. Đóng form con đang mở (nếu có)
            if (activeForm != null)
            {
                activeForm.Close();
            }

            // 2. Kích hoạt hiệu ứng nút
            ActivateButton(btnSender);

            // 3. Khởi tạo form mới
            activeForm = childForm;
            childForm.TopLevel = false; // Bắt buộc: Xóa thuộc tính cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            childForm.Dock = DockStyle.Fill; // Lấp đầy pnlDesktop

            // 4. Nhúng vào pnlDesktop
            this.pnlDesktop.Controls.Add(childForm);
            this.pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region Xử lý Sự kiện Click vào Menu bên trái

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Mở frmAdminDashboard
            OpenChildForm(new frmAdminDashboard(), sender);
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            // Mở frmAdminOrder
            OpenChildForm(new frmAdminOrder(), sender);
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            // Mở frmAdminProduct
            OpenChildForm(new frmAdminProduct(), sender);
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            // Mở frmCategory
            OpenChildForm(new frmCategory(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                "Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                // Giả định form đăng nhập tên là frmLogin
                frmLogin fLogin = new frmLogin();
                fLogin.ShowDialog();
                this.Close();
            }
        }
        #endregion

        
        
        private void pnlDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OpenChildForm(Form childForm)
        {
            // Đóng form hiện tại nếu có
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            // Cấu hình nhúng Form con vào Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // Tự động co giãn 100% theo pnlDesktop

            // Xóa các control cũ và thêm Form mới vào pnlDesktop
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
    }
}