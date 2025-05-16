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
using System.Globalization;
using app.model;
namespace app
{
    public partial class F_DM_Doanh_Thu : Form
    {
        DBConnect connect;

        public F_DM_Doanh_Thu()
        {
            InitializeComponent();
            dt_doanhthu.CustomFormat = "MMMM yyyy ";
            dt_doanhthu.Format = DateTimePickerFormat.Custom;
            grid_view_Doanh_Thu.ReadOnly = true;
            connect = new DBConnect();
            LoadDataIntoGridView();
            // Căn chỉnh cột "Giá sách" sang phải
            grid_view_Doanh_Thu.Columns["Giá sách"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Căn chỉnh cột "Thành Tiền" sang phải
            grid_view_Doanh_Thu.Columns["Thành Tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void F_DM_Doanh_Thu_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView(); // Gọi phương thức để nạp dữ liệu khi form được tải
        }

        private void LoadDataIntoGridView()
        {
            try
            {
                // Lấy tháng và năm từ DateTimePicker
                int thang = dt_doanhthu.Value.Month;
                int nam = dt_doanhthu.Value.Year;

                // Câu lệnh SQL với tham số
                string query = @"
                    SELECT 
                    SACH.MASH, 
                    SACH.TENSH AS N'Tên sách', 
                    LOAISACH.TENLOAI AS N'Loại Sách', 
                    FORMAT(HOADON.NGAYLAP, 'dd/MM/yyyy') AS 'Ngày lập', 
                    SUM(CT_HOADON.SOLUONG) AS N'Số Lượng Bán', 
                    FORMAT(SACH.GIABAN, N'N0', 'vi-VN') AS N'Giá sách', 
                    FORMAT(SUM(CT_HOADON.THANHTIEN), 'N0', 'vi-VN') + ' VND' AS N'Thành Tiền'
                FROM CT_HOADON
                JOIN HOADON ON CT_HOADON.MAHD = HOADON.MAHD
                JOIN SACH ON CT_HOADON.MASH = SACH.MASH
                JOIN LOAISACH ON LOAISACH.MALOAI = SACH.MALOAI
                 WHERE MONTH(HOADON.NGAYLAP) = @thang
                                     AND YEAR(HOADON.NGAYLAP) = @nam
                GROUP BY SACH.MASH, SACH.TENSH, LOAISACH.TENLOAI, SACH.GIABAN, HOADON.NGAYLAP
                ORDER BY SUM(CT_HOADON.SOLUONG) DESC;
                ";

                // Lấy dữ liệu
                using (SqlConnection conn = new SqlConnection(connect.strConnect))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@thang", thang);
                    cmd.Parameters.AddWithValue("@nam", nam);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Thiết lập tiêu đề cột cho DataGridView
                   
                    grid_view_Doanh_Thu.DataSource = dt; // Gán DataTable cho DataGridView

                    // Hiển thị thông tin sản phẩm bán chạy nhất
                    if (dt.Rows.Count > 0)
                    {
                        // Lấy thông tin sản phẩm bán chạy nhất
                        string tenSachBanChay = dt.Rows[0]["Tên sách"].ToString();
                        //int soLuongBanChay = Convert.ToInt32(dt.Rows[0]["Số Lượng Bán"]);
                        decimal soLuongBanChay = 0;
                        decimal doanhThuThang = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            // Tính tổng thành tiền
                            doanhThuThang += Convert.ToDecimal(row["Thành Tiền"].ToString().Replace(".", "").Replace(" VND", ""));
                            soLuongBanChay += Convert.ToDecimal(row["Số Lượng Bán"].ToString());
                        }

                        // Gán vào các textbox
                        txt_name_sach.Text = tenSachBanChay; // Tên sản phẩm
                        txt_soLuong.Text = soLuongBanChay.ToString(); // Số lượng
                        txt_DoanhThu.Text = doanhThuThang.ToString("N0", new CultureInfo("vi-VN")) + " VND"; // Doanh thu (định dạng tiền tệ VND)
                    }
                    else
                    {
                        // Nếu không có dữ liệu
                        txt_name_sach.Text = "Không có dữ liệu";
                        txt_soLuong.Text = "0";
                        txt_DoanhThu.Text = "0 VND";
                    }

                    // Tính doanh thu cả năm
                    string queryYear = @"
                        SELECT 
                            SUM(CT_HOADON.THANHTIEN) AS 'Doanh Thu Năm'
                        FROM CT_HOADON
                        JOIN HOADON ON CT_HOADON.MAHD = HOADON.MAHD
                        WHERE YEAR(HOADON.NGAYLAP) = @nam";

                    SqlCommand cmdYear = new SqlCommand(queryYear, conn);
                    cmdYear.Parameters.AddWithValue("@nam", nam);

                    conn.Open();
                    object result = cmdYear.ExecuteScalar();
                    conn.Close();

                    // Hiển thị doanh thu năm
                    decimal doanhThuNam = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    txt_DoanhThu_Nam.Text = doanhThuNam.ToString("N0", new CultureInfo("vi-VN")) + " VND"; // Doanh thu năm
                }
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

        private void dt_doanhthu_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoGridView(); // Gọi lại phương thức để nạp dữ liệu khi giá trị thay đổi
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nhấn vào label (nếu cần)
        }

        private void btn_rp_Click(object sender, EventArgs e)
        {
            F_Thong_Ke f = new F_Thong_Ke();
            f.Show();
        }
    }
}
