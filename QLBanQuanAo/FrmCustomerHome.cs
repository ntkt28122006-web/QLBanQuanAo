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
    public partial class FrmCustomerHome : Form
    {
        private user CurrentUser;
        private bool isLoaded = false;
        private string currentTab = "ALL";
        private Timer hoverTimer;

        public FrmCustomerHome(user u)
        {
            InitializeComponent();
            this.CurrentUser = u;
            if (u != null)
            {
                UserSession.IsLoggedIn = true;
                UserSession.CurrentUserId = u.id;
                UserSession.CurrentUserName = u.full_name;
            }
            
            hoverTimer = new Timer();
            hoverTimer.Interval = 250;
            hoverTimer.Tick += (s, ev) =>
            {
                Point pt = this.PointToClient(Cursor.Position);
                if (!btnUser.Bounds.Contains(pt) && !btnLogout.Bounds.Contains(pt))
                {
                    btnLogout.Visible = false;
                    hoverTimer.Stop();
                }
            };
            btnUser.MouseEnter += (s, ev) =>
            {
                if (UserSession.IsLoggedIn)
                {
                    btnLogout.Visible = true;
                    btnLogout.BringToFront();
                    hoverTimer.Stop();
                }
            };
            btnUser.MouseLeave += (s, ev) => { if (UserSession.IsLoggedIn) hoverTimer.Start(); };
            btnLogout.MouseEnter += (s, ev) => { hoverTimer.Stop(); };
            btnLogout.MouseLeave += (s, ev) => { hoverTimer.Start(); };

        }

        private void FrmCustomerHome_Load(object sender, EventArgs e)
        {
            isLoaded = false;
            using (var db = new QLBanHangDataContext())
            {
                var listDanhMuc = (from c in db.categories
                                   where c.is_active == true
                                   select c.name).Distinct().ToArray();

                cboCategory.Items.Clear();
                cboCategory.Items.Add("Tất cả");
                cboCategory.Items.AddRange(listDanhMuc);
                cboCategory.SelectedIndex = 0;

                var listSize = (from s in db.product_sizes
                                orderby s.sort_order
                                select s.name).ToArray();
                cboSize.Items.Clear();
                cboSize.Items.Add("Tất cả");
                cboSize.Items.AddRange(listSize);
                cboSize.SelectedIndex = 0;

                var listMauSac = (from col in db.product_colors
                                  select col.name).Distinct().ToArray();

                cboColor.Items.Clear();
                cboColor.Items.Add("Tất cả");
                cboColor.Items.AddRange(listMauSac);
                cboColor.SelectedIndex = 0;

                cboPrice.Items.Clear();
                cboPrice.Items.AddRange(new string[]
                {
                "Tất cả",
                "Dưới 500.000đ",
                "Từ 500.000đ - 1.000.000đ",
                "Trên 1.000.000đ",
                });
                cboPrice.SelectedIndex = 0;

                cboSort.Items.Clear();
                cboSort.Items.AddRange(new string[]
                {
                "Mặc định",
                "Giá: Tăng dần",
                "Giá: Giảm dần",

                });
                cboSort.SelectedIndex = 0;
            }

            isLoaded = true;
            CapNhatHeader();
            DoiMauNutTab();
            LocVaHienThiSanPham();


        }
        private void CapNhatHeader()
        {
            btnUser.Visible = true;
            btnLogout.Visible = false;
            if (UserSession.IsLoggedIn)
            {
                btnUser.Text = "👤 " + UserSession.CurrentUserName;
                if (lblWelcome != null) lblWelcome.Text = "Xin chào, " + UserSession.CurrentUserName;
                btnLogout.Visible = false;
                using (var db = new QLBanHangDataContext())
                {
                    int tongSL = (from sl in db.cart_items
                                  join c in db.carts on sl.cart_id equals c.id
                                  where c.user_id == UserSession.CurrentUserId
                                  select (int?)sl.quantity).Sum() ?? 0;
                    btnCart.Text = "🛒 Giỏ hàng (" + tongSL + ")";
                }
            }
            else
            {
                btnUser.Text = "👤 Đăng nhập";
                if (lblWelcome != null) lblWelcome.Text = "";
                btnLogout.Visible = false;
                btnCart.Text = "🛒 Giỏ hàng";
            }
        }

        private void pnlSub_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LocVaHienThiSanPham();
        }

        private void pnlSubHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {

        }
        private void LocVaHienThiSanPham()
        {
            string tuKhoa = txtSearch.Text.Trim().ToLower();
            string danhMuc = cboCategory.SelectedItem != null ? cboCategory.SelectedItem.ToString() : "Tất cả";
            string kichCo = cboSize.SelectedItem != null ? cboSize.SelectedItem.ToString() : "Tất cả";
            string mauSac = cboColor.SelectedItem != null ? cboColor.SelectedItem.ToString() : "Tất cả";
            int mucGia = cboPrice.SelectedIndex;
            int sapXep = cboSort.SelectedIndex;

            using (var db = new QLBanHangDataContext())
            {
                var ketquaLinQ = from sp in db.products
                                 join cat in db.categories on sp.category_id equals cat.id into gjCat
                                 from subCat in gjCat.DefaultIfEmpty()
                                 where (sp.status == "active" || sp.status == "out_of_stock")
                                 && (tuKhoa == "" || sp.name.ToLower().Contains(tuKhoa))
                                 && (cboCategory.SelectedIndex <= 0 || (subCat != null && subCat.name == danhMuc))
                                 && (cboSize.SelectedIndex <= 0 || (from v in db.product_variants
                                                                    join s in db.product_sizes on v.size_id equals s.id
                                                                    where v.product_id == sp.id && s.name == kichCo
                                                                    select v.id).Any())
                                 && (cboColor.SelectedIndex <= 0 || (from v in db.product_variants
                                                                     join s in db.product_colors on v.color_id equals s.id
                                                                     where v.product_id == sp.id && s.name == mauSac
                                                                     select v.id).Any())
                                 && (mucGia <= 0
                                        || (mucGia == 1 && (sp.sale_price ?? sp.price) < 500000)
                                        || (mucGia == 2 && (sp.sale_price ?? sp.price) >= 500000 && (sp.sale_price ?? sp.price) <= 1000000)
                                        || (mucGia == 3 && (sp.sale_price ?? sp.price) > 1000000))
                                 && (currentTab == "ALL"
                                        || (currentTab == "HOT" && sp.is_hot == true)
                                        || (currentTab == "SALE" && sp.is_sale == true))
                                 select sp;


                if (sapXep == 1)
                    ketquaLinQ = ketquaLinQ.OrderBy(sp => sp.sale_price ?? sp.price);
                else if (sapXep == 2)
                    ketquaLinQ = ketquaLinQ.OrderByDescending(Sp => Sp.sale_price ?? Sp.price);

                List<product> danhSachHienThi = ketquaLinQ.ToList();
                flowProducts.SuspendLayout();
                flowProducts.Controls.Clear();

                var cardControls = danhSachHienThi.Select(sp =>
                {
                    ucProductCard card = new ucProductCard();
                    card.SetData(sp);
                    card.Margin = new Padding(10);
                    return card;
                }).ToArray();

                flowProducts.Controls.AddRange(cardControls);
                flowProducts.ResumeLayout();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void cboPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) LocVaHienThiSanPham();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isLoaded = false;
            txtSearch.Clear();
            cboCategory.SelectedIndex = 0;
            cboSize.SelectedIndex = 0;
            cboColor.SelectedIndex = 0;
            cboPrice.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            currentTab = "ALL";
            DoiMauNutTab();

            isLoaded = true;
            LocVaHienThiSanPham();
        }
        private void DoiMauNutTab()
        {
            Color mauCam = Color.FromArgb(238, 77, 45);
            btnTabAll.BackColor = (currentTab == "ALL") ? mauCam : Color.White;
            btnTabAll.ForeColor = (currentTab == "ALL") ? mauCam : Color.Black;


            btnTabHot.BackColor = (currentTab == "HOT") ? mauCam : Color.White;
            btnTabHot.ForeColor = (currentTab == "HOT") ? mauCam : Color.Black;


            btnTabSale.BackColor = (currentTab == "SALE") ? mauCam : Color.White;
            btnTabSale.ForeColor = (currentTab == "SALE") ? mauCam : Color.Black;

        }

        private void btnTabSale_Click(object sender, EventArgs e)
        {
            currentTab = "SALE";
            DoiMauNutTab();
            LocVaHienThiSanPham();
        }

        private void btnTabHot_Click(object sender, EventArgs e)
        {
            currentTab = "HOT";
            DoiMauNutTab();
            LocVaHienThiSanPham();
        }

        private void btnTabAll_Click(object sender, EventArgs e)
        {
            currentTab = "ALL";
            DoiMauNutTab();
            LocVaHienThiSanPham();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuyển sang Form Giỏ hàng (FrmCart)!", "Thông báo");
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuyển sang Form Lịch sử đơn hàng (FrmOrderHistory)!", "Thông báo");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCustomerProfile_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();

                bool daMoFormMoi = Application.OpenForms.Cast<Form>()
                            .Any(f => f != this && (f is FrmCustomerHome || f is frmMainAdmin) && f.Visible);
                
                if (!daMoFormMoi)
                {
                    CapNhatHeader();
                    LocVaHienThiSanPham();
                    this.Show();
                }
            }

            // Cập nhật tên hiển thị sau khi khách hàng sửa hồ sơ.
            CapNhatHeader();
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn) return;

            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                UserSession.IsLoggedIn = false;
                UserSession.CurrentUserId = 0;
                UserSession.CurrentUserName = "";
                this.CurrentUser = null;
                CapNhatHeader();
            }
        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem Lịch sử đơn hàng!", "Thông báo");
                return;
            }
            FrmOrderHistory frm = new FrmOrderHistory();
            frm.ShowDialog();
        }

        private void btnCart_Click_1(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem Giỏ hàng!", "Thông báo");
                return;
            }
            FrmCart frm = new FrmCart();
            frm.ShowDialog();
            CapNhatHeader();
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBanner_Click(object sender, EventArgs e)
        {

        }
    }
}
