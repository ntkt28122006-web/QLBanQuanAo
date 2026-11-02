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
    public partial class FrmCart : Form
    {
        public FrmCart()
        {
            InitializeComponent();
        }

        private void FrmCart_Load(object sender, EventArgs e)
        {
            TaiGioHang();
        }
        private void TaiGioHang()
        {
            using (var db = new QLBanHangDataContext())
            {
                var dsGioHang = ( from ds in db.cart_items
                                join c in db.carts on ds.cart_id equals c.id
                                join v in db.product_variants on ds.variant_id equals v.id
                                join p in db.products on v.product_id equals p.id
                                join col in db.product_colors on v.product_id equals col.id into gjCol
                                from subCol in gjCol.DefaultIfEmpty()
                                join s in db.product_sizes on v.product.id equals s.id into gjSz
                                from subSz in gjSz.DefaultIfEmpty()
                                where c.user_id == UserSession.CurrentUserId
                                select new
                                {
                                    MaGioHang = ds.id,
                                    MaSKU = v.sku,
                                    TenSanPham = p.name,
                                    MauSac = subCol != null ? subCol.name : "Mặc định",
                                    KichCo = subSz != null ? subSz.name : "Free size",
                                    DonGia = v.price_override ?? ((p.is_sale && p.sale_price.HasValue) ? p.sale_price.Value : p.price),
                                    SoLuong = ds.quantity,
                                    ThanhTien = (v.price_override ?? ((p.is_sale && p.sale_price.HasValue) ? p.sale_price.Value : p.price)) * ds.quantity
                                }).ToList();
                dgvCart.DataSource = dsGioHang;
                decimal tongTien = dsGioHang.Sum(x => x.ThanhTien);
                lblTotalAmount.Text = string.Format("Tổng tiền: {0:N0} VNĐ", tongTien);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            using (var db = new QLBanHangDataContext())
            {
                bool coHang = (from ds in db.cart_items
                               join c in db.carts on ds.cart_id equals c.id
                               where c.user_id == UserSession.CurrentUserId
                               select ds.id).Any();
                if (!coHang)
                {
                    MessageBox.Show("Giỏ hàng của bạn đang trốn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            frmCheckout frm = new frmCheckout();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                TaiGioHang();
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            int cartItemId = Convert.ToInt32(dgvCart.CurrentRow.Cells["MaGioHang"].Value);

            using (var db = new QLBanHangDataContext())
            {
                var item = (from ds in db.cart_items where ds.id == cartItemId select ds).FirstOrDefault();
                if (item != null)
                {
                    var tonKho = (from inv in db.inventories where inv.variant_id == item.variant_id select inv).FirstOrDefault();
                    int maxStock = tonKho != null ? tonKho.stock_quantity : 0;

                    if (item.quantity < maxStock)
                    {
                        item.quantity++;
                        db.SubmitChanges();
                        TaiGioHang();
                    }
                    else
                    {
                        MessageBox.Show("Số lượng đã đạt tối đa tồn kho!", "Thông báo");
                    }
                }
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            int cartItemId = Convert.ToInt32(dgvCart.CurrentRow.Cells["MaGioHang"].Value);

            using (var db = new QLBanHangDataContext())
            {
                var item = (from ds in db.cart_items where ds.id == cartItemId select ds).FirstOrDefault();
                if (item != null)
                {
                    if (item.quantity > 1)
                    {
                        item.quantity--;
                    }
                    else
                    {
                        db.cart_items.DeleteOnSubmit(item);
                    }
                    db.SubmitChanges();
                    TaiGioHang();
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            int cartItemId = Convert.ToInt32(dgvCart.CurrentRow.Cells["MaGioHang"].Value);
            
            using (var db = new QLBanHangDataContext())
            {
                var item = (from ds in db.cart_items where ds.id == cartItemId select ds).FirstOrDefault();
                if (item != null)
                {
                    db.cart_items.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    TaiGioHang();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
