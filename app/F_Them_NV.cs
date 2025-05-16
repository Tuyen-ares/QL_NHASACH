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
    public partial class F_Them_NV : Form
    {
        DBConnect data = new DBConnect();
        List<ChucVu2> listCV = new List<ChucVu2>();
        bool checkSDT = true;
        public F_Them_NV()
        {
            InitializeComponent();
            txt_ma.Text = generateID();
            txt_ma.ReadOnly = true;
            loadChucVu();
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
            cbb_cv.SelectedItem = null;
        }
        //Tạo mã nhân viên
        string generateID()
        {
            string sql = "select top 1 MANV from NhanVien order by MANV desc ";
            DataTable dt = data.getDataTable(sql);
            if (dt.Rows.Count == 0)
                return "NV001";
            string ma = dt.Rows[0][0].ToString();
            int so = int.Parse(ma.Substring(3)) + 1;

            if (so < 10)
                return "NV00" + so;
            if (so < 100)
                return "NV0" + so;

            return "NV" + so;
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!checkSDT)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                return;
            }
            if (txt_ma.Text.Length == 0 || txt_ten.Text.Length == 0 ||
                txt_mk.Text.Length == 0 || txt_sdt.Text.Length == 0 ||
                cbb_cv.Text.Length == 0 || cbb_gt.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                return;
            }
            NhanVien nv = new NhanVien(txt_ma.Text, txt_ten.Text, txt_mk.Text, txt_sdt.Text, cbb_gt.Text, cbb_cv.SelectedValue.ToString());
            string strInsert = "Insert into NhanVien Values " +
                "('" + nv.MaNV + "',N'" + nv.TENNV + "','" + nv.MK + "','" + nv.SDT + "',N'" + nv.GIOITINH + "','" + nv.MACV + "')";
            int kq = data.getNonQuery(strInsert);
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Thêm thất bại");

        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            if (txt_sdt.Text.Length > 10)
            {
                errorProvider1.SetError(txt_sdt, "Số điện thoại không vượt quá 10 số ");
                checkSDT = false;
            }
            else
            {
                errorProvider1.SetError(txt_sdt, string.Empty);
                checkSDT = true;
            }


        }
        //




    }
}
