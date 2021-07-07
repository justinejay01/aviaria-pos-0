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
    public partial class frmSIGNUP : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        public frmSIGNUP()
        {
            InitializeComponent();
        }

        private void SetUpAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "insert into account (id, username, password, privilege) values (0, @username, @password, @privilege);";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPassword.Text);
                com.Parameters.Add("@privilege", MySqlDbType.Int16).Value = 0;

                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful! Press OK to login!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    frmLOGIN frm = new frmLOGIN();
                    frm.Show();
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

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetUpAccount();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
