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
    public partial class frmSPLASH : Form
    {
        string conText = "server = localhost; uid = root; password =; database = aviaria; Convert Zero Datetime = True";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        bool isAdminExist = false;
        public frmSPLASH()
        {
            InitializeComponent();
        }

        private void CheckAccount()
        {
            try
            {
                if (con == null)
                    con = new MySqlConnection(conText);

                con.Open();
                string query = "select count(*) from account where privilege=@privilege;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@privilege", MySqlDbType.VarChar).Value = "admin";

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) != 0)
                        {
                            isAdminExist = true;
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

        private void frmSPLASH_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void bwork_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckAccount();
        }

        private void bwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isAdminExist)
            {
                new frmLOGIN().Show();
                this.Hide();
            }
            else
            {
                new frmSIGNUP(true).Show();
                this.Hide();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bwork.RunWorkerAsync();
            timer.Stop();
        }

        private void bwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

    }
}
