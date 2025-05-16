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
    public partial class F_QL_NhanVien : Form
    {
        DBConnect data = new DBConnect();
        List<NhanVien2> listNV = new List<NhanVien2>();
        List<ChucVu2> listCV = new List<ChucVu2>();
        public F_QL_NhanVien()
        {
            InitializeComponent();
            LoadDSNV();
            loadChucVu();
            LoadDSNV();
            grid_nv.AllowUserToResizeRows = false;

            // Đặt RowHeadersWidthSizeMode để cố định độ rộng
            grid_nv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            grid_nv.CellMouseEnter += grid_nv_CellMouseEnter;
            grid_nv.CellMouseLeave += grid_nv_CellMouseLeave;
        }
        //Load chức vụ
        void loadChucVu()
        {
            string sqlSelect = "select * from ChucVu";
            DataTable dt = data.getDataTable(sqlSelect);
            foreach (DataRow row in dt.Rows)
            {
                ChucVu2 cv = new ChucVu2(row["MACV"].ToString(), row["TENCV"].ToString());
                listCV.Add(cv);
            }
            cbb_chucvu.DataSource = listCV;
            cbb_chucvu.DisplayMember = "ten";
            cbb_chucvu.ValueMember = "ma";
            cbb_chucvu.SelectedItem = null;
        }
        //Load dữ liệu nhân viên
        public void LoadDSNV()
        {
            string sqlSelect = "select * from NhanVien";
            DataTable dt = data.getDataTable(sqlSelect);

            foreach (DataRow row in dt.Rows)
            {
                NhanVien2 nhanVien = new NhanVien2
                (
                    row["MANV"].ToString(),
                    row["TENNV"].ToString(),
                    row["MK"].ToString(),

                   row["SDT"].ToString(),
                   row["GIOITINH"].ToString(),
                   row["MACV"].ToString()
                );

                listNV.Add(nhanVien);
            }

            grid_nv.DataSource = listNV;

            // Đặt tên cho các cột
            grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
            grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
            grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
            grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
            grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_nv.Columns["macv"].HeaderText = "Mã công việc";
        }
        private void grid_nv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Đổi màu nền của toàn bộ dòng khi di chuột vào
            if (e.RowIndex >= 0) // Kiểm tra xem có phải là dòng hợp lệ không
            {
                for (int i = 0; i < grid_nv.Columns.Count; i++)
                {
                    grid_nv[i, e.RowIndex].Style.BackColor = Color.Yellow; // Màu nền khi hover
                }
            }
        }
        private void grid_nv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Khôi phục màu nền của toàn bộ dòng về màu mặc định
            if (e.RowIndex >= 0) // Kiểm tra xem có phải là dòng hợp lệ không
            {
                for (int i = 0; i < grid_nv.Columns.Count; i++)
                {
                    grid_nv[i, e.RowIndex].Style.BackColor = Color.White; // Màu nền mặc định
                }
            }
        }

        private void grid_nv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_nv.SelectedRows.Count > 0)
            {
                // Lấy chỉ số của hàng đầu tiên được chọn
                int selectedIndex = grid_nv.SelectedRows[0].Index;
                NhanVien2 selectNhanVien = listNV[selectedIndex];
                // Khởi tạo và hiển thị form F_TuyChinhNV
                F_TuyChinh_NV tuyChinhNV = new F_TuyChinh_NV(selectNhanVien);
                tuyChinhNV.Show(); // Đảm bảo rằng bạn gọi Show() để hiển thị form

            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            grid_nv.DataSource = null;
            listNV.Clear(); // Xóa danh sách hiện tại trước khi thêm mới
            LoadDSNV();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            grid_nv.DataSource = null;
            listNV.Clear();
            string sqlSelect = "SELECT * FROM NhanVien WHERE TENNV LIKE N'%" + txt_name.Text.ToString() + "%'";
            DataTable dt = data.getDataTable(sqlSelect);

            foreach (DataRow row in dt.Rows)
            {
                NhanVien2 nhanVien = new NhanVien2
                    (
                    row["MANV"].ToString(),
                    row["TENNV"].ToString(),
                    row["MK"].ToString(), // Thêm cột Giới tính

                    row["SDT"].ToString(),
                    row["GIOITINH"].ToString(),
                    row["MACV"].ToString()
                    );


                listNV.Add(nhanVien);
            }

            grid_nv.DataSource = listNV;
            grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
            grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
            grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
            grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
            grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_nv.Columns["macv"].HeaderText = "Mã công việc";
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            grid_nv.DataSource = null;
            listNV.Clear();
            string sqlSelect = "SELECT * FROM NhanVien WHERE MANV LIKE N'%" + txt_id.Text.ToString() + "%'";
            DataTable dt = data.getDataTable(sqlSelect);

            foreach (DataRow row in dt.Rows)
            {
                NhanVien2 nhanVien = new NhanVien2
                    (
                    row["MANV"].ToString(),
                    row["TENNV"].ToString(),
                    row["MK"].ToString(), // Thêm cột Giới tính

                    row["SDT"].ToString(),
                    row["GIOITINH"].ToString(),
                    row["MACV"].ToString()
                    );


                listNV.Add(nhanVien);
            }

            grid_nv.DataSource = listNV;
            grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
            grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
            grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
            grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
            grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_nv.Columns["macv"].HeaderText = "Mã công việc";
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            grid_nv.DataSource = null;
            listNV.Clear();
            string sqlSelect = "SELECT * FROM NhanVien WHERE SDT LIKE N'%" + txt_sdt.Text.ToString() + "%'";
            DataTable dt = data.getDataTable(sqlSelect);

            foreach (DataRow row in dt.Rows)
            {
                NhanVien2 nhanVien = new NhanVien2
                    (
                    row["MANV"].ToString(),
                    row["TENNV"].ToString(),
                    row["MK"].ToString(), // Thêm cột Giới tính

                    row["SDT"].ToString(),
                    row["GIOITINH"].ToString(),
                    row["MACV"].ToString()
                    );


                listNV.Add(nhanVien);
            }

            grid_nv.DataSource = listNV;
            grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
            grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
            grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
            grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
            grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_nv.Columns["macv"].HeaderText = "Mã công việc";
        }

        private void cbb_chucvu_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbb_chucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_chucvu.SelectedItem != null)
            {
                grid_nv.DataSource = null;
                listNV.Clear();
                string sqlSelect = "SELECT * FROM NhanVien WHERE MACV ='" + cbb_chucvu.SelectedValue.ToString() + "'";
                DataTable dt = data.getDataTable(sqlSelect);

                foreach (DataRow row in dt.Rows)
                {
                    NhanVien2 nhanVien = new NhanVien2
                        (
                        row["MANV"].ToString(),
                        row["TENNV"].ToString(),
                        row["MK"].ToString(), // Thêm cột Giới tính

                        row["SDT"].ToString(),
                        row["GIOITINH"].ToString(),
                        row["MACV"].ToString()
                        );


                    listNV.Add(nhanVien);
                }

                grid_nv.DataSource = listNV;
                grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
                grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
                grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
                grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
                grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
                grid_nv.Columns["macv"].HeaderText = "Mã công việc";
            }
        }

        private void cbb_gt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_gt.SelectedItem != null)
            {
                grid_nv.DataSource = null;
                listNV.Clear();
                string sqlSelect = "SELECT * FROM NhanVien WHERE GIOITINH ='" + cbb_gt.Text.ToString() + "'";
                DataTable dt = data.getDataTable(sqlSelect);

                foreach (DataRow row in dt.Rows)
                {
                    NhanVien2 nhanVien = new NhanVien2
                        (
                        row["MANV"].ToString(),
                        row["TENNV"].ToString(),
                        row["MK"].ToString(), // Thêm cột Giới tính

                        row["SDT"].ToString(),
                        row["GIOITINH"].ToString(),
                        row["MACV"].ToString()
                        );


                    listNV.Add(nhanVien);
                }

                grid_nv.DataSource = listNV;
                grid_nv.Columns["ma"].HeaderText = "Mã Nhân viên";
                grid_nv.Columns["ten"].HeaderText = "Họ và Tên";
                grid_nv.Columns["mk"].HeaderText = "Mật khẩu"; // Thêm tiêu đề cho cột Giới tính
                grid_nv.Columns["sdt"].HeaderText = "Số Điện Thoại";
                grid_nv.Columns["gioitinh"].HeaderText = "Giới tính";
                grid_nv.Columns["macv"].HeaderText = "Mã công việc";
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            F_Them_NV frm = new F_Them_NV();
            frm.ShowDialog();
        }
    }
}
