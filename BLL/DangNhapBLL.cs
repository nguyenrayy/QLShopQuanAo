using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBLL
    {
        DangNhapDAL dangnhapdall = new DangNhapDAL();
        public int CheckUser(NhanVien nv)
        {
            int i;
            if (int.TryParse(dangnhapdall.CheckPosition(nv),out i))
                return Int32.Parse(dangnhapdall.CheckPosition(nv));
            else
                return 0;
        }
        public NhanVien getUser(String SDT)
        {
            return dangnhapdall.getUser(SDT);
        }
    }
}
