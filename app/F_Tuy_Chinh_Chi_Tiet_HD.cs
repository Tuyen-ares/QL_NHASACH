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
    public partial class F_Tuy_Chinh_Chi_Tiet_HD : Form
    {
        DBConnect db = new DBConnect();
        private ChiTietHoaDon chiTietHoaDon;
        string maSachCu;
        // Constructor nhận đối tượng ChiTietHoaDon
        public F_Tuy_Chinh_Chi_Tiet_HD(ChiTietHoaDon chiTietHoaDon)
        {
            InitializeComponent();
            this.chiTietHoaDon = chiTietHoaDon;

            // Hiển thị dữ liệu từ chi tiết hóa đơn lên các control
            DisplayChiTietHoaDon();
        }

        private void DisplayChiTietHoaDon()
        {

            
            // Ví dụ: Gán dữ liệu lên các TextBox
            txt_ma.Text = chiTietHoaDon.MaHoaDon;
            txt_ma_Sach.Text = chiTietHoaDon.MaSach;
            txt_sl.Text = chiTietHoaDon.SoLuong.ToString();
            txt_Thanh_Tien.Text = chiTietHoaDon.ThanhTien.ToString();
            LoadTenSach(txt_ma_Sach.Text);
            maSachCu = txt_ma_Sach.Text;
        }

        private void LoadTenSach(string maSach)
        {
            try
            {
                // Chuỗi truy vấn SQL để lấy tên sách dựa trên mã sách
                string sqlSelect = $"SELECT TENSH FROM SACH WHERE MASH = '{maSach}'";

                // Gọi phương thức getScalar để lấy giá trị
                object result = db.getScalar(sqlSelect);

                if (result != null)
                {
                    // Gán tên sách vào TextBox
                    txt_Ten_Sach.Text = result.ToString();
                }
                else
                {
                    // Nếu không tìm thấy sách, xóa TextBox và hiển thị thông báo
                    txt_Ten_Sach.Text = "";
                    MessageBox.Show("Không tìm thấy sách với mã: " + maSach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi khi tải tên sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ma_Sach_TextChanged(object sender, EventArgs e)
        {
            // Lấy mã sách từ TextBox
            string maSach = txt_ma_Sach.Text.Trim();

            if (!string.IsNullOrEmpty(maSach))
            {
                try
                {
                    // Chuỗi truy vấn SQL để lấy tên sách
                    string sqlSelect = $"SELECT TENSH FROM SACH WHERE MASH = '{maSach}'";

                    // Gọi phương thức getScalar để lấy tên sách
                    object result = db.getScalar(sqlSelect);

                    if (result != null)
                    {
                        // Hiển thị tên sách vào TextBox txt_Ten_Sach
                        txt_Ten_Sach.Text = result.ToString();
                    }
                    else
                    {
                        // Nếu không tìm thấy tên sách, xóa nội dung TextBox txt_Ten_Sach
                        txt_Ten_Sach.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("Lỗi khi lấy tên sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Xóa nội dung TextBox txt_Ten_Sach nếu mã sách bị xóa
                txt_Ten_Sach.Text = "";
            }
        }

        private void txt_sl_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị số lượng từ txt_sl
            if (int.TryParse(txt_sl.Text.Trim(), out int soLuong) && soLuong > 0)
            {
                try
                {
                    // Lấy mã sách từ txt_ma_Sach
                    string maSach = txt_ma_Sach.Text.Trim();

                    if (!string.IsNullOrEmpty(maSach))
                    {
                        // Truy vấn để lấy giá sách
                        string sqlSelect = $"SELECT GIABAN FROM SACH WHERE MASH = '{maSach}'";

                        // Gọi phương thức getScalar để lấy giá bán
                        object result = db.getScalar(sqlSelect);

                        if (result != null && double.TryParse(result.ToString(), out double giaBan))
                        {
                            // Tính tổng tiền
                            double thanhTien = giaBan * soLuong;

                            // Gán tổng tiền vào txt_thanh_tien
                            txt_Thanh_Tien.Text = thanhTien.ToString(); // Hiển thị định dạng số
                        }
                        else
                        {
                            // Nếu không tìm thấy giá bán, xóa txt_thanh_tien
                            txt_Thanh_Tien.Text = "";
                            MessageBox.Show("Không tìm thấy giá bán cho mã sách này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // Nếu mã sách rỗng, xóa txt_thanh_tien
                        txt_Thanh_Tien.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("Lỗi khi tính tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu số lượng không hợp lệ, xóa txt_thanh_tien
                txt_Thanh_Tien.Text = "";
            }
        }

        private void btn_Doi_Sach_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã hóa đơn và mã sách hiện tại từ form
                string maHoaDon = txt_ma.Text.Trim();
                //string maSachCu = txt_ma_Sach_Cu.Text.Trim(); // TextBox chứa mã sách cũ
                string maSachMoi = txt_ma_Sach.Text.Trim(); // TextBox chứa mã sách mới
                int soLuongMoi = int.Parse(txt_sl.Text.Trim()); // TextBox chứa số lượng mới

                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(maSachCu) || string.IsNullOrEmpty(maSachMoi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đổi sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xóa chi tiết hóa đơn cũ
                string sqlDelete = $@"
            DELETE FROM CT_HOADON
            WHERE MAHD = '{maHoaDon}' AND MASH = '{maSachCu}'";

                int rowsAffectedDelete = db.getNonQuery(sqlDelete); // Chỉ truyền chuỗi SQL vào đây
                if (rowsAffectedDelete == 0)
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn cũ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu cặp MAHD và MASH đã tồn tại trong CT_HOADON
                string sqlCheckExists = $@"
            SELECT COUNT(*) FROM CT_HOADON 
            WHERE MAHD = '{maHoaDon}' AND MASH = '{maSachMoi}'";

                int count = Convert.ToInt32(db.getScalar(sqlCheckExists));
                if (count > 0)
                {
                    // Nếu đã tồn tại, thực hiện UPDATE
                    string sqlUpdate = $@"
                UPDATE CT_HOADON
                SET SOLUONG = {soLuongMoi},
                    THANHTIEN = (SELECT GIABAN FROM SACH WHERE MASH = '{maSachMoi}') * {soLuongMoi}
                WHERE MAHD = '{maHoaDon}' AND MASH = '{maSachMoi}'";

                    int rowsAffectedUpdate = db.getNonQuery(sqlUpdate);
                    if (rowsAffectedUpdate > 0)
                    {
                        MessageBox.Show("Cập nhật chi tiết hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Nếu chưa tồn tại, thực hiện INSERT
                    string sqlInsert = $@"
                INSERT INTO CT_HOADON (MAHD, MASH, SOLUONG, THANHTIEN)
                VALUES ('{maHoaDon}', '{maSachMoi}', {soLuongMoi}, 
                    (SELECT GIABAN FROM SACH WHERE MASH = '{maSachMoi}') * {soLuongMoi})";

                    int rowsAffectedInsert = db.getNonQuery(sqlInsert);
                    if (rowsAffectedInsert > 0)
                    {
                        MessageBox.Show("Đổi sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Hoa_Tien_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã hóa đơn và mã sách từ form
                string maHoaDon = txt_ma.Text.Trim();  // TextBox chứa mã hóa đơn
                string maSach = txt_ma_Sach.Text.Trim(); // TextBox chứa mã sách (có thể chọn sách cần hoàn tiền)

                // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
                if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn và mã sách để hoàn tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Câu lệnh SQL để xóa chi tiết hóa đơn
                string sqlDelete = $@"
            DELETE FROM CT_HOADON
            WHERE MAHD = '{maHoaDon}' AND MASH = '{maSach}'";

                // Thực thi câu lệnh xóa
                int rowsAffected = db.getNonQuery(sqlDelete);  // Chỉ truyền chuỗi SQL vào đây

                // Kiểm tra kết quả sau khi thực thi câu lệnh SQL
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Chi tiết hóa đơn đã được hoàn tiền và xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới dữ liệu trên giao diện nếu cần
                    // LoadChiTietHoaDon(maHoaDon);  // Ví dụ nếu bạn muốn tải lại danh sách chi tiết hóa đơn
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn để xóa. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
