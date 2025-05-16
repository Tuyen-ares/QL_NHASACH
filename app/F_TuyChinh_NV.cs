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
    public partial class F_TuyChinh_NV : Form
    {
        NhanVien2 nv;
        List<ChucVu2> listCV = new List<ChucVu2>();
        DBConnect data = new DBConnect();
        public F_TuyChinh_NV(NhanVien2 nhanvien)
        {
            InitializeComponent();
            loadChucVu();
            loadGioiTinh();
            nv = nhanvien;
            showInfo();
        }


        void loadChucVu()
        {
            string sqlSelect = "select * from ChucVu";
            DataTable dt = data.getDataTable(sqlSelect);
            foreach (DataRow row in dt.Rows)
            {
                ChucVu2 cv = new ChucVu2(row["MACV"].ToString(), row["TENCV"].ToString());
                listCV.Add(cv);
            }
            cbb_cv.DataSource = listCV;
            cbb_cv.DisplayMember = "ten";
            cbb_cv.ValueMember = "ma";
        }
        void loadGioiTinh()
        {
            cbb_gt.Items.Add("Nam");
            cbb_gt.Items.Add("Nữ");
        }
        public void showInfo()
        {
            txt_ma.Text = nv.ma;
            txt_ten.Text = nv.ten;
            txt_mk.Text = nv.mk;
            txt_sdt.Text = nv.sdt;
            cbb_cv.SelectedValue = nv.macv;
            cbb_gt.SelectedIndex = nv.gioitinh == "Nữ" ? 1 : 0;

            txt_ma.ReadOnly = true;
            txt_ten.ReadOnly = true;
            txt_mk.ReadOnly = true;
            txt_sdt.ReadOnly = true;
            cbb_cv.Enabled = false;
            cbb_gt.Enabled = false;

            btn_update.Enabled = false;

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            txt_ma.ReadOnly = false;

            txt_ten.ReadOnly = false;
            txt_mk.ReadOnly = false;
            txt_sdt.ReadOnly = false;
            cbb_cv.Enabled = true;
            cbb_gt.Enabled = true;
            txt_ten.Focus();
            btn_update.Enabled = true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text.Length == 0 || txt_ten.Text.Length == 0 || txt_mk.Text.Length == 0
                || txt_sdt.Text.Length == 0 || cbb_cv.Text.Length == 0 || cbb_gt.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sqlUpdate = "UPDATE NhanVien SET "
             + "TENNV = N'" + txt_ten.Text.ToString() + "', "
              + "MK = N'" + txt_mk.Text.ToString() + "', "
               + "SDT = '" + txt_sdt.Text.ToString() + "', "
                + "GIOITINH = N'" + cbb_gt.SelectedItem.ToString() + "', "
             + "MACV = '" + cbb_cv.SelectedValue.ToString() + "', "
             + " WHERE MANV = '" + txt_ma.Text.ToString() + "'";


            int kq = data.getNonQuery(sqlUpdate);
            if (kq != 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại ");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string strDelNV = "Update Hoadon Set MaNV = NULL where MANV =  '" + txt_ma.Text + "'" +
                    "delete from NhanVien where MANV ='" + txt_ma.Text + "' ";

                int kq = data.getNonQuery(strDelNV);
                if (kq != 0)
                {
                    MessageBox.Show("Thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }

        }


    }
}
