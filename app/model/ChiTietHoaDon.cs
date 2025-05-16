using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    public class ChiTietHoaDon
    {
        // Thuộc tính
        public string MaHoaDon { get; set; }   // Tương ứng với MAHD
        public string MaSach { get; set; }     // Tương ứng với MASH
        public int SoLuong { get; set; }       // Tương ứng với SOLUONG
        public double ThanhTien { get; set; }  // Tương ứng với THANHTIEN

        // Constructor không tham số
        public ChiTietHoaDon() { }

        // Constructor có tham số
        public ChiTietHoaDon(string maHoaDon, string maSach, int soLuong, double thanhTien)
        {
            MaHoaDon = maHoaDon;
            MaSach = maSach;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }

        // Phương thức hiển thị thông tin chi tiết hóa đơn
       
    }
}
