namespace QLShopQuanAo
{
    partial class fNhanVien
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
            this.btDangXuat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSDTKH = new System.Windows.Forms.TextBox();
            this.txtDCKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.btResetKH = new System.Windows.Forms.Button();
            this.btXoaKH = new System.Windows.Forms.Button();
            this.btSuaKH = new System.Windows.Forms.Button();
            this.btThemKH = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgKHNV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKHNV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDangXuat
            // 
            this.btDangXuat.Location = new System.Drawing.Point(715, 6);
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.Size = new System.Drawing.Size(87, 34);
            this.btDangXuat.TabIndex = 111;
            this.btDangXuat.Text = "Đăng xuất";
            this.btDangXuat.UseVisualStyleBackColor = true;
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 470);
            this.tabControl1.TabIndex = 112;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSDTKH);
            this.tabPage1.Controls.Add(this.txtDCKH);
            this.tabPage1.Controls.Add(this.txtTenKH);
            this.tabPage1.Controls.Add(this.txtMaKH);
            this.tabPage1.Controls.Add(this.btResetKH);
            this.tabPage1.Controls.Add(this.btXoaKH);
            this.tabPage1.Controls.Add(this.btSuaKH);
            this.tabPage1.Controls.Add(this.btThemKH);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Khách hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSDTKH
            // 
            this.txtSDTKH.Location = new System.Drawing.Point(631, 222);
            this.txtSDTKH.Name = "txtSDTKH";
            this.txtSDTKH.Size = new System.Drawing.Size(174, 20);
            this.txtSDTKH.TabIndex = 128;
            // 
            // txtDCKH
            // 
            this.txtDCKH.Location = new System.Drawing.Point(631, 178);
            this.txtDCKH.Name = "txtDCKH";
            this.txtDCKH.Size = new System.Drawing.Size(174, 20);
            this.txtDCKH.TabIndex = 127;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(631, 139);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(174, 20);
            this.txtTenKH.TabIndex = 125;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(631, 96);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(174, 20);
            this.txtMaKH.TabIndex = 124;
            // 
            // btResetKH
            // 
            this.btResetKH.Location = new System.Drawing.Point(500, 333);
            this.btResetKH.Name = "btResetKH";
            this.btResetKH.Size = new System.Drawing.Size(305, 33);
            this.btResetKH.TabIndex = 123;
            this.btResetKH.Text = "Nhập lại";
            this.btResetKH.UseVisualStyleBackColor = true;
            this.btResetKH.Click += new System.EventHandler(this.btResetKH_Click);
            // 
            // btXoaKH
            // 
            this.btXoaKH.Location = new System.Drawing.Point(717, 294);
            this.btXoaKH.Name = "btXoaKH";
            this.btXoaKH.Size = new System.Drawing.Size(88, 33);
            this.btXoaKH.TabIndex = 122;
            this.btXoaKH.Text = "Xóa";
            this.btXoaKH.UseVisualStyleBackColor = true;
            this.btXoaKH.Click += new System.EventHandler(this.btXoaKH_Click);
            // 
            // btSuaKH
            // 
            this.btSuaKH.Location = new System.Drawing.Point(606, 294);
            this.btSuaKH.Name = "btSuaKH";
            this.btSuaKH.Size = new System.Drawing.Size(88, 33);
            this.btSuaKH.TabIndex = 121;
            this.btSuaKH.Text = "Sửa";
            this.btSuaKH.UseVisualStyleBackColor = true;
            this.btSuaKH.Click += new System.EventHandler(this.btSuaKH_Click);
            // 
            // btThemKH
            // 
            this.btThemKH.Location = new System.Drawing.Point(500, 294);
            this.btThemKH.Name = "btThemKH";
            this.btThemKH.Size = new System.Drawing.Size(88, 33);
            this.btThemKH.TabIndex = 120;
            this.btThemKH.Text = "Thêm";
            this.btThemKH.UseVisualStyleBackColor = true;
            this.btThemKH.Click += new System.EventHandler(this.btThemKH_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 119;
            this.label5.Text = "SDT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(497, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 118;
            this.label4.Text = "Địa chỉ: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(497, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 117;
            this.label3.Text = "Tên khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(497, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 116;
            this.label2.Text = "Mã Khách Hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(565, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 115;
            this.label1.Text = "Thông tin khách hàng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgKHNV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 395);
            this.panel2.TabIndex = 114;
            // 
            // dgKHNV
            // 
            this.dgKHNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKHNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKHNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgKHNV.Location = new System.Drawing.Point(0, 0);
            this.dgKHNV.Name = "dgKHNV";
            this.dgKHNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKHNV.Size = new System.Drawing.Size(478, 264);
            this.dgKHNV.TabIndex = 112;
            this.dgKHNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKHNV_CellContentClick_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btDangXuat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 43);
            this.panel1.TabIndex = 113;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thanh Toán";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(832, 470);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "fNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhanVien";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKHNV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDangXuat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgKHNV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSDTKH;
        private System.Windows.Forms.TextBox txtDCKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Button btResetKH;
        private System.Windows.Forms.Button btXoaKH;
        private System.Windows.Forms.Button btSuaKH;
        private System.Windows.Forms.Button btThemKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}