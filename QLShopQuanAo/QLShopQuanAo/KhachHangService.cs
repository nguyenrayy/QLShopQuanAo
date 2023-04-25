using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace QLShopQuanAo
{
    public class KhachHangService
    {
        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM khachhang", DBConnect.Conn);
            DataTable dtSinhvien = new DataTable();
            da.Fill(dtSinhvien);
            return dtSinhvien;
        }

        public DataTable getNhanVien()
        {
            SqlDataAdapter nv = new SqlDataAdapter("SELECT * FROM NhanVien", DBConnect.Conn);
            DataTable data1 = new DataTable();
            nv.Fill(data1);
            return data1;
        }
        public bool themKH(KhachHang kh)
        {
           
                string SQL = string.Format("INSERT INTO khachhang VALUES ('{0}', '{1}', '{2}' , '{3}')", kh.MaKhachHang, kh.TenKhachHang, kh.DiaChi, kh.SDT);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
          
        }

        public bool suaKhachHang(KhachHang kh)
        {
            try
            {
                string SQL = string.Format("UPDATE khachhang SET tenKhach = '{0}',diaChi = '{1}', soDienThoai = '{2}' WHERE maKhach = {3}",
                kh.TenKhachHang, kh.DiaChi, kh.SDT, kh.MaKhachHang);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public bool xoaKhachHang(string id)
        {
            try
            {
                string SQL = string.Format("DELETE FROM khachhang WHERE maKhach = {0}", id);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }
        public bool ktraKhachHang(string sdt)
        {
            string sql = "select count(*) from khachhang where soDienThoai = @soDienThoai ";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@soDienThoai", sdt);
            int r = (int)cmd.ExecuteScalar();
            if (r > 0)
                return true;
            else
                return false;
        }
        public string getTenKhachHang(string MKH)
        {
            string name = "";
            string sql = "select * from khachhang where maKhach =@maKhach";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maKhach", MKH);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                name = rd["tenKhach"].ToString();
            }
            rd.Close();
            return name;
        }
        public string getTenNhanVien(string MNV)
        {
            string name = "";
            string sql = "select * from NhanVien where maNhanVien =@maNhanVien";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maNhanVien", MNV);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                name = rd["tenNhanVien"].ToString();
            }
            rd.Close();
            return name;
        }
    }
    


}
    

