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
    public partial class F_DM_Cap_Nhat_Sach : Form
    {
        DBConnect db = new DBConnect();
        public F_DM_Cap_Nhat_Sach()
        {
            InitializeComponent();
        }

        private void F_DM_Cap_Nhat_Sach_Load(object sender, EventArgs e)
        {
            LoadSach();
            LoadComboBoxDataLoai(cmbmaloai, "LOAISACH", "MALOAI", "TENLOAI");
            LoadComboBoxDataNXB(cmbmanxb, "NHAXUATBAN", "MANXB", "TENNXB");
            
        }
        private void LoadSach()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng SACH kèm theo tên loại và tên nhà xuất bản
                string query = @"
                SELECT 
                    SACH.MASH, 
                    SACH.TENSH, 
                    SACH.GIANHAP, 
                    SACH.GIABAN, 
                    SACH.TONKHO, 
                    LOAISACH.TENLOAI, 
                    NHAXUATBAN.TENNXB 
                FROM SACH
                LEFT JOIN LOAISACH ON SACH.MALOAI = LOAISACH.MALOAI
                LEFT JOIN NHAXUATBAN ON SACH.MANXB = NHAXUATBAN.MANXB";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                guna2DataGridView1.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    guna2DataGridView1.Rows.Add(
                        row["MASH"].ToString(),
                        row["TENSH"].ToString(),
                        row["GIANHAP"].ToString(),
                        row["GIABAN"].ToString(),
                        row["TONKHO"].ToString(),
                        row["TENLOAI"].ToString(), // Hiển thị tên loại
                        row["TENNXB"].ToString()  // Hiển thị tên nhà xuất bản
                    );
                    guna2DataGridView1.Columns["drvgiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    guna2DataGridView1.Columns["drvgianhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxDataLoai(ComboBox comboBox, string tableName, string valueField, string textField)
        {
            try
            {
                string query = $"SELECT {valueField}, {textField} FROM {tableName}";

                using (SqlConnection connection = db.getConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(new ComboBoxItem
                                {
                                    Value = reader[valueField].ToString(),
                                    Text = reader[textField].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxDataNXB(ComboBox comboBox, string tableName, string valueField, string textField)
        {
            try
            {
                string query = $"SELECT {valueField}, {textField} FROM {tableName}";

                using (SqlConnection connection = db.getConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(new ComboBoxItem
                                {
                                    Value = reader[valueField].ToString(),
                                    Text = reader[textField].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchBooksInDataGridView()
        {
            // Lấy giá trị từ ComboBox
            string selectedLoai = cmbmaloai.Text.Trim();
            string selectedNXB = cmbmanxb.Text.Trim();

            // Lọc dữ liệu trong DataGridView
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool matchesFilter = true;

                // Kiểm tra MALOAI và MANXB của mỗi dòng với điều kiện tìm kiếm
                if (!string.IsNullOrEmpty(selectedLoai) && row.Cells["drvmaloai"].Value.ToString() != selectedLoai)
                {
                    matchesFilter = false;
                }

                if (!string.IsNullOrEmpty(selectedNXB) && row.Cells["drvmanxb"].Value.ToString() != selectedNXB)
                {
                    matchesFilter = false;
                }

                // Ẩn dòng không khớp với điều kiện tìm kiếm
                row.Visible = matchesFilter;
            }
        }

        private void cmbmaloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi phương thức tìm kiếm khi Mã Loại thay đổi
            SearchBooksInDataGridView();
        }

        private void cmbmanxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi phương thức tìm kiếm khi Mã Loại thay đổi
            SearchBooksInDataGridView();
        }
        private void SearchBooksInDataGridViewtxt()
        {
            // Lấy giá trị từ các TextBox
            string maSach = txtmasach.Text.Trim();
            string tenSach = txttensach.Text.Trim();
            string giaNhap = txtgianhap.Text.Trim();
            string giaBan = txtgiaban.Text.Trim();
            string tonKho = txttonkho.Text.Trim();

            // Lọc dữ liệu trong DataGridView
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue; // Bỏ qua dòng mới (dòng trống)

                bool matchesFilter = true;

                // Kiểm tra mã sách
                if (!string.IsNullOrEmpty(maSach) && !row.Cells["drvmasach"].Value.ToString().Contains(maSach))
                {
                    matchesFilter = false;
                }

                // Kiểm tra tên sách
                if (!string.IsNullOrEmpty(tenSach) && !row.Cells["drvtensach"].Value.ToString().Contains(tenSach))
                {
                    matchesFilter = false;
                }

                // Kiểm tra giá nhập
                if (!string.IsNullOrEmpty(giaNhap) && !row.Cells["drvgianhap"].Value.ToString().Contains(giaNhap))
                {
                    matchesFilter = false;
                }

                // Kiểm tra giá bán
                if (!string.IsNullOrEmpty(giaBan) && !row.Cells["drvgiaban"].Value.ToString().Contains(giaBan))
                {
                    matchesFilter = false;
                }

                // Kiểm tra tồn kho
                if (!string.IsNullOrEmpty(tonKho) && !row.Cells["drvtonkho"].Value.ToString().Contains(tonKho))
                {
                    matchesFilter = false;
                }

                // Ẩn hoặc hiển thị dòng trong DataGridView dựa trên kết quả tìm kiếm
                row.Visible = matchesFilter;
            }
        }

        private void txtmasach_TextChanged(object sender, EventArgs e)
        {
            SearchBooksInDataGridViewtxt();
        }

        private void txttensach_TextChanged(object sender, EventArgs e)
        {
            SearchBooksInDataGridViewtxt();
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            //SearchBooksInDataGridViewtxt();
        }

        private void txtgiaban_TextChanged(object sender, EventArgs e)
        {
            //SearchBooksInDataGridViewtxt();
        }

        private void txttonkho_TextChanged(object sender, EventArgs e)
        {
           // SearchBooksInDataGridViewtxt();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox và ComboBox
            string maSach = txtmasach.Text.Trim();
            string tenSach = txttensach.Text.Trim();
            string giaNhap = txtgianhap.Text.Trim();
            string giaBan = txtgiaban.Text.Trim();
            string tonKho = txttonkho.Text.Trim();

            // Kiểm tra nếu có trường nào bị bỏ trống
            if (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(giaNhap) || string.IsNullOrEmpty(giaBan) || string.IsNullOrEmpty(tonKho) || cmbmaloai.SelectedItem == null || cmbmanxb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã loại và mã nhà xuất bản từ ComboBox
            string maLoai = ((ComboBoxItem)cmbmaloai.SelectedItem).Value;
            string maNXB = ((ComboBoxItem)cmbmanxb.SelectedItem).Value;

            // Câu lệnh SQL để thêm sách vào database
            string query = @"
        INSERT INTO SACH (MASH, TENSH, GIANHAP, GIABAN, TONKHO, MALOAI, MANXB)
        VALUES (@MASH, @TENSH, @GIANHAP, @GIABAN, @TONKHO, @MALOAI, @MANXB)";

            try
            {
                // Mở kết nối cơ sở dữ liệu
                using (SqlConnection connection = db.getConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@MASH", maSach);
                        command.Parameters.AddWithValue("@TENSH", tenSach);
                        command.Parameters.AddWithValue("@GIANHAP", giaNhap);
                        command.Parameters.AddWithValue("@GIABAN", giaBan);
                        command.Parameters.AddWithValue("@TONKHO", tonKho);
                        command.Parameters.AddWithValue("@MALOAI", maLoai);
                        command.Parameters.AddWithValue("@MANXB", maNXB);

                        // Thực thi câu lệnh SQL để thêm sách vào database                       
                        command.ExecuteNonQuery();
                    }

                    // Đóng kết nối sau khi thực hiện xong
                    connection.Close();
                }

                // Cập nhật lại DataGridView
                LoadSach(); // Gọi lại phương thức LoadSach để làm mới DataGridView với sách vừa thêm

                // Thông báo thành công
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các trường nhập liệu sau khi thêm sách thành công
                txtmasach.Clear();
                txttensach.Clear();
                txtgianhap.Clear();
                txtgiaban.Clear();
                txttonkho.Clear();
                cmbmaloai.SelectedIndex = -1;
                cmbmanxb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Lấy mã sách từ DataGridView
            string maSach = guna2DataGridView1.SelectedRows[0].Cells["drvmasach"].Value.ToString();

            // Kiểm tra nếu không có sách được chọn
            if (string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa sách
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return; // Nếu chọn No, không thực hiện xóa
            }

            try
            {
                // Mở kết nối cơ sở dữ liệu
                using (SqlConnection connection = db.getConnection())
                {
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Xóa các bản ghi liên quan trong bảng CT_PHIEUNHAP (sách này có thể tồn tại trong phiếu nhập)
                        string deleteCTPNQuery = "DELETE FROM CT_PHIEUNHAP WHERE MASH = @MASH";
                        using (SqlCommand cmdDeleteCTPN = new SqlCommand(deleteCTPNQuery, connection, transaction))
                        {
                            cmdDeleteCTPN.Parameters.AddWithValue("@MASH", maSach);
                            cmdDeleteCTPN.ExecuteNonQuery();
                        }
                        // Xóa các bản ghi liên quan trong bảng CT_PHIEUNHAP (sách này có thể tồn tại trong phiếu nhập)
                        string deleteCTHDQuery = "DELETE FROM CT_HOADON WHERE MASH = @MASH";
                        using (SqlCommand cmdDeleteCTHD = new SqlCommand(deleteCTHDQuery, connection, transaction))
                        {
                            cmdDeleteCTHD.Parameters.AddWithValue("@MASH", maSach);
                            cmdDeleteCTHD.ExecuteNonQuery();
                        }

                        // Xóa các bản ghi liên quan trong bảng CHITIETTACGIA (sách này có thể liên kết với tác giả)
                        string deleteCTTGQuery = "DELETE FROM CHITIETTACGIA WHERE MASH = @MASH";
                        using (SqlCommand cmdDeleteCTTG = new SqlCommand(deleteCTTGQuery, connection, transaction))
                        {
                            cmdDeleteCTTG.Parameters.AddWithValue("@MASH", maSach);
                            cmdDeleteCTTG.ExecuteNonQuery();
                        }

                        // Xóa sách khỏi bảng SACH
                        string deleteSachQuery = "DELETE FROM SACH WHERE MASH = @MASH";
                        using (SqlCommand cmdDeleteSach = new SqlCommand(deleteSachQuery, connection, transaction))
                        {
                            cmdDeleteSach.Parameters.AddWithValue("@MASH", maSach);
                            cmdDeleteSach.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();

                        // Cập nhật lại DataGridView
                        LoadSach(); // Gọi lại phương thức LoadSach để làm mới DataGridView

                        // Thông báo thành công
                        MessageBox.Show("Sách đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Rollback nếu có lỗi xảy ra
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Validate selection or entry from controls
            if (guna2DataGridView1.SelectedRows.Count == 0 && string.IsNullOrEmpty(txtmasach.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng hoặc nhập mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get values from selected row if available
            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows.Count > 0 ? guna2DataGridView1.SelectedRows[0] : null;

            string maSach = selectedRow?.Cells["drvmasach"].Value?.ToString() ?? txtmasach.Text;
            string tenSach = selectedRow?.Cells["drvtensach"].Value?.ToString() ?? txttensach.Text;
            string giaNhap = selectedRow?.Cells["drvgianhap"].Value?.ToString() ?? txtgianhap.Text;
            string giaBan = selectedRow?.Cells["drvgiaban"].Value?.ToString() ?? txtgiaban.Text;
            string tonKho = selectedRow?.Cells["drvtonkho"].Value?.ToString() ?? txttonkho.Text;
            string tenLoai = selectedRow?.Cells["drvmaloai"].Value?.ToString() ?? cmbmaloai.Text;
            string tenNXB = selectedRow?.Cells["drvmanxb"].Value?.ToString() ?? cmbmanxb.Text;

            // Validate required fields
            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(giaNhap) ||
                string.IsNullOrEmpty(giaBan) || string.IsNullOrEmpty(tonKho) ||
                string.IsNullOrEmpty(tenLoai) || string.IsNullOrEmpty(tenNXB))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = db.getConnection())
                {
                    // Lấy MALOAI từ TENLOAI
                    string maLoai = null;
                    using (SqlCommand cmdLoai = new SqlCommand("SELECT MALOAI FROM LOAISACH WHERE TENLOAI = @TENLOAI", connection))
                    {
                        cmdLoai.Parameters.AddWithValue("@TENLOAI", tenLoai);
                        maLoai = cmdLoai.ExecuteScalar()?.ToString();
                    }

                    // Lấy MANXB từ TENNXB
                    string maNXB = null;
                    using (SqlCommand cmdNXB = new SqlCommand("SELECT MANXB FROM NHAXUATBAN WHERE TENNXB = @TENNXB", connection))
                    {
                        cmdNXB.Parameters.AddWithValue("@TENNXB", tenNXB);
                        maNXB = cmdNXB.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(maNXB))
                    {
                        MessageBox.Show("Không tìm thấy Mã Loại hoặc Mã Nhà Xuất Bản phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Determine whether to insert or update
                    bool isNew = string.IsNullOrEmpty(maSach) || selectedRow == null;

                    string query;
                    if (isNew)
                    {
                        query = @"
                                INSERT INTO SACH (MASH, TENSH, GIANHAP, GIABAN, TONKHO, MALOAI, MANXB)
                                VALUES (@MASH, @TENSH, @GIANHAP, @GIABAN, @TONKHO, @MALOAI, @MANXB)";

                    }
                    else
                    {
                        query = @"
    UPDATE SACH
    SET TENSH = @TENSH, GIANHAP = @GIANHAP, GIABAN = @GIABAN, TONKHO = @TONKHO, MALOAI = @MALOAI, MANXB = @MANXB
    WHERE MASH = @MASH";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MASH", maSach);
                        command.Parameters.AddWithValue("@TENSH", tenSach);
                        command.Parameters.AddWithValue("@GIANHAP", giaNhap);
                        command.Parameters.AddWithValue("@GIABAN", giaBan);
                        command.Parameters.AddWithValue("@TONKHO", tonKho);
                        command.Parameters.AddWithValue("@MALOAI", maLoai);
                        command.Parameters.AddWithValue("@MANXB", maNXB);

                        command.ExecuteNonQuery();
                    }
                }

                // Cập nhật lại giao diện
                LoadSach();

                // Hiển thị thông báo thành công
                MessageBox.Show(string.IsNullOrEmpty(maSach)
                    ? "Thêm mới sách thành công!"
                    : "Cập nhật sách thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ DataGridView vào các TextBox và ComboBox
                txtmasach.Text = row.Cells["drvmasach"].Value?.ToString();
                txttensach.Text = row.Cells["drvtensach"].Value?.ToString();
                txtgianhap.Text = row.Cells["drvgianhap"].Value?.ToString();
                txtgiaban.Text = row.Cells["drvgiaban"].Value?.ToString();
                txttonkho.Text = row.Cells["drvtonkho"].Value?.ToString();

                // Gán giá trị vào ComboBox MALOAI và MaNXB (nếu có sẵn danh sách trong ComboBox)
                cmbmaloai.SelectedItem = cmbmaloai.Items
                    .Cast<object>()
                    .FirstOrDefault(item => item.ToString() == row.Cells["drvmaloai"].Value?.ToString());

                cmbmanxb.SelectedItem = cmbmanxb.Items
                    .Cast<object>()
                    .FirstOrDefault(item => item.ToString() == row.Cells["drvmanxb"].Value?.ToString());
            }
        }

    }
}
