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
    public partial class frmPRINT : Form
    {
        string filePath = null;
        public frmPRINT()
        {
            InitializeComponent();
        }

        public frmPRINT(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPRINT_Load(object sender, EventArgs e)
        {
            webPrint.Url = new Uri(filePath, UriKind.Absolute);
        }
    }
}
