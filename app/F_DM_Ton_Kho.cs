using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using app.model;

namespace app
{
    public partial class F_DM_Ton_Kho : Form
    {
        private DBConnect connect; // Kết nối cơ sở dữ liệu

        public F_DM_Ton_Kho()
        {
            InitializeComponent();
            connect = new DBConnect(); // Khởi tạo kết nối
            grid_view_Ton_Kho.ReadOnly = true;
            LoadDataIntoGridView();
            // Căn chỉnh cột "Giá sách" sang phải
            grid_view_Ton_Kho.Columns["Giá Nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Căn chỉnh cột "Thành Tiền" sang phải
            grid_view_Ton_Kho.Columns["THÀNH TIỀN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void F_DM_Ton_Kho_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView(); // Gọi phương thức để nạp dữ liệu khi form được tải
        }

        private void LoadDataIntoGridView()
        {
            try
            {
                // Câu lệnh SQL để lấy thông tin tồn kho
                string query = @"
        SELECT
            SACH.MASH,
            SACH.TENSH AS N'Tên sách',
            LOAISACH.TENLOAI AS N'Loại sách',
            SACH.TONKHO AS N'Số Lượng Tồn Kho',
            FORMAT(SACH.GIANHAP, 'N0', 'vi-VN') + ' VND' AS 'Giá Nhập',  
            FORMAT(SACH.TONKHO * SACH.GIANHAP, 'N0', 'vi-VN') + ' VND' AS 'THÀNH TIỀN'
        FROM
            SACH
        LEFT JOIN
            CT_HOADON ON SACH.MASH = CT_HOADON.MASH
        JOIN
            LOAISACH ON LOAISACH.MALOAI = SACH.MALOAI
        GROUP BY
            SACH.MASH,
            SACH.TENSH,
            LOAISACH.TENLOAI,
            SACH.GIANHAP,
            SACH.TONKHO
        ORDER BY
            SACH.TONKHO DESC;";

                // Sử dụng phương thức getDataTable từ DBConnect
                DataTable dt = connect.getDataTable(query);
                grid_view_Ton_Kho.DataSource = dt; // Gán DataTable cho DataGridView

                // Kiểm tra xem có dữ liệu không
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nào được trả về.");
                    return; // Thoát khỏi phương thức nếu không có dữ liệu
                }

                // Tính tổng số lượng tồn kho và tổng giá trị tồn kho
                int totalQuantity = 0;
                decimal totalValue = 0;
                string tenSachTonNhieu = dt.Rows[0]["Tên sách"].ToString(); // Tên sách tồn nhiều nhất

                foreach (DataRow row in dt.Rows)
                {
                    int quantityInStock = Convert.ToInt32(row["Số Lượng Tồn Kho"]);
                    totalQuantity += quantityInStock;

                    // Xử lý "Thành Tiền"
                    string thanhTienStr = row["THÀNH TIỀN"].ToString().Replace(" VND", "").Replace(".", ""); // Tách "VND" và dấu chấm
                    if (decimal.TryParse(thanhTienStr, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"), out decimal thanhTien))
                    {
                        totalValue += thanhTien;
                    }
                    else
                    {
                        MessageBox.Show($"Giá trị 'Thành Tiền' không hợp lệ cho sách: {row["Tên sách"]}");
                    }
                }

                // Gán vào các textbox
                txt_name_sach.Text = tenSachTonNhieu; // Tên sách tồn nhiều nhất
                txt_soLuong.Text = totalQuantity.ToString(); // Tổng số lượng tồn
                txt_TongTien.Text = totalValue.ToString("N0", new CultureInfo("vi-VN")) + " VND"; // Tổng tiền tồn kho, có "VND" ở cuối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu: " + ex.Message);
            }
        }

        private void grid_view_Doanh_Thu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi người dùng nhấn vào ô của DataGridView (nếu cần)
        }
    }
}
