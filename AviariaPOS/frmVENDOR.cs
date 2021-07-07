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
    public partial class frmVENDOR : Form
    {
        string path, conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        public frmVENDOR()
        {
            InitializeComponent();
        }

        private void LoadVendor(int i)
        {
            if (dgvVendor.Rows.Count > 0)
            {
                dgvVendor.Rows.Clear();
            }

            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select vendorID, vendorName, vendorAddress, vendorContactPerson, vendorContactNumber, vendorEmail from vendor;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvVendor.Rows.Add(new object[] { reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) });
                    }
                }

                reader.Close();
                reader.Dispose();
                com.Dispose();
                con.Close();
                con.Dispose();

                if (i > 0)
                {
                    dgvVendor.Rows[i].Selected = true;
                    dgvVendor.Focus();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterTable(string col, int i)
        {
            if (txtSearch.TextLength > 0)
            {
                if (dgvVendor.Rows.Count > 0)
                {
                    dgvVendor.Rows.Clear();
                }

                try
                {
                    if (con == null)
                        con = new MySqlConnection(conText);

                    con.Open();
                    string query = "select vendorID, vendorName, vendorAddress, vendorContactPerson, vendorContactNumber, vendorEmail from vendor where " + col + " LIKE '%" + txtSearch.Text + "%';";
                    com = new MySqlCommand(query, con);

                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dgvVendor.Rows.Add(new object[] { reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) });
                        }
                    }

                    reader.Close();
                    reader.Dispose();
                    com.Dispose();
                    con.Close();
                    con.Dispose();

                    if (i > 0)
                    {
                        dgvVendor.Rows[i].Selected = true;
                        dgvVendor.Focus();
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else LoadVendor(0);
        }

        private void DeleteRow(int vendorID)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the product selected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (con == null)
                        con = new MySqlConnection(conText);

                    con.Open();
                    string query = "delete from vendor where vendorID = @vendorID;";
                    com = new MySqlCommand(query, con);
                    com.Parameters.Add("@vendorID", MySqlDbType.Double).Value = vendorID;

                    com.ExecuteNonQuery();
                    com.Dispose();

                    MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    LoadVendor(0);
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
                r = "vendorName";
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                r = "vendorAddress";
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                r = "vendorContactPerson";
            }

            FilterTable(r, 0);
            return r;
        }

        public void AfterDialogExit()
        {
            LoadVendor(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_EDIT_VENDOR frm = new frmADD_EDIT_VENDOR(this);
            frm.ShowDialog();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ColumnSelection();
        }

        private void dgvVendor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgvVendor.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvVendor.Columns["vendorDelete"].Index)
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

            if (e.ColumnIndex == dgvVendor.Columns["vendorEdit"].Index)
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

        private void dgvVendor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int selectedIndex = dgvVendor.SelectedRows[0].Index;
                int vendorID = int.Parse(dgvVendor.Rows[selectedIndex].Cells[0].Value.ToString());

                frmADD_EDIT_VENDOR frm = new frmADD_EDIT_VENDOR(this, vendorID);
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 7)
            {
                int selectedIndex = dgvVendor.SelectedRows[0].Index;
                int vendorID = int.Parse(dgvVendor.Rows[selectedIndex].Cells[0].Value.ToString());

                DeleteRow(vendorID);
            }
        }

        private void frmVENDOR_Load(object sender, EventArgs e)
        {
            LoadVendor(0);
        }
    }
}
