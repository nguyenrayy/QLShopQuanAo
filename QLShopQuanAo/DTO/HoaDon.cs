using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private string mahoadon;
        public string MaHoaDon
        {
            get { return mahoadon; }
            set { mahoadon = value; }
        }

        private string manhanvien;
        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }

        private string makhach;
        public string Makhach
        {
            get { return makhach; }
            set { makhach = value; }
        }

        private int tongtien;
        public int TongTien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        private DateTime ngaylaphoadon;
        public DateTime NgayLapHoaDon
        {
            get { return ngaylaphoadon; }
            set { ngaylaphoadon = value; }
        }

        public string randomString()
        {
            string result = "";
            var rd = new Random();
            for (int i = 0; i <= 5; i++)
            {
                result += rd.Next(10).ToString();
            }

            return result;
        }

        public HoaDon(string manhanvien, string makhach, int tongtien)
        {
            this.mahoadon = randomString();
            this.manhanvien = manhanvien;
            this.makhach = makhach;
            this.tongtien = tongtien;
            this.ngaylaphoadon = DateTime.Now;
        }
    }
}

