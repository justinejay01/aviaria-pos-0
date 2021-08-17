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

using iText;
using System.IO;
using iText.Layout;
using iText.Layout.Element;
using iText.IO;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel;
using iText.Kernel.Pdf;

namespace AviariaPOS
{
    public partial class frmINVENTORY : Form
    {
        string path, conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        public frmINVENTORY()
        {
            InitializeComponent();
        }

        private void LoadInventory(int i)
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
                string query = "select prodID, prodName, prodPrice, prodManufactureName from inventory;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvProducts.Rows.Add(new object[] { reader.GetDouble(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3) });
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

        private void FilterTable(string colName, int i)
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
                    string query = "select prodID, prodName, prodPrice, prodManufactureName from inventory where " + colName + " LIKE '%" + txtSearch.Text + "%';";
                    com = new MySqlCommand(query, con);

                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dgvProducts.Rows.Add(new object[] { reader.GetDouble(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3) });
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
            else LoadInventory(0);
        }

        public int CheckMaxValue()
        {
            int max = 0;
            for (int i = 0; i < dgvProducts.RowCount; i++)
            {
                int id = int.Parse(dgvProducts.Rows[i].Cells[0].Value.ToString());

                if (id > max)
                {
                    max = id;
                }
            }
            return max;
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

        private void DeleteRow(double prodID)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the product selected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (con == null)
                        con = new MySqlConnection(conText);

                    con.Open();
                    string query = "delete from inventory where prodID = @prodID;";
                    com = new MySqlCommand(query, con);
                    com.Parameters.Add("@prodID", MySqlDbType.Double).Value = prodID;

                    com.ExecuteNonQuery();
                    com.Dispose();

                    MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    LoadInventory(0);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ColumnSelection()
        {
            string r = "";
            if (cmbSearch.SelectedIndex == 0)
            {
                r = "prodName";
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                r = "prodPrice";
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                r = "manufactureName";
            }

            FilterTable(r, 0);
            return r;
        }

        public void AfterDialogClosed(int i)
        {
            FilterTable(ColumnSelection(), i);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvProducts.Rows.Count > 0 && e.KeyCode == Keys.Down)
                dgvProducts.Focus();
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvProducts.Rows[0].Selected && e.KeyCode == Keys.Up)
            {
                txtSearch.Focus();
            }
            else if (e.KeyCode == Keys.Insert)
            {
                frmADD_EDIT_INVENTORY frm = new frmADD_EDIT_INVENTORY(this, CheckMaxValue());
                frm.ShowDialog();
            }
            else if (e.KeyCode == Keys.F6)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                double prodID = double.Parse(dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString());

                frmADD_EDIT_INVENTORY frm = new frmADD_EDIT_INVENTORY(this, prodID, selectedIndex);
                frm.ShowDialog();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                double prodID = double.Parse(dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString());

