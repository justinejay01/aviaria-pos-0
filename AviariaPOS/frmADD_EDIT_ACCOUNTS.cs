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
using System.Security.Cryptography;

namespace AviariaPOS
{
    public partial class frmADD_EDIT_ACCOUNTS : Form
    {
        string[] s;
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        frmACCOUNT account;
        public frmADD_EDIT_ACCOUNTS(frmACCOUNT account, params string[] s)
        {
            this.account = account;
            this.s = s;
            InitializeComponent();
        }

        private void GetAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select firstname, lastname, address, contactnumber, emailaddress, username from account where username = @username;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = s[0];

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtFName.Text = reader.GetString(0);
                        txtLName.Text = reader.GetString(1);
                        txtAddress.Text = reader.GetString(2);
                        txtCNumber.Text = reader.GetString(3);
                        txtEmail.Text = reader.GetString(4);
                        txtUname.Text = reader.GetString(5);
                        txtUname.Enabled = false;
                    }
                }

                com.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckPassword()
        {
            if (txtPword.Text == txtRPword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InsertAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "insert into account (id, username, password, privilege, firstname, lastname, address, contactnumber, emailaddress) values (1, @username, @password, @privilege, @firstname, @lastname, @address, @contactnumber, @emailaddress);";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUname.Text;
                com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPword.Text);
                com.Parameters.Add("@privilege", MySqlDbType.Int16).Value = 1;
                com.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = txtFName.Text;
                com.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = txtLName.Text;
                com.Parameters.Add("@address", MySqlDbType.VarChar).Value = txtAddress.Text;
                com.Parameters.Add("@emailaddress", MySqlDbType.VarChar).Value = txtEmail.Text;

                double cnumber = 0;
                if (double.TryParse(txtCNumber.Text, out cnumber))
                {
                    com.Parameters.Add("@contactnumber", MySqlDbType.Double).Value = cnumber;
                }

                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

                com.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "update account set password=@password, firstname=@firstname, lastname=@lastname, address=@address, contactnumber=@contactnumber, emailaddress=@emailaddress where username=@username;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUname.Text;
                com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPword.Text);
                com.Parameters.Add("@privilege", MySqlDbType.Int16).Value = 1;
                com.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = txtFName.Text;
                com.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = txtLName.Text;
                com.Parameters.Add("@address", MySqlDbType.VarChar).Value = txtAddress.Text;
                com.Parameters.Add("@emailaddress", MySqlDbType.VarChar).Value = txtEmail.Text;

                double cnumber = 0;
                if (double.TryParse(txtCNumber.Text, out cnumber))
                {
                    com.Parameters.Add("@contactnumber", MySqlDbType.Double).Value = cnumber;
                }

                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

                com.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ComputeHash(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2") + "A");
                }
                return builder.ToString().ToUpper();
            }
        }

        private void frmADD_EDIT_ACCOUNTS_Load(object sender, EventArgs e)
        {
            if (s != null)
            {
                GetAccount();
            }
        }

        private void cboxPword_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxPword.Checked)
            {
                txtPword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPword.UseSystemPasswordChar = true;
            }
        }

        private void cboxRPword_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxRPword.Checked)
            {
                txtRPword.UseSystemPasswordChar = false;
            }
            else
            {
                txtRPword.UseSystemPasswordChar = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckPassword())
            {
                InsertAccount();
            }
            else
            {
                MessageBox.Show("Password do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmADD_EDIT_ACCOUNTS_FormClosing(object sender, FormClosingEventArgs e)
        {
            account.AfterDialogClosed();
        }
    }
}
