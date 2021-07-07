using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace AviariaPOS
{
    public partial class frmMAIN : Form
    {
        Guna2Button btnGlobal;
        Guna2PictureBox pboxGlobal;
        bool isAdmin = false;
        public frmMAIN(bool isAdmin)
        {
            this.isAdmin = isAdmin;
            InitializeComponent();
        }

        private void ChangeButton(Guna2Button btnTo, Guna2PictureBox pboxTo)
        {
            if (btnGlobal == null && pboxGlobal == null)
            {
                btnGlobal = btnHome;
                pboxGlobal = pboxHome;
            }

            btnGlobal.UseTransparentBackground = false;
            pboxGlobal.Visible = false;

            btnTo.UseTransparentBackground = true;
            pboxTo.Visible = true;

            btnGlobal = btnTo;
            pboxGlobal = pboxTo;
        }

        private void ChangeForm(Form frm)
        {
            frm.TopLevel = false;
            frm.AutoScroll = true;

            if (!pnlMain.Controls.Contains(frm))
            {
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(frm);
                frm.Show();
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ChangeButton(btnInventory, pboxInventory);

            frmINVENTORY frm = new frmINVENTORY();
            ChangeForm(frm);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeButton(btnHome, pboxHome);

            frmDASHBOARD frm = new frmDASHBOARD();
            ChangeForm(frm);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ChangeButton(btnReports, pboxReports);
        }

        private void frmDASHBOARD_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                pnlCashier.Visible = false;
                frmDASHBOARD frm = new frmDASHBOARD();
                ChangeForm(frm);
            }
            else
            {
                pnlAdmin.Visible = false;
                frmCASHIER frm = new frmCASHIER();
                ChangeForm(frm);
            }
        }

        private void btnSwitchToCashier_Click(object sender, EventArgs e)
        {
            pnlAdmin.Visible = false;
            pnlCashier.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frmLOGIN frm = new frmLOGIN();
                frm.Show();
                this.Close();
            }
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            ChangeButton(btnStocks, pboxStocks);

            frmSTOCKS frm = new frmSTOCKS();
            ChangeForm(frm);
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            ChangeButton(btnVendor, pboxVendor);

            frmVENDOR frm = new frmVENDOR();
            ChangeForm(frm);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ChangeButton(btnAccount, pboxAccount);

            frmACCOUNT frm = new frmACCOUNT();
            ChangeForm(frm);
        }
    }
}
