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
using System.Data.SqlClient;
namespace app
{
    public partial class F_Doi_Tra_Sach : Form
    {
        DBConnect data = new DBConnect();
        List<ChiTietHoaDon> list_CT_HD = new List<ChiTietHoaDon>();
        public F_Doi_Tra_Sach()
        {
            InitializeComponent();
            grid_nv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chỉ cho phép chọn cả dòng
            grid_nv.ReadOnly = true; // Không cho phép chỉnh sửa nội dung
            grid_nv.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            grid_nv.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
            grid_nv.AllowUserToResizeColumns = true; // Có thể tùy chọn cho phép thay đổi kích thước cột
            LoadChiTietHoaDon();
            grid_nv.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            grid_nv.DataSource = null;
            list_CT_HD.Clear();

            string hoTenKhachHang = txt_name.Text.Trim();

            // Câu truy vấn SQL lấy dữ liệu với tất cả các trường cần thiết
            string sqlSelect = @"
    SELECT 
        HOADON.MAHD AS [Mã hóa đơn],
        SACH.MASH AS [Mã sách],
        CT_HOADON.SOLUONG AS [Số lượng],
        CT_HOADON.THANHTIEN AS [Thành tiền]
    FROM 
        KHACHHANG
    JOIN 
        HOADON ON KHACHHANG.MAKH = HOADON.MAKH
    JOIN 
        CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD
    JOIN 
        SACH ON CT_HOADON.MASH = SACH.MASH
    WHERE 
        KHACHHANG.TENKH LIKE N'%" + hoTenKhachHang + "%'";

            // Lấy dữ liệu từ cơ sở dữ liệu
            DataTable dt = data.getDataTable(sqlSelect);

            // Duyệt qua DataTable và thêm vào danh sách chi tiết hóa đơn
            foreach (DataRow row in dt.Rows)
            {
                ChiTietHoaDon chiTietHoa = new ChiTietHoaDon
                (
                    row["Mã hóa đơn"].ToString(),     // Mã hóa đơn
                    row["Mã sách"].ToString(),        // Mã sách
                    Convert.ToInt32(row["Số lượng"]), // Số lượng
                    Convert.ToDouble(row["Thành tiền"]) // Thành tiền
                );

                list_CT_HD.Add(chiTietHoa);
            }

            // Gán danh sách vào DataGridView
            grid_nv.DataSource = list_CT_HD;

            // Thiết lập tiêu đề cột cho DataGridView
            grid_nv.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            grid_nv.Columns["MaSach"].HeaderText = "Mã Sách";
            grid_nv.Columns["SoLuong"].HeaderText = "Số Lượng";
            grid_nv.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";

        }

        private void txt_Ma_HD_TextChanged(object sender, EventArgs e)
        {
            grid_nv.DataSource = null; // Xóa nguồn dữ liệu hiện tại
            list_CT_HD.Clear();        // Xóa danh sách chi tiết hóa đơn

            string maHD = txt_Ma_HD.Text.Trim(); // Lấy giá trị Mã hóa đơn từ textbox

            // Câu truy vấn SQL lấy dữ liệu dựa trên Mã hóa đơn
            string sqlSelect = @"
        SELECT 
            HOADON.MAHD AS [Mã hóa đơn],
            SACH.MASH AS [Mã sách],
            CT_HOADON.SOLUONG AS [Số lượng],
            CT_HOADON.THANHTIEN AS [Thành tiền]
        FROM 
            HOADON
        JOIN 
            CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD
        JOIN 
            SACH ON CT_HOADON.MASH = SACH.MASH
        WHERE 
            HOADON.MAHD LIKE N'%" + maHD + "%'";

            // Lấy dữ liệu từ cơ sở dữ liệu
            DataTable dt = data.getDataTable(sqlSelect);

            // Duyệt qua DataTable và thêm vào danh sách chi tiết hóa đơn
            foreach (DataRow row in dt.Rows)
            {
                ChiTietHoaDon chiTietHoa = new ChiTietHoaDon
                (
                    row["Mã hóa đơn"].ToString(),     // Mã hóa đơn
                    row["Mã sách"].ToString(),        // Mã sách
                    Convert.ToInt32(row["Số lượng"]), // Số lượng
                    Convert.ToDouble(row["Thành tiền"]) // Thành tiền
                );

                list_CT_HD.Add(chiTietHoa);
            }

            // Gán danh sách vào DataGridView
            grid_nv.DataSource = list_CT_HD;

            // Thiết lập tiêu đề cột cho DataGridView
            grid_nv.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            grid_nv.Columns["MaSach"].HeaderText = "Mã Sách";
            grid_nv.Columns["SoLuong"].HeaderText = "Số Lượng";
            grid_nv.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
        }

