using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaSanXuatDAL : DBConnect
    {
        public List<NhaSanXuat> getNhaSX()
        {
            List<NhaSanXuat> NhaSX = new List<NhaSanXuat>();
            Moketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM NhaSanXuat";
            cmd.Connection = conec;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhaSanXuat nsx = new NhaSanXuat();
                nsx.maNhaSanXuat = rd.GetString(0);
                nsx.tenNhaSanXuat = rd.GetString(1);
                nsx.soDienThoai = rd.GetString(2);
                nsx.diaChi = rd.GetString(3);
                nsx.email = rd.GetString(4);
                nsx.website = rd.GetString(5);
                NhaSX.Add(nsx);
            }
            rd.Close();
            Dongketnoi();
            return NhaSX;
        }
    }
}
