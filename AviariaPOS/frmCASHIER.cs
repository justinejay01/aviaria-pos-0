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
    public partial class frmCASHIER : Form
    {
        public frmCASHIER()
        {
            InitializeComponent();
        }

        public void ClearForm()
        {
            dgvProducts.Rows.Clear();
            lblTotalAmount.Text = "0";
            lblTotalQty.Text = "0";

            lblTNo.Text = DateTime.Now.ToString("yyyyMMddhhmmss");
            lblTDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
        }

        private void ComputeQuantityAndAmount()
        {
            if (dgvProducts.Rows.Count > 0)
            {
                int qty = 0;
                double amount = 0;

                for (int i = 0; i < dgvProducts.RowCount; i++)
                {
                    qty += int.Parse(dgvProducts.Rows[i].Cells[2].Value.ToString());
                    amount += double.Parse(dgvProducts.Rows[i].Cells[3].Value.ToString());
                }

                lblTotalQty.Text = qty.ToString();
                lblTotalAmount.Text = amount.ToString();
            }
            else
            {
                lblTotalQty.Text = "0";
                lblTotalAmount.Text = "0";
            }
        }

        public void UpdateQty(int index, int qty)
        {
            dgvProducts.Rows[index].Cells[2].Value = qty;
            dgvProducts.Rows[index].Cells[3].Value = double.Parse(dgvProducts.Rows[index].Cells[1].Value.ToString()) * qty;

            ComputeQuantityAndAmount();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_PRODUCTS_CASHIER frm = new frmADD_PRODUCTS_CASHIER(this);
            frm.ShowDialog();
        }

        public void AddProduct(int qty, params string[] addprod)
        {
            double prodPrice = double.Parse(addprod[1]);
            dgvProducts.Rows.Add(addprod[0], prodPrice, qty, prodPrice * qty);

            ComputeQuantityAndAmount();
        }

        private void frmCASHIER_Load(object sender, EventArgs e)
        {
            lblTNo.Text = DateTime.Now.ToString("yyyyMMddhhmmss");
            lblTDate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                string prodName = dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString();
                double prodPrice = int.Parse(dgvProducts.Rows[selectedIndex].Cells[1].Value.ToString());
                frmADD_PRODUCTS_CASHIER1 frm = new frmADD_PRODUCTS_CASHIER1(this, selectedIndex);
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 5)
            {
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                {
                    dgvProducts.Rows.RemoveAt(row.Index);
                }
                ComputeQuantityAndAmount();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            frmCHECKOUT frm = new frmCHECKOUT(this, double.Parse(lblTotalAmount.Text));
            frm.ShowDialog();
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
