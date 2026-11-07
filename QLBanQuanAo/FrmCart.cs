using System;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class FrmCart : Form
    {
        public FrmCart()
        {
            InitializeComponent();
        }

        private void FrmCart_Load(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;
            TaiGioHang();
        }

        private bool KiemTraPhienDangNhap()
        {
            if (UserSession.IsLoggedIn && UserSession.CurrentUserId > 0)
                return true;

            MessageBox.Show(
                "Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            Close();
            return false;
        }

        private int? LayMaGioHangDangChon()
        {
            if (dgvCart.CurrentRow == null || !dgvCart.Columns.Contains("MaGioHang"))
                return null;

            object value = dgvCart.CurrentRow.Cells["MaGioHang"].Value;
            int id;
            return value != null && int.TryParse(value.ToString(), out id)
                ? (int?)id
                : null;
        }

        private cart_item LayCartItemCuaNguoiDung(QLBanHangDataContext db, int cartItemId)
        {
            int userId = UserSession.CurrentUserId;
            return (from item in db.cart_items
                    join cart in db.carts on item.cart_id equals cart.id
                    where item.id == cartItemId && cart.user_id == userId
                    select item).SingleOrDefault();
        }

        private void TaiGioHang()
        {
            if (!KiemTraPhienDangNhap()) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    int userId = UserSession.CurrentUserId;
                    var dsGioHang = (from item in db.cart_items
                                     join cart in db.carts on item.cart_id equals cart.id
                                     join variant in db.product_variants on item.variant_id equals variant.id
                                     join product in db.products on variant.product_id equals product.id
                                     join color in db.product_colors on variant.color_id equals (int?)color.id into colorJoin
                                     from subColor in colorJoin.DefaultIfEmpty()
                                     join size in db.product_sizes on variant.size_id equals (int?)size.id into sizeJoin
                                     from subSize in sizeJoin.DefaultIfEmpty()
                                     where cart.user_id == userId
                                     select new
                                     {
                                         MaGioHang = item.id,
                                         MaSKU = variant.sku,
                                         TenSanPham = product.name,
                                         MauSac = subColor != null ? subColor.name : "Mặc định",
                                         KichCo = subSize != null ? subSize.name : "Free size",
                                         DonGia = variant.price_override ??
                                             ((product.is_sale && product.sale_price.HasValue)
                                                 ? product.sale_price.Value
                                                 : product.price),
                                         SoLuong = item.quantity,
                                         ThanhTien = (variant.price_override ??
                                             ((product.is_sale && product.sale_price.HasValue)
                                                 ? product.sale_price.Value
                                                 : product.price)) * item.quantity
                                     }).ToList();

                    dgvCart.DataSource = dsGioHang;
                    decimal tongTien = dsGioHang.Sum(x => x.ThanhTien);
                    lblTotalAmount.Text = string.Format("Tổng tiền: {0:N0} VNĐ", tongTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải giỏ hàng.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    int userId = UserSession.CurrentUserId;
                    bool coHang = (from item in db.cart_items
                                   join cart in db.carts on item.cart_id equals cart.id
                                   where cart.user_id == userId
                                   select item.id).Any();

                    if (!coHang)
                    {
                        MessageBox.Show(
                            "Giỏ hàng của bạn đang trống!",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (frmCheckout frm = new frmCheckout())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        Close();
                    else
                        TaiGioHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở màn hình thanh toán.\nChi tiết: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            int? selectedId = LayMaGioHangDangChon();
            if (!selectedId.HasValue) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var item = LayCartItemCuaNguoiDung(db, selectedId.Value);
                    if (item == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm trong giỏ hàng hiện tại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiGioHang();
                        return;
                    }

                    var tonKho = db.inventories.SingleOrDefault(inv => inv.variant_id == item.variant_id);
                    if (tonKho == null)
                    {
                        MessageBox.Show("Biến thể này chưa có thông tin tồn kho.", "Lỗi tồn kho",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (item.quantity >= tonKho.stock_quantity)
                    {
                        MessageBox.Show("Số lượng đã đạt tối đa tồn kho!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    item.quantity++;
                    db.SubmitChanges();
                }

                TaiGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tăng số lượng.\nChi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            int? selectedId = LayMaGioHangDangChon();
            if (!selectedId.HasValue) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var item = LayCartItemCuaNguoiDung(db, selectedId.Value);
                    if (item == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm trong giỏ hàng hiện tại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiGioHang();
                        return;
                    }

                    if (item.quantity > 1)
                        item.quantity--;
                    else
                        db.cart_items.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                TaiGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể giảm số lượng.\nChi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            int? selectedId = LayMaGioHangDangChon();
            if (!selectedId.HasValue) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var item = LayCartItemCuaNguoiDung(db, selectedId.Value);
                    if (item == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm trong giỏ hàng hiện tại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiGioHang();
                        return;
                    }

                    db.cart_items.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }

                TaiGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa sản phẩm khỏi giỏ hàng.\nChi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {
        }
    }
}
