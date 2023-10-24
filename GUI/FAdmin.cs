using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using System.Xml.Linq;

namespace GUI
{
    public partial class FAdmin : Form
    {

        public FAdmin()
        {
            InitializeComponent();
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            LoadDsSanPham();
            loadCbMaSize();
            loadCbMaNhaSX();
            LoadDsNhanVien();
            loadCbMaChucVu();
            loadCbMaCuaHang();
            LoadDsCuaHang();
            LoadDsSPCH();
            loadCbMaSanPhamTheoSize();




        }

        private void LoadDsSanPham()
        {
            SanPhamBLL spbll = new BLL.SanPhamBLL();
            List<SanPham> dsspGui = spbll.LoadDlSanPham();
            dgvSanPham.Rows.Clear();
            foreach (SanPham sp in dsspGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.maSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.tenSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.moTaSanPham });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.giaNhap });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.donGiaNiemYet });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sp.chatLieu });
                // Thêm hàng vào DataGridView
                dgvSanPham.Rows.Add(row);
            }
        }

        private void loadCbMaSize()
        {
            BLL.SizeBLL sizeBLL = new BLL.SizeBLL();
            List<DTO.Size> sizelist = sizeBLL.GetSizes(); // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbSize.Items.Clear();

            // Thêm danh sách các size vào ComboBox
            foreach (DTO.Size size in sizelist) // Sử dụng DTO.Size để chỉ rõ bạn đang sử dụng Size từ DTO
            {
                // Sử dụng thuộc tính hoặc phương thức của đối tượng Size để lấy giá trị cần hiển thị trong ComboBox
                cbSize.Items.Add(size.tenSize); // Giả sử maSize là một thuộc tính của đối tượng Size
            }
        }
        private void loadCbMaChucVu()
        {
            BLL.ChucVuBLL chucVuBLL = new BLL.ChucVuBLL();
            List<ChucVu> chucVu = chucVuBLL.GetChucVu();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbChucVu.Items.Clear();

            // Thêm danh sách "maNSX" vào ComboBox
            foreach (ChucVu cv in chucVu)
            {
                cbChucVu.Items.Add(cv.maChucVu);
            }
        }

        

        private void loadCbMaCuaHang()
        {
            BLL.CuaHangBLL chBLL = new BLL.CuaHangBLL();
            List<CuaHang> cuaHang = chBLL.getCuaHangList();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbMaCuaHang.Items.Clear();

            // Thêm danh sách "maNSX" vào ComboBox
            foreach (CuaHang ch in cuaHang)
            {
                cbMaCuaHang.Items.Add(ch.maCuaHang);
                cbMaCuaHangSP.Items.Add(ch.maCuaHang);
            }
        }
        private void loadCbMaSanPhamTheoSize()
        {
            BLL.MaSanPhamTheoSizeBLL chBLL = new BLL.MaSanPhamTheoSizeBLL();
            List<MaSanPhamTheoSize> sptheosize = chBLL.LoadDlMaSPTheoSize();

            cbMaSanPhamCH.Items.Clear();

            foreach (MaSanPhamTheoSize msp  in sptheosize)
            {
                cbMaSanPhamCH.Items.Add(msp.maSPTheoSize);
            }
        }
        private void loadCbMaNhaSX()
        {
            BLL.NhaSanXuatBLL nSXBLL = new BLL.NhaSanXuatBLL();
            List<NhaSanXuat> NhaSX = nSXBLL.getNhaSX();

            // Xóa tất cả các mục hiện tại trong ComboBox (nếu có)
            cbMaNhaSX.Items.Clear();

            // Thêm danh sách "maNSX" vào ComboBox
            foreach (NhaSanXuat nsx in NhaSX)
            {
                cbMaNhaSX.Items.Add(nsx.maNhaSanXuat);
            }
        }
        List<string> danhSachDuongDanAnh = new List<string>();
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // Đường dẫn đầy đủ đến thư mục "Pic"
            string fullPath = @"C:\Users\tring\OneDrive\Desktop\QLShopQuanAo\Pic";

            // Kiểm tra xem thư mục tồn tại hay không
            if (Directory.Exists(fullPath))
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                    openFileDialog.InitialDirectory = fullPath; // Đặt thư mục ban đầu cho hộp thoại chọn tệp

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in openFileDialog.FileNames)
                        {
                            // Tạo một PictureBox mới cho mỗi hình ảnh
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = new System.Drawing.Bitmap(fileName);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.Width = 100; // Điều chỉnh kích thước PictureBox theo nhu cầu
                            pictureBox.Height = 100;

                            // Thêm PictureBox vào form
                            flowLayoutPanel1.Controls.Add(pictureBox);

                            danhSachDuongDanAnh.Add(fileName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Thư mục 'Pic' không tồn tại tại đường dẫn đã cho.");
            }
        }





        private void btDangXuatAD_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTaSP.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNiemYet.Text) ||
                string.IsNullOrWhiteSpace(txtChatLieu.Text) ||
                string.IsNullOrWhiteSpace(cbMaNhaSX.Text) ||
                string.IsNullOrWhiteSpace(cbSize.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Lấy thông tin sản phẩm từ giao diện người dùng
                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                string moTaSP = txtMoTaSP.Text;
                int giaNhap = int.Parse(txtGiaNhap.Text);
                int donGiaNiemYet = int.Parse(txtGiaNiemYet.Text);
                DateTime ngayNhap = dateNgayNhap.Value;
                string chatLieu = txtChatLieu.Text;
                string maNhaSX = cbMaNhaSX.Text;

                string maSize = cbSize.Text;
                int soLuongTonKho = int.Parse(txtSoLuong.Text);
                SanPhamBLL spbll = new SanPhamBLL();
                MaSanPhamTheoSizeBLL sptsbll = new MaSanPhamTheoSizeBLL();
                AnhSanPhamBLL anhBLL = new AnhSanPhamBLL();
                if (sptsbll.KiemTraMaSPVaMaSizeTonTai(maSize, maSP))
                {
                    MessageBox.Show("Mã sản phẩm và mã size đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (spbll.KiemTraMaSanPhamTonTai(maSP))
                    {
                        MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                        {
                            maSPTheoSize = maSP + '_' + maSize,
                            maSize = maSize,
                            maSanPham = maSP,
                            soLuongTonKho = soLuongTonKho
                        };

                        // Gọi phương thức ThemSizeVaSoLuong từ lớp MaSanPhamTheoSizeBLL để thêm số lượng size cho sản phẩm
                        sptsbll.ThemSizeVaSoLuong(spts);

                        MessageBox.Show("Thêm số lượng size cho sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SanPham sp = new SanPham
                        {
                            maSanPham = maSP,
                            tenSanPham = tenSP,
                            moTaSanPham = moTaSP,
                            giaNhap = giaNhap,
                            donGiaNiemYet = donGiaNiemYet,
                            chatLieu = chatLieu
                        };

                        // Gọi phương thức ThemSanPham từ lớp SanPhamBLL để thêm sản phẩm
                        spbll.ThemSanPham(sp);

                        MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                        {
                            maSPTheoSize = maSP + '_' + maSize,
                            maSize = maSize,
                            maSanPham = maSP,
                            soLuongTonKho = soLuongTonKho
                        };

                        // Gọi phương thức ThemSizeVaSoLuong từ lớp MaSanPhamTheoSizeBLL để thêm số lượng size cho sản phẩm
                        sptsbll.ThemSizeVaSoLuong(spts);

                        foreach (string duongDanAnh in danhSachDuongDanAnh)
                        {
                            
                            // Gọi phương thức ThemAnhSanPham từ lớp AnhSanPhamBLL để thêm đường dẫn ảnh vào CSDL
                            anhBLL.ThemAnhSanPham(maSP, duongDanAnh);
                        }

                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Sau khi thêm sản phẩm, bạn có thể cập nhật DataGridView để hiển thị danh sách sản phẩm mới
                LoadDsSanPham();
            }

        }


        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = selectedRow.Cells["maSanPham"].Value.ToString();
                txtMaSP.ReadOnly = true; // không cho sửa mã
                txtTenSP.Text = selectedRow.Cells["tenSanPham"].Value.ToString();
                txtMoTaSP.Text = selectedRow.Cells["moTaSanPham"].Value.ToString();
                txtGiaNhap.Text = selectedRow.Cells["giaNhap"].Value.ToString();
                txtGiaNiemYet.Text = selectedRow.Cells["donGiaNiemYet"].Value.ToString();
                txtChatLieu.Text = selectedRow.Cells["chatLieu"].Value.ToString();
                foreach (var item in cbMaNhaSX.Items)
                    if ((string)item == selectedRow.Cells["maNhaSanXuat"].Value.ToString())
                        cbMaNhaSX.SelectedItem = item;

                string ngayNhapValue = selectedRow.Cells["ngayNhap"].Value.ToString();

                // Chuyển đổi giá trị thành kiểu DateTime và gán cho DateTimePicker
                if (DateTime.TryParse(ngayNhapValue, out DateTime ngayNhap))
                {
                    dateNgayNhap.Value = ngayNhap;
                }

                // Lấy mã sản phẩm hiện tại
                string maSanPham = selectedRow.Cells["maSanPham"].Value.ToString();

                // Gọi BLL để lấy danh sách mã size tương ứng
                MaSanPhamTheoSizeBLL sizeBLL = new MaSanPhamTheoSizeBLL();
                List<string> maSizes = sizeBLL.LayMaSizeTheoMaSanPham(maSanPham);

                // Cập nhật ComboBox cbSize với danh sách mã size
                cbSize.Items.Clear();
                foreach (string maSize in maSizes)
                {
                    cbSize.Items.Add(maSize);
                }

                // Đặt mặc định là mã size đầu tiên (nếu danh sách không rỗng)
                if (maSizes.Count > 0)
                {
                    cbSize.SelectedIndex = 0;
                }

                // Gọi BLL để lấy danh sách đường dẫn ảnh tương ứng với sản phẩm
                AnhSanPhamBLL anhBLL = new AnhSanPhamBLL();
                List<string> danhSachDuongDanAnh = anhBLL.LayDanhSachDuongDanAnh(maSanPham);
                // Xóa tất cả các PictureBox hiện có trên flowLayoutPanel1
                flowLayoutPanel1.Controls.Clear();

                // Lặp qua danh sách đường dẫn ảnh và hiển thị ảnh lên flowLayoutPanel1
                foreach (string duongDanAnh in danhSachDuongDanAnh)
                {
                    // Tạo một PictureBox mới cho mỗi đường dẫn ảnh
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = new Bitmap(duongDanAnh);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 100; // Điều chỉnh kích thước PictureBox theo nhu cầu
                    pictureBox.Height = 100;

                    // Thêm PictureBox vào flowLayoutPanel1
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }
            }
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "ngayNhap" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSize.SelectedItem != null) // Đảm bảo đã chọn một mã size
            {
                string maSize = cbSize.SelectedItem.ToString();
                string maSanPham = txtMaSP.Text; // Lấy mã sản phẩm từ TextBox txtMaSP

                // Gọi BLL để lấy số lượng tương ứng
                MaSanPhamTheoSizeBLL sizeBLL = new MaSanPhamTheoSizeBLL();
                int soLuong = sizeBLL.LaySoLuongTheoMaSizeVaMaSanPham(maSize, maSanPham);

                // Hiển thị số lượng lên TextBox txtSoLuong
                txtSoLuong.Text = soLuong.ToString();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtMoTaSP.Clear();
            txtGiaNhap.Clear();
            txtGiaNiemYet.Clear();
            cbSize.SelectedIndex = -1;
            dateNgayNhap.ResetText();
            txtSoLuong.Clear();
            txtChatLieu.Clear();
            cbMaNhaSX.SelectedIndex = -1;
            flowLayoutPanel1.Controls.Clear();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin sản phẩm từ giao diện người dùng và cập nhật vào đối tượng SanPham
                SanPham sp = new SanPham
                {
                    maSanPham = txtMaSP.Text,
                    tenSanPham = txtTenSP.Text,
                    moTaSanPham = txtMoTaSP.Text,
                    giaNhap = int.Parse(txtGiaNhap.Text),
                    donGiaNiemYet = int.Parse(txtGiaNiemYet.Text),
                    chatLieu = txtChatLieu.Text,
                };

                // Gọi phương thức SuaSanPham từ lớp SanPhamBLL để thực hiện cập nhật sản phẩm vào CSDL
                SanPhamBLL spbll = new SanPhamBLL();
                spbll.SuaSanPham(sp);

                // Thực hiện cập nhật số lượng tồn kho (nếu cần)
                MaSanPhamTheoSize spts = new MaSanPhamTheoSize
                {
                    maSize = cbSize.Text,
                    maSanPham = txtMaSP.Text,
                    soLuongTonKho = int.Parse(txtSoLuong.Text)
                };
                MaSanPhamTheoSizeBLL mspts = new MaSanPhamTheoSizeBLL();
                mspts.SuaSoLuongTonKho(spts);

                // Hiển thị thông báo khi sửa thành công
                MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách sản phẩm sau khi sửa thành công
                LoadDsSanPham();
            }
            catch (Exception exception)
            {
                // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                MessageBox.Show("Sửa sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maSP = txtMaSP.Text; // Lấy mã sản phẩm từ TextBox
                    AnhSanPhamBLL asp = new AnhSanPhamBLL();
                    asp.XoaMaSanPhamTrongAnh(maSP);
                    MaSanPhamTheoSizeBLL mspts = new MaSanPhamTheoSizeBLL();
                    mspts.XoaSanPhamTheoSize(maSP);
                    SanPhamBLL spbll = new SanPhamBLL();
                    spbll.XoaSanPham(maSP); // Truyền mã sản phẩm (chuỗi) vào phương thức
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsSanPham();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Xóa sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemSP.Text;

            SanPhamBLL spbll = new SanPhamBLL();
            List<SanPham> ketQuaTimKiem = spbll.TimKiemSanPham(tuKhoa);

            // Xóa tất cả các hàng hiện có trong DataGridView
            dgvSanPham.Rows.Clear();

            if (ketQuaTimKiem.Count > 0)
            {
                // Nếu có kết quả tìm kiếm, thêm từng sản phẩm vào DataGridView
                foreach (SanPham sp in ketQuaTimKiem)
                {
                    dgvSanPham.Rows.Add(sp.maSanPham, sp.tenSanPham, sp.moTaSanPham, sp.giaNhap, sp.donGiaNiemYet,  sp.chatLieu);
                }

                MessageBox.Show("Tìm thấy " + ketQuaTimKiem.Count + " sản phẩm.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào với từ khóa '" + tuKhoa + "'.");
            }
        }

        private void LoadDsNhanVien()
        {
            NhanVienBLL nvbll = new BLL.NhanVienBLL();
            List<NhanVien> dsnvGui = nvbll.LoadDlNhanVien();
            dgvNhanVien.Rows.Clear();
            foreach (NhanVien nv in dsnvGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.hoNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.tenNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.gioiTinh });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.soDienThoai });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.ngaySinh });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.chucVu });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.pass });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = nv.maCuaHang });
                // Thêm hàng vào DataGridView
                dgvNhanVien.Rows.Add(row);
            }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "ngaySinh" && e.Value != null)
            {
                // Định dạng giá trị trong cột "Ngày nhập" theo định dạng dd/MM/yyyy
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true; // Đánh dấu rằng việc định dạng đã được áp dụng
            }
        }
        private Boolean getGioiTinhNV()
        {
            Boolean gt = false;
            String sgt = cbGioiTinhNV.SelectedItem.ToString();
            if (sgt == "Nam")
                gt = true;
            return gt;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinhNV.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDTNV.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(cbMaCuaHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    NhanVien nv = new NhanVien
                    {
                        maNhanVien = txtMaNV.Text,
                        hoNhanVien = txtHoNV.Text,
                        tenNhanVien = txtTenNV.Text,
                        gioiTinh = getGioiTinhNV(),
                        diaChi = txtDiaChiNV.Text,
                        soDienThoai = txtSDTNV.Text,
                        ngaySinh = dateNgaySinhNV.Value,

                        chucVu = cbChucVu.Text,
                        pass = txtPass.Text,
                        maCuaHang = cbMaCuaHang.Text
                    };
                    NhanVienBLL nhanVienBLL = new NhanVienBLL();
                    nhanVienBLL.ThemNhanVien(nv);
                    MessageBox.Show("Nhân viên được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm nhân viên. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = selectedRow.Cells["maNhanVien"].Value.ToString();
                txtMaNV.ReadOnly = true; // không cho sửa mã
                txtHoNV.Text = selectedRow.Cells["hoNhanVien"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["tenNhanVien"].Value.ToString();
                txtDiaChiNV.Text = selectedRow.Cells["diaChi"].Value.ToString();
                txtSDTNV.Text = selectedRow.Cells["soDienThoai"].Value.ToString();
                txtPass.Text = selectedRow.Cells["pass"].Value.ToString();


                // Lấy giá trị từ cột "gioiTinh" trong dòng được chọn
                string gioiTinhValue = selectedRow.Cells["gioiTinh"].Value.ToString();

                // Chuyển giá trị True, False thành "Nam" hoặc "Nữ" và gán cho ComboBox
                if (gioiTinhValue == "True")
                {
                    cbGioiTinhNV.SelectedItem = "Nam";
                }
                else
                {
                    cbGioiTinhNV.SelectedItem = "Nữ";
                }

                foreach (var item in cbChucVu.Items)
                    if ((string)item == selectedRow.Cells["chucVu"].Value.ToString())
                        cbChucVu.SelectedItem = item;
                foreach (var item in cbMaCuaHang.Items)
                    if ((string)item == selectedRow.Cells["maCuaHang"].Value.ToString())
                        cbMaCuaHang.SelectedItem = item;

                string ngaySinhValue = selectedRow.Cells["ngaySinh"].Value.ToString();

                // Chuyển đổi giá trị thành kiểu DateTime và gán cho DateTimePicker
                if (DateTime.TryParse(ngaySinhValue, out DateTime ngaySinh))
                {
                    dateNgaySinhNV.Value = ngaySinh;
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                bool gioiTinhValue;
                if (cbGioiTinhNV.Text == "Nam")
                {
                    gioiTinhValue = true;
                }
                else
                {
                    gioiTinhValue = false;
                }
                NhanVien nv = new NhanVien
                {
                    maNhanVien = txtMaNV.Text,
                    hoNhanVien = txtHoNV.Text,
                    tenNhanVien = txtTenNV.Text,
                    gioiTinh = gioiTinhValue,
                    diaChi = txtDiaChiNV.Text,
                    soDienThoai = txtSDTNV.Text,
                    ngaySinh = dateNgaySinhNV.Value,
                    chucVu = cbChucVu.Text,
                    pass = txtPass.Text,
                    maCuaHang = cbMaCuaHang.Text
                };


                NhanVienBLL nvBLL = new NhanVienBLL();
                nvBLL.editNhanVien(nv);


                MessageBox.Show("Sửa sản nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadDsNhanVien();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sửa nhân viên thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapLaiNV_Click(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtHoNV.Clear();
            txtTenNV.Clear();
            txtDiaChiNV.Clear();
            txtSDTNV.Clear();
            txtPass.Clear();
            cbGioiTinhNV.SelectedIndex = -1;
            dateNgaySinhNV.ResetText();
            cbChucVu.SelectedIndex = -1;
            cbMaCuaHang.SelectedIndex = -1;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maNV = txtMaNV.Text; 
                    NhanVienBLL nvBLL = new NhanVienBLL();
                    nvBLL.XoaNhanVien(maNV);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsNhanVien();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Xóa nhân viên thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemNV.Text;

            NhanVienBLL nvBLL = new NhanVienBLL();
            List<NhanVien> ketQuaTimKiem = nvBLL.TimKiemNhanVien(tuKhoa);

            dgvNhanVien.Rows.Clear();

            if (ketQuaTimKiem.Count > 0)
            {
                foreach (NhanVien nv in ketQuaTimKiem)
                {
                    dgvNhanVien.Rows.Add(nv.maNhanVien, nv.hoNhanVien, nv.tenNhanVien, nv.gioiTinh, nv.diaChi, nv.soDienThoai, nv.ngaySinh, nv.chucVu, nv.pass, nv.maCuaHang);
                }

                MessageBox.Show("Tìm thấy " + ketQuaTimKiem.Count + " nhân viên.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa '" + tuKhoa + "'.");
            }
        }

        private void LoadDsCuaHang()
        {
            CuaHangBLL chBLL = new BLL.CuaHangBLL();
            List<CuaHang> dsCHGui = chBLL.getCuaHang();
            dgvCuaHang.Rows.Clear();
            foreach (CuaHang ch in dsCHGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.maCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.tenCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.SDT });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.gioMoCua });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ch.gioDongCua });
                
                // Thêm hàng vào DataGridView
                dgvCuaHang.Rows.Add(row);
            }
        }

        private void btnThemCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCH.Text) ||
                string.IsNullOrWhiteSpace(txtTenCH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiCH.Text) ||
                string.IsNullOrWhiteSpace(txtSDTCH.Text))
                
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cửa hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    TimeSpan gioMoCH = dateGioMoCua.Value.TimeOfDay; // Lấy thời gian mở cửa
                    TimeSpan gioDongCH = dateGioDongCua.Value.TimeOfDay; // Lấy thời gian đóng cửa

                    CuaHang ch = new CuaHang
                    {

                        maCuaHang = txtMaCH.Text,
                        tenCuaHang = txtTenCH.Text,
                        diaChi = txtDiaChiCH.Text,
                        SDT = txtSDTCH.Text,
                        gioMoCua = gioMoCH,
                        gioDongCua = gioDongCH
                        

                       
                    };
                    CuaHangBLL chBLL = new CuaHangBLL();
                    chBLL.ThemCuaHang(ch);
                    MessageBox.Show("Cửa hàng được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsCuaHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaCH_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gioMoCH = dateGioMoCua.Value.TimeOfDay; // Lấy thời gian mở cửa
                TimeSpan gioDongCH = dateGioDongCua.Value.TimeOfDay; // Lấy thời gian đóng cửa
                CuaHang ch = new CuaHang
                {
                    maCuaHang = txtMaCH.Text,
                    tenCuaHang = txtTenCH.Text,
                    diaChi = txtDiaChiCH.Text,
                    SDT = txtSDTCH.Text,
                    gioMoCua = gioMoCH,
                    gioDongCua = gioDongCH,
                    
                };


                CuaHangBLL chBLL = new CuaHangBLL();
                chBLL.SuaCuaHang(ch);


                MessageBox.Show("Sửa thông tin cửa hàng "+ txtTenCH.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadDsCuaHang();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sửa thông tin cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCuaHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvCuaHang.Rows[e.RowIndex];
                txtMaCH.Text = selectedRow.Cells["maCuaHang1"].Value.ToString();
                txtMaCH.ReadOnly = true; // không cho sửa mã
                txtTenCH.Text = selectedRow.Cells["tenCuaHang"].Value.ToString();
                txtDiaChiCH.Text = selectedRow.Cells["diaChiCuaHang"].Value.ToString();
                txtSDTCH.Text = selectedRow.Cells["SDT"].Value.ToString();

                // Lấy giờ mở cửa và giờ đóng cửa từ DataGridView
                string gioMoCuaStr = selectedRow.Cells["gioMoCua"].Value.ToString();
                string gioDongCuaStr = selectedRow.Cells["gioDongCua"].Value.ToString();

                // Chuyển đổi chuỗi thời gian sang kiểu TimeSpan
                TimeSpan gioMoCua = TimeSpan.Parse(gioMoCuaStr);
                TimeSpan gioDongCua = TimeSpan.Parse(gioDongCuaStr);

                // Hiển thị giờ mở cửa và giờ đóng cửa lên các DateTimePicker hoặc TextBox tương ứng
                dateGioMoCua.Value = DateTime.Today.Add(gioMoCua);
                dateGioDongCua.Value = DateTime.Today.Add(gioDongCua);

            }
        }

        private void btnNhapLaiCH_Click(object sender, EventArgs e)
        {
            txtMaCH.ReadOnly = false;
            txtMaCH.Clear();
            txtTenCH.Clear();
            txtDiaChiCH.Clear();
            txtSDTCH.Clear();
            dateGioMoCua.ResetText();
            dateGioDongCua.ResetText();
        }

        private void btnXoaCH_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa cửa hàng "+ txtTenCH.Text +"?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maCH = txtMaCH.Text;
                    CuaHangBLL chBLL = new CuaHangBLL();
                    chBLL.XoaCuaHang(maCH);
                    MessageBox.Show("Xóa cửa hàng "+ txtTenCH.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsCuaHang();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Xóa cửa hàng "+ txtTenCH.Text + " thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemCH_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemCH.Text;

            CuaHangBLL chBLL = new CuaHangBLL();
            List<CuaHang> ketQuaTimKiem = chBLL.TimKiemCuaHang(tuKhoa);

            dgvCuaHang.Rows.Clear();

            if (ketQuaTimKiem.Count > 0)
            {
                foreach (CuaHang ch in ketQuaTimKiem)
                {
                    dgvCuaHang.Rows.Add(ch.maCuaHang, ch.tenCuaHang, ch.diaChi, ch.SDT, ch.gioMoCua, ch.gioDongCua);
                }

                MessageBox.Show("Tìm thấy " + ketQuaTimKiem.Count + " cửa hàng.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy cửa hàng nào với từ khóa '" + tuKhoa + "'.");
            }
        }

        private void LoadDsSPCH()
        {
            SanPham_CuaHangBLL spchBLL = new BLL.SanPham_CuaHangBLL();
            List<SanPham_CuaHang> dsCHSPGui = spchBLL.LoadDlSP_CH();
            dgvSanPhamCuaHang.Rows.Clear();
            foreach (SanPham_CuaHang spch in dsCHSPGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.maCuaHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spch.soLuong });
                
                // Thêm hàng vào DataGridView
                dgvSanPhamCuaHang.Rows.Add(row);
            }
        }

        private void dgvSanPhamCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPhamCuaHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvSanPhamCuaHang.Rows[e.RowIndex];
                foreach (var item in cbMaCuaHangSP.Items)
                    if ((string)item == selectedRow.Cells["maCuaHangSP"].Value.ToString())
                        cbMaCuaHangSP.SelectedItem = item;

                foreach (var item in cbMaSanPhamCH.Items)
                    if ((string)item == selectedRow.Cells["maSanPhamCH"].Value.ToString())
                        cbMaSanPhamCH.SelectedItem = item;

                txtSoLuongSPCH.Text = selectedRow.Cells["soLuongSPCH"].Value.ToString();

            }
        }

        private void btnThemSPChoCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaCuaHangSP.Text) ||
                string.IsNullOrWhiteSpace(cbMaSanPhamCH.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongSPCH.Text))   
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string maSanPham = cbMaSanPhamCH.Text;
                    int soLuongNhap = int.Parse(txtSoLuongSPCH.Text);

                    // Load số lượng tồn kho hiện tại từ cơ sở dữ liệu
                    MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                    List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                    MaSanPhamTheoSize maSPtheoSize = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSanPham);

                    if (maSPtheoSize != null)
                    {
                        // Kiểm tra xem số lượng nhập có vượt quá số lượng tồn kho không
                        if (soLuongNhap > maSPtheoSize.soLuongTonKho)
                        {
                            MessageBox.Show("Số lượng nhập vượt quá số lượng tồn kho. Không thể thêm sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Trừ số lượng nhập từ số lượng tồn kho hiện tại
                            maSPtheoSize.soLuongTonKho -= soLuongNhap;

                            // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                            msptsBLL.SuaSoLuongTonKho(maSPtheoSize);
                        }
                        
                    }

                    // Tiến hành thêm sản phẩm cho cửa hàng
                    SanPham_CuaHang spch = new SanPham_CuaHang
                    {
                        maCuaHang = cbMaCuaHangSP.Text,
                        maSPTheoSize = maSanPham,
                        soLuong = soLuongNhap
                    };

                    SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                    spchBLL.ThemSPChoCH(spch);

                    MessageBox.Show("Sản phẩm được thêm cho cửa hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsSPCH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm sản phẩm cho cửa hàng. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        }

        private void btnSuaSPCuaCH_Click(object sender, EventArgs e)
        {
            try
            {
                string maCuaHang = cbMaCuaHangSP.Text;
                string maSanPham = cbMaSanPhamCH.Text;
                int soLuongNhapMoi = int.Parse(txtSoLuongSPCH.Text);

                // Declare the spch variable here
               

                // Load số lượng tồn kho hiện tại từ cơ sở dữ liệu
                MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                MaSanPhamTheoSize sanPham = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSanPham);

                if (sanPham != null)
                {
                    int soLuongBanDau = int.Parse(dgvSanPhamCuaHang.SelectedRows[0].Cells["soLuongSPCH"].Value.ToString());
                    int soLuongChenhLech = soLuongNhapMoi - soLuongBanDau;

                    // Kiểm tra xem số lượng nhập mới có vượt quá số lượng tồn kho không
                    if (soLuongChenhLech > sanPham.soLuongTonKho)
                    {
                        MessageBox.Show("Số lượng nhập vượt quá số lượng tồn kho. Không thể sửa sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không thực hiện sửa sản phẩm nếu số lượng nhập vượt quá tồn kho
                    }
                    else
                    {
                        // Tính toán số lượng tồn kho mới bằng số lượng nhập mới
                        sanPham.soLuongTonKho -= soLuongChenhLech ;

                        // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                        msptsBLL.SuaSoLuongTonKho(sanPham);
                    }

                    
                }

                // Tiến hành sửa sản phẩm cho cửa hàng
                SanPham_CuaHang spch = new SanPham_CuaHang
                {
                    maCuaHang = maCuaHang,
                    maSPTheoSize = maSanPham,
                    soLuong = soLuongNhapMoi
                };
                SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                spchBLL.SuaSPCuaCH(spch);

                MessageBox.Show("Sửa thông tin sản phẩm cho cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDsSPCH();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sửa thông tin sản phẩm cho cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSPCuaCH_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm của cửa hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maCH = cbMaCuaHangSP.Text;
                    string maSPTS = cbMaSanPhamCH.Text;

                    // Lấy thông tin sản phẩm từ DataGridView
                    int soLuongBanDau = int.Parse(dgvSanPhamCuaHang.SelectedRows[0].Cells["soLuongSPCH"].Value.ToString());

                    // Trừ soLuongBanDau từ soLuongTonKho của sản phẩm trong cơ sở dữ liệu
                    MaSanPhamTheoSizeBLL msptsBLL = new MaSanPhamTheoSizeBLL();
                    List<MaSanPhamTheoSize> msptsList = msptsBLL.LoadDlMaSPTheoSize();
                    MaSanPhamTheoSize sanPham = msptsList.SingleOrDefault(s => s.maSPTheoSize == maSPTS);

                    if (sanPham != null)
                    {
                        sanPham.soLuongTonKho += soLuongBanDau;

                        // Cập nhật số lượng tồn kho mới vào cơ sở dữ liệu
                        msptsBLL.SuaSoLuongTonKho(sanPham);
                    }

                    // Xóa sản phẩm của cửa hàng
                    SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
                    spchBLL.XoaSPCuaCH(maCH, maSPTS);

                    MessageBox.Show("Xóa sản phẩm của cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDsSPCH();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Xóa sản phẩm của cửa hàng thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapLaiSPChoCH_Click(object sender, EventArgs e)
        {
            cbMaCuaHangSP.SelectedIndex = -1;
            cbMaSanPhamCH.SelectedIndex = -1;
            txtSoLuongSPCH.Clear();
        }

        private void btnTimKiemSPCuaCH_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemSPCuaCH.Text;

            SanPham_CuaHangBLL spchBLL = new SanPham_CuaHangBLL();
            List<SanPham_CuaHang> ketQuaTimKiem = spchBLL.TimKiemSanPham_CuaHang(tuKhoa);

            dgvSanPhamCuaHang.Rows.Clear();

            if (ketQuaTimKiem.Count > 0)
            {
                foreach (SanPham_CuaHang spch in ketQuaTimKiem)
                {
                    dgvSanPhamCuaHang.Rows.Add(spch.maCuaHang, spch.maSPTheoSize, spch.soLuong);
                }

                MessageBox.Show("Tìm thấy " + ketQuaTimKiem.Count + " cửa hàng.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy cửa hàng nào với từ khóa '" + tuKhoa + "'.");
            }
        }
    }
}

