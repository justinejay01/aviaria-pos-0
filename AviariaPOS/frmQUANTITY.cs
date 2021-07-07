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
    public partial class frmQUANTITY : Form
    {
        frmADD_EDIT_STOCKS stocks;
        frmADD_PRODUCTS addprod;
        string[] prod;
        int index, qty = 0;
        string manufactureDate, expirationDate;
        public frmQUANTITY(frmADD_EDIT_STOCKS stocks, frmADD_PRODUCTS addprod, string[] prod)
        {
            this.stocks = stocks;
            this.addprod = addprod;
            this.prod = prod;
            InitializeComponent();
        }

        public frmQUANTITY(frmADD_EDIT_STOCKS stocks, int qty, string[] dates, int index)
        {
            this.stocks = stocks;
            this.index = index;
            this.qty = qty;
            this.manufactureDate = dates[0];
            this.expirationDate = dates[1];

            InitializeComponent();
        }

        private void AddStock()
        {
            if (stocks != null)
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

                            stocks.AddProduct(prod, qty, manufactureDate, expirationDate);
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

                            stocks.ChangeQuantity(index, qty, manufactureDate, expirationDate);
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

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddStock();
            }
        }

        private void frmQUANTITY_Load(object sender, EventArgs e)
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
