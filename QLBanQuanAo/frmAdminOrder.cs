using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class frmAdminOrder : Form
    {
        public frmAdminOrder()
        {
            InitializeComponent();
        }

        private void frmAdminOrder_Load(object sender, EventArgs e)
        {
            if (dtpFromDate != null && dtpToDate != null)
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-30);
                dtpToDate.Value = DateTime.Now;
            }

            loadFilterStatusComboBox();
            loadFilterPaymentStatusComboBox();
            loadOrdersData();
        }

        private void loadFilterStatusComboBox()
        {
            var filterList = new[]
            {
                new { Value = "all", Text = "-- Tất cả trạng thái --" },
                new { Value = "pending", Text = "Chờ xử lý (pending)" },
                new { Value = "confirmed", Text = "Đã xác nhận (confirmed)" },
                new { Value = "processing", Text = "Đang đóng gói (processing)" },
                new { Value = "shipping", Text = "Đang giao hàng (shipping)" },
                new { Value = "completed", Text = "Hoàn thành (completed)" },
                new { Value = "cancelled", Text = "Đã hủy (cancelled)" }
            };

            if (cboFilterStatus != null)
            {
                cboFilterStatus.DataSource = filterList.ToList();
                cboFilterStatus.DisplayMember = "Text";
                cboFilterStatus.ValueMember = "Value";
            }
        }

        private void loadFilterPaymentStatusComboBox()
        {
            var paymentList = new[]
            {
                new { Value = "all", Text = "-- Tất cả thanh toán --" },
                new { Value = "unpaid", Text = "Chưa thanh toán (unpaid)" },
                new { Value = "paid", Text = "Đã thanh toán (paid)" },
                new { Value = "refunded", Text = "Đã hoàn tiền (refunded)" }
            };

            if (cboFilterPaymentStatus != null)
            {
                cboFilterPaymentStatus.DataSource = paymentList.ToList();
                cboFilterPaymentStatus.DisplayMember = "Text";
                cboFilterPaymentStatus.ValueMember = "Value";
            }
        }

        private void loadOrdersData()
        {
            QLBanHangDataContext db = new QLBanHangDataContext();
            var query = db.orders.AsQueryable();

            // Lọc theo khoảng thời gian
            if (dtpFromDate != null && dtpToDate != null)
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                query = query.Where(o => o.created_at >= fromDate && o.created_at <= toDate);
            }

            // Lọc theo trạng thái đơn hàng
            string selectedStatus = (cboFilterStatus != null && cboFilterStatus.SelectedValue != null)
                ? cboFilterStatus.SelectedValue.ToString()
                : "all";
            if (selectedStatus != "all")
            {
                query = query.Where(o => o.status == selectedStatus);
            }

            // Lọc theo trạng thái thanh toán
            string selectedPayment = (cboFilterPaymentStatus != null && cboFilterPaymentStatus.SelectedValue != null)
                ? cboFilterPaymentStatus.SelectedValue.ToString()
                : "all";
            if (selectedPayment != "all")
            {
                query = query.Where(o => o.payment_status == selectedPayment);
            }

            // Tìm kiếm theo Mã Đơn, Tên người nhận, SĐT
            string keyword = txtSearchOrder != null ? txtSearchOrder.Text.Trim().ToLower() : "";
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(o => o.id.ToString().Contains(keyword) ||
                                         o.recipient_name.ToLower().Contains(keyword) ||
                                         o.recipient_phone.Contains(keyword));
            }

            var orderList = query
                .Select(o => new
                {
                    MaDonHang = o.id,
                    KhachHang = o.user != null ? o.user.full_name : o.recipient_name,
                    NguoiNhan = o.recipient_name,
                    SDT = o.recipient_phone,
                    TongTien = o.total_amount,
                    TrangThai = o.status,
                    ThanhToan = o.payment_status,
                    NgayDat = o.created_at
                })
                .OrderByDescending(o => o.MaDonHang)
                .ToList();

            if (dgvOrders != null)
            {
                dgvOrders.DataSource = orderList;
            }

            if (orderList.Count > 0)
            {
                hienthiChiTietDonHang(orderList[0].MaDonHang);
            }
            else
            {
                if (dgvOrderDetails != null) dgvOrderDetails.DataSource = null;
            }
        }

        private void hienthiChiTietDonHang(int orderId)
        {
            QLBanHangDataContext db = new QLBanHangDataContext();

            if (dgvOrderDetails != null)
            {
                dgvOrderDetails.DataSource = db.order_items
                    .Where(oi => oi.order_id == orderId)
                    .Select(oi => new
                    {
                        MaCT = oi.id,
                        TenSanPham = oi.product_name,
                        SKU = oi.sku,
                        MauSac = oi.color_name,
                        KichThuoc = oi.size_name,
                        SoLuong = oi.quantity,
                        DonGia = oi.unit_price,
                        ThanhTien = oi.line_total
                    })
                    .ToList();
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1 || dgvOrders == null) return;

            int orderId = Convert.ToInt32(dgvOrders.Rows[idrow].Cells[0].Value);
            hienthiChiTietDonHang(orderId);
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow == -1 || dgvOrders == null) return;

            int orderId = Convert.ToInt32(dgvOrders.Rows[idrow].Cells[0].Value);
            hienthiChiTietDonHang(orderId);
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void cboFilterPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            loadOrdersData();
        }

        private void btnResetOrderFilter_Click(object sender, EventArgs e)
        {
            if (dtpFromDate != null) dtpFromDate.Value = DateTime.Now.AddDays(-30);
            if (dtpToDate != null) dtpToDate.Value = DateTime.Now;
            if (txtSearchOrder != null) txtSearchOrder.Clear();
            if (cboFilterStatus != null && cboFilterStatus.Items.Count > 0) cboFilterStatus.SelectedIndex = 0;
            if (cboFilterPaymentStatus != null && cboFilterPaymentStatus.Items.Count > 0) cboFilterPaymentStatus.SelectedIndex = 0;

            loadOrdersData();
        }

        private void btnViewOrderDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrders != null && dgvOrders.CurrentRow != null)
            {
                int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
                hienthiChiTietDonHang(orderId);
                MessageBox.Show($"Đã hiển thị chi tiết cho đơn hàng mã #{orderId}", "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders == null || dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
            QLBanHangDataContext db = new QLBanHangDataContext();
            var ord = db.orders.SingleOrDefault(o => o.id == orderId);

            if (ord != null)
            {
                if (cboFilterStatus != null && cboFilterStatus.SelectedValue != null && cboFilterStatus.SelectedValue.ToString() != "all")
                {
                    ord.status = cboFilterStatus.SelectedValue.ToString();
                }

                ord.updated_at = DateTime.Now;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật trạng thái đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadOrdersData();
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvOrders != null && dgvOrders.CurrentRow != null)
            {
                int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
                MessageBox.Show($"Đang chuẩn bị in hóa đơn cho đơn hàng #{orderId}...", "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblOrderTitle_Click(object sender, EventArgs e) { }
        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}