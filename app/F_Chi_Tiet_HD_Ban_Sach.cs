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
    public partial class F_Chi_Tiet_HD_Ban_Sach : Form
    {
        DBConnect db = new DBConnect(); // Khởi tạo đối tượng DBConnect
        public F_Chi_Tiet_HD_Ban_Sach()
        {
            InitializeComponent();
        }

        public F_Chi_Tiet_HD_Ban_Sach(string maHD)
        {
            InitializeComponent();
            InitializeDataGridView();
            load_DL(maHD);
        }

        private void InitializeDataGridView()
        {
            grd_Chi_Tiet_HD.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm cột và đặt tên cho từng cột
            grd_Chi_Tiet_HD.Columns.Add("MAHD", "Mã Hóa Đơn");
            grd_Chi_Tiet_HD.Columns.Add("MASH", "Mã Sách");
            grd_Chi_Tiet_HD.Columns.Add("SOLUONG", "Số Lượng");
            grd_Chi_Tiet_HD.Columns.Add("THANHTIEN", "Thành Tiền");
            // Đặt chiều cao của hàng là 24px
            // Đặt chiều cao của từng hàng là 24px cho Guna2DataGridView
            grd_Chi_Tiet_HD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grd_Chi_Tiet_HD.RowHeadersVisible = false;
            grd_Chi_Tiet_HD.ColumnHeadersHeight = 30; // Đặt chiều cao của header (nếu cần)

            foreach (DataGridViewRow row in grd_Chi_Tiet_HD.Rows)
            {
                row.Height = 24;
            }

            // Nếu muốn tất cả các hàng có chiều cao cố định
            grd_Chi_Tiet_HD.DefaultCellStyle.Padding = new Padding(0, 4, 0, 4); // Tùy chỉnh padding để đảm bảo hiển thị đẹp
        }

        public void load_DL(string maHD)
        {
          
            try
            {
                // Câu lệnh SQL để lấy dữ liệu từ bảng CT_HOADON dựa vào mã hóa đơn
                string query = $"SELECT TOP (1000) MAHD, MASH, SOLUONG, THANHTIEN FROM CT_HOADON WHERE MAHD = '{maHD}'";

                // Lấy dữ liệu từ cơ sở dữ liệu bằng phương thức getDataTable
                DataTable data = db.getDataTable(query);

                // Xóa dữ liệu cũ trong DataGridView
                grd_Chi_Tiet_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_Chi_Tiet_HD.Rows.Add(
                        row["MAHD"].ToString(),
                        row["MASH"].ToString(),
                        row["SOLUONG"].ToString(),
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
