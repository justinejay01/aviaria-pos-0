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
    public partial class frmACCOUNT : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        public frmACCOUNT()
        {
            InitializeComponent();
        }

        private void LoadAccounts()
        {
            if (dgvAccounts.Rows.Count > 0)
            {
                dgvAccounts.Rows.Clear();
            }

            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select firstname, lastname, address, contactnumber, emailaddress, username, privilege from account where not privilege=0;";
                com = new MySqlCommand(query, con);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string s = "";
                        if (reader.GetInt32(6) == 2)
                        {
                            s = "Not Active";
                        }
                        else
                        {
                            s = "Active";
                        }

                        dgvAccounts.Rows.Add(new object[] { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), s });
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

        private void DeactivateAccount(int index)
        {
            if (MessageBox.Show("Are you sure you want to deactivate this account?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (con == null)
                        con = new MySqlConnection(conText);

                    con.Open();
                    string query = "update account set privilege=2 where username=@username;";
                    com = new MySqlCommand(query, con);
                    com.Parameters.Add("@username", MySqlDbType.VarChar).Value = dgvAccounts.Rows[index].Cells[5].Value.ToString();

                    com.ExecuteNonQuery();

                    MessageBox.Show("Successfully deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    com.Dispose();
                    con.Close();
                    con.Dispose();

                    LoadAccounts();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AfterDialogClosed()
        {
            LoadAccounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmADD_EDIT_ACCOUNTS frm = new frmADD_EDIT_ACCOUNTS(this);
            frm.ShowDialog();
        }

        private void frmACCOUNT_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int selectedIndex = dgvAccounts.SelectedRows[0].Index;

                frmADD_EDIT_ACCOUNTS frm = new frmADD_EDIT_ACCOUNTS(this, dgvAccounts.Rows[selectedIndex].Cells[5].Value.ToString());
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 8)
            {
                int selectedIndex = dgvAccounts.SelectedRows[0].Index;

                DeactivateAccount(selectedIndex);
            }
        }

        private void dgvAccounts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgvAccounts.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvAccounts.Columns["accountDeactivate"].Index)
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

            if (e.ColumnIndex == dgvAccounts.Columns["accountEdit"].Index)
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
