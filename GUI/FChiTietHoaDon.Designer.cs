namespace GUI
{
    partial class FChiTietHoaDon
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
            this.lbCTHD = new System.Windows.Forms.Label();
            this.CTHDList = new System.Windows.Forms.DataGridView();
            this.btLuuHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lbSPNV_TongTien = new System.Windows.Forms.Label();
            this.lbTongTienHD = new System.Windows.Forms.Label();
            this.lbSPNV_MHD = new System.Windows.Forms.Label();
            this.lbSPNV_HoaDon = new System.Windows.Forms.Label();
            this.lbCTHDSP = new System.Windows.Forms.Label();
            this.label1xy = new System.Windows.Forms.Label();
            this.lbCTHDMxx = new System.Windows.Forms.Label();
            this.lbMSP = new System.Windows.Forms.Label();
            this.lbSoLuongSP = new System.Windows.Forms.Label();
            this.txtSP_SoLuongM = new System.Windows.Forms.TextBox();
            this.lbWarningCTHD = new System.Windows.Forms.Label();
            this.btCTHDXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btCTHDSua = new Guna.UI2.WinForms.Guna2Button();
            this.phanChia1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.phanChia2 = new Guna.UI2.WinForms.Guna2VSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.CTHDList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCTHD
            // 
            this.lbCTHD.AutoSize = true;
            this.lbCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCTHD.Location = new System.Drawing.Point(56, 9);
            this.lbCTHD.Name = "lbCTHD";
            this.lbCTHD.Size = new System.Drawing.Size(146, 20);
            this.lbCTHD.TabIndex = 0;
            this.lbCTHD.Text = "Chi Tiết Hóa Đơn";
            this.lbCTHD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CTHDList
            // 
            this.CTHDList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CTHDList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CTHDList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CTHDList.GridColor = System.Drawing.Color.SkyBlue;
            this.CTHDList.Location = new System.Drawing.Point(1, 44);
            this.CTHDList.Name = "CTHDList";
            this.CTHDList.ReadOnly = true;
            this.CTHDList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CTHDList.Size = new System.Drawing.Size(262, 150);
            this.CTHDList.TabIndex = 1;
            this.CTHDList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CTHDList_CellContentClick);
            // 
            // btLuuHoaDon
            // 
            this.btLuuHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btLuuHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btLuuHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btLuuHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btLuuHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btLuuHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btLuuHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuuHoaDon.ForeColor = System.Drawing.Color.White;
            this.btLuuHoaDon.Location = new System.Drawing.Point(13, 459);
            this.btLuuHoaDon.Name = "btLuuHoaDon";
            this.btLuuHoaDon.Size = new System.Drawing.Size(112, 48);
            this.btLuuHoaDon.TabIndex = 21;
            this.btLuuHoaDon.Text = "Lưu Hóa Đơn";
            this.btLuuHoaDon.Click += new System.EventHandler(this.btLuuHoaDon_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Yellow;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(138, 459);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(112, 48);
            this.guna2Button1.TabIndex = 22;
            this.guna2Button1.Text = "In Hóa Đơn";
            // 
            // lbSPNV_TongTien
            // 
            this.lbSPNV_TongTien.AutoSize = true;
            this.lbSPNV_TongTien.Location = new System.Drawing.Point(134, 335);
            this.lbSPNV_TongTien.Name = "lbSPNV_TongTien";
            this.lbSPNV_TongTien.Size = new System.Drawing.Size(18, 20);
            this.lbSPNV_TongTien.TabIndex = 31;
            this.lbSPNV_TongTien.Text = "0";
            // 
            // lbTongTienHD
            // 
            this.lbTongTienHD.AutoSize = true;
            this.lbTongTienHD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTienHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTongTienHD.Location = new System.Drawing.Point(8, 335);
            this.lbTongTienHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongTienHD.Name = "lbTongTienHD";
            this.lbTongTienHD.Size = new System.Drawing.Size(87, 19);
            this.lbTongTienHD.TabIndex = 30;
            this.lbTongTienHD.Text = "Tổng tiền:";
            // 
            // lbSPNV_MHD
            // 
            this.lbSPNV_MHD.AutoSize = true;
            this.lbSPNV_MHD.Location = new System.Drawing.Point(134, 305);
            this.lbSPNV_MHD.Name = "lbSPNV_MHD";
            this.lbSPNV_MHD.Size = new System.Drawing.Size(18, 20);
            this.lbSPNV_MHD.TabIndex = 29;
            this.lbSPNV_MHD.Text = "0";
            // 
            // lbSPNV_HoaDon
            // 
            this.lbSPNV_HoaDon.AutoSize = true;
            this.lbSPNV_HoaDon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSPNV_HoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSPNV_HoaDon.Location = new System.Drawing.Point(12, 305);
            this.lbSPNV_HoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSPNV_HoaDon.Name = "lbSPNV_HoaDon";
            this.lbSPNV_HoaDon.Size = new System.Drawing.Size(83, 19);
            this.lbSPNV_HoaDon.TabIndex = 28;
            this.lbSPNV_HoaDon.Text = "Hóa Đơn:";
            // 
            // lbCTHDSP
            // 
            this.lbCTHDSP.AutoSize = true;
            this.lbCTHDSP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTHDSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCTHDSP.Location = new System.Drawing.Point(8, 206);
            this.lbCTHDSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCTHDSP.Name = "lbCTHDSP";
            this.lbCTHDSP.Size = new System.Drawing.Size(170, 19);
            this.lbCTHDSP.TabIndex = 32;
            this.lbCTHDSP.Text = "Thông tin Sản Phẩm:";
            // 
            // label1xy
            // 
            this.label1xy.AutoSize = true;
            this.label1xy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1xy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1xy.Location = new System.Drawing.Point(8, 234);
            this.label1xy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1xy.Name = "label1xy";
            this.label1xy.Size = new System.Drawing.Size(0, 19);
            this.label1xy.TabIndex = 33;
            // 
            // lbCTHDMxx
            // 
            this.lbCTHDMxx.AutoSize = true;
            this.lbCTHDMxx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTHDMxx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCTHDMxx.Location = new System.Drawing.Point(8, 234);
            this.lbCTHDMxx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCTHDMxx.Name = "lbCTHDMxx";
            this.lbCTHDMxx.Size = new System.Drawing.Size(119, 19);
            this.lbCTHDMxx.TabIndex = 34;
            this.lbCTHDMxx.Text = "Mã Sản Phẩm:";
            // 
            // lbMSP
            // 
            this.lbMSP.AutoSize = true;
            this.lbMSP.Location = new System.Drawing.Point(134, 233);
            this.lbMSP.Name = "lbMSP";
            this.lbMSP.Size = new System.Drawing.Size(0, 20);
            this.lbMSP.TabIndex = 35;
            // 
            // lbSoLuongSP
            // 
            this.lbSoLuongSP.AutoSize = true;
            this.lbSoLuongSP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuongSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSoLuongSP.Location = new System.Drawing.Point(8, 265);
            this.lbSoLuongSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoLuongSP.Name = "lbSoLuongSP";
            this.lbSoLuongSP.Size = new System.Drawing.Size(87, 19);
            this.lbSoLuongSP.TabIndex = 36;
            this.lbSoLuongSP.Text = "Số lượng:";
            // 
            // txtSP_SoLuongM
            // 
            this.txtSP_SoLuongM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtSP_SoLuongM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSP_SoLuongM.Location = new System.Drawing.Point(138, 264);
            this.txtSP_SoLuongM.Name = "txtSP_SoLuongM";
            this.txtSP_SoLuongM.Size = new System.Drawing.Size(29, 19);
            this.txtSP_SoLuongM.TabIndex = 37;
            this.txtSP_SoLuongM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSP_SoLuongM_KeyPress);
            // 
            // lbWarningCTHD
            // 
            this.lbWarningCTHD.AutoSize = true;
            this.lbWarningCTHD.ForeColor = System.Drawing.Color.Red;
            this.lbWarningCTHD.Location = new System.Drawing.Point(21, 385);
            this.lbWarningCTHD.Name = "lbWarningCTHD";
            this.lbWarningCTHD.Size = new System.Drawing.Size(0, 20);
            this.lbWarningCTHD.TabIndex = 38;
            // 
            // btCTHDXoa
            // 
            this.btCTHDXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCTHDXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCTHDXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCTHDXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCTHDXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCTHDXoa.FillColor = System.Drawing.Color.Red;
            this.btCTHDXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCTHDXoa.ForeColor = System.Drawing.Color.White;
            this.btCTHDXoa.Location = new System.Drawing.Point(12, 413);
            this.btCTHDXoa.Name = "btCTHDXoa";
            this.btCTHDXoa.Size = new System.Drawing.Size(113, 40);
            this.btCTHDXoa.TabIndex = 39;
            this.btCTHDXoa.Text = "Xóa SP";
            this.btCTHDXoa.Click += new System.EventHandler(this.btCTHDXoa_Click);
            // 
            // btCTHDSua
            // 
            this.btCTHDSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCTHDSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCTHDSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCTHDSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCTHDSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCTHDSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCTHDSua.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCTHDSua.ForeColor = System.Drawing.Color.White;
            this.btCTHDSua.Location = new System.Drawing.Point(138, 413);
            this.btCTHDSua.Name = "btCTHDSua";
            this.btCTHDSua.Size = new System.Drawing.Size(113, 40);
            this.btCTHDSua.TabIndex = 40;
            this.btCTHDSua.Text = "Đổi Số lượng";
            this.btCTHDSua.Click += new System.EventHandler(this.btCTHDSua_Click);
            // 
            // phanChia1
            // 
            this.phanChia1.BackColor = System.Drawing.Color.Teal;
            this.phanChia1.Location = new System.Drawing.Point(12, 289);
            this.phanChia1.Name = "phanChia1";
            this.phanChia1.Size = new System.Drawing.Size(223, 2);
            this.phanChia1.TabIndex = 41;
            // 
            // phanChia2
            // 
            this.phanChia2.BackColor = System.Drawing.Color.Teal;
            this.phanChia2.Location = new System.Drawing.Point(12, 369);
            this.phanChia2.Name = "phanChia2";
            this.phanChia2.Size = new System.Drawing.Size(223, 2);
            this.phanChia2.TabIndex = 42;
            // 
            // FChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(266, 519);
            this.Controls.Add(this.phanChia2);
            this.Controls.Add(this.phanChia1);
            this.Controls.Add(this.btCTHDSua);
            this.Controls.Add(this.btCTHDXoa);
            this.Controls.Add(this.lbWarningCTHD);
            this.Controls.Add(this.txtSP_SoLuongM);
            this.Controls.Add(this.lbSoLuongSP);
            this.Controls.Add(this.lbMSP);
            this.Controls.Add(this.lbCTHDMxx);
            this.Controls.Add(this.label1xy);
            this.Controls.Add(this.lbCTHDSP);
            this.Controls.Add(this.lbSPNV_TongTien);
            this.Controls.Add(this.lbTongTienHD);
            this.Controls.Add(this.lbSPNV_MHD);
            this.Controls.Add(this.lbSPNV_HoaDon);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btLuuHoaDon);
            this.Controls.Add(this.CTHDList);
            this.Controls.Add(this.lbCTHD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(501, 500);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FChiTietHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ChiTietHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.CTHDList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCTHD;
        private System.Windows.Forms.DataGridView CTHDList;
        private Guna.UI2.WinForms.Guna2Button btLuuHoaDon;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label lbSPNV_TongTien;
        private System.Windows.Forms.Label lbTongTienHD;
        private System.Windows.Forms.Label lbSPNV_MHD;
        private System.Windows.Forms.Label lbSPNV_HoaDon;
        private System.Windows.Forms.Label lbCTHDSP;
        private System.Windows.Forms.Label label1xy;
        private System.Windows.Forms.Label lbCTHDMxx;
        private System.Windows.Forms.Label lbMSP;
        private System.Windows.Forms.Label lbSoLuongSP;
        private System.Windows.Forms.TextBox txtSP_SoLuongM;
        private System.Windows.Forms.Label lbWarningCTHD;
        private Guna.UI2.WinForms.Guna2Button btCTHDXoa;
        private Guna.UI2.WinForms.Guna2Button btCTHDSua;
        private Guna.UI2.WinForms.Guna2VSeparator phanChia1;
        private Guna.UI2.WinForms.Guna2VSeparator phanChia2;
    }
}