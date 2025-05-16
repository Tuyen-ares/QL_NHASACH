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
    public partial class F_DM_CAP_Nhat_TLvaTG : Form
    {
        DBConnect db = new DBConnect();
        public F_DM_CAP_Nhat_TLvaTG()
        {
            InitializeComponent();
        }
        private void LoadTacGia()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng TACGIA
                string query = "SELECT MATG, TENTG FROM TACGIA";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                drvTacGia.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    drvTacGia.Rows.Add(row["MATG"].ToString(), row["TENTG"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLoaiSach()
        {
            try
            {
                // Lệnh SQL để lấy dữ liệu từ bảng TACGIA
                string query = "SELECT MALOAI, TENLOAI FROM LOAISACH";

                // Lấy dữ liệu từ database
                DataTable data = db.getDataTable(query);

                // Xóa các hàng cũ trong DataGridView (nếu cần)
                guna2DataGridView1.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    guna2DataGridView1.Rows.Add(row["MALOAI"].ToString(), row["TENLOAI"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_DM_CAP_Nhat_TLvaTG_Load_1(object sender, EventArgs e)
        {
            LoadTacGia();
            LoadLoaiSach();
        }
        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tìm kiếm
                string maTL = txtMaTL.Text.Trim();
                string tenTL = txttenTL.Text.Trim();

                // Lệnh SQL cơ bản
                string query = "SELECT MALOAI, TENLOAI FROM LOAISACH WHERE 1=1";

                // Thêm điều kiện tìm kiếm nếu người dùng nhập
                if (!string.IsNullOrEmpty(maTL))
                {
                    query += $" AND MALOAI LIKE '%{maTL}%'";
                }

                if (!string.IsNullOrEmpty(tenTL))
                {
                    query += $" AND TENLOAI LIKE '%{tenTL}%'";
                }

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = db.getDataTable(query);

                // Xóa dữ liệu hiện tại trong DataGridView
                guna2DataGridView1.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    guna2DataGridView1.Rows.Add(row["MALOAI"].ToString(), row["TENLOAI"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Txt_Search_TextChanged_TG(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tìm kiếm
                string maTL = txtMaTG.Text.Trim();
                string tenTL = txttenTG.Text.Trim();

                // Lệnh SQL cơ bản
                string query = "SELECT MATG, TENTG FROM TACGIA WHERE 1=1";

                // Thêm điều kiện tìm kiếm nếu người dùng nhập
                if (!string.IsNullOrEmpty(maTL))
                {
                    query += $" AND MATG LIKE '%{maTL}%'";
                }

                if (!string.IsNullOrEmpty(tenTL))
                {
                    query += $" AND TENTG LIKE '%{tenTL}%'";
                }

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = db.getDataTable(query);

                // Xóa dữ liệu hiện tại trong DataGridView
                drvTacGia.Rows.Clear();

                // Duyệt qua từng dòng trong DataTable và thêm vào DataGridView
                foreach (DataRow row in data.Rows)
                {
                    drvTacGia.Rows.Add(row["MATG"].ToString(), row["TENTG"].ToString());
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
            string maTheLoai = txtMaTL.Text.Trim();
            string tenTheLoai = txttenTL.Text.Trim();
            string maTacGia = txtMaTG.Text.Trim(); // TextBox cho mã tác giả
            string tenTacGia = txttenTG.Text.Trim(); // TextBox cho tên tác giả

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maTheLoai) && string.IsNullOrEmpty(maTacGia))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin để thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm vào loại sách nếu thông tin loại sách hợp lệ
            if (!string.IsNullOrEmpty(maTheLoai) && !string.IsNullOrEmpty(tenTheLoai))
            {
                // Kiểm tra mã thể loại trong DataGridView loại sách
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (row.Cells["drvmatheloai"].Value?.ToString() == maTheLoai)
                    {
                        MessageBox.Show("Mã thể loại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thực hiện câu lệnh SQL để thêm loại sách
                string queryLoaiSach = $"INSERT INTO LOAISACH (MALOAI, TENLOAI) VALUES ('{maTheLoai}', '{tenTheLoai}')";
                int resultLoaiSach = db.getNonQuery(queryLoaiSach); // Hàm thực thi SQL

                if (resultLoaiSach > 0)
                {
                    MessageBox.Show("Thêm loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Thêm dòng vào DataGridView loại sách
                    guna2DataGridView1.Rows.Add(maTheLoai, tenTheLoai);
                }
                else
                {
                    MessageBox.Show("Thêm loại sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Thêm vào tác giả nếu thông tin tác giả hợp lệ
            if (!string.IsNullOrEmpty(maTacGia) && !string.IsNullOrEmpty(tenTacGia))
            {
                // Kiểm tra mã tác giả trong DataGridView tác giả
                foreach (DataGridViewRow row in drvTacGia.Rows) // DGV cho tác giả
                {
                    if (row.Cells["drvmatg"].Value?.ToString() == maTacGia)
                    {
                        MessageBox.Show("Mã tác giả đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thực hiện câu lệnh SQL để thêm tác giả
                string queryTacGia = $"INSERT INTO TACGIA (MATG, TENTG) VALUES ('{maTacGia}', '{tenTacGia}')";
                int resultTacGia = db.getNonQuery(queryTacGia); // Hàm thực thi SQL

                if (resultTacGia > 0)
                {
                    MessageBox.Show("Thêm tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Thêm dòng vào DataGridView tác giả
                    drvTacGia.Rows.Add(maTacGia, tenTacGia);
                }
                else
                {
                    MessageBox.Show("Thêm tác giả thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Xóa dữ liệu trong các TextBox sau khi thêm
            txtMaTL.Clear();
            txttenTL.Clear();
            txtMaTG.Clear();
            txttenTG.Clear();

            // Đặt con trỏ vào ô nhập Mã Thể Loại hoặc Tác Giả
            if (string.IsNullOrEmpty(maTacGia)) txtMaTL.Focus();
            else txtMaTG.Focus();
        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (guna2DataGridView1.SelectedRows.Count == 0 && drvTacGia.SelectedRows.Count == 0)
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
                string maTheLoai = selectedRow1.Cells["drvmatheloai"].Value?.ToString();

                if (!string.IsNullOrEmpty(maTheLoai))
                {
                    // Kiểm tra tham chiếu đến bảng SACH
                    string checkQuery1 = $"SELECT COUNT(*) FROM SACH WHERE MALOAI = '{maTheLoai}'";
                    object result1 = db.getScalar(checkQuery1);
                    int referenceCount1 = (result1 != null && int.TryParse(result1.ToString(), out int count1)) ? count1 : 0;

                    if (referenceCount1 > 0)
                    {
                        MessageBox.Show(
                            $"Không thể xóa Mã Thể Loại '{maTheLoai}' vì dữ liệu đang được tham chiếu trong bảng SACH!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        string deleteQuery1 = $"DELETE FROM LOAISACH WHERE MALOAI = '{maTheLoai}'";
                        int resultDelete1 = db.getNonQuery(deleteQuery1);

                        if (resultDelete1 > 0)
                        {
                            guna2DataGridView1.Rows.Remove(selectedRow1);
                            MessageBox.Show($"Xóa Mã Thể Loại '{maTheLoai}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa Mã Thể Loại '{maTheLoai}' thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            // Xử lý xóa trong bảng TACGIA
            if (drvTacGia.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow2 = drvTacGia.SelectedRows[0];
                string maTacGia = selectedRow2.Cells["drvmatg"].Value?.ToString();

                if (!string.IsNullOrEmpty(maTacGia))
                {
                    // Kiểm tra tham chiếu đến bảng SACH
                    string checkQuery2 = $"SELECT COUNT(*) FROM CHITIETTACGIA WHERE MATG = '{maTacGia}'";
                    object result2 = db.getScalar(checkQuery2);
                    int referenceCount2 = (result2 != null && int.TryParse(result2.ToString(), out int count2)) ? count2 : 0;

                    if (referenceCount2 > 0)
                    {
                        MessageBox.Show(
                            $"Không thể xóa Mã Tác Giả '{maTacGia}' vì dữ liệu đang được tham chiếu trong bảng SACH!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        string deleteQuery2 = $"DELETE FROM TACGIA WHERE MATG = '{maTacGia}'";
                        int resultDelete2 = db.getNonQuery(deleteQuery2);

                        if (resultDelete2 > 0)
                        {
                            drvTacGia.Rows.Remove(selectedRow2);
                            MessageBox.Show($"Xóa Mã Tác Giả '{maTacGia}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa Mã Tác Giả '{maTacGia}' thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Lấy giá trị Mã Thể Loại và Tên Thể Loại
                string maTheLoai = row.Cells["drvmatheloai"].Value?.ToString();
                string tenTheLoai = row.Cells["drvtentheloai"].Value?.ToString();

                // Kiểm tra nếu dữ liệu không hợp lệ
                if (string.IsNullOrEmpty(maTheLoai) || string.IsNullOrEmpty(tenTheLoai))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra các dòng chưa điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isSavedSuccessfully = false;
                    break;
                }

                // Kiểm tra xem Mã Thể Loại đã tồn tại trong cơ sở dữ liệu chưa
                string checkQuery = $"SELECT COUNT(*) FROM LOAISACH WHERE MALOAI = '{maTheLoai}'";
                object result = db.getScalar(checkQuery); // Hàm kiểm tra trong cơ sở dữ liệu
                int recordCount = (result != null && int.TryParse(result.ToString(), out int count)) ? count : 0;

                if (recordCount > 0)
                {
                    // Nếu tồn tại, thực hiện cập nhật
                    string updateQuery = $"UPDATE LOAISACH SET TENLOAI = '{tenTheLoai}' WHERE MALOAI = '{maTheLoai}'";
                    int updateResult = db.getNonQuery(updateQuery);

                    if (updateResult <= 0)
                    {
                        MessageBox.Show($"Cập nhật thất bại cho Mã Thể Loại '{maTheLoai}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isSavedSuccessfully = false;
                        break;
                    }
                }
                else
                {
                    // Nếu chưa tồn tại, thực hiện thêm mới
                    string insertQuery = $"INSERT INTO LOAISACH (MALOAI, TENLOAI) VALUES ('{maTheLoai}', '{tenTheLoai}')";
                    int insertResult = db.getNonQuery(insertQuery);

                    if (insertResult <= 0)
                    {
                        MessageBox.Show($"Thêm mới thất bại cho Mã Thể Loại '{maTheLoai}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isSavedSuccessfully = false;
                        break;
                    }
                }
            }

            // Hiển thị thông báo lưu thành công
            if (isSavedSuccessfully)
            {
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }



        /*Nếu lượng dữ liệu lớn, bạn có thể dùng phương pháp tải dữ liệu ban đầu và lọc cục bộ với DataTable:
* private DataTable allData; // Lưu trữ toàn bộ dữ liệu

private void LoadData()
{
   allData = db.getDataTable("SELECT MATL, TENTL FROM THELOAI");
   guna2DataGridView1.DataSource = allData;
}

private void Txt_Search_TextChanged(object sender, EventArgs e)
{
   string filter = $"MATL LIKE '%{txtMaTL.Text.Trim()}%' AND TENTL LIKE '%{txttenTL.Text.Trim()}%'";
   (guna2DataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
}
Cách này giảm số lần truy vấn cơ sở dữ liệu, giúp ứng dụng phản hồi nhanh hơn.
*/
    }
}
