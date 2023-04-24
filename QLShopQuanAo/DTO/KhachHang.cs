using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        private string makhachhang;
        public string MaKhachHang
        {
            get { return makhachhang; }
            set { makhachhang = value; }
        }

        private string tenkhachhang;
        public string TenKhachHang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }

        }
        private string sdt;
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string diachi;
        public string DiaChi
        {
            get { return diachi; }
            set
            {
                diachi = value;
            }
        }
        public string randomString()
        {
            string result = "";
            var rd = new Random();
            for (int i = 0; i <= 7; i++)
            {
                result += rd.Next(10).ToString();
            }

            return result;
        }
        public KhachHang(string tenkhachhang, string sdt, string diachi)
        {
            this.makhachhang = randomString();
            this.tenkhachhang = tenkhachhang;
            this.sdt = sdt;
            this.diachi = diachi;
        }
        public KhachHang(string makhachhang, string tenkhachhang, string sdt, string diachi)
        {
            this.makhachhang = makhachhang;
            this.tenkhachhang = tenkhachhang;
            this.sdt = sdt;
            this.diachi = diachi;
        }
        //override
        //public String ()
        //{ return this.tenkhachhang; }
    }
   
}
