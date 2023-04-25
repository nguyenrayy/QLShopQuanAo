using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    public class ThongKeDoanhThuService
    {
        public DataTable getHoaDon()
        {
            SqlCommand cmd = new SqlCommand("select * from HoaDonBan", DBConnect.Conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            dt.Fill(dta);
            return dta;
        }
        public DataTable getSanPhamTKDT()
        {
            SqlCommand cmd = new SqlCommand("select * from SanPham", DBConnect.Conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            dt.Fill(dta);
            return dta;
        }

        public bool xoaHoaDon(string MHD)
        {
            
            string SQL = string.Format("DELETE FROM ChiTietHoaDon WHERE maHoaDon = {0}", MHD);
            string sql2 = string.Format("DELETE FROM HoaDonBan WHERE maHoaDon = {0}", MHD);
            SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            int r = cmd.ExecuteNonQuery();
            if(r > 0)
            {
                
                SqlCommand cmd2 = new SqlCommand(sql2, DBConnect.Conn);
                return  cmd2.ExecuteNonQuery() > 0;
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand(sql2, DBConnect.Conn);
                return cmd2.ExecuteNonQuery() > 0;
            }    
                      
        }

        public string countTongHoaDon(DateTime nbd, DateTime nkt)
        {
           
            string sql = String.Format("select count(*) from HoaDonBan where ngayLapHoaDon between '{0}' and '{1}'", nbd.ToString("yyyy-MM-dd"), nkt.ToString("yyyy-MM-dd"));
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            int count = (int)cmd.ExecuteScalar();
            
            return count.ToString();
        }
        public int TinhTongTien(DateTime nbd, DateTime nkt)
        {
            int i = 0;
            
            string sql = String.Format("select sum(tongTien) from HoaDonBan where ngayLapHoaDon between '{0}' and '{1}'", nbd.ToString("yyyy-MM-dd"), nkt.ToString("yyyy-MM-dd"));
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            i = (int)cmd.ExecuteScalar();        
            return i;
        }
        public int TinhLoiNhuan(DateTime nbd, DateTime nkt)
        {
            int i = 0;

            string sql = String.Format("select Sum(tongTienLoi) as TongCacTienLoi \n" +
                                              "from(SELECT " +
                                                "sp.maSanPham, " +
                                                "SUM(cthd.soLuong) AS tongSoLuong, " +
                                                "SUM((sp.giaXuat - sp.giaNhap) * cthd.soLuong) AS tongTienLoi " +
                                            "FROM ChiTietHoaDon cthd JOIN SanPham sp ON cthd.maSanPham = sp.maSanPham join HoaDonBan hdb on hdb.maHoaDon = cthd.maHoaDon " +
                                            "where hdb.NgayLapHoaDon between '{0}' AND  '{1}'" +
                                            "GROUP BY  sp.maSanPham) as cacTienLoi", nbd.ToString("yyyy-MM-dd"), nkt.ToString("yyyy-MM-dd"));
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            i = (int)cmd.ExecuteScalar();
            return i;
        }
        public string getSoLuong(string msp, DateTime nbd, DateTime nkt)
        {
            string sql = String.Format(" select sum(soLuong) from ChiTietHoaDon cthd join HoaDonBan hdb on cthd.maHoaDon = hdb.maHoaDon" +
                " where maSanPham ={0} and hdb.ngayLapHoaDon between '{1}' and '{2}'", msp, nbd.ToString("yyyy-MM-dd"), nkt.ToString("yyyy-MM-dd"));
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);          
            string i = cmd.ExecuteScalar().ToString();
            if (i == "")
                return "0";
            return i;
        }
    }
}
