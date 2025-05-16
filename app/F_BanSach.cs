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
    public partial class F_BanSach : Form
    {
        DBConnect connect = new DBConnect();
        SqlConnection conn;
        public F_BanSach()
        {
            InitializeComponent();
        }

        private void F_BanSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxSach();
            SinhMaHoaDon();
            LoadMaNV();
            cboChonSach.SelectedIndexChanged += cboChonSach_SelectedIndexChanged;
            dataGridView_SachBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_SachBan.Columns["DONGIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_SachBan.Columns["THANHTIEN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void SinhMaHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();

                string query = "SELECT COUNT(MAHD) FROM HOADON";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                // Tự động sinh mã theo định dạng: HD + số thứ tự
                txtMaHD.Text = "HD" + count.ToString("000"); // Ví dụ: HD001, HD002
            }
        }

        private void LoadComboBoxSach()
        {
            string query = "SELECT MASH, TENSH FROM SACH";
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cboChonSach.DataSource = dt;
                cboChonSach.DisplayMember = "TENSH";
                cboChonSach.ValueMember = "MASH";
                cboChonSach.SelectedIndex = -1;
                txtMaSach.Text = "";
            }
        }

        public bool checkSL (string ma , int sl)
        {
            string sql = "select TONKHO from SACH WHERE MASH ='" + ma + "'";
            object sl11 = connect.getScalar(sql);
            int kq = int.Parse(sl11.ToString());
            if(kq > sl)
            {
                return true;
            }
            return false;

        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            if (cboChonSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = cboChonSach.SelectedValue.ToString();
            string tenSach = cboChonSach.Text;

            if (!float.TryParse(txtDonGia.Text, out float donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không   hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(checkSL (txtMaSach.Text, int.Parse(txtSoLuong.Text)))
            {
                float thanhTien = donGia * soLuong;
                dataGridView_SachBan.Rows.Add(maSach, tenSach, donGia, soLuong, thanhTien);
                TinhTongTien();
                return;
            }
            MessageBox.Show("Số lượng không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void TinhTongTien()
        {
            float tongTien = 0;
            foreach (DataGridViewRow row in dataGridView_SachBan.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += float.Parse(row.Cells["ThanhTien"].Value.ToString());
                }
            }
            txtTongTien.Text = tongTien.ToString();
        }

        private void button_ThanhToan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();
                foreach (DataGridViewRow row in dataGridView_SachBan.Rows)
                {
                    if (row.Cells["MASH"].Value != null)
                    {
                        string maSach = row.Cells["MASH"].Value.ToString();
                        int soLuongBan = int.Parse(row.Cells["SoLuong"].Value.ToString());

                        string queryUpdateTonKho = "UPDATE SACH SET TONKHO = TONKHO - @SOLUONGBAN WHERE MASH = @MASH";
                        SqlCommand cmd = new SqlCommand(queryUpdateTonKho, conn);
                        cmd.Parameters.AddWithValue("@SOLUONGBAN", soLuongBan);
                        cmd.Parameters.AddWithValue("@MASH", maSach);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Thanh toán thành công!");
        }

        private void cboChonSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonSach.SelectedValue != null)
            {
                string maSach = cboChonSach.SelectedValue.ToString();
                txtMaSach.Text = maSach;
                LoadThongTinSach(maSach);
            }
        }
        private void LoadThongTinSach(string maSach)
        {
            string query = "SELECT GIABAN FROM SACH WHERE MASH = @MASH";
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASH", maSach);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtDonGia.Text = reader["GIABAN"].ToString();
                }
                reader.Close();
            }
        }
        private void LoadMaNV()
        {
            string query = "SELECT MANV FROM NHANVIEN";

            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboChonMNV.Items.Clear();

                    while (reader.Read())
                    {
                        string maNV = reader["MANV"].ToString();
                        cboChonMNV.Items.Add(maNV);
                    }

                    reader.Close();

                    if (cboChonMNV.Items.Count > 0)
                    {
                        cboChonMNV.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách mã nhân viên: " + ex.Message);
                }
            }
        }

        private void button_Huy_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtGioiTinh.Clear();
            dataGridView_SachBan.Rows.Clear();
            txtTongTien.Clear();
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            string maKH = txtMaKH.Text;
            string maNV = cboChonMNV.SelectedItem?.ToString();
            DateTime ngayLap = DateTime.Now;
            float tongTien = float.Parse(txtTongTien.Text);

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string queryHD = "INSERT INTO HOADON (MAHD, NGAYLAP, MAKH, MANV, TONGTIEN) VALUES (@MAHD, @NGAYLAP, @MAKH, @MANV, @TONGTIEN)";

            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryHD, conn);
                    cmd.Parameters.AddWithValue("@MAHD", maHD);
                    cmd.Parameters.AddWithValue("@NGAYLAP", ngayLap);
                    cmd.Parameters.AddWithValue("@MAKH", maKH);
                    cmd.Parameters.AddWithValue("@MANV", maNV);
                    cmd.Parameters.AddWithValue("@TONGTIEN", tongTien);
                    cmd.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridView_SachBan.Rows)
                    {
                        if (row.Cells["MASH"].Value != null)
                        {
                            string maSach = row.Cells["MASH"].Value.ToString();
                            int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                            float thanhTien = float.Parse(row.Cells["ThanhTien"].Value.ToString());

                            string queryCTHD = "INSERT INTO CT_HOADON (MAHD, MASH, SOLUONG, THANHTIEN) VALUES (@MAHD, @MASH, @SOLUONG, @THANHTIEN)";
                            SqlCommand cmdCTHD = new SqlCommand(queryCTHD, conn);
                            cmdCTHD.Parameters.AddWithValue("@MAHD", maHD);
                            cmdCTHD.Parameters.AddWithValue("@MASH", maSach);
                            cmdCTHD.Parameters.AddWithValue("@SOLUONG", soLuong);
                            cmdCTHD.Parameters.AddWithValue("@THANHTIEN", thanhTien);
                            cmdCTHD.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox_KhachHang_Enter(object sender, EventArgs e)
        {
            //////////////
        }

        private void button_ThemKH_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string sdt = txtSDT.Text;
            string gioiTinh = txtGioiTinh.Text;

            string query = "INSERT INTO KHACHHANG (MAKH, TENKH, SDT, GIOITINH) VALUES (@MAKH, @TENKH, @SDT, @GIOITINH)";
            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.Parameters.AddWithValue("@TENKH", tenKH);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

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

        private void dataGridView_SachBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.strConnect))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT MAKH, TENKH, SDT, GIOITINH FROM KHACHHANG WHERE SDT = @SDT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtMaKH.Text = reader["MAKH"].ToString();
                        txtTenKH.Text = reader["TENKH"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtGioiTinh.Text = reader["GIOITINH"].ToString();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng.");
                        txtTenKH.Clear();
                        txtSDT.Clear();
                        txtGioiTinh.Clear();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            //F_ThongKeHD formThongKe = new F_ThongKeHD();
            //formThongKe.ShowDialog();
        }

        private void btn_ThongKe_Click_1(object sender, EventArgs e)
        {
            F_Thong_Ke_Ban_Sach f = new F_Thong_Ke_Ban_Sach();
            f.Show();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
