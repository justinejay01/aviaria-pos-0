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
    public partial class frmADD_PRODUCTS_CASHIER : Form
    {
        string path, conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        frmCASHIER cashier;
        public frmADD_PRODUCTS_CASHIER(frmCASHIER cashier)
        {
            this.cashier = cashier;
            InitializeComponent();
        }

        private void LoadProducts()
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
                string query = "select prodName, prodPrice from inventory;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvProducts.Rows.Add(new object[] { reader.GetString(0), reader.GetString(1) });
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

        private void FilterTable()
        {
            if (txtSearch.TextLength > 0)
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
                    string query = "select prodName, prodPrice from inventory where prodName LIKE '%" + txtSearch.Text + "%';";
                    com = new MySqlCommand(query, con);

                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dgvProducts.Rows.Add(new object[] { reader.GetDouble(0), reader.GetString(1) });
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
            else LoadProducts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmADD_PRODUCTS_CASHIER_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterTable();
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

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                string prodName = dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString();
                double prodPrice = double.Parse(dgvProducts.Rows[selectedIndex].Cells[1].Value.ToString());

                frmADD_PRODUCTS_CASHIER1 frm = new frmADD_PRODUCTS_CASHIER1(cashier, prodName, prodPrice.ToString());
                frm.ShowDialog();
            }
        }
    }
}
