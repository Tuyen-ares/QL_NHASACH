using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TENNV { get; set; }
        public string MK { get; set; }
        public string SDT { get; set; }
        public string GIOITINH { get; set; }
        public string MACV { get; set; }
        public NhanVien() { }
        public NhanVien(string maNV, string tENNV, string mK, string sDT, string gIOITINH, string mACV)
        {
            MaNV = maNV;
            TENNV = tENNV;
            MK = mK;
            SDT = sDT;
            GIOITINH = gIOITINH;
            MACV = mACV;
        }
    }
}
