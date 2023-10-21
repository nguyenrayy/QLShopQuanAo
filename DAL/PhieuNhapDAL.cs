﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapDAL:DBConnect
    {
        public List<PhieuNhap> getPhieuNhapList(NhanVien nv)
        {
            List<PhieuNhap> pnl = new List<PhieuNhap>();
            Moketnoi();
            var sql = "SELECT * FROM PhieuNhap";

            if (nv != null)
            {
                sql += " where maCuaHang = @maCuaHang";
            }
            var cmd = new SqlCommand(sql, conec);
            if (nv != null)
            {
                cmd.Parameters.AddWithValue("@maCuaHang", nv.maCuaHang);
            }
            PhieuNhap pn = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    pn = new PhieuNhap();
                    pn.maPhieuNhap = rd["maPhieuNhap"].ToString();
                    pn.maNhanVien = rd["maNhanVien"].ToString();
                    pn.maCuaHang = rd["maCuaHang"].ToString();
                    pn.ngayNhap = rd.GetDateTime(rd.GetOrdinal("ngayNhap"));
                    pn.trangThai = rd.GetBoolean(rd.GetOrdinal("trangThai"));
                    pnl.Add(pn);
                }
            }
            Dongketnoi();
            return pnl;
        }

      
        public bool addPhieuNhap(PhieuNhap pn)
        {
            Boolean success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("INSERT INTO PhieuNhap VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}' )",
                     pn.maPhieuNhap, pn.maNhanVien, pn.maCuaHang, pn.ngayNhap, pn.trangThai);
                
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    success =  true;
                }
            }
            
            finally { Dongketnoi(); }
            return success;
        }
        public bool editPhieuNhap(PhieuNhap pn)
        {
            Boolean success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("UPDATE PhieuNhap SET maNhanVien = '{0}',maCuaHang = '{1}', ngayNhap = '{2}', trangThai ='{3}'" +
                    "WHERE maPhieuNhap = '{4}'",
               pn.maNhanVien, pn.maCuaHang, pn.ngayNhap, pn.trangThai, pn.maPhieuNhap);
                SqlCommand cmd = new SqlCommand(SQL,conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally {Dongketnoi(); }
            return success;

        }
        public Boolean delPhieuNhap(PhieuNhap pn)
        {
            Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM PhieuNhap WHERE maPhieuNhap = '{0}'", pn.maPhieuNhap);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;
        }

        public List<ChiTietPhieuNhap> getCTPhieuNhap(PhieuNhap pn)
        {
            List<ChiTietPhieuNhap> pnl = new List<ChiTietPhieuNhap>();
            Moketnoi();
            var sql = "SELECT * FROM ChiTietPhieuNhap where maPhieuNhap = @maPhieuNhap";
            var cmd = new SqlCommand(sql, conec);

            cmd.Parameters.AddWithValue("@maPhieuNhap", pn.maPhieuNhap);

            ChiTietPhieuNhap ctpn = null;
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    ctpn = new ChiTietPhieuNhap();
                    ctpn.maPhieuNhap = pn.maPhieuNhap.ToString();
                    ctpn.maSPTheoSize = rd.GetString(rd.GetOrdinal("maSPTheoSize"));
                    ctpn.soLuong = rd.GetInt32(rd.GetOrdinal("soLuong"));
                    
                    pnl.Add(ctpn);
                }
            }
            Dongketnoi();
            return pnl;
        }
        public bool addCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            bool success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("INSERT INTO ChiTietPhieuNhap VALUES ('{0}', '{1}', '{2}' )",
                  ctpn.maPhieuNhap, ctpn.maSPTheoSize, ctpn.soLuong);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    success =  true;
                }
            }
           
            finally { Dongketnoi(); }
            return success;
        }
        public bool editCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            Boolean success = false;
            Moketnoi();
            try
            {
                string SQL = string.Format("UPDATE ChiTietPhieuNhap SET soLuong = '{0}'" +
                    "WHERE maPhieuNhap = '{1}' and maSPTheoSize = '{2}' ", ctpn.soLuong, ctpn.maPhieuNhap, ctpn.maSPTheoSize);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;

        }
        public Boolean delCTPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            Moketnoi();
            Boolean success = false;
            try
            {
                string SQL = string.Format("DELETE FROM ChiTietPhieuNhap WHERE maPhieuNhap = '{0}' and maSPTheoSize = '{1}'", ctpn.maPhieuNhap, ctpn.maSPTheoSize);
                SqlCommand cmd = new SqlCommand(SQL, conec);
                if (cmd.ExecuteNonQuery() > 0)
                    success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { Dongketnoi(); }
            return success;
        }


    }
}