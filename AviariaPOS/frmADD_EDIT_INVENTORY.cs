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
    public partial class frmADD_EDIT_INVENTORY : Form
    {
        int tableIndex = 0, maxValue = 0;
        double prodID = 0;
        string conText = "server=localhost;uid=root;password=;database=aviaria";
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataReader reader;
        frmINVENTORY inventory;
        frmSTOCKS stocks;

        public frmADD_EDIT_INVENTORY(frmINVENTORY inventory, int maxValue)
        {
            this.inventory = inventory;
            this.maxValue = maxValue;
            InitializeComponent();
        }

        public frmADD_EDIT_INVENTORY(frmINVENTORY inventory, double prodID, int tableIndex)
        {
            this.inventory = inventory;
            this.prodID = prodID;
            this.tableIndex = tableIndex;
            InitializeComponent();
        }

        private void CheckProduct()
        {
            try
            {
                string query = "select count(*) from inventory where prodName=@prodName and prodPrice=@prodPrice;";
                con = new MySqlConnection(conText);
                con.Open();
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@prodName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@prodPrice", MySqlDbType.VarChar).Value = txtPrice.Text;
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
                    AddProduct();
                }
                else
                {
                    MessageBox.Show("Product already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetProduct()
        {
            try
            {
                string query = "select prodID, prodName, prodPrice, prodManufactureName from inventory where prodID=@prodID;";
                con = new MySqlConnection(conText);
                con.Open();
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@prodID", MySqlDbType.VarChar).Value = prodID;
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtID.Text = reader.GetDouble(0).ToString();
                        txtName.Text = reader.GetString(1);
                        txtPrice.Text = reader.GetDouble(2).ToString();
                        txtManuName.Text = reader.GetString(3);

                        //if (!dr.IsDBNull(4))
                        //    dateManu.Value = DateTime.Parse(dr.GetString(4));
                        //else
                        //{
                        //    dateManu.Enabled = false;
                        //    cboxManuDate.Checked = true;
                        //}

                        //if (!dr.IsDBNull(5))
                        //    dateExpi.Value = DateTime.Parse(dr.GetString(5));
                        //else
                        //{
                        //    dateExpi.Enabled = false;
                        //    cboxExpiDate.Checked = true;
                        //}
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

        private void AddProduct()
        {
            try
            {
                string query = "insert into inventory(prodID, prodName, prodPrice, prodManufactureName) values (@prodID, @prodName, @prodPrice, @prodManufactureName);";
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@prodID", MySqlDbType.Double).Value = txtID.Text;
                com.Parameters.Add("@prodName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@prodPrice", MySqlDbType.VarChar).Value = txtPrice.Text;
                com.Parameters.Add("@prodManufactureName", MySqlDbType.VarChar).Value = txtManuName.Text;

                //if (dateManu.Enabled)
                //    cm.Parameters.Add("@manufactureDate", MySqlDbType.Date).Value = dateManu.Value.Date;
                //else
                //    cm.Parameters.Add("@manufactureDate", MySqlDbType.Date).Value = null;

                //if (dateExpi.Enabled)
                //    cm.Parameters.Add("@expirationDate", MySqlDbType.Date).Value = dateExpi.Value.Date;
                //else
                //    cm.Parameters.Add("@expirationDate", MySqlDbType.Date).Value = null;

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

        private void EditProduct()
        {
            try
            {
                string query = "update inventory set prodName=@prodName, prodPrice=@prodPrice, prodManufactureName=@prodManufactureName where prodID=@prodID;";
                con = new MySqlConnection(conText);
                con.Open();
                com = new MySqlCommand(query, con);
                com.Parameters.Add("@prodID", MySqlDbType.Double).Value = txtID.Text;
                com.Parameters.Add("@prodName", MySqlDbType.VarChar).Value = txtName.Text;
                com.Parameters.Add("@prodPrice", MySqlDbType.Double).Value = txtPrice.Text;
                com.Parameters.Add("@prodManufactureName", MySqlDbType.VarChar).Value = txtManuName.Text;

                //if (dateManu.Enabled)
                //    cm.Parameters.Add("@manufactureDate", MySqlDbType.Date).Value = dateManu.Value.Date;
                //else
                //    cm.Parameters.Add("@manufactureDate", MySqlDbType.Date).Value = null;

                //if (dateExpi.Enabled)
                //    cm.Parameters.Add("@expirationDate", MySqlDbType.Date).Value = dateExpi.Value.Date;
                //else
                //    cm.Parameters.Add("@expirationDate", MySqlDbType.Date).Value = null;

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

        private void frmADD_EDIT_INVENTORY_Load(object sender, EventArgs e)
        {
            if (prodID != 0)
            {
                GetProduct();
            }
            else
            {
                int max = maxValue+1;
                txtID.Text = max.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (prodID != 0)
            {
                EditProduct();
            }
            else
            {
                CheckProduct();
            }
        }

        private void frmADD_EDIT_INVENTORY_FormClosing(object sender, FormClosingEventArgs e)
        {
            inventory.AfterDialogClosed(tableIndex);
        }

        private void frmADD_EDIT_INVENTORY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (prodID != 0)
                {
                    EditProduct();
                }
                else
                {
                    CheckProduct();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
