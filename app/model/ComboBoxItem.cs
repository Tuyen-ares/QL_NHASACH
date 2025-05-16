using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    class ComboBoxItem
    {
        public string Value { get; set; } // Giá trị (Mã)
        public string Text { get; set; }  // Hiển thị (Tên)

        public override string ToString()
        {
            return Text; // Hiển thị Text trong ComboBox
        }
    }
}
