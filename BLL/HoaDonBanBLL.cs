using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBanBLL
    {
        HoaDonBanDAL hdbDAL = new HoaDonBanDAL();
        SanPhamBLL spBLL = new SanPhamBLL();
        public List<HoaDonBan> getHoaDonBanList(KhachHang kh)
        {
            return hdbDAL.getHoaDonBanList(kh);
        }
        public bool addHoaDonBan(HoaDonBan hdb)
        {
            return hdbDAL.addHoaDonBan(hdb);
        }
        public bool delHoaDonBan(HoaDonBan hdb)
        {
            return hdbDAL.delHoaDonBan(hdb);
        }
        public HoaDonBan SetHoaDonBan(HoaDonBan hdb, NhanVien nv, KhachHang kh)
        {
            var mchnew = new String(nv.maCuaHang.Where(Char.IsLetter).ToArray());
            hdb.maHoaDon = mchnew + kh.maKhachHang + (countHoaDonBan(kh) + 1).ToString();
            hdb.maNhanVien = nv.maNhanVien;
            hdb.maKhachHang = kh.maKhachHang;
            hdb.ngayLapHoaDon = DateTime.Now;
            return hdb;
        }

        // Chi Tiết Hóa Đơn Bán
        public List<ChiTietHoaDon> getCTHDList(ChiTietHoaDon cthd)
        {
            return hdbDAL.getCTHDList(cthd);
        }

        public bool addChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.addChiTietHoaDon(cthd);
        }
        public bool editChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.editChiTietHoaDon(cthd);
        }
        public Boolean delChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return hdbDAL.delChiTietHoaDon(cthd);
        }
        public int countHoaDonBan(KhachHang kh)
        {
            return hdbDAL.countHoaDonBan(kh);
        }
        public double tinhTongTien(KhachHang kh)
        {
            return hdbDAL.tinhTongTien(kh);
        }
        public int TinhTongTien(List<ChiTietHoaDon> cthdlprivate)
        {
            int t = 0;
            foreach (ChiTietHoaDon cthd in cthdlprivate)
            {
                String msp = cthd.maSanPhamTheoSize.Split('_')[0];
                int donGia = spBLL.getSanPham(msp).donGiaNiemYet;
                t += donGia * cthd.soLuong;
            }
            return t;
        }
        public List<HoaDonBan> getHDBListTheoCH(List<NhanVien> nhanVienList, List<HoaDonBan> hdbl)
        {
            List<HoaDonBan> hdblSameStore = new List<HoaDonBan>();
            foreach (HoaDonBan hdb in hdbl)
            {
                if (nhanVienList.Any(nhanvien => nhanvien.maNhanVien == hdb.maNhanVien))
                {
                    hdblSameStore.Add(hdb);
                }
            }
            return hdblSameStore;
        }
        public List<HoaDonBan> TimKiemHDB(string tuKhoa)
        {
            return hdbDAL.TimKiemHDB(tuKhoa);
        }

        }
}