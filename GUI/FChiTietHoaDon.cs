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

namespace GUI
{
    public partial class FChiTietHoaDon : Form
    {
        //FNhanVienSanPham fnvsp = new FNhanVienSanPham(null);

        HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
        SanPhamCuaHangBLL spchBLL = new SanPhamCuaHangBLL();

        SanPham_CuaHang spch = new SanPham_CuaHang();
        HoaDonBan hdb = FNhanVienSanPham.hdb;

        NhanVien nv = FNhanVien.getNhanVien();
        List<ChiTietHoaDon> cthdlprivate = null;
        int soLuongSPTrongCH = 0;

        public FChiTietHoaDon(List<ChiTietHoaDon> cthdl)
        {
            InitializeComponent();


            cthdlprivate = cthdl;
            loadCTHDList(cthdlprivate);

            lbSPNV_MHD.Text = hdb.maHoaDon;
        }

        private void loadCTHDList(List<ChiTietHoaDon> cthdlprivate)
        {

            CTHDList.DataSource = cthdlprivate;

            CTHDList.Columns["maHoaDon"].Visible = false;
            CTHDList.Columns["maSanPhamTheoSize"].HeaderText = "Mã SP";
            CTHDList.Columns["soLuong"].HeaderText = "Số Lượng";
            CTHDList.Columns["donGIa"].HeaderText = "Tổng tiến";
            CTHDList.Columns["giamGia"].HeaderText = "Giảm Giá";

            lbSPNV_TongTien.Text = TinhTongTien(cthdlprivate).ToString() + " VNĐ";
            
        }
        private int TinhTongTien(List<ChiTietHoaDon> cthdlprivate)
        {
            int t = 0;
            foreach (ChiTietHoaDon cthd in cthdlprivate)
            {
                t += cthd.donGia;
            }
            return t;
        }

        private void CTHDList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            lbMSP.Text = CTHDList.SelectedRows[0].Cells["maSanPhamTheoSize"].Value.ToString();
            txtSP_SoLuongM.Text = CTHDList.SelectedRows[0].Cells["soLuong"].Value.ToString();

            spch = spchBLL.getSanPhamCuaHang(FNhanVien.getNhanVien().maCuaHang, lbMSP.Text);            
        }

        private void btLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (cthdlprivate.Count == 0)
                lbWarningCTHD.Text = "Hóa đơn rỗng, không có gì để lưu ! ";
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc sẽ lưu hóa đơn ?", "Hóa đơn", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    if (hdbBLL.addHoaDonBan(hdb))
                    {
                        bool checkThanhCong = true;
                       
                        foreach (ChiTietHoaDon cthd in cthdlprivate)
                        {
                            SanPham_CuaHang spch = spchBLL.getSanPhamCuaHang(nv.maCuaHang, cthd.maSanPhamTheoSize);
                            spch.soLuong -= cthd.soLuong;
                            if(!spchBLL.updateSanPhamCuaHang(spch))
                            {
                                checkThanhCong = false;
                                break;
                            }    
                            if (!hdbBLL.addChiTietHoaDon(cthd))
                            {
                                checkThanhCong = false;                               
                               break;
                            }
                            
                            
                        }
                        if (checkThanhCong)
                        {                          
                            MessageBox.Show("Lưu hóa đơn thành công !", "Hóa đơn", MessageBoxButtons.OK);
                        } 
                        else
                        {
                            lbWarningCTHD.Text = "Lưu sản phẩm vào hóa đơn thất bại !";
                        }    
                    }
                    else
                        MessageBox.Show("Lưu hóa đơn thất bại !", "Hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btCTHDXoa_Click(object sender, EventArgs e)
        {
            if (lbMSP.Text == "")
                lbWarningCTHD.Text = "Hãy chọn sản Phẩm để xóa";
            else
            {
                cthdlprivate.RemoveAll(cthd => cthd.maSanPhamTheoSize == lbMSP.Text);
                lbWarningCTHD.Text = "Xóa SP Thành công !";
                CTHDList.DataSource = null;
                loadCTHDList(cthdlprivate);

            }
        }

        private void btCTHDSua_Click(object sender, EventArgs e)
        {
            FNhanVienSanPham fnvsp = new FNhanVienSanPham(null);
            if (lbMSP.Text == "")
                lbWarningCTHD.Text = "Hãy chọn sản phẩm để đổi !";
            else
            {
                if (txtSP_SoLuongM.Text == "")
                    lbWarningCTHD.Text = "Hãy nhập số lượng cần mua !";
                else
                {
                    int i = Convert.ToInt32(txtSP_SoLuongM.Text);
                    if ( spch.soLuong < i)
                        lbWarningCTHD.Text = "Số lượng sản phẩm lớn hơn đang có !";
                    else
                    {
                        ChiTietHoaDon sanPhamCanCapNhat = cthdlprivate.FirstOrDefault(cthd => cthd.maSanPhamTheoSize == lbMSP.Text);
                        sanPhamCanCapNhat.soLuong = Convert.ToInt32(txtSP_SoLuongM.Text);
                        CTHDList.Refresh();
                        lbWarningCTHD.Text = "Đổi số lượng thành công !";
                    }
                }
            }    
        }

        private void txtSP_SoLuongM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8 || e.KeyChar != 13))
            {
                e.Handled = true;

            }
        }
    } 

}
