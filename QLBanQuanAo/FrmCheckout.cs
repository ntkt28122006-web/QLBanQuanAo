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
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.AddRange(new string[]
            {
                "Thanh toán khi nhận hàng (COD)",
                "Chuyển khoản ngân hàng"
            });
            cboPaymentMethod.SelectedIndex = 0;

            using (var db = new QLBanHangDataContext())
            {
                var diaChi = (from a in db.addresses
                              where a.user_id == UserSession.CurrentUserId && a.is_default == true
                              select a).FirstOrDefault();

                if (diaChi != null)
                {
                    txtReceiverName.Text = diaChi.recipient_name;
                    txtPhone.Text = diaChi.phone;
                    txtAddress.Text = diaChi.street + ", " + diaChi.ward + ", " + diaChi.district + ", " + diaChi.city;
                }

                var listThanhTien = (from ci in db.cart_items
                                     join c in db.carts on ci.cart_id equals c.id
                                     join v in db.product_variants on ci.variant_id equals v.id
                                     join p in db.products on v.product_id equals p.id
                                     where c.user_id == UserSession.CurrentUserId
                                     select (v.price_override ?? ((p.is_sale && p.sale_price.HasValue) ? p.sale_price.Value : p.price)) * ci.quantity).ToList();
                decimal tongTien = listThanhTien.Sum();
                lblFinalTotal.Text = string.Format("Tổng thanh toán: {0:N0} VNĐ", tongTien);
            }


        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReceiverName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên, Số điện thoại và Địa chỉ nhận hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QLBanHangDataContext())
            {
                var dsMua = (from ci in db.cart_items
                             join c in db.carts on ci.cart_id equals c.id
                             join v in db.product_variants on ci.variant_id equals v.id
                             join p in db.products on v.product_id equals p.id
                             join inv in db.inventories on v.product_id equals inv.variant_id
                             join col in db.product_colors on v.color_id equals col.id into gjC
                             from subCol in gjC.DefaultIfEmpty()
                             join sz in db.product_sizes on v.size_id equals sz.id into gjSz
                             from subSz in gjSz.DefaultIfEmpty()
                             where c.user_id == UserSession.CurrentUserId
                             select new
                             {
                                 CartItem = ci,
                                 Variant = v,
                                 Products = p,
                                 Inventory = inv,
                                 ColorName = subCol != null ? subCol.name : "Mặc định",
                                 SizeName = subSz != null ? subSz.name : "Free Size",
                                 DonGia = v.price_override ?? ((p.is_sale && p.sale_price.HasValue) ? p.sale_price.Value : p.price)
                             }).ToList();
                if (!dsMua.Any())
                {
                    MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                    return;
                }
                bool hetHang = dsMua.Any(item =>
                    (from inv in db.inventories where inv.variant_id == item.Variant.id select inv.stock_quantity).FirstOrDefault() < item.CartItem.quantity
                    );
                if (hetHang)
                {
                    MessageBox.Show("Có sản phẩm trong giỏ hàng không đủ số lượng tồn kho!", "Lỗi tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal subtotal = dsMua.Sum(x => x.DonGia * x.CartItem.quantity);

                order donHangMoi = new order
                {
                    user_id = UserSession.CurrentUserId,
                    recipient_name = txtReceiverName.Text.Trim(),
                    recipient_phone = txtPhone.Text.Trim(),
                    shipping_address = txtAddress.Text.Trim(),
                    subtotal = subtotal,
                    shipping_fee = 0,
                    discount_amount = 0,
                    total_amount = subtotal,
                    status = "pending",
                    payment_status = cboPaymentMethod.SelectedIndex == 0 ? "unpaid" : "paid",
                    note = cboPaymentMethod.SelectedItem.ToString(),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                db.orders.InsertOnSubmit(donHangMoi);
                db.SubmitChanges();

                db.order_items.InsertAllOnSubmit(
                    dsMua.Select(item => new order_item
                    {
                        order_id = donHangMoi.id,
                        variant_id = item.Variant.id,
                        product_name = item.Products.name,
                        sku = item.Variant.sku,
                        color_name = item.ColorName,
                        size_name = item.SizeName,
                        quantity = item.CartItem.quantity,
                        unit_price = item.DonGia
                    })
                );

                dsMua.All(item =>
                {
                    item.Inventory.stock_quantity -= item.CartItem.quantity;
                    item.Inventory.updated_at = DateTime.Now;
                    return true;
                });
                db.cart_items.DeleteAllOnSubmit(dsMua.Select(x => x.CartItem));
                db.SubmitChanges();

                MessageBox.Show("Đặt hàng thành công! Mã đơn hàng của bạn là #" + donHangMoi.id, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        } 
    }
}
