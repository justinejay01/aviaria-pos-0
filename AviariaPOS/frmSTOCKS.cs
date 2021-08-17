using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AviariaPOS
{
    public partial class frmSTOCKS : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        public frmSTOCKS()
        {
            InitializeComponent();
        }

        private void LoadStocks(int i)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                dgvProducts.Rows.Clear();
            }

            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select stockID, stockName, stockPrice, stockQty, stockManufactureDate, stockExpirationDate, stockInBy, stockVendor from stocks;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dateManu, dateExpi;

                        if (!reader.IsDBNull(4))
                            dateManu = GetDate(reader.GetMySqlDateTime(4).GetDateTime());
                        else
                            dateManu = "";

                        if (!reader.IsDBNull(5))
                            dateExpi = GetDate(reader.GetMySqlDateTime(5).GetDateTime());
                        else
                            dateExpi = "";

                        dgvProducts.Rows.Add(new object[] { reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3), dateManu, dateExpi, reader.GetString(6), reader.GetString(7) });
                    }
                }

                reader.Close();
                reader.Dispose();
                com.Dispose();
                con.Close();
                con.Dispose();

                if (i > 0)
                {
                    dgvProducts.Rows[i].Selected = true;
                    dgvProducts.Focus();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDate(DateTime dateTime)
        {
            if (dateTime != null)
            {
                return dateTime.ToString("MMMM dd, yyyy");
            }
            else
            {
                return "";
            }
        }


        private void frmSTOCKS_Load(object sender, EventArgs e)
        {
            LoadStocks(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_EDIT_STOCKS frm = new frmADD_EDIT_STOCKS();
            frm.ShowDialog();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {

            }
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgvProducts.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvProducts.Columns["prodDelete"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Bitmap image = Properties.Resources.trash_64pxr;
                int h = image.Height / 2;
                int w = image.Width / 2;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));

                e.Handled = true;
            }

            if (e.ColumnIndex == dgvProducts.Columns["prodEdit"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Bitmap image = Properties.Resources.edit_64pxbla;
                int h = image.Height / 2;
                int w = image.Width / 2;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));

                e.Handled = true;
            }
        }
    }
}
