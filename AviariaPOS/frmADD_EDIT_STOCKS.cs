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
    public partial class frmADD_EDIT_STOCKS : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        string vendor;
        public frmADD_EDIT_STOCKS()
        {
            InitializeComponent();
        }

        private void LoadVendor()
        {
            if (cmbVendor.Items.Count > 0)
            {
                cmbVendor.Items.Clear();
            }

            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select vendorName from vendor;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cmbVendor.Items.AddRange(new object[] { reader.GetString(0) });
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

        private void FilterVendor()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select vendorAddress, vendorContactPerson from vendor where vendorName=@vendorName;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@vendorName", MySqlDbType.VarChar).Value = cmbVendor.Text;

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtCPerson.Text = reader.GetString(1);
                        txtAddress.Text = reader.GetString(0);
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

        public void AddProduct(string[] prod, int qty, string manufactureDate, string expirationDate)
        {
            dgvProducts.Rows.Add(prod[0], prod[1], prod[2], prod[3], qty, manufactureDate, expirationDate);
        }

        public void ChangeQuantity(int index, int qty, string manufactureDate, string expirationDate)
        {
            dgvProducts.Rows[index].Cells[4].Value = qty;
            dgvProducts.Rows[index].Cells[5].Value = manufactureDate;
            dgvProducts.Rows[index].Cells[6].Value = expirationDate;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_PRODUCTS frm = new frmADD_PRODUCTS(this);
            frm.ShowDialog();
        }

        private void frmADD_EDIT_STOCKS_Load(object sender, EventArgs e)
        {
            LoadVendor();
        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterVendor();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtCPerson.Clear();
            txtAddress.Clear();
            LoadVendor();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;

                frmQUANTITY frm = new frmQUANTITY(this, int.Parse(dgvProducts.Rows[selectedIndex].Cells[4].Value.ToString()), new string[] { dgvProducts.Rows[selectedIndex].Cells[5].Value.ToString(), dgvProducts.Rows[selectedIndex].Cells[6].Value.ToString() }, selectedIndex);
                frm.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vendor = cmbVendor.Text;
            bworkStock.RunWorkerAsync();
        }

        private void bworkStock_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "insert into stocks(stockID, stockName, stockPrice, stockQty, stockManufactureDate, stockExpirationDate, stockInBy, stockVendor) values (@stockID, @stockName, @stockPrice, @stockQty, @stockManufactureDate, @stockExpirationDate, @stockInBy, @stockVendor);";
                con = new MySqlConnection(conText);
                con.Open();
                //com = new MySqlCommand(query, con);

                for (int i = 0; i < dgvProducts.RowCount; i++)
                {
                    com = new MySqlCommand(query, con);
                    com.Parameters.Add("@stockID", MySqlDbType.Int32).Value = dgvProducts.Rows[i].Cells[0].Value;
                    com.Parameters.Add("@stockName", MySqlDbType.VarChar).Value = dgvProducts.Rows[i].Cells[1].Value;
                    com.Parameters.Add("@stockPrice", MySqlDbType.Double).Value = dgvProducts.Rows[i].Cells[2].Value;
                    com.Parameters.Add("@stockQty", MySqlDbType.Int32).Value = dgvProducts.Rows[i].Cells[4].Value;
                    com.Parameters.Add("@stockInBy", MySqlDbType.VarChar).Value = txtName.Text;
                    com.Parameters.Add("@stockVendor", MySqlDbType.VarChar).Value = vendor;

                    DateTime manuDate, expiDate;
                    if (DateTime.TryParse(dgvProducts.Rows[i].Cells[5].Value.ToString(), out manuDate))
                    {
                        com.Parameters.Add("@stockManufactureDate", MySqlDbType.Date).Value = manuDate;
                    }
                    else
                    {
                        com.Parameters.Add("@stockManufactureDate", MySqlDbType.Date).Value = null;
                    }

                    if (DateTime.TryParse(dgvProducts.Rows[i].Cells[6].Value.ToString(), out expiDate))
                    {
                        com.Parameters.Add("@stockExpirationDate", MySqlDbType.Date).Value = expiDate;
                    }
                    else
                    {
                        com.Parameters.Add("@stockExpirationDate", MySqlDbType.Date).Value = null;
                    }

                    com.ExecuteNonQuery();
                    com.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bworkStock_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //pbarProgress.Value = e.ProgressPercentage;
        }

        private void bworkStock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
