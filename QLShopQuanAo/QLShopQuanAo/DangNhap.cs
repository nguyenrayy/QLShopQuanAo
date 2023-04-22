using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    public partial class DangNhap : Form
    {
        LoginService login = new LoginService();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            if (txtMatKhau.Text != "" || txtMatKhau.Text != "")
            {
                if (login.Login(username, password) == 1)
                {
                    FromQLHang f = new FromQLHang();
                    this.Hide();
                    f.ShowDialog();
                }
                else
                    if (login.Login(username, password) == 0)
                {
                    fNhanVien fnv = new fNhanVien();
                    this.Hide();
                    fnv.ShowDialog();
                }
                else
                    MessageBox.Show("Sai tai khoan hoac mat khau.", "Login", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Hãy nhập đầy đủ thông tin.", "Login", MessageBoxButtons.OK);
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
