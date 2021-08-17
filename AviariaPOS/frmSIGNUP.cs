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
        bool isForAdmin = false;
        public frmSIGNUP(bool isForAdmin)
        {
            this.isForAdmin = isForAdmin;
            InitializeComponent();
        }

        private void SetUpAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "insert into account (id, username, password, privilege, recovery) values (0, @username, @password, @privilege, @recovery);", s = RandomString(10);
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPassword.Text);

                if (isForAdmin)
                    com.Parameters.Add("@privilege", MySqlDbType.Int16).Value = "admin";
                else
                    com.Parameters.Add("@privilege", MySqlDbType.Int16).Value = "none";

                //com.Parameters.Add("@recovery", MySqlDbType.VarChar).Value = ComputeHash(s);                

                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    pnlSetup.Visible = false;
                    pnlRec.Visible = true;
                    pnlRec.Location = new Point(16, 78);
                    txtForgotPass.Text = s;
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

        private static string RandomString(int length)
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
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

        private void txtForgotPass_Click(object sender, EventArgs e)
        {
            txtForgotPass.SelectAll();
            Clipboard.SetText(txtForgotPass.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMAIN frm = new frmMAIN(true, txtUsername.Text);
            frm.Show();
            this.Close();
        }
    }
}
