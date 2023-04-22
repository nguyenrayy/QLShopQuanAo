
namespace QLShopQuanAo
{
    partial class FromQLHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.maSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moTaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhaSanXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anhSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.pic = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbTinhTrang = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtGiaXuat = new System.Windows.Forms.TextBox();
            this.txtNhaSanXuat = new System.Windows.Forms.TextBox();
            this.txtChatLieu = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lable1111 = new System.Windows.Forms.Label();
            this.txtAnhSanPham = new System.Windows.Forms.TextBox();
            this.btDangXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1180, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý sản phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSanPham,
            this.tenSanPham,
            this.moTaSanPham,
            this.giaNhap,
            this.giaXuat,
            this.Size,
            this.tinhTrang,
            this.ngayNhap,
            this.soLuong,
            this.chatLieu,
            this.nhaSanXuat,
            this.anhSanPham});
            this.dgvSanPham.Location = new System.Drawing.Point(65, 76);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(1024, 143);
            this.dgvSanPham.TabIndex = 69;
            // 
            // maSanPham
            // 
            this.maSanPham.DataPropertyName = "maSanPham";
            this.maSanPham.HeaderText = "Mã sản phẩm";
            this.maSanPham.MinimumWidth = 6;
            this.maSanPham.Name = "maSanPham";
            this.maSanPham.Width = 125;
            // 
            // tenSanPham
            // 
            this.tenSanPham.DataPropertyName = "tenSanPham";
            this.tenSanPham.HeaderText = "Tên sản phẩm";
            this.tenSanPham.MinimumWidth = 6;
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.Width = 125;
            // 
            // moTaSanPham
            // 
            this.moTaSanPham.DataPropertyName = "moTaSanPham";
            this.moTaSanPham.HeaderText = "Mô tả sản phẩm";
            this.moTaSanPham.MinimumWidth = 6;
            this.moTaSanPham.Name = "moTaSanPham";
            this.moTaSanPham.Width = 125;
            // 
            // giaNhap
            // 
            this.giaNhap.DataPropertyName = "giaNhap";
            this.giaNhap.HeaderText = "Giá Nhập";
            this.giaNhap.MinimumWidth = 6;
            this.giaNhap.Name = "giaNhap";
            this.giaNhap.Width = 125;
            // 
            // giaXuat
            // 
            this.giaXuat.DataPropertyName = "giaXuat";
            this.giaXuat.HeaderText = "Giá xuất";
            this.giaXuat.MinimumWidth = 6;
            this.giaXuat.Name = "giaXuat";
            this.giaXuat.Width = 125;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.Width = 125;
            // 
            // tinhTrang
            // 
            this.tinhTrang.DataPropertyName = "tinhTrang";
            this.tinhTrang.HeaderText = "Tình Trạng";
            this.tinhTrang.MinimumWidth = 6;
            this.tinhTrang.Name = "tinhTrang";
            this.tinhTrang.Width = 125;
            // 
            // ngayNhap
            // 
            this.ngayNhap.DataPropertyName = "ngayNhap";
            this.ngayNhap.HeaderText = "Ngày nhập";
            this.ngayNhap.MinimumWidth = 6;
            this.ngayNhap.Name = "ngayNhap";
            this.ngayNhap.Width = 125;
            // 
            // soLuong
            // 
            this.soLuong.DataPropertyName = "soLuong";
            this.soLuong.HeaderText = "Số Lượng";
            this.soLuong.MinimumWidth = 6;
            this.soLuong.Name = "soLuong";
            this.soLuong.Width = 125;
            // 
            // chatLieu
            // 
            this.chatLieu.DataPropertyName = "chatLieu";
            this.chatLieu.HeaderText = "Chất liệu";
            this.chatLieu.MinimumWidth = 6;
            this.chatLieu.Name = "chatLieu";
            this.chatLieu.Width = 125;
            // 
            // nhaSanXuat
            // 
            this.nhaSanXuat.DataPropertyName = "nhaSanXuat";
            this.nhaSanXuat.HeaderText = "Nhà sản xuất";
            this.nhaSanXuat.MinimumWidth = 6;
            this.nhaSanXuat.Name = "nhaSanXuat";
            this.nhaSanXuat.Width = 125;
            // 
            // anhSanPham
            // 
            this.anhSanPham.DataPropertyName = "anhSanPham";
            this.anhSanPham.HeaderText = "Ảnh sản phẩm";
            this.anhSanPham.MinimumWidth = 6;
            this.anhSanPham.Name = "anhSanPham";
            this.anhSanPham.Width = 125;
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dateNgayNhap.Location = new System.Drawing.Point(573, 378);
            this.dateNgayNhap.Margin = new System.Windows.Forms.Padding(0);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(196, 24);
            this.dateNgayNhap.TabIndex = 98;
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pic.Location = new System.Drawing.Point(873, 378);
            this.pic.Margin = new System.Windows.Forms.Padding(0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(274, 226);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 97;
            this.pic.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(435, 530);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 18);
            this.label12.TabIndex = 96;
            this.label12.Text = "Nhà sản xuất:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(461, 485);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 18);
            this.label11.TabIndex = 95;
            this.label11.Text = "Chất liệu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(61, 538);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 94;
            this.label10.Text = "Giá xuất:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(61, 482);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 93;
            this.label9.Text = "Giá nhập:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(421, 434);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 91;
            this.label7.Text = "Số lượng nhập:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(461, 330);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 18);
            this.label6.TabIndex = 90;
            this.label6.Text = "Tình trạng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(429, 378);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 88;
            this.label5.Text = "Ngày sản xuất:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(869, 330);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 18);
            this.label13.TabIndex = 87;
            this.label13.Text = "Ảnh sản phẩm:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(89, 575);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 18);
            this.label15.TabIndex = 85;
            this.label15.Text = "Size:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(13, 378);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 18);
            this.label16.TabIndex = 83;
            this.label16.Text = "Tên sản phẩm:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(21, 330);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 18);
            this.label17.TabIndex = 81;
            this.label17.Text = "Mã sản phẩm:";
            // 
            // cbTinhTrang
            // 
            this.cbTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cbTinhTrang.FormattingEnabled = true;
            this.cbTinhTrang.Items.AddRange(new object[] {
            "Còn hàng",
            "Hết hàng"});
            this.cbTinhTrang.Location = new System.Drawing.Point(573, 322);
            this.cbTinhTrang.Margin = new System.Windows.Forms.Padding(0);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new System.Drawing.Size(196, 26);
            this.cbTinhTrang.TabIndex = 75;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtSoLuong.Location = new System.Drawing.Point(573, 426);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(0);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(196, 24);
            this.txtSoLuong.TabIndex = 76;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtGiaNhap.Location = new System.Drawing.Point(157, 482);
            this.txtGiaNhap.Margin = new System.Windows.Forms.Padding(0);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(196, 24);
            this.txtGiaNhap.TabIndex = 73;
            // 
            // txtGiaXuat
            // 
            this.txtGiaXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtGiaXuat.Location = new System.Drawing.Point(157, 530);
            this.txtGiaXuat.Margin = new System.Windows.Forms.Padding(0);
            this.txtGiaXuat.Name = "txtGiaXuat";
            this.txtGiaXuat.Size = new System.Drawing.Size(196, 24);
            this.txtGiaXuat.TabIndex = 74;
            // 
            // txtNhaSanXuat
            // 
            this.txtNhaSanXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNhaSanXuat.Location = new System.Drawing.Point(573, 530);
            this.txtNhaSanXuat.Margin = new System.Windows.Forms.Padding(0);
            this.txtNhaSanXuat.Name = "txtNhaSanXuat";
            this.txtNhaSanXuat.Size = new System.Drawing.Size(196, 24);
            this.txtNhaSanXuat.TabIndex = 79;
            // 
            // txtChatLieu
            // 
            this.txtChatLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtChatLieu.Location = new System.Drawing.Point(573, 482);
            this.txtChatLieu.Margin = new System.Windows.Forms.Padding(0);
            this.txtChatLieu.Name = "txtChatLieu";
            this.txtChatLieu.Size = new System.Drawing.Size(196, 24);
            this.txtChatLieu.TabIndex = 78;
            // 
            // txtSize
            // 
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtSize.Location = new System.Drawing.Point(153, 575);
            this.txtSize.Margin = new System.Windows.Forms.Padding(0);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(196, 24);
            this.txtSize.TabIndex = 72;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtTen.Location = new System.Drawing.Point(157, 378);
            this.txtTen.Margin = new System.Windows.Forms.Padding(0);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(196, 24);
            this.txtTen.TabIndex = 71;
            // 
            // txtMa
            // 
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtMa.Location = new System.Drawing.Point(157, 322);
            this.txtMa.Margin = new System.Windows.Forms.Padding(0);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(196, 24);
            this.txtMa.TabIndex = 70;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(380, 258);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(174, 46);
            this.btnSua.TabIndex = 101;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(122, 258);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(173, 46);
            this.btnThem.TabIndex = 102;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(664, 258);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(177, 46);
            this.btnXoa.TabIndex = 103;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(912, 258);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(173, 46);
            this.btnNhapLai.TabIndex = 104;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click_1);
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(1033, 322);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(118, 42);
            this.btnChon.TabIndex = 105;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 426);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 107;
            this.label2.Text = "Mô tả sản phẩm:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtMoTa.Location = new System.Drawing.Point(153, 426);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(0);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(196, 24);
            this.txtMoTa.TabIndex = 106;
            // 
            // lable1111
            // 
            this.lable1111.AutoSize = true;
            this.lable1111.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lable1111.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lable1111.Location = new System.Drawing.Point(429, 575);
            this.lable1111.Margin = new System.Windows.Forms.Padding(0);
            this.lable1111.Name = "lable1111";
            this.lable1111.Size = new System.Drawing.Size(106, 18);
            this.lable1111.TabIndex = 109;
            this.lable1111.Text = "Ảnh sản phẩm:";
            // 
            // txtAnhSanPham
            // 
            this.txtAnhSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtAnhSanPham.Location = new System.Drawing.Point(567, 575);
            this.txtAnhSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.txtAnhSanPham.Name = "txtAnhSanPham";
            this.txtAnhSanPham.Size = new System.Drawing.Size(196, 24);
            this.txtAnhSanPham.TabIndex = 108;
            // 
            // btDangXuat
            // 
            this.btDangXuat.Location = new System.Drawing.Point(1018, 12);
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.Size = new System.Drawing.Size(87, 34);
            this.btDangXuat.TabIndex = 110;
            this.btDangXuat.Text = "Đăng xuất";
            this.btDangXuat.UseVisualStyleBackColor = true;
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // FromQLHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 838);
            this.Controls.Add(this.btDangXuat);
            this.Controls.Add(this.lable1111);
            this.Controls.Add(this.txtAnhSanPham);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dateNgayNhap);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbTinhTrang);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.txtGiaXuat);
            this.Controls.Add(this.txtNhaSanXuat);
            this.Controls.Add(this.txtChatLieu);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FromQLHang";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FromQLHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DateTimePicker dateNgayNhap;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbTinhTrang;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtGiaXuat;
        private System.Windows.Forms.TextBox txtNhaSanXuat;
        private System.Windows.Forms.TextBox txtChatLieu;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn moTaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn chatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhaSanXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn anhSanPham;
        private System.Windows.Forms.Label lable1111;
        private System.Windows.Forms.TextBox txtAnhSanPham;
        private System.Windows.Forms.Button btDangXuat;
    }
}

