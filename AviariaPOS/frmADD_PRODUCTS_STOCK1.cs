using Guna.UI2.WinForms;
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
    public partial class frmADD_PRODUCTS_STOCK1 : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;

        Guna2DataGridView dgvProducts;

        frmSTOCKS stocks;
        frmADD_EDIT_STOCKS addstocks;
        frmADD_PRODUCTS_STOCKS addprod;
        string[] prod;
        int index, qty = 0;
        string manufactureDate, expirationDate;
        public frmADD_PRODUCTS_STOCK1(frmADD_EDIT_STOCKS stocks, frmADD_PRODUCTS_STOCKS addprod, string[] prod)
        {
            this.addstocks = stocks;
            this.addprod = addprod;
            this.prod = prod;
            InitializeComponent();
        }

        public frmADD_PRODUCTS_STOCK1(frmADD_EDIT_STOCKS stocks, int qty, string[] dates, int index)
        {
            this.addstocks = stocks;
            this.index = index;
            this.qty = qty;
            this.manufactureDate = dates[0];
            this.expirationDate = dates[1];

            InitializeComponent();
        }

        public frmADD_PRODUCTS_STOCK1(frmSTOCKS stocks, int index)
        {
            this.stocks = stocks;
            this.dgvProducts = stocks.dgvProducts;
            this.index = index;

            InitializeComponent();
        }

        private void AddStock()
        {
            if (addstocks != null)
            {
                if (addprod != null)
                {
                    int qty = 0;

                    if (int.TryParse(txtQuantity.Text, out qty))
                    {
                        if (qty != 0)
                        {
                            if (!cboxManufacture.Checked)
                            {
                                manufactureDate = dateManufacture.Text;
                            }
                            else
                            {
                                manufactureDate = "";
                            }

                            if (!cboxExpiration.Checked)
                            {
                                expirationDate = dateExpiration.Text;
                            }
                            else
                            {
                                expirationDate = "";
                            }

                            addstocks.AddProduct(prod, qty, manufactureDate, expirationDate);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Product not added or removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int qty = 0;

                    if (int.TryParse(txtQuantity.Text, out qty))
                    {
                        if (qty != 0)
                        {
                            if (!cboxManufacture.Checked)
                            {
                                manufactureDate = dateManufacture.Text;
                            }
                            else
                            {
                                manufactureDate = "";
                            }

                            if (!cboxExpiration.Checked)
                            {
                                expirationDate = dateExpiration.Text;
                            }
                            else
                            {
                                expirationDate = "";
                            }

                            addstocks.ChangeQuantity(index, qty, manufactureDate, expirationDate);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Product not added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateStocks(int i)
        {
            try
            {
                string query = "update stocks set stockManufactureDate=@stockManufactureDate, stockExpirationDate=@stockExpirationDate, stockQty=@stockQty where stockName=@stockName and stockInBy=@stockInBy and stockVendor=@stockVendor;";
                con = new MySqlConnection(conText);
                con.Open();
                //com = new MySqlCommand(query, con);

                com = new MySqlCommand(query, con);
                com.Parameters.Add("@stockName", MySqlDbType.VarChar).Value = dgvProducts.Rows[index].Cells[1].Value;
                com.Parameters.Add("@stockQty", MySqlDbType.Int32).Value = txtQuantity.Text;
                com.Parameters.Add("@stockInBy", MySqlDbType.VarChar).Value = dgvProducts.Rows[index].Cells[6].Value;
                com.Parameters.Add("@stockVendor", MySqlDbType.VarChar).Value = dgvProducts.Rows[index].Cells[7].Value;

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

                MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                com.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddStock();
            }
        }

        private void frmQUANTITY_Load(object sender, EventArgs e)
        {
            if (stocks == null)
            {
                if (manufactureDate != null || expirationDate != null)
                {
                    if (manufactureDate != null)
                    {
                        dateManufacture.Text = manufactureDate;
                    }

                    if (expirationDate != null)
                    {
                        dateExpiration.Text = expirationDate;
                    }
                }
                else
                {
                    dateManufacture.Enabled = false;
                    dateExpiration.Enabled = false;

                    cboxManufacture.Checked = true;
                    cboxExpiration.Checked = true;
                }
            }
        }

        private void cboxManufacture_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxManufacture.Checked)
            {
                dateManufacture.Enabled = false;
            }
            else
            {
                dateManufacture.Enabled = true;
            }
        }

        private void cboxExpiration_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxExpiration.Checked)
            {
                dateExpiration.Enabled = false;
            }
            else
            {
                dateExpiration.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddStock();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
