using Microsoft.Reporting.WinForms;
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
    public partial class FrmInHoaDon : Form
    {
        private int _orderId;
        public FrmInHoaDon(int orderId)
        {
            InitializeComponent();
            _orderId = orderId ;
        }

        private void FrmInHoaDon_Load(object sender, EventArgs e)
        {
            using (var db = new QLBanHangDataContext())
            {
                var duLieuBaoCao = (from o in db.orders
                                    join oi in db.order_items on o.id equals oi.order_id
                                    where o.id == _orderId
                                    select new OrderReportDTO
                                    {
                                        MaDonHang = o.id,
                                        NgayDat = o.created_at,
                                        NguoiNhan = o.recipient_name,
                                        SoDienThoai = o.recipient_phone,
                                        DiaChiGiao = o.shipping_address,
                                        MaSKU = oi.sku,
                                        TenSanPham = oi.product_name,
                                        MauSac = oi.color_name,
                                        KichCo = oi.size_name,
                                        SoLuong = oi.quantity,
                                        DonGia = oi.unit_price,
                                        ThanhTien = oi.line_total ?? (oi.quantity * oi.unit_price),
                                        TongTienDonHang = o.total_amount
                                    }).ToList();
                reportViewer1.LocalReport.ReportPath = "rptHoaDon.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("dsHoaDon", duLieuBaoCao);
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
                
        }
    }
}
