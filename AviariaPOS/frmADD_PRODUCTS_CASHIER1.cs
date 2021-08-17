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
    public partial class frmADD_PRODUCTS_CASHIER1 : Form
    {
        frmCASHIER cashier;
        string[] prod;
        int index = -1;
        public frmADD_PRODUCTS_CASHIER1(frmCASHIER cashier, int index)
        {
            this.cashier = cashier;
            this.index = index;
            InitializeComponent();
        }
        public frmADD_PRODUCTS_CASHIER1(frmCASHIER cashier, params string[] prod)
        {
            this.cashier = cashier;
            this.prod = prod;
            InitializeComponent();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int qty = 0;
                if (int.TryParse(txtQuantity.Text, out qty))
                {
                    if (index == -1)
                    {
                        cashier.AddProduct(qty, prod);
                        this.Close();
                    }
                    else
                    {
                        cashier.UpdateQty(index, qty);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
