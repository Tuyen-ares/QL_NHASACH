using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class F_Thong_Ke_Nhap_Sach : Form
    {
        public F_Thong_Ke_Nhap_Sach()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            TK_Nhap_Sach rpt = new TK_Nhap_Sach();
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();

        }
    }
}
