using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    public class SanPhamService
    {
        public void loadSanPhamNhanVien(DataGridView dg)
        {
            
            dg.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select * from sanpham",DBConnect.Conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dg.Rows.Clear();
            while(dr.Read())
            {
                var i = dg.Rows.Add();
                var row = dg.Rows[i];
                row.Cells["maSanPham"].Value = dr["maSanPham"];
                row.Cells["tenSanPham"].Value = dr["TenSanPham"];
                row.Cells["giaXuat"].Value = dr["GiaXuat"];
                row.Cells["size"].Value = dr["Size"];
                row.Cells["tinhTrang"].Value = dr["TinhTrang"];
                row.Cells["soLuong"].Value = dr["SoLuong"];
                row.Cells["chatLieu"].Value = dr["ChatLieu"];
            }
            dr.Close();
        }
        public DataTable getSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SanPham", DBConnect.Conn);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }
        public string getTenSanPham(string MSP)
        {
            string name = "";
            string sql = "select * from SanPham where maSanPham =@maSanPham";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maSanPham", MSP);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                name = rd["tenSanPham"].ToString();
            }
            rd.Close();
            return name;
        }
    }
}
