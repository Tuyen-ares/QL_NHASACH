using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using app.model;
namespace app
{
    public partial class F_Lich_Su_Ban_Sach : Form
    {
        DBConnect db = new DBConnect();
        public F_Lich_Su_Ban_Sach()
        {
            InitializeComponent();
            load_LS_HD(); 
            grd_LS_HD.Columns["drvemail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        public void load_LS_HD()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng TACGIA
                string query = "SELECT MAHD, MAKH, NGAYLAP , MANV, TONGTIEN FROM HOADON";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                grd_LS_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_LS_HD.Rows.Add(row["MAHD"].ToString(), row["MAKH"].ToString(), row["NGAYLAP"].ToString(), row["MANV"].ToString(), row["TONGTIEN"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txt_Ma_HD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã hóa đơn từ textbox
                string maHD = txt_Ma_HD.Text.Trim();

                // Tạo câu lệnh SQL với điều kiện lọc theo MAHD
                string sqlSelect = "SELECT MAHD, MAKH, NGAYLAP, MANV, TONGTIEN FROM HOADON WHERE MAHD LIKE '%" + maHD + "%'";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(sqlSelect);

                // Xóa dữ liệu cũ trong DataGridView
                grd_LS_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_LS_HD.Rows.Add(
                        row["MAHD"].ToString(),
                        row["MAKH"].ToString(),
                        row["NGAYLAP"].ToString(),
                        row["MANV"].ToString(),
                        row["TONGTIEN"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_LS_HD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào một hàng hợp lệ
            {
                // Lấy mã hóa đơn từ cột đầu tiên (giả sử cột MAHD là cột đầu tiên)
                string maHD = grd_LS_HD.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Tạo và hiển thị form chi tiết hóa đơn, truyền mã hóa đơn vào
                F_Chi_Tiet_HD_Ban_Sach f = new F_Chi_Tiet_HD_Ban_Sach(maHD);
                f.Show();
            }
        }
    }
}

