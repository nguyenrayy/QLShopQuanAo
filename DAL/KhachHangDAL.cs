using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        DBConnect DBConnect = new DBConnect();
        public List<KhachHang> getKhachHangList(String x)
        {
            List<KhachHang> khl = new List<KhachHang>();
            DBConnect.Moketnoi();
            var sql = "SELECT * FROM [KhachHang] WHERE [tenKhach] COLLATE Latin1_General_BIN LIKE @x OR SoDienThoai LIKE @x";
            var cmd = new SqlCommand(sql, DBConnect.conec);
            cmd.Parameters.AddWithValue("@x", $"%{x}%");
            KhachHang kh = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {

                    kh = new KhachHang();
                    kh.maKhachHang = rd["maKhachHang"].ToString();
                    kh.tenKhach = rd["tenKhach"].ToString();
                    kh.gioiTinh = (Boolean)rd["gioiTinh"];
                    kh.ngaySinh = rd.GetDateTime(3);
                    kh.diaChi = rd["diaChi"].ToString();
                    kh.soDienThoai = rd["soDienThoai"].ToString();
                    khl.Add(kh);
                }
            }
            DBConnect.Dongketnoi();
            return khl;
        }
        public KhachHang getKhachHang(String MaKhachHang)
        {
            DBConnect.Moketnoi();
            var sql = "SELECT * FROM KhachHang where maKhachHang = @maKhachHang or soDienThoai = @maKhachHang";
            var cmd = new SqlCommand(sql, DBConnect.conec);
            cmd.Parameters.AddWithValue("@maKhachHang", MaKhachHang);
            KhachHang kh = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    kh = new KhachHang();
                    kh.maKhachHang = rd["maKhachHang"].ToString();
                    kh.tenKhach = rd["tenKhach"].ToString();                   
                    kh.gioiTinh = (Boolean)rd["gioiTinh"];
                    kh.diaChi = rd["diaChi"].ToString();
                    kh.ngaySinh = rd.GetDateTime(3);
                    kh.soDienThoai = rd["soDienThoai"].ToString();
                }
            }
            DBConnect.Dongketnoi();
            return kh;
        }
        public bool themKH(KhachHang kh)
        {
            DBConnect.Moketnoi();
            try
            {
                string SQL = string.Format("INSERT INTO khachhang VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}')",
                    kh.randomString(), kh.tenKhach, kh.gioiTinh, kh.ngaySinh, kh.diaChi, kh.soDienThoai);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { DBConnect.Dongketnoi(); }
        }
        public bool checkKhachHangValid(KhachHang kh)
        {
            Boolean Isvalid = false;
            DBConnect.Moketnoi();
            try
            {
                var sql = "SELECT COUNT(*) FROM dbo.KhachHang WHERE soDienThoai = @soDienThoai";
                var cmd = new SqlCommand(sql, DBConnect.conec);
                cmd.Parameters.AddWithValue("@soDienThoai", kh.soDienThoai);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    Isvalid = true;
                }
            }
         
            finally
            {
                DBConnect.Dongketnoi();
            }
            return Isvalid;
        }
        public bool editKhachHang(KhachHang kh) {
            Boolean success = false;
            DBConnect.Moketnoi();
            try
            {
                string SQL = string.Format("UPDATE khachhang SET tenKhach = '{0}',gioiTinh = '{1}', ngaySinh = '{2}', diaChi ='{3}' , soDienThoai = '{4}' " +
                    "WHERE maKhachHang = '{5}'",
                kh.tenKhach, kh.gioiTinh, kh.ngaySinh, kh.diaChi, kh.soDienThoai, kh.maKhachHang);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success =  true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { DBConnect.Dongketnoi(); }
            return success;
            
        }
        public Boolean delKhachHang(KhachHang kh)
        {
            DBConnect.Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM khachhang WHERE maKhachHang = '{0}'", kh.maKhachHang);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { DBConnect.Dongketnoi(); }
            return success;
        }

       
    }
}
