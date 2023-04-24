using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
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
        SellService ssv = new SellService();
        public fNhanVien()
        {
            InitializeComponent();
            dgKHNV.DataSource = khsv.getKhachHang();
            spsv.loadSanPhamNhanVien(dgSanPhamNV);
            loadComboKhachHang();
            LoadDsDoiTra();
        }
        public void loadComboKhachHang()
        {
            cbMaKHTT.ValueMember = "maKhach";
            cbMaKHTT.DataSource = khsv.getKhachHang();
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

        private void LoadDsDoiTra()
        {

            var sql = "SELECT maPhieuDoiTra, maNhanVien, maKhachHang, ngayDoiTra = CONVERT(NVARCHAR(10),ngayDoiTra,103), congViec, tongTien FROM PhieuDoiTra";

            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();
            //Xóa dữ liệu cũ trong datagridview
            dgvDoiTra.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
            while (dr.Read())
            {
                var i = dgvDoiTra.Rows.Add();
                var row = dgvDoiTra.Rows[i];
                row.Cells["maPhieuDoiTra"].Value = dr["maPhieuDoiTra"];
                row.Cells["maNhanVien"].Value = dr["maNhanVien"];
                row.Cells["maKhachHang"].Value = dr["maKhachHang"];
                row.Cells["ngayDoiTra"].Value = dr["ngayDoiTra"];
                row.Cells["congViec"].Value = dr["congViec"];
                row.Cells["tongTien"].Value = dr["tongTien"];
            }

            dr.Close();

        }

        private void cbMaKHTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtTenKHTT.Text = khsv.getTenKhachHang(cbMaKHTT.Text);
        }

        private void tabControl11_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboKhachHang();
            cbMaKHTT.SelectedItem = null;
            txtTenKHTT.Text = null;
        }

        private void btresetSPTT_Click(object sender, EventArgs e)
        {
            txtTenSPTT.Text = "";
            txtTenKHTT.Text = "";
            txtGiaSPTT.Text = "";
            txtSoLuongTT.Text = "";
            txtMaSPTT.Text = "";
            cbMaKHTT.SelectedItem = null;
        }
        int stock = 0;
        int TongTien = 0;
        private void dgSanPhamNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSPTT.Text = dgSanPhamNV.SelectedRows[0].Cells[1].Value.ToString();
            txtGiaSPTT.Text = dgSanPhamNV.SelectedRows[0].Cells[2].Value.ToString();
            stock = Convert.ToInt32(dgSanPhamNV.SelectedRows[0].Cells[5].Value.ToString());
            txtMaSPTT.Text = dgSanPhamNV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btThemSPTT_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonTT.Text != "")
            {

                
                if (txtSoLuongTT.Text == "")
                {
                    MessageBox.Show("Hãy nhập số lượng");

                }
                else
                {
                    int soluongban = Convert.ToInt32(txtSoLuongTT.Text);
                    string MSP = dgSanPhamNV.SelectedRows[0].Cells[0].Value.ToString();
                    if (soluongban > stock)
                        MessageBox.Show("Số lượng không đủ");
                    else
                    {
                        string MHD = txtMaHoaDonTT.Text;
                        CTHoaDon cthd = new CTHoaDon(MHD,
                            MSP,
                            Convert.ToInt32(txtSoLuongTT.Text),
                            Convert.ToInt32(txtGiaSPTT.Text),
                            Convert.ToInt32(txtSoLuongTT.Text) * Convert.ToInt32(txtGiaSPTT.Text)
                            );
                        if (ssv.ktraSanPhamTT(txtMaHoaDonTT.Text,txtMaSPTT.Text) == false)
                        {
                            if (ssv.themCThoadon(cthd))
                            {
                                dgCTHDTT.DataSource = ssv.getCTHD(MHD);
                                ssv.CanNhatSoLuong(stock, soluongban, MSP);
                                spsv.loadSanPhamNhanVien(dgSanPhamNV);
                                TongTien += cthd.ThanhTien;
                                txtTongTien.Text = TongTien.ToString();

                                ssv.CapNhatTongTien(Convert.ToInt32(txtTongTien.Text), MHD);
                                MessageBox.Show("Thêm thành công");
                            }
                            else
                                MessageBox.Show("Thêm sản phẩm thất bại ");
                        }
                        else
                            MessageBox.Show("San pham da ton tai trong hoa don. Hay chon them hoac xoa SP");
                    }
                }
            }
            else
                MessageBox.Show("Hãy lập hóa đơn");
        }

        private void btLapHDTT_Click(object sender, EventArgs e)
        {
            string MK = cbMaKHTT.Text;
            if (MK != "")
            {
                if (txtMaHoaDonTT.Text == "")
                {
                    HoaDon hd = new HoaDon("1", MK, TongTien);
                    if (ssv.themHoaDon(hd))
                    {
                        txtMaHoaDonTT.Text = hd.MaHoaDon;
                        txtTongTien.Text = TongTien.ToString();

                        MessageBox.Show("Tạo hóa đơn mới thành công .");
                    }
                    else
                        MessageBox.Show("Tạo hóa đơn thất bại");
                }
                else
                    MessageBox.Show("Có hóa đơn đang sử dụng hãy reset hóa đơn");
            }
            else
                MessageBox.Show("Hãy chọn Khách Hàng", "Khách hàng");
        }

        private void dgCTHDTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSPTT.Text = dgCTHDTT.SelectedRows[0].Cells[1].Value.ToString();
            txtGiaSPTT.Text = dgCTHDTT.SelectedRows[0].Cells[3].Value.ToString();
            txtSoLuongTT.Text = dgCTHDTT.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btSearchHD_Click(object sender, EventArgs e)
        {
            dgCTHDTT.DataSource = ssv.getCTHD(txtMaHoaDonTT.Text);
            
            if (dgCTHDTT.Rows.Count == 0)
            {
                txtTongTien.Text = 0.ToString();
                TongTien = 0;
                ssv.CapNhatTongTien(TongTien, txtMaHoaDonTT.Text);
            }
            else
                txtTongTien.Text = ssv.getTongTien(txtMaHoaDonTT.Text);

        }

        private void rsHoaDon_Click(object sender, EventArgs e)
        {
            txtMaHoaDonTT.Text = "";
            txtTongTien.Text = "";
            this.dgCTHDTT.DataSource = null;
            this.dgCTHDTT.Rows.Clear();
        }

        private void btInHD_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DocumentName = "test";
            doc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);
            PrintDialog dlg = new PrintDialog();
            dlg.Document = doc;
            dlg.UseEXDialog = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Print p = new Print();
            p.DrawDataGridView(g, dgCTHDTT);
        }

        private void btXoaSP_Click(object sender, EventArgs e)
        {
            int TongTien = Convert.ToInt32(ssv.getTongTien(txtMaHoaDonTT.Text).ToString());
            string id = txtMaHoaDonTT.Text;
            string MSP = dgCTHDTT.SelectedRows[0].Cells[1].Value.ToString();
            int soluonghuy = Convert.ToInt32(dgCTHDTT.SelectedRows[0].Cells[2].Value.ToString());

            if (ssv.xoaCTHD(id, MSP))
            {
                int st = ssv.getStock(MSP);
                ssv.CanNhatSoLuong(st, soluonghuy * (-1), MSP);

                TongTien -= soluonghuy * Convert.ToInt32(dgCTHDTT.SelectedRows[0].Cells[3].Value.ToString());
                txtTongTien.Text = TongTien.ToString();
                if (dgCTHDTT.Rows.Count == 0)
                {
                    txtTongTien.Text = 0.ToString();
                    TongTien = 0;
                }
                ssv.CapNhatTongTien(TongTien, id);

                dgCTHDTT.DataSource = ssv.getCTHD(id);
                spsv.loadSanPhamNhanVien(dgSanPhamNV);

                MessageBox.Show("Xóa sản phầm thành công");
            }
            else
            {
                MessageBox.Show("Xóa sản phầm thất bại");
            }
        }

        private void btSuaSP_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonTT.Text != "")
            {     
                if (txtSoLuongTT.Text == "")
                {
                    MessageBox.Show("Hãy nhập số lượng");

                }
                else
                {
                    int soluongbannew = Convert.ToInt32(txtSoLuongTT.Text);
                    int soluongold = Convert.ToInt32(dgCTHDTT.SelectedRows[0].Cells[2].Value.ToString());
                    string MSP = txtMaSPTT.Text;
                    int TongTien = Convert.ToInt32(ssv.getTongTien(txtMaHoaDonTT.Text).ToString());
                    int stock = ssv.getStock(txtMaSPTT.Text);
                    if (soluongbannew > stock)
                        MessageBox.Show("Số lượng không đủ");
                    else
                    {
                        string MHD = txtMaHoaDonTT.Text;
                        CTHoaDon cthd = new CTHoaDon(MHD,
                            MSP,
                           soluongbannew,
                            Convert.ToInt32(txtGiaSPTT.Text),
                            Convert.ToInt32(txtSoLuongTT.Text) * Convert.ToInt32(txtGiaSPTT.Text)
                            );

                        if (ssv.capNhatSP(cthd))
                        {
                          
                            dgCTHDTT.DataSource = ssv.getCTHD(MHD);
                           
                            int i = soluongbannew - soluongold;

                            ssv.CanNhatSoLuong(stock, i, MSP);

                            spsv.loadSanPhamNhanVien(dgSanPhamNV);

                                TongTien += i * Convert.ToInt32(txtGiaSPTT.Text.ToString());
                            txtTongTien.Text = TongTien.ToString();
                            ssv.CapNhatTongTien(Convert.ToInt32(txtTongTien.Text.ToString()), MHD);
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                            MessageBox.Show("Sửa sản phẩm thất bại ");
                    }
                }
            }
            else
                MessageBox.Show("Hãy lập hóa đơn hoặc thêm hóa đơn cần sửa");
        }
    }
}