                DeleteRow(prodID);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_EDIT_INVENTORY frm = new frmADD_EDIT_INVENTORY(this, CheckMaxValue());
            frm.ShowDialog();
        }

        private void frmINVENTORY_Load(object sender, EventArgs e)
        {
            LoadInventory(0);

            cmbSearch.Items.AddRange(new object[] { "Product Name", "Price", "Manufacture Name" });
            cmbSearch.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ColumnSelection();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnSelection();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                double prodID = double.Parse(dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString());

                frmADD_EDIT_INVENTORY frm = new frmADD_EDIT_INVENTORY(this, prodID, selectedIndex);
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;
                double prodID = double.Parse(dgvProducts.Rows[selectedIndex].Cells[0].Value.ToString());

                DeleteRow(prodID);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pbarPrint.Value = 0;
            pbarPrint.Visible = true;
            bworkPrint.RunWorkerAsync();
        }

        private void PrintReport()
        {
            //Cell cell0, cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9, cell10, cell11, cell12, cell13;
            string filePath = "F:/AviariaPOS/apossample.pdf";
            try
            {
                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument docu = new PdfDocument(writer);
                Document doc = new Document(docu);
                
                Table tbl0 = new Table(new float[] { 11, 80, 11 }, true);

                Bitmap bmp = Properties.Resources.add_64px;
                byte[] byte_logo;
                using (MemoryStream m_strm = new MemoryStream())
                {
                    bmp.Save(m_strm, bmp.RawFormat);
                    byte_logo = m_strm.ToArray();
                }

                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(byte_logo));

                //cell0 = new Cell();
                //cell0.SetHeight(60.0f);
                //cell0.SetWidth(60.0f);
                //cell0.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell0.Add(logo);

                tbl0.AddCell(new Cell()
                    .SetHeight(60.0f)
                    .SetWidth(60.0f)
                    .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                    .Add(logo));

                Cell cell = new Cell()
                    .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                    .Add(new Paragraph("Aviaria Padua")
                        .SetFontSize(20)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER))
                    .Add(new Paragraph("Santa Cruz, Laguna")
                        .SetFontSize(10)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                //Paragraph p0 = new Paragraph("Aviaria Padua").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                //Paragraph p1 = new Paragraph("Santa Cruz, Laguna").SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                //cell1.Add(new Paragraph("Aviaria Padua").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                //cell1.Add(new Paragraph("Santa Cruz, Laguna").SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                tbl0.AddCell(cell);
                doc.Add(tbl0);
                tbl0.Complete();

                Table tbl1 = new Table(new float[] { 10, 45, 12, 35 }, true);

                //cell2 = new Cell().Add(new Paragraph("Product ID#"));
                //Paragraph col0 = new Paragraph("Product ID#");
                //cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell3 = new Cell().Add(new Paragraph("Name"));
                //Paragraph col1 = new Paragraph("Name");
                //cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell4 = new Cell().Add(new Paragraph("Price"));
                //Paragraph col2 = new Paragraph("Price");
                //cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell5 = new Cell().Add(new Paragraph("Manufacturer Name"));
                //Paragraph col3 = new Paragraph("Manufacturer Name");
                //cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell6 = new Cell().Add(new Paragraph("Manufactured Date"));
                //Paragraph col4 = new Paragraph("Manufactured Date");
                //cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                //cell7 = new Cell();
                //Paragraph col5 = new Paragraph("Expiration Date");
                //cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Product ID#").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Name").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Price").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Manufacturer Name").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));

                for (int i = 0; i < dgvProducts.RowCount; i++)
                {
                    //cell8 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[0].Value.ToString()));
                    //cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //cell9 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[1].Value.ToString()));
                    //cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //cell10 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[2].Value.ToString()));
                    //cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //cell11 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[3].Value.ToString()));
                    //cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //cell12 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[4].Value.ToString()));
                    //cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //cell13 = new Cell().Add(new Paragraph(dgvProducts.Rows[i].Cells[5].Value.ToString()));
                    //cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    //Paragraph p2 = new Paragraph(dgvProducts.Rows[i].Cells[0].Value.ToString());
                    //Paragraph p3 = new Paragraph(dgvProducts.Rows[i].Cells[1].Value.ToString());
                    //Paragraph p4 = new Paragraph(dgvProducts.Rows[i].Cells[2].Value.ToString());
                    //Paragraph p5 = new Paragraph(dgvProducts.Rows[i].Cells[3].Value.ToString());
                    //Paragraph p6 = new Paragraph(dgvProducts.Rows[i].Cells[4].Value.ToString());
                    //Paragraph p7 = new Paragraph(dgvProducts.Rows[i].Cells[5].Value.ToString());

                    //cell8.Add(p2);
                    //cell9.Add(p3);
                    //cell10.Add(p4);
                    //cell11.Add(p5);
                    //cell12.Add(p6);
                    //cell13.Add(p7);

                    tbl1.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[0].Value.ToString())));
                    tbl1.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[1].Value.ToString())));
                    tbl1.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[2].Value.ToString())));
                    tbl1.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[3].Value.ToString())));
                }

                doc.Add(tbl1);
                tbl1.Complete();
                doc.Close();

                path = "file:///" + filePath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bworkPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            PrintReport();
        }

        private void bworkPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbarPrint.Visible = false;
            frmPRINT frm = new frmPRINT(path);
            frm.ShowDialog();
        }
    }
}
