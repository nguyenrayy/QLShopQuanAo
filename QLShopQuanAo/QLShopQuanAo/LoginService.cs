    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    internal class LoginService
    {
        public int Login(String SDT, String pass)
        {
            var sql = "SELECT COUNT(*) FROM dbo.NhanVien WHERE dienThoai = @dienThoai AND pass = @pass";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            cmd.Parameters.AddWithValue("dienThoai", SDT);
            cmd.Parameters.AddWithValue("pass", pass);
            int kq = (int)cmd.ExecuteScalar();
            if (kq > 0)
            {
                var sqln = "SELECT COUNT(*) FROM dbo.NhanVien WHERE dienThoai = @dienThoai AND pass = @pass and chucVu ='Admin'";
                var cmd2 = new SqlCommand(sqln, DBConnect.Connect());
                cmd2.Parameters.AddWithValue("dienThoai", SDT);
                cmd2.Parameters.AddWithValue("pass", pass);

                int kq2 = (int)cmd2.ExecuteScalar();
                if (kq2 > 0)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
