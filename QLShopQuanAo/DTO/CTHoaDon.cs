using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDon
    {
        private string mahoadon;
        public string MaHoaDon
        {
            get { return mahoadon; }
            set { mahoadon = value; }
        }


        private string masanpham;
        public string MaSanPham
        {
            get { return masanpham; }
            set { masanpham = value; }
        }

        private int soluong;
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        private int dongia;
        public int Dongia
        {
            get { return dongia; }
            set
            {
                dongia = value;
            }
        }


        private int giamgia;
        public int Giamgia
        {
            get { return giamgia; }
            set
            {
                giamgia = value;
            }
        }

        private int thanhtien;
        public int ThanhTien
        {
            get { return thanhtien; }
            set
            {
                thanhtien = value;
            }
        }
        public CTHoaDon(string mahoadon, string masanpham, int soluong, int dongia, int thanhtien)
        {
            this.giamgia = 0;
            this.mahoadon = mahoadon;
            this.masanpham = masanpham;
            this.soluong = soluong;
            this.dongia = dongia;
            this.thanhtien = thanhtien;
        }
    }
}

