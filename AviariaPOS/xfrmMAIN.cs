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
    public partial class frmMAIN0 : Form
    {
        bool isLogOut = false;
        public frmMAIN0()
        {
            InitializeComponent();
        }

        private void ChangeNavBtn(Button btn)
        {
            Color clrNotClck = Color.FromArgb(45, 45, 48);
            btnHome.BackColor = clrNotClck;
            btnCashier.BackColor = clrNotClck;
            btnReports.BackColor = clrNotClck;
            btnInventory.BackColor = clrNotClck;
            btnAbout.BackColor = clrNotClck;

            btn.BackColor = Color.FromArgb(28, 151, 234);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            ChangeNavBtn(btnCashier);

            if (pnlMain.Controls != null)
            {
                pnlMain.Controls.Clear();
            }
            
            frmCASHIER frm = new frmCASHIER();
            frm.TopLevel = false;
            frm.AutoScroll = true;

            if (!pnlMain.Controls.Contains(frm))
            {
                pnlMain.Controls.Add(frm);
                frm.Show();
            }
        }

        private void frmMAIN_Load(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(28, 151, 234);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeNavBtn(btnHome);
        }

        private void frmMAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLogOut)
                Application.Exit();
            else
                e.Cancel = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                isLogOut = true;
                Application.Exit();
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ChangeNavBtn(btnInventory);

            if (pnlMain.Controls != null)
            {
                pnlMain.Controls.Clear();
            }

            frmINVENTORY frm = new frmINVENTORY();
            frm.TopLevel = false;
            frm.AutoScroll = true;

            if (!pnlMain.Controls.Contains(frm))
            {
                pnlMain.Controls.Add(frm);
                frm.Show();
            }
        }
    }
}
