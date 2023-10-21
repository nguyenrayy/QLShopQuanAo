using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class FQLKhachHang : Form
    {
        public FQLKhachHang()
        {
            InitializeComponent();
            loadKhachHangList();
        }

        private void loadKhachHangList()
        {
            KhachHangBLL khBLL = new BLL.KhachHangBLL();
            List<KhachHang> dskhGui = khBLL.getKhachHangList(null);
            dgvKhachHang.Rows.Clear();
            string gt = null;
            foreach (KhachHang kh in dskhGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.tenKhach });
                if (kh.gioiTinh == true)
                {
                    gt = "Nam";
                }
                else
                {
                    gt = "Nữ";
                }
                row.Cells.Add(new DataGridViewTextBoxCell { Value = gt });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.ngaySinh });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.diaChi });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = kh.soDienThoai });

                // Thêm hàng vào DataGridView
                dgvKhachHang.Rows.Add(row);
            }

        }

        private void btnGuiTN_Click(object sender, EventArgs e)
        {
            try
            {
                string promotionMessage = rtxtTinNhanGui.Text;
                KhachHangBLL khBLL = new KhachHangBLL();
                khBLL.SendPromotionSMS(promotionMessage);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                // Hiển thị thông báo khi sửa thất bại và bao gồm thông điệp lỗi từ ngoại lệ trong thông báo
                MessageBox.Show("Thêm sản phẩm thất bại. Lỗi: " + exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemKH.Text;

            KhachHangBLL khBLL = new KhachHangBLL();
            List<KhachHang> ketQuaTimKiem = khBLL.TimKiemKH(tuKhoa);

            dgvKhachHang.Rows.Clear();

            foreach (KhachHang kh in ketQuaTimKiem)
            {
                dgvKhachHang.Rows.Add(kh.maKhachHang, kh.tenKhach, kh.gioiTinh, kh.ngaySinh, kh.diaChi, kh.soDienThoai);
            }
        }

        private void loadHoaDonList(string x)
        {
            KhachHang kh = new KhachHang();
            kh.maKhachHang = x;
            HoaDonBanBLL hdbBLL = new HoaDonBanBLL();
            List<HoaDonBan> dshdGui = hdbBLL.getHoaDonBanList(kh);
            dgvQLHoaDon.Rows.Clear();
            foreach (HoaDonBan hd in dshdGui)
            {
                // Tạo một hàng mới trong DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Thêm các ô thông tin từ đối tượng SanPham vào các ô trong hàng
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maHoaDon });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maNhanVien });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.maKhachHang });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = hd.ngayLapHoaDon });

                // Thêm hàng vào DataGridView
                dgvQLHoaDon.Rows.Add(row);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];
                
                loadHoaDonList(selectedRow.Cells["maKhachHang"].Value.ToString());
            }
        }
    }
}
