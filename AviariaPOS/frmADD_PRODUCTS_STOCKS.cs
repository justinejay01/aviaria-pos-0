using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviariaPOS
{
    public partial class frmADD_PRODUCTS_STOCKS : Form
    {
        string path, conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        frmADD_EDIT_STOCKS stocks;
        public frmADD_PRODUCTS_STOCKS(frmADD_EDIT_STOCKS stocks)
        {
            this.stocks = stocks;
            InitializeComponent();
        }

        private void GetProduct()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select prodID, prodName, prodPrice, prodManufactureName from inventory;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvProducts.Rows.Add(new object[] { reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3) });
                    }
                }

                reader.Close();
                reader.Dispose();
                com.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgvProducts.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvProducts.Columns["prodAdd"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Bitmap image = Properties.Resources.ok;
                int h = image.Height / 2;
                int w = image.Width / 2;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));

                e.Handled = true;
            }
        }

        private void frmADD_PRODUCTS_Load(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                int prodID = int.Parse(dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString());
                string prodName = dgvProducts.Rows[selectedIndex].Cells[1].Value.ToString();
                double prodPrice = double.Parse(dgvProducts.Rows[selectedIndex].Cells[2].Value.ToString());
                string prodManufactureName = dgvProducts.Rows[selectedIndex].Cells[3].Value.ToString();

                frmADD_PRODUCTS_STOCK1 frm = new frmADD_PRODUCTS_STOCK1(stocks, this, new string[] { prodID.ToString(), prodName, prodPrice.ToString(), prodManufactureName});
                frm.ShowDialog();
            }
        }
    }
}
