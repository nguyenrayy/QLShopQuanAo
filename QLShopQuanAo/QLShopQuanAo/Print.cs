using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    public class Print
    {
        SellService ssv = new SellService();
        public void DrawDataGridView(Graphics g, DataGridView dgCTHDTT)
        {
            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            int x = 30;
            int y = 30;

            g.DrawString("SHOP CLOSTHES", new Font("Century Gothic", 16, FontStyle.Bold), new SolidBrush(Color.Red), 10, 10);
            for (int i = 0; i < dgCTHDTT.RowCount; i++)
            {

                if (i == 0)
                {
                    for (int j = 0; j < dgCTHDTT.ColumnCount; j++)
                    {
                        g.DrawString(dgCTHDTT.Columns[j].HeaderText, font, brush, x, y);
                        x += dgCTHDTT.Columns[j].Width;
                    }
                    y += dgCTHDTT.Rows[i].Height;
                    x = 10;
                }

                for (int j = 0; j < dgCTHDTT.ColumnCount; j++)
                {
                    g.DrawString(dgCTHDTT.Rows[i].Cells[j].FormattedValue.ToString(), font, brush, x, y);
                    x += dgCTHDTT.Columns[j].Width;
                }
                y += dgCTHDTT.Rows[i].Height;
                x = 10;
            }
            g.DrawString("Tổng tiền: " + ssv.getTongTien(dgCTHDTT.Rows[0].Cells[0].FormattedValue.ToString()), font, brush, x, y);
            g.DrawString("Ngày in: " + DateTime.Now.ToString(), font, brush, x + 20, y + 20);
        }
    }
}

