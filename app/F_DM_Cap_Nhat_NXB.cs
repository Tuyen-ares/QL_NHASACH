using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using app.model;
namespace app
{
    public partial class F_DM_Cap_Nhat_NXB : Form
    {
        DBConnect db = new DBConnect();
        public F_DM_Cap_Nhat_NXB()
        {
            InitializeComponent();
            LoadNXB();

        }

        private void F_DM_Cap_Nhat_NXB_Load(object sender, EventArgs e)
        {
            LoadNXB();
        }
        private void LoadNXB()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng TACGIA
                string query = "SELECT MANXB, TENNXB, DIACHI, SODIENTHOAI, EMAIL FROM NHAXUATBAN";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                guna2DataGridView1.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    guna2DataGridView1.Rows.Add(row["MANXB"].ToString(), row["TENNXB"].ToString(), row["DIACHI"].ToString(), row["SODIENTHOAI"].ToString(), row["EMAIL"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tìm kiếm
                string maNXB = txtMaNXB.Text.Trim();
                string tenNXB = txttenNXB.Text.Trim();
                string dcNXB = txtDCNXB.Text.Trim();
                string sdtNXB = txtSDT.Text.Trim();
                string emailNXB = txtEmail.Text.Trim();

                // Lệnh SQL cơ bản
                string query = "SELECT MANXB, TENNXB, DIACHI, SODIENTHOAI, EMAIL FROM NHAXUATBAN WHERE 1=1";

                // Thêm điều kiện tìm kiếm nếu người dùng nhập
                if (!string.IsNullOrEmpty(maNXB))
                {
                    query += $" AND MANXB LIKE '%{maNXB}%'";
                }

                if (!string.IsNullOrEmpty(tenNXB))
                {
                    query += $" AND TENNXB LIKE '%{tenNXB}%'";
                }
                if (!string.IsNullOrEmpty(dcNXB))
                {
                    query += $" AND DIACHI LIKE '%{dcNXB}%'";
                }

                if (!string.IsNullOrEmpty(sdtNXB))
                {
                    query += $" AND SODIENTHOAI LIKE '%{sdtNXB}%'";
                }
                if (!string.IsNullOrEmpty(emailNXB))
                {
                    query += $" AND EMAIL LIKE '%{emailNXB}%'";
                }



                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = db.getDataTable(query);

                // Xóa dữ liệu hiện tại trong DataGridView
                guna2DataGridView1.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    guna2DataGridView1.Rows.Add(row["MANXB"].ToString(), row["TENNXB"].ToString(), row["DIACHI"].ToString(), row["SODIENTHOAI"].ToString(), row["EMAIL"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string maNXB = txtMaNXB.Text.Trim();
            string tenNXB = txttenNXB.Text.Trim();
            string dcNXB = txtDCNXB.Text.Trim(); // TextBox cho mã tác giả
            string SdtNXB = txtSDT.Text.Trim(); // TextBox cho tên tác giả
            string email = txtEmail.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maNXB) && string.IsNullOrEmpty(tenNXB) && string.IsNullOrEmpty(SdtNXB) && string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin để thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm vào loại sách nếu thông tin loại sách hợp lệ
            if (!string.IsNullOrEmpty(maNXB) && !string.IsNullOrEmpty(tenNXB) && !string.IsNullOrEmpty(dcNXB) && !string.IsNullOrEmpty(SdtNXB) && !string.IsNullOrEmpty(email))
            {
                // Kiểm tra mã thể loại trong DataGridView loại sách
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (row.Cells["drvmaNXB"].Value?.ToString() == maNXB)
                    {
                        MessageBox.Show("Mã thể loại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thực hiện câu lệnh SQL để thêm loại sách
                string queryLoaiSach = $"INSERT INTO NHAXUATBAN (MANXB, TENNXB, DIACHI, SODIENTHOAI, EMAIL) VALUES ('{maNXB}', '{tenNXB}','{dcNXB}', '{SdtNXB}', '{email}')";
                int resultLoaiSach = db.getNonQuery(queryLoaiSach); // Hàm thực thi SQL

                if (resultLoaiSach > 0)
                {
                    MessageBox.Show("Thêm loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Thêm dòng vào DataGridView loại sách
                    guna2DataGridView1.Rows.Add(maNXB, tenNXB, dcNXB, SdtNXB, email);
                }
                else
                {
                    MessageBox.Show("Thêm loại sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Xóa dữ liệu trong các TextBox sau khi thêm
            txtMaNXB.Clear();
            txttenNXB.Clear();
            txtDCNXB.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            // Đặt con trỏ vào ô nhập Mã Thể Loại hoặc Tác Giả
            if (string.IsNullOrEmpty(maNXB)) txtMaNXB.Focus();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa các dòng đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            // Xử lý xóa trong bảng LOAISACH
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow1 = guna2DataGridView1.SelectedRows[0];
                string maNXB = selectedRow1.Cells["drvmanxb"].Value?.ToString();

                if (!string.IsNullOrEmpty(maNXB))
                {
                    // Kiểm tra tham chiếu đến bảng SACH
                    string checkQuery1 = $"SELECT COUNT(*) FROM SACH WHERE MANXB = '{maNXB}'";
                    object result1 = db.getScalar(checkQuery1);
                    int referenceCount1 = (result1 != null && int.TryParse(result1.ToString(), out int count1)) ? count1 : 0;

                    if (referenceCount1 > 0)
                    {
                        MessageBox.Show(
                            $"Không thể xóa Mã Nhà Xuất Bản '{maNXB}' vì dữ liệu đang được tham chiếu trong bảng SACH!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        string deleteQuery1 = $"DELETE FROM NHAXUATBAN WHERE MANXB = '{maNXB}'";
                        int resultDelete1 = db.getNonQuery(deleteQuery1);

                        if (resultDelete1 > 0)
                        {
                            guna2DataGridView1.Rows.Remove(selectedRow1);
                            MessageBox.Show($"Xóa Mã Nhà Xuất Bản '{maNXB}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa Mã Nhà Xuất Bản '{maNXB}' thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào trong DataGridView
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSavedSuccessfully = true;

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                // Bỏ qua dòng mới (NewRow)
                if (row.IsNewRow)
                    continue;

                // Lấy giá trị từ các cột, kiểm tra null trước khi chuyển đổi
                string maNXB = row.Cells["drvmanxb"].Value?.ToString();
                string tenNXB = row.Cells["drvtennxb"].Value?.ToString();
                string dcNXB = row.Cells["drvdiachinxb"].Value?.ToString();
                string stdNXB = row.Cells["drvsdt"].Value?.ToString();
                string email = row.Cells["drvemail"].Value?.ToString();

                // Kiểm tra nếu dữ liệu không hợp lệ
                if (string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(tenNXB) || string.IsNullOrEmpty(dcNXB) || string.IsNullOrEmpty(stdNXB) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show($"Dữ liệu không hợp lệ ở dòng {row.Index + 1}! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isSavedSuccessfully = false;
                    break;
                }

                try
                {
                    // Kiểm tra xem Mã NXB đã tồn tại trong cơ sở dữ liệu chưa
                    string checkQuery = "SELECT COUNT(*) FROM NHAXUATBAN WHERE MANXB = @maNXB";
                    int recordCount = 0;

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, db.getConnection()))
                    {
                        checkCmd.Parameters.AddWithValue("@maNXB", maNXB);
                        recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    }

                    if (recordCount > 0)
                    {
                        // Nếu tồn tại, thực hiện cập nhật
                        string updateQuery = "UPDATE NHAXUATBAN SET TENNXB = @tenNXB, DIACHI = @dcNXB, SODIENTHOAI = @stdNXB, EMAIL = @eamil WHERE MANXB = @maNXB";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.getConnection()))
                        {
                            updateCmd.Parameters.AddWithValue("@tenNXB", tenNXB);
                            updateCmd.Parameters.AddWithValue("@dcNXB", dcNXB);
                            updateCmd.Parameters.AddWithValue("@stdNXB", stdNXB);
                            updateCmd.Parameters.AddWithValue("@eamil", email);
                            updateCmd.Parameters.AddWithValue("@maNXB", maNXB);

                            int updateResult = updateCmd.ExecuteNonQuery();

                            if (updateResult <= 0)
                            {
                                throw new Exception($"Cập nhật thất bại cho mã Nhà xuất bản '{maNXB}'!");
                            }
                        }
                    }
                    else
                    {
                        // Nếu chưa tồn tại, thực hiện thêm mới
                        string insertQuery = "INSERT INTO NHAXUATBAN (MANXB, TENNXB, DIACHI, SODIENTHOAI, EMAIL) VALUES (@maNXB, @tenNXB, @dcNXB, @stdNXB, @eamil)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, db.getConnection()))
                        {
                            insertCmd.Parameters.AddWithValue("@maNXB", maNXB);
                            insertCmd.Parameters.AddWithValue("@tenNXB", tenNXB);
                            insertCmd.Parameters.AddWithValue("@dcNXB", dcNXB);
                            insertCmd.Parameters.AddWithValue("@stdNXB", stdNXB);
                            insertCmd.Parameters.AddWithValue("@eamil", email);

                            int insertResult = insertCmd.ExecuteNonQuery();

                            if (insertResult <= 0)
                            {
                                throw new Exception($"Thêm mới thất bại cho mã Nhà xuất bản '{maNXB}'!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSavedSuccessfully = false;
                    break;
                }
            }

            // Hiển thị thông báo lưu thành công
            if (isSavedSuccessfully)
            {
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
