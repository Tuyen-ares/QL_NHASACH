
namespace app
{
    partial class F_BanSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_MaHD = new System.Windows.Forms.Label();
            this.button_Luu = new System.Windows.Forms.Button();
            this.button_Huy = new System.Windows.Forms.Button();
            this.btnTimKiemKH = new System.Windows.Forms.Button();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.button_ThemKH = new System.Windows.Forms.Button();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label_GioiTinh = new System.Windows.Forms.Label();
            this.label_SDT = new System.Windows.Forms.Label();
            this.label_TenKH = new System.Windows.Forms.Label();
            this.label_MaKh = new System.Windows.Forms.Label();
            this.cboChonMNV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.button_Them = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChonSach = new System.Windows.Forms.ComboBox();
            this.label_SoLuong = new System.Windows.Forms.Label();
            this.label_DonGia = new System.Windows.Forms.Label();
            this.label_ChonSach = new System.Windows.Forms.Label();
            this.MASH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THANHTIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.dataGridView_SachBan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.button_ThanhToan = new System.Windows.Forms.Button();
            this.label_TongTien = new System.Windows.Forms.Label();
            this.label_DS_Sach = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SachBan)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_MaHD
            // 
            this.label_MaHD.AutoSize = true;
            this.label_MaHD.ForeColor = System.Drawing.Color.Black;
            this.label_MaHD.Location = new System.Drawing.Point(26, 46);
            this.label_MaHD.Name = "label_MaHD";
            this.label_MaHD.Size = new System.Drawing.Size(106, 23);
            this.label_MaHD.TabIndex = 8;
            this.label_MaHD.Text = "Mã hóa dơn";
            // 
            // button_Luu
            // 
            this.button_Luu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Luu.ForeColor = System.Drawing.Color.White;
            this.button_Luu.Location = new System.Drawing.Point(515, 729);
            this.button_Luu.Name = "button_Luu";
            this.button_Luu.Size = new System.Drawing.Size(180, 45);
            this.button_Luu.TabIndex = 28;
            this.button_Luu.Text = "Lưu Hóa Đơn";
            this.button_Luu.UseVisualStyleBackColor = false;
            this.button_Luu.Click += new System.EventHandler(this.button_Luu_Click);
            // 
            // button_Huy
            // 
            this.button_Huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Huy.ForeColor = System.Drawing.Color.White;
            this.button_Huy.Location = new System.Drawing.Point(733, 729);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(180, 45);
            this.button_Huy.TabIndex = 26;
            this.button_Huy.Text = "Hủy Hóa Đơn";
            this.button_Huy.UseVisualStyleBackColor = false;
            this.button_Huy.Click += new System.EventHandler(this.button_Huy_Click);
            // 
            // btnTimKiemKH
            // 
            this.btnTimKiemKH.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemKH.Location = new System.Drawing.Point(26, 248);
            this.btnTimKiemKH.Name = "btnTimKiemKH";
            this.btnTimKiemKH.Size = new System.Drawing.Size(181, 34);
            this.btnTimKiemKH.TabIndex = 10;
            this.btnTimKiemKH.Text = "Tìm Kiếm";
            this.btnTimKiemKH.UseVisualStyleBackColor = true;
            this.btnTimKiemKH.Click += new System.EventHandler(this.btnTimKiemKH_Click);
            // 
            // txtMaHD
            // 
            this.txtMaHD.ForeColor = System.Drawing.Color.Black;
            this.txtMaHD.Location = new System.Drawing.Point(195, 46);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(251, 30);
            this.txtMaHD.TabIndex = 9;
            // 
            // button_ThemKH
            // 
            this.button_ThemKH.ForeColor = System.Drawing.Color.Black;
            this.button_ThemKH.Location = new System.Drawing.Point(273, 244);
            this.button_ThemKH.Name = "button_ThemKH";
            this.button_ThemKH.Size = new System.Drawing.Size(173, 38);
            this.button_ThemKH.TabIndex = 7;
            this.button_ThemKH.Text = "Thêm Khách Hàng";
            this.button_ThemKH.UseVisualStyleBackColor = true;
            this.button_ThemKH.Click += new System.EventHandler(this.button_ThemKH_Click);
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.ForeColor = System.Drawing.Color.Black;
            this.txtGioiTinh.Location = new System.Drawing.Point(195, 190);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(253, 30);
            this.txtGioiTinh.TabIndex = 5;
            // 
            // txtTenKH
            // 
            this.txtTenKH.ForeColor = System.Drawing.Color.Black;
            this.txtTenKH.Location = new System.Drawing.Point(195, 118);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(253, 30);
            this.txtTenKH.TabIndex = 5;
            // 
            // txtSDT
            // 
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.Location = new System.Drawing.Point(195, 152);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(253, 30);
            this.txtSDT.TabIndex = 4;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // txtMaKH
            // 
            this.txtMaKH.ForeColor = System.Drawing.Color.Black;
            this.txtMaKH.Location = new System.Drawing.Point(195, 80);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(253, 30);
            this.txtMaKH.TabIndex = 4;
            // 
            // label_GioiTinh
            // 
            this.label_GioiTinh.AutoSize = true;
            this.label_GioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GioiTinh.ForeColor = System.Drawing.Color.Black;
            this.label_GioiTinh.Location = new System.Drawing.Point(23, 195);
            this.label_GioiTinh.Name = "label_GioiTinh";
            this.label_GioiTinh.Size = new System.Drawing.Size(71, 18);
            this.label_GioiTinh.TabIndex = 3;
            this.label_GioiTinh.Text = "Giới tính";
            // 
            // label_SDT
            // 
            this.label_SDT.AutoSize = true;
            this.label_SDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SDT.ForeColor = System.Drawing.Color.Black;
            this.label_SDT.Location = new System.Drawing.Point(23, 155);
            this.label_SDT.Name = "label_SDT";
            this.label_SDT.Size = new System.Drawing.Size(107, 18);
            this.label_SDT.TabIndex = 2;
            this.label_SDT.Text = "Số điện thoại";
            // 
            // label_TenKH
            // 
            this.label_TenKH.AutoSize = true;
            this.label_TenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TenKH.ForeColor = System.Drawing.Color.Black;
            this.label_TenKH.Location = new System.Drawing.Point(23, 119);
            this.label_TenKH.Name = "label_TenKH";
            this.label_TenKH.Size = new System.Drawing.Size(127, 18);
            this.label_TenKH.TabIndex = 1;
            this.label_TenKH.Text = "Tên khách hàng";
            // 
            // label_MaKh
            // 
            this.label_MaKh.AutoSize = true;
            this.label_MaKh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MaKh.ForeColor = System.Drawing.Color.Black;
            this.label_MaKh.Location = new System.Drawing.Point(23, 84);
            this.label_MaKh.Name = "label_MaKh";
            this.label_MaKh.Size = new System.Drawing.Size(122, 18);
            this.label_MaKh.TabIndex = 0;
            this.label_MaKh.Text = "Mã khách hàng";
            // 
            // cboChonMNV
            // 
            this.cboChonMNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboChonMNV.FormattingEnabled = true;
            this.cboChonMNV.Location = new System.Drawing.Point(168, 208);
            this.cboChonMNV.Name = "cboChonMNV";
            this.cboChonMNV.Size = new System.Drawing.Size(301, 31);
            this.cboChonMNV.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(33, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mã nhân viên";
            // 
            // txtMaSach
            // 
            this.txtMaSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMaSach.Location = new System.Drawing.Point(168, 93);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(301, 30);
            this.txtMaSach.TabIndex = 19;
            // 
            // button_Them
            // 
            this.button_Them.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Them.Location = new System.Drawing.Point(177, 245);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(182, 38);
            this.button_Them.TabIndex = 6;
            this.button_Them.Text = "Thêm Vào Giỏ Hàng";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSoLuong.Location = new System.Drawing.Point(168, 167);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(301, 30);
            this.txtSoLuong.TabIndex = 5;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDonGia.Location = new System.Drawing.Point(168, 131);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(301, 30);
            this.txtDonGia.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(33, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mã sách";
            // 
            // cboChonSach
            // 
            this.cboChonSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboChonSach.FormattingEnabled = true;
            this.cboChonSach.Location = new System.Drawing.Point(168, 57);
            this.cboChonSach.Name = "cboChonSach";
            this.cboChonSach.Size = new System.Drawing.Size(301, 31);
            this.cboChonSach.TabIndex = 4;
            this.cboChonSach.SelectedIndexChanged += new System.EventHandler(this.cboChonSach_SelectedIndexChanged);
            // 
            // label_SoLuong
            // 
            this.label_SoLuong.AutoSize = true;
            this.label_SoLuong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_SoLuong.Location = new System.Drawing.Point(33, 177);
            this.label_SoLuong.Name = "label_SoLuong";
            this.label_SoLuong.Size = new System.Drawing.Size(83, 23);
            this.label_SoLuong.TabIndex = 2;
            this.label_SoLuong.Text = "Số lượng";
            // 
            // label_DonGia
            // 
            this.label_DonGia.AutoSize = true;
            this.label_DonGia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_DonGia.Location = new System.Drawing.Point(33, 139);
            this.label_DonGia.Name = "label_DonGia";
            this.label_DonGia.Size = new System.Drawing.Size(74, 23);
            this.label_DonGia.TabIndex = 1;
            this.label_DonGia.Text = "Đơn giá";
            // 
            // label_ChonSach
            // 
            this.label_ChonSach.AutoSize = true;
            this.label_ChonSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_ChonSach.Location = new System.Drawing.Point(33, 65);
            this.label_ChonSach.Name = "label_ChonSach";
            this.label_ChonSach.Size = new System.Drawing.Size(90, 23);
            this.label_ChonSach.TabIndex = 0;
            this.label_ChonSach.Text = "Chọn sách";
            // 
            // MASH
            // 
            this.MASH.HeaderText = "Mã sách";
            this.MASH.MinimumWidth = 6;
            this.MASH.Name = "MASH";
            this.MASH.Width = 200;
            // 
            // TENSH
            // 
            this.TENSH.HeaderText = "Tên sách";
            this.TENSH.MinimumWidth = 6;
            this.TENSH.Name = "TENSH";
            this.TENSH.Width = 300;
            // 
            // DONGIA
            // 
            this.DONGIA.HeaderText = "Đơn giá";
            this.DONGIA.MinimumWidth = 6;
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.Width = 200;
            // 
            // SOLUONG
            // 
            this.SOLUONG.HeaderText = "Số lượng";
            this.SOLUONG.MinimumWidth = 6;
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.Width = 200;
            // 
            // THANHTIEN
            // 
            this.THANHTIEN.HeaderText = "Thành tiền";
            this.THANHTIEN.MinimumWidth = 6;
            this.THANHTIEN.Name = "THANHTIEN";
            this.THANHTIEN.Width = 200;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.Location = new System.Drawing.Point(1066, 729);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(180, 45);
            this.btn_ThongKe.TabIndex = 29;
            this.btn_ThongKe.Text = "Thống Kê";
            this.btn_ThongKe.UseVisualStyleBackColor = false;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click_1);
            // 
            // dataGridView_SachBan
            // 
            this.dataGridView_SachBan.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_SachBan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_SachBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SachBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASH,
            this.TENSH,
            this.DONGIA,
            this.SOLUONG,
            this.THANHTIEN});
            this.dataGridView_SachBan.Location = new System.Drawing.Point(21, 422);
            this.dataGridView_SachBan.Name = "dataGridView_SachBan";
            this.dataGridView_SachBan.RowHeadersWidth = 51;
            this.dataGridView_SachBan.RowTemplate.Height = 24;
            this.dataGridView_SachBan.Size = new System.Drawing.Size(1225, 246);
            this.dataGridView_SachBan.TabIndex = 20;
            this.dataGridView_SachBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SachBan_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 38);
            this.label1.TabIndex = 19;
            this.label1.Text = "Phiếu bán sách";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(505, 678);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(315, 22);
            this.txtTongTien.TabIndex = 27;
            // 
            // button_ThanhToan
            // 
            this.button_ThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_ThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ThanhToan.ForeColor = System.Drawing.Color.White;
            this.button_ThanhToan.Location = new System.Drawing.Point(294, 729);
            this.button_ThanhToan.Name = "button_ThanhToan";
            this.button_ThanhToan.Size = new System.Drawing.Size(180, 45);
            this.button_ThanhToan.TabIndex = 25;
            this.button_ThanhToan.Text = "Thanh Toán";
            this.button_ThanhToan.UseVisualStyleBackColor = false;
            this.button_ThanhToan.Click += new System.EventHandler(this.button_ThanhToan_Click);
            // 
            // label_TongTien
            // 
            this.label_TongTien.AutoSize = true;
            this.label_TongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TongTien.Location = new System.Drawing.Point(365, 671);
            this.label_TongTien.Name = "label_TongTien";
            this.label_TongTien.Size = new System.Drawing.Size(134, 29);
            this.label_TongTien.TabIndex = 24;
            this.label_TongTien.Text = "Tổng Tiền";
            // 
            // label_DS_Sach
            // 
            this.label_DS_Sach.AutoSize = true;
            this.label_DS_Sach.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DS_Sach.Location = new System.Drawing.Point(499, 372);
            this.label_DS_Sach.Name = "label_DS_Sach";
            this.label_DS_Sach.Size = new System.Drawing.Size(290, 32);
            this.label_DS_Sach.TabIndex = 23;
            this.label_DS_Sach.Text = "Danh Sách Đã Chọn";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox1.Controls.Add(this.btnTimKiemKH);
            this.guna2GroupBox1.Controls.Add(this.txtTenKH);
            this.guna2GroupBox1.Controls.Add(this.txtMaHD);
            this.guna2GroupBox1.Controls.Add(this.label_MaKh);
            this.guna2GroupBox1.Controls.Add(this.label_MaHD);
            this.guna2GroupBox1.Controls.Add(this.label_TenKH);
            this.guna2GroupBox1.Controls.Add(this.button_ThemKH);
            this.guna2GroupBox1.Controls.Add(this.label_SDT);
            this.guna2GroupBox1.Controls.Add(this.label_GioiTinh);
            this.guna2GroupBox1.Controls.Add(this.txtMaKH);
            this.guna2GroupBox1.Controls.Add(this.txtGioiTinh);
            this.guna2GroupBox1.Controls.Add(this.txtSDT);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(21, 76);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(602, 293);
            this.guna2GroupBox1.TabIndex = 30;
            this.guna2GroupBox1.Text = "Thông tin khách hàng";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox2.Controls.Add(this.cboChonMNV);
            this.guna2GroupBox2.Controls.Add(this.cboChonSach);
            this.guna2GroupBox2.Controls.Add(this.label4);
            this.guna2GroupBox2.Controls.Add(this.label_ChonSach);
            this.guna2GroupBox2.Controls.Add(this.txtMaSach);
            this.guna2GroupBox2.Controls.Add(this.label_DonGia);
            this.guna2GroupBox2.Controls.Add(this.button_Them);
            this.guna2GroupBox2.Controls.Add(this.label_SoLuong);
            this.guna2GroupBox2.Controls.Add(this.txtSoLuong);
            this.guna2GroupBox2.Controls.Add(this.label3);
            this.guna2GroupBox2.Controls.Add(this.txtDonGia);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(663, 76);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(583, 293);
            this.guna2GroupBox2.TabIndex = 31;
            this.guna2GroupBox2.Text = "Thông tin sách";
            // 
            // F_BanSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 798);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.button_Luu);
            this.Controls.Add(this.button_Huy);
            this.Controls.Add(this.btn_ThongKe);
            this.Controls.Add(this.dataGridView_SachBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.button_ThanhToan);
            this.Controls.Add(this.label_TongTien);
            this.Controls.Add(this.label_DS_Sach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_BanSach";
            this.Text = "F_Ban_Sach";
            this.Load += new System.EventHandler(this.F_BanSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SachBan)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_MaHD;
        private System.Windows.Forms.Button button_Luu;
        private System.Windows.Forms.Button button_Huy;
        private System.Windows.Forms.Button btnTimKiemKH;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Button button_ThemKH;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label_GioiTinh;
        private System.Windows.Forms.Label label_SDT;
        private System.Windows.Forms.Label label_TenKH;
        private System.Windows.Forms.Label label_MaKh;
        private System.Windows.Forms.ComboBox cboChonMNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChonSach;
        private System.Windows.Forms.Label label_SoLuong;
        private System.Windows.Forms.Label label_DonGia;
        private System.Windows.Forms.Label label_ChonSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONGIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn THANHTIEN;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.DataGridView dataGridView_SachBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button button_ThanhToan;
        private System.Windows.Forms.Label label_TongTien;
        private System.Windows.Forms.Label label_DS_Sach;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
    }
}