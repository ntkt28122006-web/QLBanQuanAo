using System;
using System.Linq;
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
            dgvOrders.ReadOnly = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.MultiSelect = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
                case "returned": return "Đã trả hàng";
                default: return status;
            }
        }

        private void TaiDanhSachDonHang()
        {
            if (!UserSession.IsLoggedIn || UserSession.CurrentUserId <= 0)
            {
                dgvOrders.DataSource = null;
                dgvOrderItems.DataSource = null;
                btnCancelOrder.Enabled = false;
                btnPrint.Enabled = false;
                MessageBox.Show(
                    "Vui lòng đăng nhập để xem lịch sử đơn hàng.",
                    "Yêu cầu đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var dsHienThi = (from o in db.orders
                                     where o.user_id == UserSession.CurrentUserId
                                     orderby o.created_at descending
                                     select new
                                     {
                                         MaDonHang = o.id,
                                         NgayDat = o.created_at,
                                         NguoiNhan = o.recipient_name,
                                         SoDienThoai = o.recipient_phone,
                                         DiaChiGiao = o.shipping_address,
                                         TongTien = o.total_amount,
                                         TrangThai = o.status
                                     }).ToList()
                                     .Select(o => new
                                     {
                                         o.MaDonHang,
                                         NgayDat = o.NgayDat.ToString("dd/MM/yyyy HH:mm"),
                                         o.NguoiNhan,
                                         o.SoDienThoai,
                                         o.DiaChiGiao,
                                         o.TongTien,
                                         TrangThai = HienThiTrangThai(o.TrangThai)
                                     }).ToList();

                    dgvOrders.DataSource = dsHienThi;
                }

                if (dgvOrders.Rows.Count > 0)
                {
                    dgvOrders.ClearSelection();
                    dgvOrders.Rows[0].Selected = true;
                    dgvOrders.CurrentCell = dgvOrders.Rows[0].Cells[0];
                    HienThiChiTietDong(0);
                }
                else
                {
                    dgvOrderItems.DataSource = null;
                    btnCancelOrder.Enabled = false;
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                dgvOrders.DataSource = null;
                dgvOrderItems.DataSource = null;
                btnCancelOrder.Enabled = false;
                btnPrint.Enabled = false;
                MessageBox.Show(
                    "Không thể tải lịch sử đơn hàng.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void HienThiChiTietDong(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvOrders.Rows.Count)
            {
                dgvOrderItems.DataSource = null;
                btnCancelOrder.Enabled = false;
                btnPrint.Enabled = false;
                return;
            }

            object idValue = dgvOrders.Rows[rowIndex].Cells["MaDonHang"].Value;
            int orderId;
            if (idValue == null || !int.TryParse(idValue.ToString(), out orderId))
            {
                dgvOrderItems.DataSource = null;
                btnCancelOrder.Enabled = false;
                btnPrint.Enabled = false;
                return;
            }

            TaiChiTietDonHang(orderId);

            string statusText = Convert.ToString(dgvOrders.Rows[rowIndex].Cells["TrangThai"].Value);
            btnCancelOrder.Enabled = statusText == "Chờ xác nhận";
            btnPrint.Enabled = true;
        }

        private void TaiChiTietDonHang(int orderId)
        {
            using (var db = new QLBanHangDataContext())
            {
                var dsChiTiet = (from oi in db.order_items
                                 where oi.order_id == orderId
                                 select new
                                 {
                                     MaSKU = oi.sku,
                                     TenSanPham = oi.product_name,
                                     MauSac = oi.color_name,
                                     KichCo = oi.size_name,
                                     SoLuong = oi.quantity,
                                     DonGia = oi.unit_price,
                                     ThanhTien = oi.line_total
                                 }).ToList();

                dgvOrderItems.DataSource = dsChiTiet;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HienThiChiTietDong(e.RowIndex);
            }
        }

        private int? LayMaDonHangDangChon()
        {
            if (dgvOrders.CurrentRow == null || !dgvOrders.Columns.Contains("MaDonHang"))
            {
                return null;
            }

            object value = dgvOrders.CurrentRow.Cells["MaDonHang"].Value;
            int orderId;
            return value != null && int.TryParse(value.ToString(), out orderId)
                ? (int?)orderId
                : null;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            int? selectedOrderId = LayMaDonHangDangChon();
            if (!selectedOrderId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để hủy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = selectedOrderId.Value;
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy đơn hàng #" + orderId + " không?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new QLBanHangDataContext())
                {
                    var donHang = db.orders.SingleOrDefault(o =>
                        o.id == orderId && o.user_id == UserSession.CurrentUserId);

                    if (donHang == null)
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng thuộc tài khoản hiện tại.",
                            "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiDanhSachDonHang();
                        return;
                    }

                    if (donHang.status != "pending")
                    {
                        MessageBox.Show(
                            "Chỉ được hủy đơn hàng khi đơn còn ở trạng thái 'Chờ xác nhận'.",
                            "Không thể hủy",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    var orderItems = db.order_items
                        .Where(oi => oi.order_id == orderId)
                        .ToList();

                    foreach (var orderItem in orderItems)
                    {
                        if (!orderItem.variant_id.HasValue) continue;

                        int variantId = orderItem.variant_id.Value;
                        var inventory = db.inventories.SingleOrDefault(inv => inv.variant_id == variantId);
                        if (inventory == null)
                        {
                            throw new InvalidOperationException(
                                "Không tìm thấy bản ghi tồn kho của biến thể SKU " + orderItem.sku +
                                ". Đơn hàng chưa được hủy để tránh sai lệch tồn kho.");
                        }

                        inventory.stock_quantity += orderItem.quantity;
                        inventory.updated_at = DateTime.Now;
                    }

                    donHang.status = "cancelled";
                    donHang.updated_at = DateTime.Now;
                    db.SubmitChanges();
                }

                MessageBox.Show(
                    "Đã hủy đơn hàng #" + orderId + " và hoàn lại số lượng tồn kho.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaiDanhSachDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hủy đơn hàng.\nChi tiết: " + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int? selectedOrderId = LayMaDonHangDangChon();
            if (!selectedOrderId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để in hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmInHoaDon frm = new FrmInHoaDon(selectedOrderId.Value);
            frm.ShowDialog();
        }
    }
}
