using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class FNhanVienHoaDon : UserControl
    {
        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        KhachHangBLL khBLL = new KhachHangBLL();

        NhanVien nv = FNhanVien.getNhanVien();
        ChiTietHoaDon cthd = new ChiTietHoaDon();
        List<ChiTietHoaDon> cthdl = new List<ChiTietHoaDon> ();
        int tongtien;
        public FNhanVienHoaDon()
        {
            InitializeComponent();
            getHoaDonList();
        }
        private void getHoaDonList()
        {
            List<HoaDonBan> hdbl = hdbBLL.getHoaDonBanList(null);
            List<HoaDonBan> hdblSameStore = new List<HoaDonBan>();
            List<NhanVien> nhanVienList = nvBLL.getNhanVienList(nv.maCuaHang, null);

            foreach (HoaDonBan hdb in hdbl)
            {
                if (nhanVienList.Any(nhanvien => nhanvien.maNhanVien == hdb.maNhanVien))
                {
                    hdblSameStore.Add(hdb);
                }
            }
            dgHDNV.DataSource = hdblSameStore;
            dgHDNV.Columns["maHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgHDNV.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
            dgHDNV.Columns["maKhachHang"].HeaderText = "Mã Khách Hàng";
            dgHDNV.Columns["ngayLapHoaDon"].HeaderText = "Ngày Lập";
        }
        private void getCTHDList(ChiTietHoaDon cthd)
        {
            cthdl = hdbBLL.getCTHDList(cthd);
            dgCTHD.DataSource = cthdl;
            dgCTHD.Columns["maHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgCTHD.Columns["maSanPhamTheoSize"].HeaderText = "Mã Sản Phẩm";
            dgCTHD.Columns["soLuong"].HeaderText = "Số lượng";
            dgCTHD.Columns["donGia"].HeaderText = "Đơn Giá";
            dgCTHD.Columns["giamGia"].HeaderText = "Giảm Giá";


            tongtien = 0;
            foreach (ChiTietHoaDon item in cthdl)
            {
                tongtien += item.donGia;
            }

        }
        private void dgHDNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgHDNV.SelectedRows[0].Cells["maHoaDon"].Value.ToString();

            String mnv = dgHDNV.SelectedRows[0].Cells["maNhanVien"].Value.ToString();
            NhanVien nvhd = nvBLL.getNhanVien(mnv);
            txtTenNVHD.Text = nvhd.hoNhanVien + " " + nvhd.tenNhanVien;

            String mkh = dgHDNV.SelectedRows[0].Cells["maKhachHang"].Value.ToString();
            txtTenKHHD.Text = khBLL.getKhachHang(mkh).tenKhach;

            dpHDNgay.Value = (DateTime)(dgHDNV.SelectedRows[0].Cells["ngayLapHoaDon"].Value);
        }

        private void btHDXem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                lbWarningHD.Text = "Hãy chọn hóa đơn để xem !";
            }
            else
            {
                cthd.maHoaDon = txtMaHD.Text;
                getCTHDList(cthd);
                txtTongTienCTHD.Text = tongtien.ToString() + "VND";
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            dgCTHD.DataSource = null;
            txtTongTienCTHD.Text = "";
        }

        private void btHDXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                lbWarningHD.Text = "Hãy chọn hóa đơn để xóa !";
            }
            else
            {
                cthd.maHoaDon = txtMaHD.Text;
                bool xoaCTHDThanhCong = false;
                HoaDonBan hdb = new HoaDonBan();
                if (dgCTHD.DataSource == null)
                {
                    lbWarningHD.Text = "Hãy xem Chi tiết hóa đơn trước để xác nhận !";
                }
                else
                {
                    foreach (ChiTietHoaDon cthd in cthdl)
                    {
                        if (!hdbBLL.delChiTietHoaDon(cthd))
                        {
                            lbWarningHD.Text = "Có sản phẩm không thể xóa khỏi hóa đơn !";
                            break;
                        }
                        xoaCTHDThanhCong = true;
                        hdb.maHoaDon = cthd.maHoaDon;
                    }


                    if (xoaCTHDThanhCong && hdbBLL.delHoaDonBan(hdb))
                    {
                        lbWarningHD.Text = "Xóa hóa đơn thành công";
                        txtMaHD_TextChanged(sender, e);
                        getHoaDonList();
                    }
                    else
                        lbWarningHD.Text = "Xóa hóa đơn thất bại";

                }
            }
        }
    }
}
