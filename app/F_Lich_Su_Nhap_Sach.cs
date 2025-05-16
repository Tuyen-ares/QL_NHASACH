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
    public partial class F_Lich_Su_Nhap_Sach : Form
    {
        DBConnect db = new DBConnect();
        public F_Lich_Su_Nhap_Sach()
        {
            InitializeComponent();
            // Thêm các cột vào DataGridView
            grd_LS_HD.Columns.Add("MAPN", "Mã Phiếu Nhập");
            grd_LS_HD.Columns.Add("NGAYLAP", "Ngày Lập");
            grd_LS_HD.Columns.Add("TONGTIEN", "Tổng Tiền");
            load_LS_HD();
            grd_LS_HD.Columns["TONGTIEN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void load_LS_HD()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng TACGIA
                string query = "SELECT MAPN, NGAYLAP, TONGTIEN FROM PHIEUNHAP";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                grd_LS_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_LS_HD.Rows.Add(row["MAPN"].ToString(), row["NGAYLAP"].ToString(), row["TONGTIEN"].ToString());
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

                // Nếu textbox trống, tải lại toàn bộ dữ liệu
                if (string.IsNullOrEmpty(maHD))
                {
                    load_LS_HD(); // Gọi lại phương thức load_LS_HD để tải lại toàn bộ dữ liệu
                    return;
                }

                // Tạo câu lệnh SQL với điều kiện lọc theo MAHD
                string sqlSelect = "SELECT MAPN, NGAYLAP, TONGTIEN FROM PHIEUNHAP WHERE MAPN LIKE '%" + maHD + "%'";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(sqlSelect);

                // Xóa dữ liệu cũ trong DataGridView
                grd_LS_HD.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    grd_LS_HD.Rows.Add(
                        row["MAPN"].ToString(),
                        row["NGAYLAP"].ToString(),
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
            // Kiểm tra nếu chỉ số dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Debugging: In ra các giá trị của các cột trong dòng đã chọn
                foreach (DataGridViewCell cell in grd_LS_HD.Rows[e.RowIndex].Cells)
                {
                    Console.WriteLine($"Column {cell.ColumnIndex}: {cell.Value}");
                }

                // Lấy giá trị từ ô cột MAPN của dòng được chọn
                var cellValue = grd_LS_HD.Rows[e.RowIndex].Cells["MAPN"].Value;
                if (cellValue != null)
                {
                    string maPN = cellValue.ToString();
                    F_Chi_Tiet_Nhap_Sach f = new F_Chi_Tiet_Nhap_Sach(maPN);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Không có mã phiếu nhập (MAPN) trong dòng này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
