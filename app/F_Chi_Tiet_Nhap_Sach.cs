using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.model;
namespace app
{
    public partial class F_Chi_Tiet_Nhap_Sach : Form
    {
        DBConnect db = new DBConnect(); // Khởi tạo đối tượng DBConnect
        public F_Chi_Tiet_Nhap_Sach()
        {
            InitializeComponent();
        }

        public F_Chi_Tiet_Nhap_Sach(string maPN)
        {
            InitializeComponent();
            InitializeDataGridViewForPhieuNhap();
            load_DL_PhieuNhap(maPN);
        }

        private void InitializeDataGridViewForPhieuNhap()
        {
            grd_Chi_Tiet_HD.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm cột và đặt tên cho từng cột
            grd_Chi_Tiet_HD.Columns.Add("MAPN", "Mã Phiếu Nhập");
            grd_Chi_Tiet_HD.Columns.Add("MASH", "Mã Sách");
            grd_Chi_Tiet_HD.Columns.Add("SOLUONG", "Số Lượng");
            grd_Chi_Tiet_HD.Columns.Add("GIANHAP", "Giá Nhập");
            grd_Chi_Tiet_HD.Columns.Add("THANHTIEN", "Thành Tiền");

            // Đặt chiều cao của từng hàng là 24px cho Guna2DataGridView
            grd_Chi_Tiet_HD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grd_Chi_Tiet_HD.RowHeadersVisible = false;
            grd_Chi_Tiet_HD.ColumnHeadersHeight = 30; // Đặt chiều cao của header

            grd_Chi_Tiet_HD.DefaultCellStyle.Padding = new Padding(0, 4, 0, 4); // Tùy chỉnh padding
        }

        public void load_DL_PhieuNhap(string maPN)
        {
            try
            {
                // Câu lệnh SQL để lấy dữ liệu từ bảng CT_PHIEUNHAP dựa vào mã phiếu nhập
                string query = $"SELECT TOP (1000) MAPN, MASH, SOLUONG, GIANHAP, THANHTIEN FROM CT_PHIEUNHAP WHERE MAPN = '{maPN}'";

                // Lấy dữ liệu từ cơ sở dữ liệu bằng phương thức getDataTable
                DataTable data = db.getDataTable(query);

                // Xóa dữ liệu cũ trong DataGridView
                grd_Chi_Tiet_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_Chi_Tiet_HD.Rows.Add(
                        row["MAPN"].ToString(),
                        row["MASH"].ToString(),
                        row["SOLUONG"].ToString(),
                        row["GIANHAP"].ToString(),
                        row["THANHTIEN"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
