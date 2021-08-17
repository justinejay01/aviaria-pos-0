using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iText;
using System.IO;
using iText.Layout;
using iText.Layout.Element;
using iText.IO;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel;
using iText.Kernel.Pdf;
using Guna.UI2.WinForms;

namespace AviariaPOS
{
    public partial class frmCHECKOUT : Form
    {
        string path;
        double amount;
        frmCASHIER cashier;
        Guna2DataGridView dgvProducts;
        public frmCHECKOUT(frmCASHIER cashier, double amount)
        {
            this.cashier = cashier;
            this.amount = amount;
            this.dgvProducts = cashier.dgvProducts;
            InitializeComponent();
        }

        private void frmCHECKOUT_Load(object sender, EventArgs e)
        {
            txtTotalAmount.Text = amount.ToString();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            double payment, change;

            if (double.TryParse(txtPayment.Text, out payment))
            {
                change = payment - amount;
                txtChange.Text = change.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (double.Parse(txtPayment.Text) > amount)
            {
                MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bworkPrint.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Payment does not meet the total amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

                Bitmap bmp = Properties.Resources.BACKGROUND;
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

                Table tbl1 = new Table(new float[] { 51, 51 }, true);

                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Transaction No.: " + cashier.lblTNo.Text).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f)).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                tbl1.AddCell(new Cell()
                    .Add(new Paragraph("Date: " + DateTime.Today.ToString("MMMM dd, yyyy")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f)).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                doc.Add(tbl1);
                tbl1.Complete();

                Table tbl2 = new Table(new float[] { 62, 15, 10, 15 }, true);

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

                tbl2.AddCell(new Cell()
                    .Add(new Paragraph("Name").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl2.AddCell(new Cell()
                    .Add(new Paragraph("Price").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl2.AddCell(new Cell()
                    .Add(new Paragraph("Quantity").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                tbl2.AddCell(new Cell()
                    .Add(new Paragraph("Total Price").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));

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

                    tbl2.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[0].Value.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                    tbl2.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[1].Value.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                    tbl2.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[2].Value.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                    tbl2.AddCell(new Cell()
                        .Add(new Paragraph(dgvProducts.Rows[i].Cells[3].Value.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                }

                doc.Add(tbl2);
                tbl2.Complete();

                Table tbl3 = new Table(new float[] { 34, 34, 34 }, true);

                tbl3.AddCell(new Cell()
                    .Add(new Paragraph("Total Amount").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f).SetBold())
                    .Add(new Paragraph(amount.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f))
                    .SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                tbl3.AddCell(new Cell()
                    .Add(new Paragraph("Cash").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f).SetBold())
                    .Add(new Paragraph(txtPayment.Text).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f))
                    .SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                tbl3.AddCell(new Cell()
                    .Add(new Paragraph("Change").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f).SetBold())
                    .Add(new Paragraph(txtChange.Text).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f))
                    .SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                doc.Add(tbl3);
                tbl3.Complete();

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
            frmPRINT frm = new frmPRINT(path);
            frm.ShowDialog();
            cashier.ClearForm();
            this.Close();
        }
    }
}
