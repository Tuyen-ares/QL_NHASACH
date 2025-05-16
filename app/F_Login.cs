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
    public partial class F_Login : Form
    {
        public string strConnect = @"Data Source=DESKTOP-C4ALSJO\SQLEXPRESS; Initial Catalog=QL_NHASACH;Integrated Security=True";
        public DBConnect db;
        public F_Login()
        {
            db = new DBConnect(strConnect);
            InitializeComponent();
        }
        



        public List<NhanVien> GetNhanVien(string tentk, string pass)
        {
            List<NhanVien> list = new List<NhanVien>();
            string sqlnv = "SELECT * FROM NhanVien WHERE MANV = @tentk AND MK = @pass";
            using (SqlConnection con = new SqlConnection(strConnect))
            {
                con.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlnv, con))
                {
                    sqlCommand.Parameters.AddWithValue("@tentk", tentk);
                    sqlCommand.Parameters.AddWithValue("@pass", pass);

                    using (SqlDataReader r = sqlCommand.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new NhanVien(r.GetString(0),
                                              r.GetString(1),
                                              r.GetString(2),
                                              r.GetString(3),
                                              r.GetString(4),
                                              r.GetString(5)));
                        }
                    }
                }
            }
            return list;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<NhanVien> nhanViens = new List<NhanVien>();
            nhanViens = GetNhanVien(username, pass);
            if (nhanViens.Count > 0)
            {
                DBConnect data = new DBConnect();
                string str = "SELECT TENCV " +
              "FROM NhanVien, CHUCVU " +
              "WHERE NhanVien.MACV = CHUCVU.MACV " +
              "AND NHANVIEN.MANV = '" + txtUsername.Text.Replace("'", "''") + "'";
                object kq = data.getScalar(str);
                string phanQuyen = kq.ToString();
                NhanVien nhanvien = nhanViens[0];
                F_Layout f_Layout = new F_Layout(phanQuyen, nhanvien.TENNV, nhanvien.MaNV);
                f_Layout.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Sai thông tin đăng nhập ");
            }


        }



        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_Register f_Register = new F_Register();
            f_Register.Show();
            this.Hide();
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {

                txtPassword.PasswordChar = '\0';
            }
            else
            {

                txtPassword.PasswordChar = '*';
            }
        }
    }
}
