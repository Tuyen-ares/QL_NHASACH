using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace app
{
    public partial class F_Layout : Form
    {
        public F_Layout()
        {
            InitializeComponent();
            HideAllSubMenu();
        }


        string phanQuyen;
        string manv;
        public F_Layout(string phanQuyen, string tennv, string manv)
        {
            InitializeComponent();
            lblName.Text = tennv;
            lblCv.Text = phanQuyen;
            lbl_manv.Text = manv;
            this.phanQuyen = phanQuyen;
            this.manv = manv;
            if (phanQuyen == "Nhân viên")
            {
                btn_QL_He_Thong.Visible = false;
                btn_QL_NV.Visible = false;
            }
            this.manv = manv;
            HideAllSubMenu();
        }
        // vẽ chart


        // ân toàn bộ submenu 
        public void HideAllSubMenu()
        {
            panel_Sub_QL_DM.Visible = false;
            panel_Sub_QL_BS.Visible = false;
            panel_Sub_QL_NS.Visible = false;
            panel_Sub_QL_DT.Visible = false;
            panel_Sub_QL_NV.Visible = false;
            panel_Sub_QL_TK.Visible = false;
            panel_Sub_QL_HT.Visible = false;
        }


        // xứ lý submenu 
        void HideSubMenu()
        {
            if (panel_Sub_QL_DM.Visible == true)
            {
                panel_Sub_QL_DM.Visible = false;
            }
            if (panel_Sub_QL_BS.Visible == true)
            {
                panel_Sub_QL_BS.Visible = false;
            }

            if (panel_Sub_QL_NS.Visible == true)
            {
                panel_Sub_QL_NS.Visible = false;
            }
            if (panel_Sub_QL_DT.Visible == true)
            {
                panel_Sub_QL_DT.Visible = false;
            }
            if (panel_Sub_QL_NV.Visible == true)
            {
                panel_Sub_QL_NV.Visible = false;
            }
            if (panel_Sub_QL_TK.Visible == true)
            {
                panel_Sub_QL_TK.Visible = false;
            }
            if (panel_Sub_QL_HT.Visible == true)
            {
                panel_Sub_QL_HT.Visible = false;
            }
        }


        // show sub menu
        private void ShowSubMenu(Guna.UI2.WinForms.Guna2Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }



        // button active 
        private void ActiveButton(Guna2Button button)
        {
            button.ForeColor = Color.White;  // Đổi màu chữ của nút
            button.FillColor = Color.FromArgb(255, 128, 0);
        }


        // button unactive 
        private void UnActiveButton()
        {
            btnHome.FillColor = Color.White;
            btnHome.ForeColor = Color.Black;

            btn_QL_Danh_Muc.FillColor = Color.White;
            btn_QL_Danh_Muc.ForeColor = Color.Black;

            btn_QL_BS.FillColor = Color.White;
            btn_QL_BS.ForeColor = Color.Black; ;
            
            btn_QL_NS.FillColor = Color.White;
            btn_QL_NS.ForeColor = Color.Black; ;

            btn_QL_Doi_Tra.FillColor = Color.White;
            btn_QL_Doi_Tra.ForeColor = Color.Black;

            btn_QL_NV.FillColor = Color.White;
            btn_QL_NV.ForeColor = Color.Black;

            btn_QL_Thong_Ke.FillColor = Color.White;
            btn_QL_Thong_Ke.ForeColor = Color.Black;

            btn_QL_He_Thong.FillColor = Color.White;
            btn_QL_He_Thong.ForeColor = Color.Black;
            ;
        }

        // open child form 
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(activeForm);
            panelChildForm.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }


        // button quản lý sân bóng 
        private void btnQLSanBong_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_Danh_Muc);
            if (panel_Sub_QL_DM.Visible)
            {
                // Nếu panel đang hiển thị, ẩn nó đi
                panel_Sub_QL_DM.Visible = false;
            }
            else
            {
                // Nếu panel đang ẩn, hiển thị nó
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_DM);  // Hiển thị panel
            }
        }

        
        // button quản lý lịch đặt sân 
        private void btnQLLichDatSan_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_BS);
            if (panel_Sub_QL_BS.Visible)
            {
                // Nếu panel đang hiển thị, ẩn nó đi
                panel_Sub_QL_BS.Visible = false;
            }
            else
            {
                // Nếu panel đang ẩn, hiển thị nó
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_BS);  // Hiển thị panel
            }
        }


        


        // button quản lý nhân viên
        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_NS);
            if (panel_Sub_QL_NS.Visible)
            {
                panel_Sub_QL_NS.Visible = false;
            }
            else
            {
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_NS);  // Hiển thị panel
            }
            
        }

       
        private void btn_QL_Doi_Tra_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_Doi_Tra);
            if (panel_Sub_QL_DT.Visible)
            {
                panel_Sub_QL_DT.Visible = false;
            }
            else
            {
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_DT);  // Hiển thị panel
            }
        }

        private void btn_QL_NV_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_NV);
            if (panel_Sub_QL_NV.Visible)
            {
                panel_Sub_QL_NV.Visible = false;
            }
            else
            {
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_NV);  // Hiển thị panel
            }
        }

        private void btn_QL_Thong_Ke_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_Thong_Ke);
            if (panel_Sub_QL_TK.Visible)
            {
                panel_Sub_QL_TK.Visible = false;
            }
            else
            {
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_TK);  // Hiển thị panel
            }
        }

        private void btn_QL_He_Thong_Click(object sender, EventArgs e)
        {
            UnActiveButton();
            ActiveButton(btn_QL_He_Thong);
            if (panel_Sub_QL_HT.Visible)
            {
                panel_Sub_QL_HT.Visible = false;
            }
            else
            {
                HideSubMenu();  // Ẩn các submenu khác nếu cần
                ShowSubMenu(panel_Sub_QL_HT);  // Hiển thị panel
            }
        }



        // button Home 
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Home());
            UnActiveButton();
            ActiveButton(btnHome);
            HideSubMenu();
        }


        private void btn_DM_NXB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_DM_Cap_Nhat_NXB());

        }

        private void btn_DM_Sach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_DM_Cap_Nhat_Sach());
        }

        private void btn_DM_The_Loai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_DM_CAP_Nhat_TLvaTG());
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            F_Login lg = new F_Login();
            lg.Show();
        }

        private void btn_NV_Cap_Nhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QL_NhanVien());
        }

        private void btn_TK_Doanh_Thu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_DM_Doanh_Thu());
            UnActiveButton();
            ActiveButton(btn_QL_Thong_Ke);
        }

        private void btn_TK_Ton_Kho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_DM_Ton_Kho());
            UnActiveButton();
            ActiveButton(btn_QL_Thong_Ke);
            
        }

        private void btn_TK_DK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Register());
            UnActiveButton();
            ActiveButton(btn_QL_He_Thong);
           
        }

        private void btn_Doi_MK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_ChangePassWord(manv));
            UnActiveButton();
            ActiveButton(btn_QL_He_Thong);
        }

        private void btn_DT_Cap_Nhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Doi_Tra_Sach());
            UnActiveButton();
            ActiveButton(btn_QL_Doi_Tra);
        }

        private void btn_BS_Hoa_Don_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_BanSach());
            UnActiveButton();
            ActiveButton(btn_QL_BS);
        }

        private void btn_NS_Hoa_Don_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_NhapSach());
            UnActiveButton();
            ActiveButton(btn_QL_NS);
        }

        private void btn_BS_Tim_Kiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Lich_Su_Ban_Sach());
            UnActiveButton();
            ActiveButton(btn_QL_BS);
        }

        private void btn_NS_Tim_Kiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Lich_Su_Nhap_Sach());
            UnActiveButton();
            ActiveButton(btn_QL_BS);
        }
    }
}
