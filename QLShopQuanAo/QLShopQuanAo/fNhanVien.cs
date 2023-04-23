using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLShopQuanAo
{
    public partial class fNhanVien : Form
    {
        KhachHangService khsv = new KhachHangService();
        SanPhamService spsv = new SanPhamService();
        public fNhanVien()
        {
            InitializeComponent();
            dgKHNV.DataSource = khsv.getKhachHang();
            spsv.loadSanPhamNhanVien(dgSanPhamNV);
            loadComboKhachHang();
        }
        public void loadComboKhachHang()
        {
            cbMaKHTT.DataSource = khsv.getKhachHang();
            cbMaKHTT.DisplayMember = "tenKhachHang".ToString();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.Show();
            this.Hide();
        }

        private void btThemKH_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtSDTKH.Text == "" || txtDCKH.Text == "")
            {
                MessageBox.Show("Nhap day du thong tin", "Khach Hang");
            }
            else {
                {
                    KhachHang kh = new KhachHang(txtTenKH.Text, txtSDTKH.Text, txtSDTKH.Text);
                    if (khsv.ktraKhachHang(txtSDTKH.Text) == false)
                    {
                        if (khsv.themKH(kh))
                        {
                            dgKHNV.DataSource = khsv.getKhachHang();
                            MessageBox.Show("Add success");
                        }
                        else
                            MessageBox.Show("Add failed");

                    }
                    else
                        MessageBox.Show("Số điện thoại đã có người sử dụng.", "Không hợp lệ");
                }
            }
        }

        private void btSuaKH_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtSDTKH.Text == "" || txtDCKH.Text == "")
            {
                MessageBox.Show("Nhap day du thong tin", "Khach Hang");
            }
            else
            {
                {
                    DataGridViewRow row = dgKHNV.SelectedRows[0];
                    string ID = row.Cells[0].Value.ToString();
                    KhachHang kh = new KhachHang(ID, txtTenKH.Text, txtSDTKH.Text, txtSDTKH.Text);
                    if (khsv.suaKhachHang(kh))
                    {
                        dgKHNV.DataSource = khsv.getKhachHang();
                        MessageBox.Show("Sua Thanh Cong");
                    }
                    else
                        MessageBox.Show("sua That Bai");

                }
            }
        }

        private void btResetKH_Click(object sender, EventArgs e)
        {
            txtDCKH.Text = "";
            txtSDTKH.Text = "";
            txtTenKH.Text = "";
            txtMaKH.Text = "";
        }
 

        private void dgKHNV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgKHNV.SelectedRows[0].Cells[0].Value.ToString();
            txtTenKH.Text = dgKHNV.SelectedRows[0].Cells[1].Value.ToString();
            txtDCKH.Text = dgKHNV.SelectedRows[0].Cells[2].Value.ToString();
            txtSDTKH.Text = dgKHNV.SelectedRows[0].Cells[3].Value.ToString();
            
        }

        private void btXoaKH_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgKHNV.SelectedRows[0];
            string ID = row.Cells[0].Value.ToString();

            if (khsv.xoaKhachHang(ID))
            {
                dgKHNV.DataSource = khsv.getKhachHang();
                MessageBox.Show("Xoa Thanh Cong");
            }
            else
                MessageBox.Show("Xoa That Bai");

        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void txtSDTKH_TextChanged(object sender, EventArgs e)
        {
            this.txtSDTKH.Text = txtSDTKH.Text;
        }
    }
}
