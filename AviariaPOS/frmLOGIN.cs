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
        bool isAdmin = false;
        bool hasAcc = false;
        bool isForgot = false;
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
                            if (reader.GetInt16(1) == 0)
                            {
                                if (MessageBox.Show("Successful! Press OK to continue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    frmMAIN frm = new frmMAIN(true, txtUsername.Text);
                                    frm.Show();
                                    this.Close();
                                }
                            }
                            else if (reader.GetInt16(1) == 1)
                            {
                                if (MessageBox.Show("Successful! Press OK to continue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    frmMAIN frm = new frmMAIN(false, txtUsername.Text);
                                    frm.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your account was deactivated! Please contact administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ForgotPass()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select count(*), username, privilege from account where recovery=@recovery;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@recovery", MySqlDbType.VarChar).Value = ComputeHash(txtForgotPass.Text);

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) != 0)
                        {
                            txtUsername.Text = reader.GetString(1);

                            if (reader.GetInt32(2) == 0)
                            {
                                isAdmin = true;
                            }
                            else
                            {
                                isAdmin = false;
                            }

                            hasAcc = true;

                            pnlForgotPass.Visible = false;
                            pnlLogin.Visible = true;
                            pnlLogin.Location = new Point(16, 78);

                            lblLogin.Text = "FORGOT PASSWORD";
                            btnLogin.Text = "SET";

                            isForgot = true;
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

        private void ForgotPass1()
        {
            try
            {
                if (hasAcc)
                {
                    con = new MySqlConnection(conText);
                    con.Open();
                    string query = "update account set username=@username, password=@password where recovery=@recovery;";
                    com = new MySqlCommand(query, con);
                    com.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                    com.Parameters.Add("@password", MySqlDbType.VarChar).Value = ComputeHash(txtPassword.Text);
                    com.Parameters.Add("@recovery", MySqlDbType.VarChar).Value = ComputeHash(txtForgotPass.Text);
                    com.ExecuteNonQuery();

                    if (MessageBox.Show("Successful!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        frmMAIN frm = new frmMAIN(isAdmin, txtUsername.Text);
                        frm.Show();
                        this.Close();
                    }
                    com.Dispose();
                    con.Close();
                    con.Dispose();
                }
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
            if (isForgot)
            {
                ForgotPass1();
            }
            else
            {
                LogIn();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlForgotPass.Visible = true;
            pnlForgotPass.Location = new Point(16, 78);

        }

        private void btnForgotPass1_Click(object sender, EventArgs e)
        {
            ForgotPass();
        }

        private void btnLogin1_Click(object sender, EventArgs e)
        {
            pnlForgotPass.Visible = false;
            pnlLogin.Visible = true;
            pnlLogin.Location = new Point(16, 78);
        }
    }
}
