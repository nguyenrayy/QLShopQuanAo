using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return false;             
        }

    }
}
