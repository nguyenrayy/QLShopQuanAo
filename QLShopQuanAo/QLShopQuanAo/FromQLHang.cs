using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QLShopQuanAo.Properties;

namespace QLShopQuanAo
{
   

    public partial class FromQLHang : Form
    {
        public FromQLHang()
        {
            InitializeComponent();
            DBConnect.Connect();
            LoadDsSanPham();
            
        }

        private void FromQLHang_Load(object sender, EventArgs e)
        {
            
        }



        private void LoadDsSanPham()
        {

            var sql = "SELECT * FROM SanPham";

            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();
            //Xóa dữ liệu cũ trong datagridview
            dgvSanPham.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
            while (dr.Read())
            {
                var i = dgvSanPham.Rows.Add();
                var row = dgvSanPham.Rows[i];
                row.Cells["maSanPham"].Value = dr["maSanPham"];
                row.Cells["tenSanPham"].Value = dr["tenSanPham"];
                row.Cells["moTaSanPham"].Value = dr["moTaSanPham"];
                row.Cells["giaNhap"].Value = dr["giaNhap"];
                row.Cells["giaXuat"].Value = dr["giaXuat"];
                row.Cells["Size"].Value = dr["Size"];
                row.Cells["tinhTrang"].Value = dr["tinhTrang"];
                row.Cells["ngayNhap"].Value = dr["ngayNhap"];
                row.Cells["soLuong"].Value = dr["soLuong"];
                row.Cells["chatLieu"].Value = dr["chatLieu"];
                row.Cells["nhaSanXuat"].Value = dr["nhaSanXuat"];
                row.Cells["anhSanPham"].Value = dr["anhSanPham"];
            }

            dr.Close();

        }


        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txtMa.ReadOnly = false;
            txtMa.Clear();
            txtTen.Clear();
            txtMoTa.Clear();
            txtGiaNhap.Clear();
            txtGiaXuat.Clear();
            txtSize.Clear();
            cbTinhTrang.SelectedIndex = -1;
            dateNgayNhap.ResetText();
            txtSoLuong.Clear();
            txtChatLieu.Clear();
            txtNhaSanXuat.Clear();
            txtAnhSanPham.Clear();
            pic.Refresh();
            pic.Image = null;
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "INSERT INTO dbo.SanPham (maSanPham, tenSanPham, moTaSanPham, giaNhap, giaXuat, Size, tinhTrang, ngayNhap, soLuong, chatLieu, nhaSanXuat, anhSanPham) VALUES (@maSanPham, @tenSanPham, @moTaSanPham, @giaNhap, @giaXuat, @Size, @tinhTrang, @ngayNhap, @soLuong, @chatLieu, @nhaSanXuat, @anhSanPham)";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("maSanPham", txtMa.Text);
                cmd.Parameters.AddWithValue("tenSanPham", txtTen.Text);
                cmd.Parameters.AddWithValue("moTaSanPham", txtMoTa.Text);
                cmd.Parameters.AddWithValue("giaNhap", txtGiaNhap.Text);
                cmd.Parameters.AddWithValue("giaXuat", txtGiaXuat.Text);
                cmd.Parameters.AddWithValue("Size", txtSize.Text);
                cmd.Parameters.AddWithValue("tinhTrang", cbTinhTrang.Text);
                cmd.Parameters.AddWithValue("ngayNhap", dateNgayNhap.Value);
                cmd.Parameters.AddWithValue("soLuong", txtSoLuong.Text);
                cmd.Parameters.AddWithValue("chatLieu", txtChatLieu.Text);
                cmd.Parameters.AddWithValue("nhaSanxuat", txtNhaSanXuat.Text);
                cmd.Parameters.AddWithValue("anhSanPham", txtAnhSanPham.Text);
                var kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadDsSanPham();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146232060)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Hide();
        }
    }
}
