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
    public partial class frmADD_EDIT_VENDOR : Form
    {
        int vendorID = 0;
        string conText = "server=localhost;uid=root;password=;database=aviaria";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        frmVENDOR vendor;
        public frmADD_EDIT_VENDOR(frmVENDOR vendor)
        {
            this.vendor = vendor;
            InitializeComponent();
        }

        public frmADD_EDIT_VENDOR(frmVENDOR vendor, int vendorID)
        {
            this.vendor = vendor;
            this.vendorID = vendorID;
            InitializeComponent();
        }

        private void CheckVendor()
        {
            try
            {
                string query = "select count(*) from vendor where vendorName=@vendorName and vendorAddress=@vendorAddress and vendorContactPerson=@vendorContactPerson;";
                con = new MySqlConnection(conText);
                con.Open();
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@vendorName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@vendorAddress", MySqlDbType.VarChar).Value = txtAddress.Text;
                com.Parameters.Add("@vendorContactPerson", MySqlDbType.VarChar).Value = txtCPerson.Text;
                reader = com.ExecuteReader();

                bool isExist = false;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) != 0)
                        {
                            isExist = true;
                        }
                    }
                }

                reader.Close();
                reader.Dispose();
                com.Dispose();

                if (!isExist)
                {
                    AddVendor();
                }
                else
                {
                    MessageBox.Show("Vendor already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetVendor()
        {
            try
            {
                string query = "select vendorName, vendorAddress, vendorContactPerson, vendorContactNumber, vendorEmail from vendor where vendorID=@vendorID;";
                con = new MySqlConnection(conText);
                con.Open();
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@vendorID", MySqlDbType.Int32).Value = vendorID;
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtName.Text = reader.GetString(0);
                        txtAddress.Text = reader.GetString(1);
                        txtCPerson.Text = reader.GetString(2);
                        txtCNumber.Text = reader.GetString(3);
                        txtEmail.Text = reader.GetString(4);
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

        private void AddVendor()
        {
            try
            {
                string query = "insert into vendor(vendorName, vendorAddress, vendorContactPerson, vendorContactNumber, vendorEmail) values (@vendorName, @vendorAddress, @vendorContactPerson, @vendorContactNumber, @vendorEmail);";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@vendorName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@vendorAddress", MySqlDbType.VarChar).Value = txtAddress.Text;
                com.Parameters.Add("@vendorContactPerson", MySqlDbType.VarChar).Value = txtCPerson.Text;
                com.Parameters.Add("@vendorContactNumber", MySqlDbType.VarChar).Value = txtCNumber.Text;
                com.Parameters.Add("@vendorEmail", MySqlDbType.VarChar).Value = txtEmail.Text;

                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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

        private void EditVendor()
        {
            try
            {
                con = new MySqlConnection(conText);
                con.Open();
                string query = "update vendor set vendorName=@vendorName, vendorAddress=@vendorAddress, vendorContactPerson=@vendorContactPerson, vendorContactNumber=@vendorContactNumber, vendorEmail=@vendorEmail where vendorID=@vendorID;";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@vendorName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@vendorAddress", MySqlDbType.VarChar).Value = txtAddress.Text;
                com.Parameters.Add("@vendorContactPerson", MySqlDbType.VarChar).Value = txtCPerson.Text;
                com.Parameters.Add("@vendorContactNumber", MySqlDbType.VarChar).Value = txtCNumber.Text;
                com.Parameters.Add("@vendorEmail", MySqlDbType.VarChar).Value = txtEmail.Text;
                com.Parameters.Add("@vendorID", MySqlDbType.VarChar).Value = vendorID;
                com.ExecuteNonQuery();

                if (MessageBox.Show("Successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (vendorID != 0)
            {
                EditVendor();
            }
            else
            {
                CheckVendor();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmADD_EDIT_VENDOR_FormClosing(object sender, FormClosingEventArgs e)
        {
            vendor.AfterDialogExit();
        }

        private void frmADD_EDIT_VENDOR_Load(object sender, EventArgs e)
        {
            if (vendorID != 0)
            {
                GetVendor();
            }
        }
    }
}
