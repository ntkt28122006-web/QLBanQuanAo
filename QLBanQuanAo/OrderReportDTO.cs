using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanQuanAo
{
    internal class OrderReportDTO
    {
        public int MaDonHang { get; set; }
        public DateTime NgayDat { get; set; }
        public string NguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiGiao { get; set; }
        public string MaSKU { get; set; }
        public string TenSanPham { get; set; }
        public string MauSac { get; set; }
        public string KichCo { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal TongTienDonHang { get; set; }
    }
}
