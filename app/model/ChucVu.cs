using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    public class ChucVu
    {
        public string MaCV { get; set; }
        public string TenCV { get; set; }


        public ChucVu(string macv, string tencv)
        {
            MaCV = macv;
            TenCV = tencv;
        }
    }
}
