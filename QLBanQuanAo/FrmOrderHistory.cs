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
    public partial class FrmOrderHistory : Form
    {
        public FrmOrderHistory()
        {
            InitializeComponent();
        }

        private void FrmOrderHistory_Load(object sender, EventArgs e)
        {
            TaiDanhSachDonHang();
        }

        private string HienThiTrangThai(string status)
        {
            switch (status)
            {
                case "pending": return "Chờ xác nhận";
                case "confirmed": return "Đã xác nhận";
                case "processing": return "Đang xử lý";
                case "shipping": return "Đang giao hàng";
                case "completed": return "Đã giao";
                case "cancelled": return "Đã hủy";
                default: return status;
            }
        }

        private void TaiDanhSachDonHang()
        {
            using (var db = new QLBanHangDataContext())
            {
                var donHangs = (from o in db.orders
                                where o.user_id == UserSession.CurrentUserId
                                orderby o.created_at descending
                                select o).ToList();

                var dsHienThi = (from o in donHangs
                                 select new
                                 {
                                     MaDonHang = o.id,
                                     NgayDat = o.created_at.ToString("dd/MM/yyyy HH:mm"),
                                     NguoiNhan = o.recipient_name,
                                     SoDienThoai = o.recipient_phone,
                                     DiaChiGiao = o.shipping_address,
                                     TongTien = string.Format("{0:N0} VNĐ", o.total_amount),
                                     TrangThai = HienThiTrangThai(o.status)
                                 }).ToList();

                dgvOrders.DataSource = dsHienThi;
                if (dsHienThi.Any())
                {
                    TaiChiTietDonHang(dsHienThi.First().MaDonHang);
                }
                else
                {
                    dgvOrderItems.DataSource = null;
                }
            }
        }

        private void TaiChiTietDonHang(int orderId)
        {
            using (var db = new QLBanHangDataContext())
            {
                var rawDetails = (from oi in db.order_items
                                  where oi.order_id == orderId
                                  select oi).ToList();

                var dsChiTiet = (from oi in rawDetails
                                 select new
                                 {
                                     MaSKU = oi.sku,
                                     TenSanPham = oi.product_name,
                                     MauSac = oi.color_name,
                                     KichCo = oi.size_name,
                                     SoLuong = oi.quantity,
                                     DonGia = string.Format("{0:N0} VNĐ", oi.unit_price),
                                     ThanhTien = string.Format("{0:N0} VNĐ", oi.line_total ?? (oi.quantity * oi.unit_price))
                                 }).ToList();

                dgvOrderItems.DataSource = dsChiTiet;
            }
        }

        
        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để hủy!", "Thông báo");
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["MaDonHang"].Value);

            using (var db = new QLBanHangDataContext())
            {
                var donHang = (from o in db.orders
                               where o.id == orderId && o.user_id == UserSession.CurrentUserId
                               select o).FirstOrDefault();
                if (donHang == null) return;

                if (donHang.status != "pending")
                {
                    MessageBox.Show("Chỉ cho phép hủy khi đơn hàng còn ở trạng thái 'Chờ xác nhận'!", "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng #" + orderId + " không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    donHang.status = "cancelled";
                    donHang.updated_at = DateTime.Now;

                    var danhSachHoanKho = (from oi in db.order_items
                                           join inv in db.inventories on oi.variant_id equals inv.variant_id
                                           where oi.order_id == orderId
                                           select new { OrderItem = oi, Inventory = inv }).ToList();
                    danhSachHoanKho.All(x =>
                    {
                        x.Inventory.stock_quantity += x.OrderItem.quantity;
                        x.Inventory.updated_at = DateTime.Now;
                        return true;
                    });
                    db.SubmitChanges();
                    MessageBox.Show("Đã hủy đơn hàng #" + orderId + " và hoàn lại tồn kho!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachDonHang();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để in hóa đơn!", "Thông báo");
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["MaDonHang"].Value);
            FrmInHoaDon frm = new FrmInHoaDon(orderId);
            frm.ShowDialog();
        }

        private void dgvOrders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.Cells["MaDonHang"].Value != null)
            {
                if (int.TryParse(dgvOrders.CurrentRow.Cells["MaDonHang"].Value.ToString(), out int orderId))
                {
                    TaiChiTietDonHang(orderId);
                }
            }
        }
    }
}