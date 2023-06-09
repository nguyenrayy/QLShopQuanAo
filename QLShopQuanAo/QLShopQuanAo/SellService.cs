﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace QLShopQuanAo
{
    public class SellService
    {
        public DataTable getCTHD(string MHD)
        {
            string sql = "select * from ChiTietHoaDon where maHoaDon =@maHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maHoaDon", MHD);

            DataTable dt = new DataTable();
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            adpter.Fill(dt);
            return dt;
        }

        public DataTable getHoaDonKH(string maKhach)
        {
            string sql = "SELECT cthd.maHoaDon,cthd.maSanPham,cthd.soLuong,cthd.DonGia,cthd.thanhTien from ChiTietHoaDon cthd join HoaDonBan hdb on hdb.MaHoaDon = cthd.maHoaDon where hdb.maKhach = @maKhach";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maKhach", maKhach);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable getSPDT()
        {
            string sql = "SELECT CTPhieuDoiTra.* , SanPham.giaXuat from CTPhieuDoiTra LEFT JOIN SanPham on CTPhieuDoiTra.maSanPham = SanPham.maSanPham";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
        public DataTable getSPDT(String MPDT)
        {
            string sql = "SELECT * from CTPhieuDoiTra";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maPhieuDoiTra",MPDT);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
        public bool CanNhatSoLuong(int soluong, int soluongban, string MSP)
        {
            int soluongnew = soluong - soluongban;

            string sql = "update sanpham set soLuong =@SoLuong where maSanPham = @MaSanPham";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@SoLuong", soluongnew);
            cmd.Parameters.AddWithValue("@MaSanPham", MSP);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool themCThoadon(CTHoaDon cthd)
        {

            string SQL = string.Format("INSERT INTO ChiTietHoaDon VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}' , '{5}')", cthd.MaHoaDon, cthd.MaSanPham, cthd.SoLuong, cthd.Dongia, cthd.Giamgia, cthd.ThanhTien);
            SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        public bool themHoaDon(HoaDon hd)
        {
            string SQL = string.Format("INSERT INTO HoaDonBan VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}')", hd.MaHoaDon, hd.Manhanvien, hd.Makhach, hd.TongTien, hd.NgayLapHoaDon);
            SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            return cmd.ExecuteNonQuery() > 0;

        }
        public bool ktraSanPhamTT(string MHD, string MSP)
        {
            string sql = "select count(*) from ChiTietHoaDon where maHoaDon =@MaHoaDon and maSanPham = @MaSanPham";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MHD);
            cmd.Parameters.AddWithValue("@MaSanPham", MSP);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool capNhatSP(CTHoaDon cthd)
        {
            try
            {
                string SQL = string.Format("UPDATE ChiTietHoaDon SET soLuong = '{0}', thanhTien ={1} WHERE maHoaDon = {2} and maSanPham ={3}",
                cthd.SoLuong, cthd.ThanhTien, cthd.MaHoaDon, cthd.MaSanPham);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public void CapNhatTongTien(int TongTien, string MHD)
        {
            string sql = "update hoadonban set tongTien =@tongTien where maHoaDon = @MaHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@tongTien", TongTien);
            cmd.Parameters.AddWithValue("@MaHoaDon", MHD);
            cmd.ExecuteNonQuery();
        }
        public string getTongTien(string MHD)
        {
            string kq = "";
            string sql = "select tongTien from HoaDonBan where maHoaDon = @MaHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", MHD);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                kq = rd["tongTien"].ToString();
            rd.Close();
            return kq;
        }

        public bool xoaCTHD(string id, string MSP)
        {
            try
            {
                string SQL = string.Format("DELETE FROM ChiTietHoaDon WHERE maHoaDon = {0} and maSanPham ={1}", id, MSP);
                SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }
        public int getStock(string MSP)
        {
            int stock = 0;
            string sql = "select * from sanpham where maSanPham =@maSanPham";
            SqlCommand cmd = new SqlCommand(sql, DBConnect.Conn);
            cmd.Parameters.AddWithValue("@maSanPham", MSP);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                stock = Convert.ToInt32(rd["soLuong"].ToString());
            }
            rd.Close();
            return stock;
        }
        public bool themCTPhieuDoiTra(string MPDT,string MSP,int soLuong)
        {
            string SQL = string.Format("INSERT INTO CTPhieuDoiTra VALUES ('{0}', '{1}', '{2}')",MPDT,MSP,soLuong);
            SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            return cmd.ExecuteNonQuery() > 0;
        }
       public bool CapNhatGiaTienDT(string mpdt, int TongTien)
        {
            string SQL = string.Format("update PhieuDoiTra SET tongTien = '{0}' where maPhieuDoiTra = '{1}'", TongTien,mpdt);
            SqlCommand cmd = new SqlCommand(SQL, DBConnect.Conn);
            return cmd.ExecuteNonQuery() > 0;
        }

        }
    }

