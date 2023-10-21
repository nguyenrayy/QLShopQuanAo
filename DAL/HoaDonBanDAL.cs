using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonBanDAL : DBConnect
    {
        public List<HoaDonBan> getHoaDonBanList(KhachHang kh)
        {
            List<HoaDonBan> hdbl = new List<HoaDonBan>();
            Moketnoi();
            var sql = "SELECT * FROM HoaDonBan";

            if (kh != null)
            {
                sql += " where maKhachHang = @maKhachHang";
            }
            var cmd = new SqlCommand(sql, conec);
            if (kh != null)
            {
                cmd.Parameters.AddWithValue("@maKhachHang", kh.maKhachHang);
            }
            HoaDonBan hdb = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    hdb = new HoaDonBan();
                    hdb.maHoaDon = rd["maHoaDon"].ToString();
                    hdb.maNhanVien = rd["maNhanVien"].ToString();
                    hdb.maKhachHang = rd["maKhachHang"].ToString();
                    hdb.ngayLapHoaDon = rd.GetDateTime(rd.GetOrdinal("ngayLapHoaDon"));
                    hdbl.Add(hdb);
                }
            }
            Dongketnoi();
            return hdbl;
        }

        public bool addHoaDonBan(HoaDonBan hdb)
        {
            Moketnoi();
            try
            {
                string SQL = string.Format("INSERT INTO HoaDonBan VALUES ('{0}', '{1}', '{2}' , '{3}')",
                  hdb.maHoaDon, hdb.maNhanVien, hdb.maKhachHang, hdb.ngayLapHoaDon);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            { return false; }
            finally { Dongketnoi(); }
            return false;
        }
        public Boolean delHoaDonBan(HoaDonBan hdb)
        {
            Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM HoaDonBan WHERE maHoaDon = '{0}'", hdb.maHoaDon);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;
        }
        public int countHoaDonBan(KhachHang kh)
        {
            int i = 0;
            Moketnoi();
            try
            {
                var sql = "SELECT count(*) FROM HoaDonBan WHERE maKhachHang = @maKhachHang";
                var cmd = new SqlCommand(sql, conec);
                cmd.Parameters.AddWithValue("@maKhachHang", kh.maKhachHang);
                if (cmd.ExecuteScalar() is int)
                {
                    i = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally { Dongketnoi(); }
            return i;

        }
        public double tinhTongTien(KhachHang kh)
        {
            double i = 0;
            Moketnoi();
            try
            {
                var sql = "  SELECT SUM(sp.donGiaNiemYet * soLuong - (sp.donGiaNiemYet * soLuong*giamGia)) from ChiTietHoaDon as cthd " +
                    "join HoaDonBan as hdb on hdb.maHoaDon = cthd.maHoaDon " +
                    "join MaSanPhamTheoSize as spts on spts.maSPTheoSize = cthd.maSanPhamTheoSize " +
                    "join SanPham as sp on sp.maSanPham = spts.maSanPham " +
                    "where hdb.maKhachHang = @maKhachHang";
                var cmd = new SqlCommand(sql, conec);
                cmd.Parameters.AddWithValue("@maKhachHang", kh.maKhachHang);
                if (cmd.ExecuteScalar() is double)
                {
                    i = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
            finally { Dongketnoi(); }
            return i;
        }
        public List<ChiTietHoaDon> getCTHDList(ChiTietHoaDon cthd)
        {
            List<ChiTietHoaDon> cthdbl = new List<ChiTietHoaDon>();
            Moketnoi();
            var sql = "SELECT * FROM ChiTietHoaDon WHERE maHoaDon = @mhd";
            var cmd = new SqlCommand(sql, conec);
            cmd.Parameters.AddWithValue("@mhd", cthd.maHoaDon);

            ChiTietHoaDon cthdb = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    cthdb = new ChiTietHoaDon();
                    cthdb.maHoaDon = rd["maHoaDon"].ToString();
                    cthdb.maSanPhamTheoSize = rd["maSanPhamTheoSize"].ToString();
                    cthdb.soLuong = Convert.ToInt32(rd["soLuong"]);

                    cthdb.giamGia = Convert.ToDouble(rd["giamGia"]);
                    cthdbl.Add(cthdb);
                }
            }
            Dongketnoi();
            return cthdbl;
        }


        public bool addChiTietHoaDon(ChiTietHoaDon cthd)
        {
            Moketnoi();
            try
            {
                string SQL = string.Format("INSERT INTO ChiTietHoaDon VALUES ('{0}', '{1}', '{2}' ,  '{3}')",
                    cthd.maHoaDon, cthd.maSanPhamTheoSize, cthd.soLuong, cthd.giamGia);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { Dongketnoi(); }
            return false;
        }
        public bool editChiTietHoaDon(ChiTietHoaDon cthd)
        {
            Boolean success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("UPDATE ChiTietHoaDon SET maSanPham = '{1}', soLuong = '{2}',giamGia = '{3}' " +
                    "WHERE maHoaDon = '{0}'",
                cthd.maHoaDon, cthd.maSanPhamTheoSize, cthd.soLuong, cthd.giamGia);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;

        }
        public Boolean delChiTietHoaDon(ChiTietHoaDon cthd)
        {
            Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM ChiTietHoaDon WHERE maHoaDon = '{0}'", cthd.maHoaDon);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;
        }

    }
}
