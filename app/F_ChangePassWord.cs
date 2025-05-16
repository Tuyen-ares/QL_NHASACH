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
    public partial class F_ChangePassWord : Form
    {
        public F_ChangePassWord()
        {
            InitializeComponent();
        }

        public string MANV { get; set; }
        public F_ChangePassWord(string manv)
        {
            InitializeComponent();
            this.MANV = manv;
        }



        private void F_ChangePassWord_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect data = new DBConnect();


            string strsql = "SELECT MK FROM NhanVien WHERE MANV = '" + MANV + "'";
            object kq = data.getScalar(strsql);
            string getpass = kq?.ToString();

            if (string.IsNullOrEmpty(getpass))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên hoặc mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!getpass.Equals(txtpassold.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtpassnew.Text.Equals(txtconfirmpass.Text))
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string update = "UPDATE NhanVien SET MK = '" + txtpassnew.Text + "' WHERE MANV = '" + MANV + "'";
            int updated = data.getNonQuery(update);

            if (updated > 0)
            {
                MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
