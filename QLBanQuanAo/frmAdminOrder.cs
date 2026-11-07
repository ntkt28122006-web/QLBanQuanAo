using System;
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

            dgvOrders.AutoGenerateColumns = false;
            dgvOrderDetails.AutoGenerateColumns = false;
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
                new { Value = "cancelled", Text = "Đã hủy (cancelled)" },
                new { Value = "returned", Text = "Đã trả hàng (returned)" }
            };

            if (cboFilterStatus != null)
            {
                cboFilterStatus.DataSource = filterList.ToList();
                cboFilterStatus.DisplayMember = "Text";
                cboFilterStatus.ValueMember = "Value";
                cboFilterStatus.SelectedValue = "all";
            }
        }

        private void loadFilterPaymentStatusComboBox()
        {
            var paymentList = new[]
            {
                new { Value = "all", Text = "-- Tất cả thanh toán --" },
                new { Value = "unpaid", Text = "Chưa thanh toán (unpaid)" },
                new { Value = "pending", Text = "Đang chờ thanh toán (pending)" },
                new { Value = "paid", Text = "Đã thanh toán (paid)" },
                new { Value = "refunded", Text = "Đã hoàn tiền (refunded)" },
                new { Value = "failed", Text = "Thanh toán thất bại (failed)" }
            };

            if (cboFilterPaymentStatus != null)
            {
                cboFilterPaymentStatus.DataSource = paymentList.ToList();
                cboFilterPaymentStatus.DisplayMember = "Text";
                cboFilterPaymentStatus.ValueMember = "Value";
                cboFilterPaymentStatus.SelectedValue = "all";
            }
        }

        private void loadOrdersData()
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var query = db.orders.AsQueryable();

                if (dtpFromDate != null && dtpToDate != null)
                {
                    DateTime fromDate = dtpFromDate.Value.Date;
                    DateTime toDateExclusive = dtpToDate.Value.Date.AddDays(1);
                    query = query.Where(o => o.created_at >= fromDate && o.created_at < toDateExclusive);
                }

                string selectedStatus = (cboFilterStatus != null && cboFilterStatus.SelectedValue != null)
                    ? cboFilterStatus.SelectedValue.ToString()
                    : "all";
                if (selectedStatus != "all")
                {
                    query = query.Where(o => o.status == selectedStatus);
                }

                string selectedPayment = (cboFilterPaymentStatus != null && cboFilterPaymentStatus.SelectedValue != null)
                    ? cboFilterPaymentStatus.SelectedValue.ToString()
                    : "all";
                if (selectedPayment != "all")
                {
                    query = query.Where(o => o.payment_status == selectedPayment);
                }

                string keyword = txtSearchOrder != null ? txtSearchOrder.Text.Trim() : string.Empty;
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    int orderIdKeyword;
                    if (int.TryParse(keyword, out orderIdKeyword))
                    {
                        query = query.Where(o => o.id == orderIdKeyword ||
                                                 o.recipient_name.Contains(keyword) ||
                                                 o.recipient_phone.Contains(keyword) ||
                                                 (o.user != null && o.user.full_name.Contains(keyword)));
                    }
                    else
                    {
                        query = query.Where(o => o.recipient_name.Contains(keyword) ||
                                                 o.recipient_phone.Contains(keyword) ||
                                                 (o.user != null && o.user.full_name.Contains(keyword)));
                    }
                }

                var orderList = query
                    .OrderByDescending(o => o.created_at)
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
                    .ToList();

                dgvOrders.DataSource = orderList;

                if (orderList.Count > 0)
                {
                    hienthiChiTietDonHang(orderList[0].MaDonHang);
                }
                else
                {
                    dgvOrderDetails.DataSource = null;
                }
            }
        }

        private void hienthiChiTietDonHang(int orderId)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
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

        private int? LayMaDonHangDangChon()
        {
            if (dgvOrders == null || dgvOrders.CurrentRow == null ||
                !dgvOrders.Columns.Contains("colOrderId"))
            {
                return null;
            }

            object value = dgvOrders.CurrentRow.Cells["colOrderId"].Value;
            int orderId;
            if (value == null || value == DBNull.Value || !int.TryParse(value.ToString(), out orderId))
            {
                return null;
            }

            return orderId;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOrders == null || !dgvOrders.Columns.Contains("colOrderId"))
                return;

            object value = dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value;
            int orderId;
            if (value != null && value != DBNull.Value && int.TryParse(value.ToString(), out orderId))
            {
                hienthiChiTietDonHang(orderId);
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Giữ handler để tương thích với Designer cũ; sự kiện này không tải lại chi tiết.
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
            if (cboFilterStatus != null && cboFilterStatus.Items.Count > 0) cboFilterStatus.SelectedValue = "all";
            if (cboFilterPaymentStatus != null && cboFilterPaymentStatus.Items.Count > 0) cboFilterPaymentStatus.SelectedValue = "all";

            loadOrdersData();
        }

        private void btnViewOrderDetail_Click(object sender, EventArgs e)
        {
            int? orderId = LayMaDonHangDangChon();
            if (!orderId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            hienthiChiTietDonHang(orderId.Value);
        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            int? selectedOrderId = LayMaDonHangDangChon();
            if (!selectedOrderId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus;
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var order = db.orders.SingleOrDefault(o => o.id == selectedOrderId.Value);
                if (order == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                currentStatus = order.status;
            }

            var statusOptions = new[]
            {
                new { Value = "confirmed", Text = "Xác nhận đơn hàng" },
                new { Value = "processing", Text = "Đang đóng gói / xử lý" },
                new { Value = "shipping", Text = "Đang giao hàng" },
                new { Value = "completed", Text = "Hoàn thành" },
                new { Value = "cancelled", Text = "Hủy đơn hàng" },
                new { Value = "returned", Text = "Đã trả hàng" }
            };

            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var option in statusOptions)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(option.Text + " (" + option.Value + ")");
                item.Enabled = LaTrangThaiHopLe(currentStatus, option.Value);
                string nextStatus = option.Value;
                item.Click += (s, args) => CapNhatTrangThaiDonHang(selectedOrderId.Value, nextStatus);
                menu.Items.Add(item);
            }

            if (!menu.Items.Cast<ToolStripMenuItem>().Any(i => i.Enabled))
            {
                menu.Dispose();
                MessageBox.Show("Đơn hàng đang ở trạng thái kết thúc, không thể chuyển trạng thái tiếp.",
                    "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            menu.Show(btnUpdateOrderStatus, 0, btnUpdateOrderStatus.Height);
        }

        private bool LaTrangThaiHopLe(string currentStatus, string nextStatus)
        {
            switch (currentStatus)
            {
                case "pending":
                    return nextStatus == "confirmed" || nextStatus == "cancelled";
                case "confirmed":
                    return nextStatus == "processing" || nextStatus == "cancelled";
                case "processing":
                    return nextStatus == "shipping" || nextStatus == "cancelled";
                case "shipping":
                    return nextStatus == "completed";
                case "completed":
                    return nextStatus == "returned";
                default:
                    return false;
            }
        }

        private void CapNhatTrangThaiDonHang(int orderId, string nextStatus)
        {
            try
            {
                using (QLBanHangDataContext db = new QLBanHangDataContext())
                {
                    var order = db.orders.SingleOrDefault(o => o.id == orderId);
                    if (order == null)
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!LaTrangThaiHopLe(order.status, nextStatus))
                    {
                        MessageBox.Show("Trạng thái đơn hàng đã thay đổi hoặc không hợp lệ. Vui lòng tải lại danh sách.",
                            "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadOrdersData();
                        return;
                    }

                    if (nextStatus == "cancelled")
                    {
                        string warning = order.payment_status == "paid"
                            ? "Đơn hàng đã được ghi nhận thanh toán. Hệ thống sẽ hoàn lại tồn kho nhưng KHÔNG tự thực hiện hoàn tiền. Ông cần xử lý hoàn tiền riêng.\n\nXác nhận hủy đơn?"
                            : "Khi hủy đơn, hệ thống sẽ hoàn lại số lượng tồn kho của các biến thể còn liên kết.\n\nXác nhận hủy đơn?";

                        if (MessageBox.Show(warning, "Xác nhận hủy đơn", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            return;
                        }

                        var orderItems = db.order_items
                            .Where(oi => oi.order_id == orderId && oi.variant_id.HasValue)
                            .ToList();

                        foreach (var orderItem in orderItems)
                        {
                            var inventory = db.inventories
                                .SingleOrDefault(inv => inv.variant_id == orderItem.variant_id.Value);

                            if (inventory != null)
                            {
                                inventory.stock_quantity += orderItem.quantity;
                                inventory.updated_at = DateTime.Now;
                            }
                        }
                    }

                    order.status = nextStatus;
                    order.updated_at = DateTime.Now;
                    db.SubmitChanges();
                }

                MessageBox.Show("Cập nhật trạng thái đơn hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadOrdersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật trạng thái đơn hàng. Chi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            int? orderId = LayMaDonHangDangChon();
            if (!orderId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để in hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FrmInHoaDon frm = new FrmInHoaDon(orderId.Value))
            {
                frm.ShowDialog(this);
            }
        }

        private void lblOrderTitle_Click(object sender, EventArgs e) { }
        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblFromDate_Click(object sender, EventArgs e) { }

        private void lblTodate_Click(object sender, EventArgs e)
        {

        }
    }
}
