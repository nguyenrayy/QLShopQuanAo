using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    
    public static class DBConnect
    {
        private static string _StrConn = @"Data Source=DELL\MSSQLSERVER02;Initial Catalog=shopQuanAo;Integrated Security=True";
        private static bool _ConnStatus;
        private static SqlConnection _Conn;
        public static string StrConn { get => _StrConn; set => _StrConn = value; }
        public static bool ConnStatus { get => _ConnStatus; set => _ConnStatus = value; }
        public static SqlConnection Conn { get => _Conn; set => _Conn = value; }



        public static SqlConnection Connect()
        {
            if (ConnStatus == false)
            {
                try
                {
                    Conn = new SqlConnection(StrConn);
                    Conn.Open();
                    ConnStatus = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Conn;
        }

    }
}
