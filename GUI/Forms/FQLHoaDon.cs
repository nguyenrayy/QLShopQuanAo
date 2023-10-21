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

namespace GUI.Forms
{
    public partial class FQLHoaDon : Form
    {
        private double tongtien;
        public FQLHoaDon()
        {
            InitializeComponent();
            loadHoaDonList();
        }
        private void loadHoaDonList()
        {
            KhachHang kh = null;
            HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
            List<HoaDonBan> dshdGui = hdbBLL.getHoaDonBanList(kh);
            dgvQLHoaDon.Rows.Clear();
            foreach (HoaDonBan hd in dshdGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maHoaDon });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.ngayLapHoaDon });

                // Thêm hàng vào DataGridView
                dgvQLHoaDon.Rows.Add(row);
            }
        }

        private void dgvQLHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvQLHoaDon.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvQLHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = selectedRow.Cells["maHoaDon"].Value.ToString();

                txtTenNVHD.Text = selectedRow.Cells["maNhanVienHD"].Value.ToString();
                txtTenKHHD.Text = selectedRow.Cells["maKhachHangHD"].Value.ToString();


                string ngayLapHoaDonValue = selectedRow.Cells["ngayLapHoaDon"].Value.ToString();

                // Chuyển đổi giá trị thành kiểu DateTime và gán cho DateTimePicker
                if (DateTime.TryParse(ngayLapHoaDonValue, out DateTime ngayLapHD))
                {
                    dpHDNgay.Value = ngayLapHD;
                }
                loadChiTietHoaDon(selectedRow.Cells["maHoaDon"].Value.ToString());

                
            }
        }

        private void loadChiTietHoaDon(String x)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.maHoaDon = x;
            HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
            List<ChiTietHoaDon> dscthd = hdbBLL.getCTHDList(cthd);
            dgvCTHoaDon.Rows.Clear();
            tongtien = 0;
            SanPhamBLL spBLL =new SanPhamBLL();



            foreach (ChiTietHoaDon cthdList in dscthd)
            {
                
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                

                String msp = cthdList.maSanPhamTheoSize.Split('_')[0];
                int donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                double thanhTien;
                
                thanhTien = cthdList.soLuong * donGia -(cthdList.soLuong * donGia* cthdList.giamGia);
    
                row.Cells.Add(new DataGridViewTextBoxCell { Value = cthdList.maHoaDon });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = cthdList.maSanPhamTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = cthdList.soLuong });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = donGia });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = cthdList.giamGia });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = thanhTien });

                // Thêm hàng vào DataGridView
                dgvCTHoaDon.Rows.Add(row);
                tongtien += thanhTien; 
            }
            txtTongTienCTHD.Text = tongtien.ToString() + "VND";

        }


        private void loadPhieuDoiTraList()
        {
            HoaDonBan hdb = null;
            XuLyDoiTra xldt = null;
            PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
            List<PhieuDoiTra> dspdtGui = pdtBLL.getPhieuDoiTraList(hdb, xldt);
            dgvPhieuDoiTra.Rows.Clear();
            foreach (PhieuDoiTra pdt in dspdtGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.maPhieuDoiTra });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.ngayDoiTra });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.maXuLyDoiTra });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = pdt.maHoaDon });
                // Thêm hàng vào DataGridView
                dgvPhieuDoiTra.Rows.Add(row);
            }
        }
        private void loadCTPhieuDoiTraList(string maPhieuDoiTra)
        {
            CTPhieuDoiTra ctpdtList = new CTPhieuDoiTra();
            ctpdtList.maPhieuDoiTra = maPhieuDoiTra;
            PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
            List<CTPhieuDoiTra> dsctpdtGui = pdtBLL.getCTPDTList(ctpdtList);
            dgvCTPhieuDoiTra.Rows.Clear();
            foreach (CTPhieuDoiTra ctpdt in dsctpdtGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpdt.maPhieuDoiTra });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpdt.maSPTheoSize });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpdt.soLuong });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = ctpdt.maSPTheoSizeRe });
                // Thêm hàng vào DataGridView
                dgvCTPhieuDoiTra.Rows.Add(row);
            }
        }

        private void dgvPhieuDoiTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhieuDoiTra.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvPhieuDoiTra.Rows[e.RowIndex];
                loadCTPhieuDoiTraList(selectedRow.Cells["maPhieuDoiTra"].Value.ToString());
            }
        }

        private void tabQLHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabQLHD.SelectedTab;

            // Kiểm tra xem TabPage được chọn có tên là gì (tùy thuộc vào tên bạn đã đặt)
            if (selectedTab.Name == "tabHD") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                loadHoaDonList();

            }
            if (selectedTab.Name == "tabPDT") // Thay "tabPage1" bằng tên thực sự của TabPage
            {
                loadPhieuDoiTraList();
            }
        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHD.Text;

            HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
            List<HoaDonBan> ketQuaTimKiem = hdbBLL.TimKiemHDB(tuKhoa);

            dgvQLHoaDon.Rows.Clear();


            foreach (HoaDonBan hdb in ketQuaTimKiem)
            {
                dgvQLHoaDon.Rows.Add(hdb.maHoaDon, hdb.maNhanVien, hdb.maKhachHang, hdb.ngayLapHoaDon);
            }
        }

        private void txtTimKiemPDT_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemPDT.Text;

            PhieuDoiTraBLL pdtBLL = new PhieuDoiTraBLL();
            List<PhieuDoiTra> ketQuaTimKiem = pdtBLL.TimKiemPDT(tuKhoa);

            dgvPhieuDoiTra.Rows.Clear();


            foreach (PhieuDoiTra pdt in ketQuaTimKiem)
            {
                dgvPhieuDoiTra.Rows.Add(pdt.maPhieuDoiTra, pdt.maNhanVien, pdt.maKhachHang, pdt.ngayDoiTra, pdt.maXuLyDoiTra, pdt.maHoaDon);
            }
        }
    }
}
