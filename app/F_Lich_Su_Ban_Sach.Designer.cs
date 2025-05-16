
namespace app
{
    partial class F_Lich_Su_Ban_Sach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labeldsNXB = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.grd_LS_HD = new Guna.UI2.WinForms.Guna2DataGridView();
            this.drvmanxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drvtennxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drvdiachinxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drvsdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drvemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txt_Ma_HD = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelMaNXB = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grd_LS_HD)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labeldsNXB
            // 
            this.labeldsNXB.BackColor = System.Drawing.Color.Transparent;
            this.labeldsNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labeldsNXB.Location = new System.Drawing.Point(38, 264);
            this.labeldsNXB.Name = "labeldsNXB";
            this.labeldsNXB.Size = new System.Drawing.Size(156, 27);
            this.labeldsNXB.TabIndex = 17;
            this.labeldsNXB.Text = "Lịch sữ hóa đơn";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(38, 31);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(233, 33);
            this.guna2HtmlLabel1.TabIndex = 15;
            this.guna2HtmlLabel1.Text = "Lịch Sử Bán Sách";
            // 
            // grd_LS_HD
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grd_LS_HD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_LS_HD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_LS_HD.ColumnHeadersHeight = 24;
            this.grd_LS_HD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grd_LS_HD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drvmanxb,
            this.drvtennxb,
            this.drvdiachinxb,
            this.drvsdt,
            this.drvemail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_LS_HD.DefaultCellStyle = dataGridViewCellStyle3;
            this.grd_LS_HD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grd_LS_HD.Location = new System.Drawing.Point(38, 307);
            this.grd_LS_HD.Name = "grd_LS_HD";
            this.grd_LS_HD.RowHeadersVisible = false;
            this.grd_LS_HD.RowHeadersWidth = 51;
            this.grd_LS_HD.RowTemplate.Height = 24;
            this.grd_LS_HD.Size = new System.Drawing.Size(1200, 458);
            this.grd_LS_HD.TabIndex = 18;
            this.grd_LS_HD.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grd_LS_HD.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grd_LS_HD.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grd_LS_HD.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grd_LS_HD.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grd_LS_HD.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.grd_LS_HD.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grd_LS_HD.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grd_LS_HD.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grd_LS_HD.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_LS_HD.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grd_LS_HD.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grd_LS_HD.ThemeStyle.HeaderStyle.Height = 24;
            this.grd_LS_HD.ThemeStyle.ReadOnly = false;
            this.grd_LS_HD.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grd_LS_HD.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grd_LS_HD.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_LS_HD.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grd_LS_HD.ThemeStyle.RowsStyle.Height = 24;
            this.grd_LS_HD.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grd_LS_HD.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grd_LS_HD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_LS_HD_CellDoubleClick);
            // 
            // drvmanxb
            // 
            this.drvmanxb.DividerWidth = 1;
            this.drvmanxb.HeaderText = "Mã hóa đơn";
            this.drvmanxb.MinimumWidth = 6;
            this.drvmanxb.Name = "drvmanxb";
            // 
            // drvtennxb
            // 
            this.drvtennxb.DividerWidth = 1;
            this.drvtennxb.HeaderText = "Mã khách hàng";
            this.drvtennxb.MinimumWidth = 6;
            this.drvtennxb.Name = "drvtennxb";
            // 
            // drvdiachinxb
            // 
            this.drvdiachinxb.DividerWidth = 1;
            this.drvdiachinxb.HeaderText = "Ngày lập";
            this.drvdiachinxb.MinimumWidth = 6;
            this.drvdiachinxb.Name = "drvdiachinxb";
            // 
            // drvsdt
            // 
            this.drvsdt.DividerWidth = 1;
            this.drvsdt.HeaderText = "Mã nhân viên";
            this.drvsdt.MinimumWidth = 6;
            this.drvsdt.Name = "drvsdt";
            // 
            // drvemail
            // 
            this.drvemail.HeaderText = "Tổng tiền";
            this.drvemail.MinimumWidth = 6;
            this.drvemail.Name = "drvemail";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox1.Controls.Add(this.txt_Ma_HD);
            this.guna2GroupBox1.Controls.Add(this.labelMaNXB);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(38, 90);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1200, 133);
            this.guna2GroupBox1.TabIndex = 16;
            this.guna2GroupBox1.Text = "Tìm kiếm ";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // txt_Ma_HD
            // 
            this.txt_Ma_HD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Ma_HD.DefaultText = "";
            this.txt_Ma_HD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Ma_HD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Ma_HD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Ma_HD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Ma_HD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Ma_HD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Ma_HD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Ma_HD.Location = new System.Drawing.Point(204, 54);
            this.txt_Ma_HD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Ma_HD.Name = "txt_Ma_HD";
            this.txt_Ma_HD.PasswordChar = '\0';
            this.txt_Ma_HD.PlaceholderText = "";
            this.txt_Ma_HD.SelectedText = "";
            this.txt_Ma_HD.Size = new System.Drawing.Size(229, 40);
            this.txt_Ma_HD.TabIndex = 10;
            this.txt_Ma_HD.TextChanged += new System.EventHandler(this.txt_Ma_HD_TextChanged);
            // 
            // labelMaNXB
            // 
            this.labelMaNXB.BackColor = System.Drawing.Color.Transparent;
            this.labelMaNXB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaNXB.ForeColor = System.Drawing.Color.Black;
            this.labelMaNXB.Location = new System.Drawing.Point(23, 69);
            this.labelMaNXB.Name = "labelMaNXB";
            this.labelMaNXB.Size = new System.Drawing.Size(99, 25);
            this.labelMaNXB.TabIndex = 1;
            this.labelMaNXB.Text = "Mã hóa đơn";
            // 
            // F_Lich_Su_Ban_Sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 798);
            this.Controls.Add(this.labeldsNXB);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.grd_LS_HD);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_Lich_Su_Ban_Sach";
            this.Text = "F_Lich_Su_Ban_Sach";
            ((System.ComponentModel.ISupportInitialize)(this.grd_LS_HD)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel labeldsNXB;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView grd_LS_HD;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txt_Ma_HD;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelMaNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn drvmanxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn drvtennxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn drvdiachinxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn drvsdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn drvemail;
    }
}