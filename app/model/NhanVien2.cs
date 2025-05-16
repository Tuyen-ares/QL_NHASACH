using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    public class NhanVien2
    {
        public string ma { get; set; }
        public string ten { get; set; }
        public string mk { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }
        public string macv { get; set; }

        public NhanVien2(string Ma, string Ten, string Mk, string Sdt, string Gioitinh, string Macv)
        {
            ma = Ma;
            ten = Ten;
            mk = Mk;
            sdt = Sdt;
            gioitinh = Gioitinh;
            macv = Macv;
        }
    }
}