        private void grid_nv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grid_nv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grid_nv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào một dòng hợp lệ
            {
                // Lấy dòng được chọn
                DataGridViewRow row = grid_nv.Rows[e.RowIndex];

                // Tạo đối tượng ChiTietHoaDon từ dữ liệu của dòng
                ChiTietHoaDon chiTietHoa = new ChiTietHoaDon
                (
                    row.Cells["MaHoaDon"].Value.ToString(),  // Mã hóa đơn
                    row.Cells["MaSach"].Value.ToString(),   // Mã sách
                    Convert.ToInt32(row.Cells["SoLuong"].Value), // Số lượng
                    Convert.ToDouble(row.Cells["ThanhTien"].Value) // Thành tiền
                );

                // Mở form F_Tuy_Chinh_Chi_Tiet_HD và truyền đối tượng ChiTietHoaDon
                F_Tuy_Chinh_Chi_Tiet_HD form = new F_Tuy_Chinh_Chi_Tiet_HD(chiTietHoa);
                form.ShowDialog();
            }
        }
        private void LoadChiTietHoaDon()
        {
            try
            {
                // Xóa dữ liệu cũ
                grid_nv.DataSource = null;
                list_CT_HD.Clear();

                // Câu truy vấn SQL để lấy tất cả dữ liệu chi tiết hóa đơn
                string sqlSelect = @"
            SELECT 
                HOADON.MAHD AS [Mã hóa đơn],
                SACH.MASH AS [Mã sách],
                CT_HOADON.SOLUONG AS [Số lượng],
                CT_HOADON.THANHTIEN AS [Thành tiền]
            FROM 
                HOADON
            JOIN 
                CT_HOADON ON HOADON.MAHD = CT_HOADON.MAHD
            JOIN 
                SACH ON CT_HOADON.MASH = SACH.MASH";

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dt = data.getDataTable(sqlSelect);

                // Duyệt qua DataTable và thêm vào danh sách chi tiết hóa đơn
                foreach (DataRow row in dt.Rows)
                {
                    ChiTietHoaDon chiTietHoa = new ChiTietHoaDon
                    (
                        row["Mã hóa đơn"].ToString(),     // Mã hóa đơn
                        row["Mã sách"].ToString(),        // Mã sách
                        Convert.ToInt32(row["Số lượng"]), // Số lượng
                        Convert.ToDouble(row["Thành tiền"]) // Thành tiền
                    );

                    list_CT_HD.Add(chiTietHoa);
                }

                // Gán danh sách vào DataGridView
                grid_nv.DataSource = list_CT_HD;

                // Thiết lập tiêu đề cột cho DataGridView
                grid_nv.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                grid_nv.Columns["MaSach"].HeaderText = "Mã Sách";
                grid_nv.Columns["SoLuong"].HeaderText = "Số Lượng";
                grid_nv.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Lam_Moi_Click(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void btn_Hoan_Tra_Toan_Bo_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã hóa đơn từ textbox
                string maHD = txt_Ma_HD.Text.Trim();

                if (string.IsNullOrEmpty(maHD))
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn để thực hiện hoàn trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Câu truy vấn SQL để xóa toàn bộ chi tiết hóa đơn
                string sqlDelete = @"
            DELETE FROM CT_HOADON 
            WHERE MAHD = '" + maHD + "'";

                // Thực thi câu truy vấn xóa chi tiết hóa đơn
                int rowsAffected = data.getNonQuery(sqlDelete);

                // Kiểm tra số dòng bị ảnh hưởng
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Toàn bộ chi tiết hóa đơn đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với mã này hoặc chi tiết hóa đơn đã được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Làm mới lại danh sách chi tiết hóa đơn
                LoadChiTietHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
