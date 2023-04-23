using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using QLShopQuanAo.Properties;

namespace QLShopQuanAo
{
   

    public partial class FromQLHang : Form
    {
        public FromQLHang()
        {
            InitializeComponent();
            DBConnect.Connect();
            LoadDsSanPham();
            LoadDsNhanVien();
            
            
            // đặt kiểu hiển thị ngày/tháng/năm cho datetimepicker
            dateNgayNhap.Format = DateTimePickerFormat.Custom;
            dateNhanVien.Format = DateTimePickerFormat.Custom;
            dateNgayNhap.CustomFormat = "dd/MM/yyyy";
        }

        private void FromQLHang_Load(object sender, EventArgs e)
        {
            
        }



        private void LoadDsSanPham()
        {

            var sql = "SELECT maSanPham, tenSanPham, moTaSanPham, giaNhap, giaXuat, Size, tinhTrang, ngayNhap = CONVERT(NVARCHAR(10),NgayNhap,103), soLuong, chatLieu, nhaSanXuat, anhSanPham FROM SanPham";

            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();
            //Xóa dữ liệu cũ trong datagridview
            dgvSanPham.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
            while (dr.Read())
            {
                var i = dgvSanPham.Rows.Add();
                var row = dgvSanPham.Rows[i];
                row.Cells["maSanPham"].Value = dr["maSanPham"];
                row.Cells["tenSanPham"].Value = dr["tenSanPham"];
                row.Cells["moTaSanPham"].Value = dr["moTaSanPham"];
                row.Cells["giaNhap"].Value = dr["giaNhap"];
                row.Cells["giaXuat"].Value = dr["giaXuat"];
                row.Cells["Size"].Value = dr["Size"];
                row.Cells["tinhTrang"].Value = dr["tinhTrang"];
                row.Cells["ngayNhap"].Value = dr["ngayNhap"];
                row.Cells["soLuong"].Value = dr["soLuong"];
                row.Cells["chatLieu"].Value = dr["chatLieu"];
                row.Cells["nhaSanXuat"].Value = dr["nhaSanXuat"];
                row.Cells["anhSanPham"].Value = dr["anhSanPham"];
            }

            dr.Close();

        }


        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txtMa.ReadOnly = false;
            txtMa.Clear();
            txtTen.Clear();
            txtMoTa.Clear();
            txtGiaNhap.Clear();
            txtGiaXuat.Clear();
            txtSize.Clear();
            cbTinhTrang.SelectedIndex = -1;
            dateNgayNhap.ResetText();
            txtSoLuong.Clear();
            txtChatLieu.Clear();
            txtNhaSanXuat.Clear();
            txtAnhSanPham.Clear();
            pic.Refresh();
            pic.Image = null;
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtTen.Text == "" || txtMoTa.Text == "" || txtGiaNhap.Text == "" || txtGiaXuat.Text == "" || txtSize.Text == "" || cbTinhTrang.Text == "" || dateNgayNhap.Value.Equals("") || txtSoLuong.Text == "" || txtChatLieu.Text == "" || txtNhaSanXuat.Text == "" || txtAnhSanPham.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var sql = "INSERT INTO dbo.SanPham (maSanPham, tenSanPham, moTaSanPham, giaNhap, giaXuat, Size, tinhTrang, ngayNhap, soLuong, chatLieu, nhaSanXuat, anhSanPham) VALUES (@maSanPham, @tenSanPham, @moTaSanPham, @giaNhap, @giaXuat, @Size, @tinhTrang, @ngayNhap, @soLuong, @chatLieu, @nhaSanXuat, @anhSanPham)";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("maSanPham", txtMa.Text);
                    cmd.Parameters.AddWithValue("tenSanPham", txtTen.Text);
                    cmd.Parameters.AddWithValue("moTaSanPham", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("giaNhap", txtGiaNhap.Text);
                    cmd.Parameters.AddWithValue("giaXuat", txtGiaXuat.Text);
                    cmd.Parameters.AddWithValue("Size", txtSize.Text);
                    cmd.Parameters.AddWithValue("tinhTrang", cbTinhTrang.Text);
                    cmd.Parameters.AddWithValue("ngayNhap", dateNgayNhap.Value);
                    cmd.Parameters.AddWithValue("soLuong", txtSoLuong.Text);
                    cmd.Parameters.AddWithValue("chatLieu", txtChatLieu.Text);
                    cmd.Parameters.AddWithValue("nhaSanxuat", txtNhaSanXuat.Text);
                    cmd.Parameters.AddWithValue("anhSanPham", txtAnhSanPham.Text);
                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadDsSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                
                
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146232060)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //chỉ cho nhập số tại các textbox nhập số
        private void NhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }



        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Hide();
        }

        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //hiện thông báo
                if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var maSanPham = dgvSanPham.SelectedRows[0].Cells["maSanPham"].Value.ToString();
                    var sql = "DELETE SanPham WHERE maSanPham = @maSanPham";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("maSanPham", maSanPham);
                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadDsSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Choose Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp;|All Files|*.*";
            ofd.ShowDialog();
            txtAnhSanPham.Text = ofd.FileName;
            if (txtAnhSanPham.Text != "")
                pic.Image = Image.FromFile(txtAnhSanPham.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var maSanPham = dgvSanPham.SelectedRows[0].Cells["maSanPham"].Value.ToString();
                var sql = "UPDATE SanPham SET tenSanPham = @tenSanPham , moTaSanPham = @moTaSanPham, giaNhap = @giaNhap, giaXuat = @giaXuat, Size = @Size, tinhTrang = @tinhTrang, ngayNhap = @ngayNhap, soLuong = @soLuong, chatLieu = @chatLieu, nhaSanXuat = @nhaSanXuat, anhSanPham = @anhSanPham WHERE maSanPham = @maSanPham";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("maSanPham", maSanPham);
                cmd.Parameters.AddWithValue("tenSanPham", txtTen.Text);
                cmd.Parameters.AddWithValue("moTaSanPham", txtMoTa.Text);
                cmd.Parameters.AddWithValue("giaNhap", txtGiaNhap.Text);
                cmd.Parameters.AddWithValue("giaXuat", txtGiaXuat.Text);
                cmd.Parameters.AddWithValue("Size", txtSize.Text);
                cmd.Parameters.AddWithValue("tinhTrang", cbTinhTrang.Text);
                cmd.Parameters.AddWithValue("ngayNhap", dateNgayNhap.Value);
                cmd.Parameters.AddWithValue("soLuong", txtSoLuong.Text);
                cmd.Parameters.AddWithValue("chatLieu", txtChatLieu.Text);
                cmd.Parameters.AddWithValue("nhaSanxuat", txtNhaSanXuat.Text);
                cmd.Parameters.AddWithValue("anhSanPham", txtAnhSanPham.Text);
                var kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsSanPham();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvSanPham.SelectedRows[0].Cells["maSanPham"].Value.ToString();
            txtMa.ReadOnly = true; // không cho sửa mã
            txtTen.Text = dgvSanPham.SelectedRows[0].Cells["tenSanPham"].Value.ToString();
            txtMoTa.Text = dgvSanPham.SelectedRows[0].Cells["moTaSanPham"].Value.ToString();
            txtGiaNhap.Text = dgvSanPham.SelectedRows[0].Cells["giaNhap"].Value.ToString();
            txtGiaXuat.Text = dgvSanPham.SelectedRows[0].Cells["giaXuat"].Value.ToString();
            txtSize.Text = dgvSanPham.SelectedRows[0].Cells["Size"].Value.ToString();
            txtSoLuong.Text = dgvSanPham.SelectedRows[0].Cells["soLuong"].Value.ToString();
            txtChatLieu.Text = dgvSanPham.SelectedRows[0].Cells["chatLieu"].Value.ToString();
            txtNhaSanXuat.Text = dgvSanPham.SelectedRows[0].Cells["nhaSanXuat"].Value.ToString();
            txtAnhSanPham.Text = dgvSanPham.SelectedRows[0].Cells["anhSanPham"].Value.ToString();

            //Chọn giá trị combobox Tình trạng nếu giá trị combobox = giá trị lưu trong csdl
            foreach (var item in cbTinhTrang.Items)
                if ((string)item == dgvSanPham.SelectedRows[0].Cells["tinhTrang"].Value.ToString())
                    cbTinhTrang.SelectedItem = item;

            //đặt ngày theo dữ liệu trong csdl
            dateNgayNhap.Value = DateTime.ParseExact(
                dgvSanPham.SelectedRows[0].Cells["ngayNhap"].Value.ToString(),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

            //load hình ảnh
            if (dgvSanPham.SelectedRows[0].Cells["anhSanPham"].Value.ToString() != "")
                pic.Image = Image.FromFile(dgvSanPham.SelectedRows[0].Cells["anhSanPham"].Value.ToString());
        }

        private void timKiemSP()
        {
            try
            {
                var sql = "SELECT maSanPham, tenSanPham, moTaSanPham, giaNhap, giaXuat, Size, tinhTrang, ngayNhap = CONVERT(NVARCHAR(10),NgayNhap,103), soLuong, chatLieu, nhaSanXuat, anhSanPham FROM SanPham WHERE maSanPham LIKE N'%' + @TuKhoa + '%' OR tenSanPham LIKE N'%' + @TuKhoa + '%' OR moTaSanPham LIKE N'%' + @TuKhoa + '%' OR giaNhap LIKE N'%' + @TuKhoa + '%' OR giaXuat LIKE N'%' + @TuKhoa + '%' OR Size LIKE N'%' + @TuKhoa + '%' OR tinhTrang LIKE N'%' + @TuKhoa + '%' OR CONVERT(NVARCHAR(10),NgayNhap,103) LIKE N'%' + @TuKhoa + '%' OR soLuong LIKE N'%' + @TuKhoa +'%' OR chatLieu LIKE N'%' + @TuKhoa + '%' OR nhaSanXuat LIKE N'%' + @TuKhoa + '%' OR anhSanPham LIKE N'%' + @TuKhoa + '%'";
                SqlCommand cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("TuKhoa", txtTimKiemSP.Text);
                var dr = cmd.ExecuteReader();
                //Xóa dữ liệu cũ trong datagridview
                dgvSanPham.Rows.Clear();

                // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
                while (dr.Read())
                {
                    var i = dgvSanPham.Rows.Add();
                    var row = dgvSanPham.Rows[i];
                    row.Cells["maSanPham"].Value = dr["maSanPham"];
                    row.Cells["tenSanPham"].Value = dr["tenSanPham"];
                    row.Cells["moTaSanPham"].Value = dr["moTaSanPham"];
                    row.Cells["giaNhap"].Value = dr["giaNhap"];
                    row.Cells["giaXuat"].Value = dr["giaXuat"];
                    row.Cells["Size"].Value = dr["Size"];
                    row.Cells["tinhTrang"].Value = dr["tinhTrang"];
                    row.Cells["ngayNhap"].Value = dr["ngayNhap"];
                    row.Cells["soLuong"].Value = dr["soLuong"];
                    row.Cells["chatLieu"].Value = dr["chatLieu"];
                    row.Cells["nhaSanXuat"].Value = dr["nhaSanXuat"];
                    row.Cells["anhSanPham"].Value = dr["anhSanPham"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
            }
        }
        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            timKiemSP();
        }

        private void txtTimKiemSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //"Enter"
            if (e.KeyChar == 13)
            {
                timKiemSP();

            }
        }

        private void LoadDsNhanVien()
        {

            var sql = "SELECT maNhanVien, tenNhanVien, gioiTinh, diaChi, dienThoai, ngaySinh = CONVERT(NVARCHAR(10),NgaySinh,103), chucVu, pass FROM NhanVien";

            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();
            //Xóa dữ liệu cũ trong datagridview
            dgvNhanVien.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
            while (dr.Read())
            {
                var i = dgvNhanVien.Rows.Add();
                var row = dgvNhanVien.Rows[i];
                row.Cells["maNhanVien"].Value = dr["maNhanVien"];
                row.Cells["tenNhanVien"].Value = dr["tenNhanVien"];
                row.Cells["gioiTinh"].Value = dr["gioiTinh"];
                row.Cells["diaChi"].Value = dr["diaChi"];
                row.Cells["dienThoai"].Value = dr["dienThoai"];
                row.Cells["ngaySinh"].Value = dr["ngaySinh"];
                row.Cells["chucVu"].Value = dr["chucVu"];
                row.Cells["pass"].Value = dr["pass"];
            }

            dr.Close();

        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNhanVien.Text == "" || txtTenNhanVien.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" ||  dateNhanVien.Value.Equals("") || txtChucVu.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var sql = "INSERT INTO dbo.NhanVien (maNhanVien, tenNhanVien, gioiTinh, diaChi, dienThoai, ngaySinh, chucVu, pass) VALUES (@maNhanVien, @tenNhanVien, @gioiTinh, @diaChi, @dienThoai, @ngaySinh, @chucVu, @pass)";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("maNhanVien", txtMaNhanVien.Text);
                    cmd.Parameters.AddWithValue("tenNhanVien", txtTenNhanVien.Text);
                    cmd.Parameters.AddWithValue("gioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("dienThoai", txtSDT.Text);
                    cmd.Parameters.AddWithValue("ngaySinh", dateNhanVien.Value);
                    cmd.Parameters.AddWithValue("chucVu", txtChucVu.Text);
                    cmd.Parameters.AddWithValue("pass", txtPass.Text);
                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadDsNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146232060)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhapLai1_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.ReadOnly = false;
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            rdNam.Checked = true;
            txtDiaChi.Clear();
            txtSDT.Clear();
            dateNgayNhap.ResetText();
            txtChucVu.Clear();
            txtPass.Clear();
            txtMaNhanVien.Focus();
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "UPDATE NhanVien SET tenNhanVien = @tenNhanVien ,gioiTinh = @gioiTinh ,diaChi = @diaChi ,dienThoai = @dienThoai,ngaySinh = @ngaySinh, chucVu = @chucVu, pass = @pass  WHERE maNhanVien = @maNhanVien";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("maNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.AddWithValue("tenNhanVien", txtTenNhanVien.Text);
                cmd.Parameters.AddWithValue("gioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("diaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("dienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("ngaySinh", dateNhanVien.Value);
                cmd.Parameters.AddWithValue("chucVu", txtChucVu.Text);
                cmd.Parameters.AddWithValue("pass", txtPass.Text);
                var kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNhanVien.Text = dgvNhanVien.SelectedRows[0].Cells["maNhanVien"].Value.ToString();
                txtMaNhanVien.ReadOnly = true; // không cho sửa mã
                txtTenNhanVien.Text = dgvNhanVien.SelectedRows[0].Cells["tenNhanVien"].Value.ToString();
                rdNam.Checked = dgvNhanVien.SelectedRows[0].Cells["gioiTinh"].Value.ToString() == "Nam";
                rdNu.Checked = dgvNhanVien.SelectedRows[0].Cells["gioiTinh"].Value.ToString() == "Nữ";
                txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells["diaChi"].Value.ToString(); 
                txtSDT.Text = dgvNhanVien.SelectedRows[0].Cells["dienThoai"].Value.ToString();
                txtChucVu.Text = dgvNhanVien.SelectedRows[0].Cells["chucVu"].Value.ToString();
                txtPass.Text = dgvNhanVien.SelectedRows[0].Cells["pass"].Value.ToString();
                //đặt ngày theo dữ liệu trong csdl
                try
                {
                    dateNhanVien.Value = DateTime.ParseExact(
                        dgvNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            try
            {
                //hiện thông báo
                if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var maNhanVien = dgvNhanVien.SelectedRows[0].Cells["maNhanVien"].Value.ToString();
                    var sql = "DELETE NhanVien WHERE maNhanVien = @maNhanVien";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);
                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadDsNhanVien();
                        
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timKiemNV()
        {
            try
            {
                var sql = "SELECT maNhanVien, tenNhanVien, gioiTinh, diaChi, dienThoai, ngaySinh = CONVERT(NVARCHAR(10),NgaySinh,103), chucVu, pass FROM NhanVien WHERE maNhanVien LIKE N'%' + @TuKhoa + '%' OR tenNhanVien LIKE N'%' + @TuKhoa + '%' OR gioiTinh LIKE N'%' + @TuKhoa + '%' OR diaChi LIKE N'%' + @TuKhoa + '%' OR dienThoai LIKE N'%' + @TuKhoa + '%' OR CONVERT(NVARCHAR(10), NgaySinh, 103) LIKE N'%' + @TuKhoa + '%' OR chucVu LIKE N'%' + @TuKhoa + '%' OR pass LIKE N'%' + @TuKhoa + '%'";
                SqlCommand cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("TuKhoa", txtTimKiemNV.Text);
                var dr = cmd.ExecuteReader();
                //Xóa dữ liệu cũ trong datagridview
                dgvNhanVien.Rows.Clear();

                // lập qua từng dòng trong bảng NhanVien, thêm vào datagridview
                while (dr.Read())
                {
                    var i = dgvNhanVien.Rows.Add();
                    var row = dgvNhanVien.Rows[i];
                    row.Cells["maNhanVien"].Value = dr["maNhanVien"];
                    row.Cells["tenNhanVien"].Value = dr["tenNhanVien"];
                    row.Cells["gioiTinh"].Value = dr["gioiTinh"];
                    row.Cells["diaChi"].Value = dr["diaChi"];
                    row.Cells["dienThoai"].Value = dr["dienThoai"];
                    row.Cells["ngaySinh"].Value = dr["ngaySinh"];
                    row.Cells["chucVu"].Value = dr["chucVu"];
                    row.Cells["pass"].Value = dr["pass"];
                }

                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            timKiemNV();
        }

        private void txtTimKiemNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            //"Enter"
            if (e.KeyChar == 13)
            {
                timKiemNV();

            }
        }
    }
}
