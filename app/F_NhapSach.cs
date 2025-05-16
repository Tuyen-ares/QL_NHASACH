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
    public partial class F_NhapSach : Form
    {
        DBConnect connect = new DBConnect();
        SqlConnection conn;
        public F_NhapSach()
        {
            InitializeComponent();
            dataGridView_SachNhap.Columns["GIABAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_SachNhap.Columns["GIANHAP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_SachNhap.Columns["THANHTIEN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void F_NhapSach_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayLap.Value = DateTime.Now;
            txtSoLuong.KeyPress += txtSoLuong_KeyPress;
            SinhMaPhieu();
            txtGiaNhap.Leave += txtGiaNhap_Leave;
            txtGiaBan.Leave += txtGiaBan_Leave;
            dataGridView_SachNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void SinhMaPhieu()
        {
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();
                string query = "SELECT COUNT(MAPN) FROM PHIEUNHAP";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                // Tự động sinh mã theo định dạng: PN + số thứ tự
                txtMaPhieu.Text = "PN" + count.ToString("000"); // Ví dụ:PN001, PN002
            }
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text;
            string tenSach = txtTenSach.Text;

            // Kiểm tra các trường nhập liệu trước khi thêm vào DataGridView
            if (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return;
            }

            if (!int.TryParse(txtGiaNhap.Text, out int giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNhap.Focus();
                txtGiaNhap.SelectAll();
                return;
            }

            int giaBan = (int)(giaNhap * 1.2);
            float thanhTien = giaNhap * soLuong;
            string maLoai = txtMaLoai.Text;
            string maNxb = txtMaNXB.Text;

            dataGridView_SachNhap.Rows.Add(maSach, tenSach, soLuong, giaBan, giaNhap, thanhTien, maLoai, maNxb);
            TinhTongTien();
            ClearForm();
        }
        private void ClearForm()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtMaLoai.Clear();
            txtMaNXB.Clear();
            txtSoLuong.Clear();
        }

        private void button_LuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieuNhap = txtMaPhieu.Text;
                DateTime ngayLap = DateTime.Now;
                float tongTien = float.Parse(txtTongTien.Text);

                using (SqlConnection conn = new SqlConnection(connect.strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO PHIEUNHAP (MAPN, NGAYLAP, TONGTIEN) VALUES (@MAPN, @NGAYLAP, @TONGTIEN)", conn);
                    cmd.Parameters.AddWithValue("@MAPN", maPhieuNhap);
                    cmd.Parameters.AddWithValue("@NGAYLAP", ngayLap);
                    cmd.Parameters.AddWithValue("@TONGTIEN", tongTien);
                    cmd.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridView_SachNhap.Rows)
                    {
                        if (row.Cells["MASH"].Value != null && !string.IsNullOrEmpty(row.Cells["MASH"].Value.ToString()))
                        {
                            string maSach = row.Cells["MASH"].Value.ToString();
                            string tenSach = row.Cells["TENSH"].Value?.ToString() ?? "Sách Mới";
                            int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                            float giaNhap = float.Parse(row.Cells["GiaNhap"].Value.ToString());
                            float thanhTien = float.Parse(row.Cells["ThanhTien"].Value.ToString());

                            // Nếu sách đã tồn tại, cập nhật tồn kho
                            SqlCommand updateTonKhoCmd = new SqlCommand("UPDATE SACH SET TONKHO = TONKHO + @SOLUONG WHERE MASH = @MASH", conn);
                            updateTonKhoCmd.Parameters.AddWithValue("@SOLUONG", soLuong);
                            updateTonKhoCmd.Parameters.AddWithValue("@MASH", maSach);
                            updateTonKhoCmd.ExecuteNonQuery();

                            SqlCommand cmdCTPN = new SqlCommand("INSERT INTO CT_PHIEUNHAP (MAPN, MASH, SOLUONG, GIANHAP, THANHTIEN) VALUES (@MAPN, @MASH, @SOLUONG, @GIANHAP, @THANHTIEN)", conn);
                            cmdCTPN.Parameters.AddWithValue("@MAPN", maPhieuNhap);
                            cmdCTPN.Parameters.AddWithValue("@MASH", maSach);
                            cmdCTPN.Parameters.AddWithValue("@SOLUONG", soLuong);
                            cmdCTPN.Parameters.AddWithValue("@GIANHAP", giaNhap);
                            cmdCTPN.Parameters.AddWithValue("@THANHTIEN", thanhTien);
                            cmdCTPN.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Lưu phiếu nhập thành công!");
                dataGridView_SachNhap.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ////////////
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ////////////
        }
        private void TinhTongTien()
        {
            float tongTien = 0;
            foreach (DataGridViewRow row in dataGridView_SachNhap.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += float.Parse(row.Cells["ThanhTien"].Value.ToString());
                }
            }
            txtTongTien.Text = tongTien.ToString();
        }
        private void dataGridView_SachNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string maSach = txtMaSach.Text;
                string tenSach = txtTenSach.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                float giaNhap = float.Parse(txtGiaNhap.Text);
                float thanhTien = soLuong * giaNhap;

                dataGridView_SachNhap.Rows.Add(maSach, tenSach, soLuong, giaNhap, thanhTien);
                TinhTongTien();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //////
        }
        private void textBox_TongTien_TextChanged(object sender, EventArgs e)
        {
            /////
        }

        private void button_Huy_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtMaLoai.Clear();
            txtMaNXB.Clear();
            dataGridView_SachNhap.Rows.Clear();
            txtTongTien.Clear();
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0-9) và phím Backspace để xóa ký tự
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự không phải số được nhập vào
            }
        }
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                if (int.TryParse(txtSoLuong.Text, out int soLuong))
                {
                    if (soLuong <= 0)
                    {
                        MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Focus();
                        txtSoLuong.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    txtSoLuong.SelectAll();
                }
            }
        }

        private void btnTimKiemSach_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            if (string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng nhập mã sách.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh SQL lấy thêm MALOAI và MaNXB
                    string query = "SELECT TENSH, GIANHAP, TONKHO, MALOAI, MaNXB FROM SACH WHERE MASH = @MASH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MASH", maSach);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Gán dữ liệu cho các ô textbox
                        txtTenSach.Text = reader["TENSH"].ToString();
                        txtGiaNhap.Text = reader["GIANHAP"].ToString();
                        txtTonKho.Text = reader["TONKHO"].ToString();
                        txtMaLoai.Text = reader["MALOAI"].ToString();
                        txtMaNXB.Text = reader["MaNXB"].ToString();
                    }
                    else
                    {
                        // Xóa nội dung nếu không tìm thấy sách
                        MessageBox.Show("Không tìm thấy sách.");
                        txtTenSach.Clear();
                        txtGiaNhap.Clear();
                        txtTonKho.Clear();
                        txtMaLoai.Clear();
                        txtMaNXB.Clear();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void btnThemSach_Click(object sender, EventArgs e)
        {

            string maSach = txtMaSach.Text.Trim();
            string tenSach = txtTenSach.Text.Trim();
            string maLoai = txtMaLoai.Text.Trim();
            string maNXB = txtMaNXB.Text.Trim();

            if (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Vui lòng nhập mã sách và tên sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra mã sách có tồn tại chưa
                    SqlCommand checkSachCmd = new SqlCommand("SELECT COUNT(*) FROM SACH WHERE MASH = @MASH", conn);
                    checkSachCmd.Parameters.AddWithValue("@MASH", maSach);
                    int exists = Convert.ToInt32(checkSachCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("Sách đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Nếu chưa tồn tại, thêm mới sách
                    SqlCommand insertSachCmd = new SqlCommand(
                        "INSERT INTO SACH (MASH, TENSH, GIANHAP, GIABAN, TONKHO, MALOAI, MaNXB) VALUES (@MASH, @TENSH, @GIANHAP, @GIABAN, @TONKHO, @MALOAI, @MaNXB)",
                        conn
                    );

                    float giaNhap = string.IsNullOrEmpty(txtGiaNhap.Text) ? 0 : float.Parse(txtGiaNhap.Text);
                    int tonKho = string.IsNullOrEmpty(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text);

                    insertSachCmd.Parameters.AddWithValue("@MASH", maSach);
                    insertSachCmd.Parameters.AddWithValue("@TENSH", tenSach);
                    insertSachCmd.Parameters.AddWithValue("@GIANHAP", giaNhap);
                    insertSachCmd.Parameters.AddWithValue("@GIABAN", giaNhap * 1.2); // Giá bán mặc định cao hơn 20%
                    insertSachCmd.Parameters.AddWithValue("@TONKHO", tonKho);
                    insertSachCmd.Parameters.AddWithValue("@MALOAI", string.IsNullOrEmpty(maLoai) ? "LS001" : maLoai); // Mã loại mặc định
                    insertSachCmd.Parameters.AddWithValue("@MaNXB", string.IsNullOrEmpty(maNXB) ? "NXB001" : maNXB); // Mã NXB mặc định

                    insertSachCmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void txtGiaNhap_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtGiaNhap.Text, out int giaNhap))
            {
                if (giaNhap <= 0)
                {
                    if (txtGiaNhap.Tag == null) // Kiểm tra nếu chưa hiển thị thông báo
                    {
                        MessageBox.Show("Giá nhập phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaNhap.Tag = true; // Đánh dấu đã hiển thị thông báo
                        txtGiaNhap.Focus();
                        txtGiaNhap.SelectAll();
                    }
                }
                else
                {
                    txtGiaNhap.Tag = null; // Xóa cờ nếu giá trị hợp lệ
                }
            }
            else
            {
                if (txtGiaNhap.Tag == null)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaNhap.Tag = true;
                    txtGiaNhap.Focus();
                    txtGiaNhap.SelectAll();
                }
            }
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtGiaBan.Text, out int giaBan))
            {
                if (giaBan <= 0)
                {
                    if (txtGiaBan.Tag == null)
                    {
                        MessageBox.Show("Giá bán phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaBan.Tag = true;
                        txtGiaBan.Focus();
                        txtGiaBan.SelectAll();
                    }
                }
                else
                {
                    txtGiaBan.Tag = null;
                }
            }
            else
            {
                if (txtGiaBan.Tag == null)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaBan.Tag = true;
                    txtGiaBan.Focus();
                    txtGiaBan.SelectAll();
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           // F_ThongKePN formThongKe = new F_ThongKePN();
            //formThongKe.ShowDialog();
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            F_Thong_Ke_Nhap_Sach f = new F_Thong_Ke_Nhap_Sach();
            f.Show();
        }

        private void groupBox_Sach_Enter(object sender, EventArgs e)
        {

        }
    }
}
