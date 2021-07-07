using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviariaPOS
{
    public partial class frmLOGIN : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        public frmLOGIN()
        {
            InitializeComponent();
        }

        private void LogIn()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select count(*), privilege from account where username=@username and password=@password;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPassword.Text);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) != 0)
                        {
                            if (MessageBox.Show("Successful! Press OK to continue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                if (reader.GetInt16(1) == 0)
                                {
                                    frmMAIN frm = new frmMAIN(true);
                                    frm.Show();
                                    this.Close();
                                }
                                else
                                {
                                    frmMAIN frm = new frmMAIN(false);
                                    frm.Show();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account credentials doesn't exist in the system!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void cboxViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxViewPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
