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
    public partial class F_Register : Form
    {
        bool isRegister = false;
        DBConnect data = new DBConnect();
        public F_Register()
        {
            InitializeComponent();

        }


        private void txt_confirmpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool KiemTraMaNhanVien()
        {
            string strSlec = "select * from NhanVien where SDT ='" + txtSDT.Text + "';";
            object kq = data.getScalar(strSlec);
            if (kq == null)
            {
                return true;
            }
            MessageBox.Show("Nhân viên này đã có tài khoản");
            return false;
        }
        public List<ChucVu> getAll_CV(DBConnect dbConnect)
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            string sql = "SELECT MaCV, TenCV FROM CHUCVU";


            SqlDataReader rd = dbConnect.getReader(sql);

            while (rd.Read())
            {

                ChucVu cv = new ChucVu(rd["MaCV"].ToString(), rd["TenCV"].ToString());
                chucVus.Add(cv);
            }

            rd.Close();
            dbConnect.Close();

            return chucVus;
        }
        public void loadCV()
        {
            List<ChucVu> listChucVu = getAll_CV(new DBConnect());
            cbo_chucvu.DataSource = listChucVu;
            cbo_chucvu.DisplayMember = "TenCV";
            cbo_chucvu.ValueMember = "MaCV";
        }

        public bool ThemAccount(NhanVien nv)
        {

            string strSql = "INSERT INTO NHANVIEN VALUES ('" + nv.MaNV + "', '" + nv.TENNV + "', '" + nv.MK + "', '" + nv.SDT + "', '" + nv.GIOITINH + "','" + nv.MACV + "')";
            int kq = data.getNonQuery(strSql);
            if (kq > 0)
            {
                return true;
            }
            return false;

        }
        public string TaoMaNV()
        {
            string sql = "select top 1 MaNV from NHanVien order by MaNV desc ";
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
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (isRegister == true)
            {
                if (KiemTraMaNhanVien() == true)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = TaoMaNV(),
                        TENNV = txttennv.Text,
                        MK = txtpass.Text,
                        SDT = txtSDT.Text,
                        GIOITINH = cbo_sex.SelectedItem.ToString(),
                        MACV = cbo_chucvu.SelectedValue.ToString()
                    };

                    if (ThemAccount(nv) == true)
                    {
                        MessageBox.Show("Tạo tài khoảng thành công");
                        return;
                    }
                    MessageBox.Show("Tạo tài khoảng thất bại");
                }
            }
            else
            {
                MessageBox.Show("Vui long điền chính xác các thông tin");
            }
        }

        private void F_Register_Load(object sender, EventArgs e)
        {
            loadCV();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text.Trim().Length < 3)
            {
                isRegister = false;
                errorProvider1.SetError(txtpass, "Password tối thiểu 3 kí tự ");
            }
            else
            {
                isRegister = true;
                errorProvider1.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_Login f_Login = new F_Login();
            f_Login.Show();
            this.Hide();
        }
    }
}
