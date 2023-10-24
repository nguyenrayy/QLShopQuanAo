using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FNhanVienSanPham : UserControl
    {
        private FNhanVien fnhanVienForm;


        // Gọi các lớp BLL cần sử dụng
        SanPhamBLL spBLL = new SanPhamBLL();
        MaSanPhamTheoSizeBLL sptsBLL = new MaSanPhamTheoSizeBLL();
        SanPhamCuaHangBLL spchBLL = new SanPhamCuaHangBLL();
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();

        public static HoaDonBan hdb = new HoaDonBan();

        
        SanPham sp = null;
        NhanVien nv = FNhanVien.getNhanVien();
        KhachHang kh = FNVKhachHang.GetKhach();


        List<ChiTietHoaDon> cthdl = new List<ChiTietHoaDon>();
        public List<SanPham> spl = null;
        public List<SanPham_CuaHang> spchl = null;
        public FNhanVienSanPham(FNhanVien form)
        {

            InitializeComponent();
            fnhanVienForm = form;


            // load Danh sách Sản phẩm theo cửa hàng của Nhân Viên
            spl = spBLL.LoadDlSanPham();
            spchl = spchBLL.getSPTheoCuaHangList();
            loadSanPhamNhanVien(spl, spchl);

            //Lấy thông tin khách hàng
            loadKhachHang(kh);

            // Sau khi lap hoa don thi Khoi tao HDB
            setHoaDonBan(nv, kh);
        }
        private HoaDonBan setHoaDonBan(NhanVien nv, KhachHang kh)
        {
            hdb.maHoaDon = hdbBLL.maHoaDonBan(nv, kh, hdbBLL.countHoaDonBan(kh) + 1);
            hdb.maNhanVien = nv.maNhanVien;
            hdb.maKhachHang = kh.maKhachHang;
            hdb.ngayLapHoaDon = DateTime.Now;
            return hdb;
        }
        public void loadSanPhamNhanVien(List<SanPham> spl, List<SanPham_CuaHang> spchl)
        {
            try
            {
                dgSPNV.DataSource = spBLL.ListSPNhanVien(nv, spl,
                    sptsBLL.getMSPTheoSizeList(), spchl);

                dgSPNV.Columns["maSPTheoSize"].HeaderText = "Mã SP";
                dgSPNV.Columns["maSPTheoSize"].Width = 50;
                dgSPNV.Columns["tenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgSPNV.Columns["tenSanPham"].Width = 100;
                dgSPNV.Columns["moTaSanPham"].HeaderText = "Mô Tả SP";
                dgSPNV.Columns["moTaSanPham"].Width = 220;
                dgSPNV.Columns["donGiaNiemYet"].HeaderText = "Giá Bán";
                dgSPNV.Columns["ngayNhap"].HeaderText = "Ngày Nhập";
                dgSPNV.Columns["chatLieu"].HeaderText = "Chất Liệu";
                dgSPNV.Columns["soLuong"].HeaderText = "Số Lượng";
                dgSPNV.Columns["soLuong"].Width = 50;

                dgSPNV.Columns["giaNhap"].Visible = false;
                dgSPNV.Columns["maNhaSanXuat"].Visible = false;
                dgSPNV.Columns["maCuaHang"].Visible = false;
            }
            catch (Exception ex)
            {
                lbWarningSP.Text= "Có lỗi trong lúc load dữ liệu";
            }    
        }
        private void loadKhachHang(KhachHang kh)
        {
            txtSPNVHo.Text = kh.tenKhach;
            txtSPNVMa.Text = kh.maKhachHang;
            txtSPNVDiaChi.Text = kh.diaChi;
            txtSPNVSDT.Text = kh.soDienThoai;
            txtSPNVGioiTinh.Text = kh.gioiTinh==true?"Nam":"Nữ";
            txtSPNVNgaySinh.Text = kh.ngaySinh.ToShortDateString();
        }
        
        private void txtSPNVSearch_TextChanged(object sender, EventArgs e)
        {
            List<SanPham> spl = spBLL.TimKiemSanPham(txtSPNVSearch.Text);
            List<SanPham_CuaHang> spchl = spchBLL.getSPTheoCuaHangList();
            loadSanPhamNhanVien(spl, spchl);
        }

        private FChiTietHoaDon fhd = null;
        private bool checkHien = false;
        private void btSPHD_Xem_Click(object sender, EventArgs e)
        {

            if (txtSPNVMa.Text == "")
            {
                lbWarningSP.Text = "Hãy chọn khách hàng !";
            }
            else
            {
                if (!checkHien)
                {
                    btSPHD_Xem.Text = "Ẩn Hóa Đơn";
                    fhd = new FChiTietHoaDon(cthdl);
                    fhd.Location = new Point(this.Location.X + this.Width + 450, this.Location.Y + 250);
                    fhd.Show();
                    checkHien = true;
                }
                else
                {
                    btSPHD_Xem.Text = "Hiện Hóa Đơn";
                    fhd.Hide();
                    checkHien = false;
                }
            }
        }

        private void dgSPNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtSP_Ma.Text = dgSPNV.SelectedRows[0].Cells["maSPTheoSize"].Value.ToString();
            txtSP_Ten.Text = dgSPNV.SelectedRows[0].Cells["tenSanPham"].Value.ToString();
            txtSP_Gia.Text = dgSPNV.SelectedRows[0].Cells["donGiaNiemYet"].Value.ToString() + " VNĐ";
            txtSP_SoLuong.Text = dgSPNV.SelectedRows[0].Cells["soLuong"].Value.ToString();                  
        }
        private void btSPNV_ThemSP_Click(object sender, EventArgs e)
        {
            if (txtSP_Ma.Text == "")
                lbWarningSP.Text = "Hãy chọn sản phẩm để thêm !";
            else
            {
                int giaBan = Convert.ToInt32(dgSPNV.SelectedRows[0].Cells["donGiaNiemYet"].Value.ToString());
                                
                if (txtSP_SoLuongM.Text == "")
                    lbWarningSP.Text = " Hãy nhập số lượng muốn mua !";
                else
                {                  
                    int soluongmua = Convert.ToInt32(txtSP_SoLuongM.Text);
                    int i = 0;
                    i = Convert.ToInt32(txtSP_SoLuong.Text);
                    if (soluongmua > i)
                    {
                        lbWarningSP.Text = "Số lượng lớn hơn sản phẩm đang có !";
                    }
                    else
                    {
                        ChiTietHoaDon cthd = new ChiTietHoaDon();
                        cthd.maSanPhamTheoSize = txtSP_Ma.Text;
                        cthd.maHoaDon = hdb.maHoaDon;

                        bool maSanPhamValid = cthdl.Exists(ct => ct.maSanPhamTheoSize == txtSP_Ma.Text);

                        if (!maSanPhamValid)
                        {                                                   
                            cthd.soLuong = Convert.ToInt32(txtSP_SoLuongM.Text);
                            cthd.donGia = giaBan * cthd.soLuong;
                            cthd.giamGia = 0;

                            cthdl.Add(cthd);                           
                            lbWarningSP.Text = "Thêm Sản Phẩm thành công !";

                            if (checkHien)
                            {
                                fhd.Update();
                                
                            }
                        }
                        else
                        {
                            lbWarningSP.Text = "Sản Phẩm đã có !";
                        }
                        
                    }
                }    
            }    
        }

        private void txtSP_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8 || e.KeyChar != 13))
            {
                e.Handled = true;

            }
            
        }

        private void btNVNVReset_Click(object sender, EventArgs e)
        {
            txtSPNVMa.Text = "";
            txtSPNVHo.Text = "";
            txtSPNVGioiTinh.Text = "";
            txtSPNVDiaChi.Text = "";
            txtSPNVNgaySinh.Text = "";
            txtSPNVSDT.Text = "";

            txtSP_Gia.Text = "";
            txtSP_Ma.Text = "";
            txtSP_SoLuong.Text = "";
            txtSP_SoLuongM.Text = "";
            txtSP_Ten.Text = "";

            fhd = new FChiTietHoaDon(null);
        }

        private void btFKhachHang_Click(object sender, EventArgs e)
        {
            FNVKhachHang fnvkh = new FNVKhachHang(fnhanVienForm);
            fnhanVienForm.addUserControl(fnvkh);
        }
    }
}