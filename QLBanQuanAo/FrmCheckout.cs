using System;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.AddRange(new string[]
            {
                "Thanh toán khi nhận hàng (COD)",
                "Chuyển khoản ngân hàng"
            });
            cboPaymentMethod.SelectedIndex = 0;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    int userId = UserSession.CurrentUserId;
                    var diaChi = (from address in db.addresses
                                  where address.user_id == userId && address.is_default
                                  select address).FirstOrDefault();

                    if (diaChi != null)
                    {
                        txtReceiverName.Text = diaChi.recipient_name ?? "";
                        txtPhone.Text = diaChi.phone ?? "";
                        txtAddress.Text = string.Join(", ", new[]
                        {
                            diaChi.street,
                            diaChi.ward,
                            diaChi.district,
                            diaChi.city
                        }.Where(part => !string.IsNullOrWhiteSpace(part)));
                    }

                    var listThanhTien = (from item in db.cart_items
                                         join cart in db.carts on item.cart_id equals cart.id
                                         join variant in db.product_variants on item.variant_id equals variant.id
                                         join product in db.products on variant.product_id equals product.id
                                         where cart.user_id == userId
                                         select (variant.price_override ??
                                             ((product.is_sale && product.sale_price.HasValue)
                                                 ? product.sale_price.Value
                                                 : product.price)) * item.quantity).ToList();

                    decimal tongTien = listThanhTien.Sum();
                    lblFinalTotal.Text = string.Format("Tổng thanh toán: {0:N0} VNĐ", tongTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin thanh toán.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnOrder.Enabled = false;
            }
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
            DialogResult = DialogResult.Cancel;
            Close();
            return false;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!KiemTraPhienDangNhap()) return;

            if (string.IsNullOrWhiteSpace(txtReceiverName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ họ tên, số điện thoại và địa chỉ nhận hàng!",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cboPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentUserId = UserSession.CurrentUserId;
            btnOrder.Enabled = false;

            try
            {
                int newOrderId;

                using (var db = new QLBanHangDataContext())
                {
                    db.Connection.Open();
                    using (var transaction = db.Connection.BeginTransaction())
                    {
                        db.Transaction = transaction;

                        try
                        {
                            var dsMua = (from cartItem in db.cart_items
                                         join cart in db.carts on cartItem.cart_id equals cart.id
                                         join variant in db.product_variants on cartItem.variant_id equals variant.id
                                         join product in db.products on variant.product_id equals product.id
                                         join color in db.product_colors on variant.color_id equals (int?)color.id into colorJoin
                                         from subColor in colorJoin.DefaultIfEmpty()
                                         join size in db.product_sizes on variant.size_id equals (int?)size.id into sizeJoin
                                         from subSize in sizeJoin.DefaultIfEmpty()
                                         join inventory in db.inventories on variant.id equals inventory.variant_id into inventoryJoin
                                         from subInventory in inventoryJoin.DefaultIfEmpty()
                                         where cart.user_id == currentUserId
                                         select new
                                         {
                                             CartItem = cartItem,
                                             Variant = variant,
                                             Product = product,
                                             Inventory = subInventory,
                                             ColorName = subColor != null ? subColor.name : "Mặc định",
                                             SizeName = subSize != null ? subSize.name : "Free Size",
                                             DonGia = variant.price_override ??
                                                 ((product.is_sale && product.sale_price.HasValue)
                                                     ? product.sale_price.Value
                                                     : product.price)
                                         }).ToList();

                            if (!dsMua.Any())
                            {
                                transaction.Rollback();
                                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            var dongLoi = dsMua.FirstOrDefault(item =>
                                item.Inventory == null ||
                                !item.Variant.is_active ||
                                item.Inventory.stock_quantity < item.CartItem.quantity);

                            if (dongLoi != null)
                            {
                                transaction.Rollback();
                                string thongBao = dongLoi.Inventory == null
                                    ? "Biến thể SKU " + dongLoi.Variant.sku + " chưa có bản ghi tồn kho."
                                    : (!dongLoi.Variant.is_active
                                        ? "Biến thể SKU " + dongLoi.Variant.sku + " đã ngừng kinh doanh."
                                        : "Biến thể SKU " + dongLoi.Variant.sku + " không đủ số lượng tồn kho.");

                                MessageBox.Show(
                                    thongBao + " Vui lòng quay lại giỏ hàng để kiểm tra.",
                                    "Không thể đặt hàng",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            decimal subtotal = dsMua.Sum(item => item.DonGia * item.CartItem.quantity);
                            DateTime now = DateTime.Now;

                            order donHangMoi = new order
                            {
                                user_id = currentUserId,
                                recipient_name = txtReceiverName.Text.Trim(),
                                recipient_phone = txtPhone.Text.Trim(),
                                shipping_address = txtAddress.Text.Trim(),
                                subtotal = subtotal,
                                shipping_fee = 0,
                                discount_amount = 0,
                                total_amount = subtotal,
                                status = "pending",
                                // Chuyen khoan chua duoc doi soat nen khong the tu dong ghi nhan da thanh toan.
                                payment_status = cboPaymentMethod.SelectedIndex == 0 ? "unpaid" : "pending",
                                note = cboPaymentMethod.SelectedItem.ToString(),
                                created_at = now,
                                updated_at = now
                            };

                            db.orders.InsertOnSubmit(donHangMoi);
                            db.SubmitChanges();
                            newOrderId = donHangMoi.id;

                            db.order_items.InsertAllOnSubmit(
                                dsMua.Select(item => new order_item
                                {
                                    order_id = newOrderId,
                                    variant_id = item.Variant.id,
                                    product_name = item.Product.name,
                                    sku = item.Variant.sku,
                                    color_name = item.ColorName,
                                    size_name = item.SizeName,
                                    quantity = item.CartItem.quantity,
                                    unit_price = item.DonGia
                                }));

                            foreach (var item in dsMua)
                            {
                                item.Inventory.stock_quantity -= item.CartItem.quantity;
                                item.Inventory.updated_at = now;
                                db.cart_items.DeleteOnSubmit(item.CartItem);
                            }

                            db.SubmitChanges();
                            transaction.Commit();
                        }
                        catch
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch
                            {
                                // Bo qua loi rollback thu cap de giu lai loi goc.
                            }
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Đặt hàng thành công! Mã đơn hàng của bạn là #" + newOrderId,
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hoàn tất đơn hàng. Giao dịch đã được hủy để tránh sai lệch dữ liệu.\nChi tiết: " + ex.Message,
                    "Lỗi đặt hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                    btnOrder.Enabled = true;
            }
        }

        private void txtReceiverName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy thanh toán không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close(); 
            }
        }

        private void lblFinalTotal_Click(object sender, EventArgs e)
        {
        }
    }
}
