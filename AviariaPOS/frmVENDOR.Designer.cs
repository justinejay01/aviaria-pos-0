namespace AviariaPOS
{
    partial class frmVENDOR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVENDOR));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bworkPrint = new System.ComponentModel.BackgroundWorker();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pbarPrint = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.cmbSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvVendor = new Guna.UI2.WinForms.Guna2DataGridView();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.vendorDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog1";
            this.printPreviewDialog.Visible = false;
            // 
            // pbarPrint
            // 
            this.pbarPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbarPrint.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pbarPrint.Location = new System.Drawing.Point(12, 165);
            this.pbarPrint.Name = "pbarPrint";
            this.pbarPrint.ShadowDecoration.Parent = this.pbarPrint;
            this.pbarPrint.Size = new System.Drawing.Size(1276, 20);
            this.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarPrint.TabIndex = 26;
            this.pbarPrint.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.pbarPrint.Visible = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Century Gothic", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(12, 9);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(247, 74);
            this.gunaLabel1.TabIndex = 25;
            this.gunaLabel1.Text = "Vendor";
            // 
            // cmbSearch
            // 
            this.cmbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSearch.FocusedState.Parent = this.cmbSearch;
            this.cmbSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.HoverState.Parent = this.cmbSearch;
            this.cmbSearch.ItemHeight = 30;
            this.cmbSearch.ItemsAppearance.Parent = this.cmbSearch;
            this.cmbSearch.Location = new System.Drawing.Point(1148, 123);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.ShadowDecoration.Parent = this.cmbSearch;
            this.cmbSearch.Size = new System.Drawing.Size(140, 36);
            this.cmbSearch.TabIndex = 22;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Animated = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.Location = new System.Drawing.Point(833, 123);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(309, 36);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvVendor
            // 
            this.dgvVendor.AllowUserToAddRows = false;
            this.dgvVendor.AllowUserToDeleteRows = false;
            this.dgvVendor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvVendor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendor.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVendor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVendor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVendor.ColumnHeadersHeight = 30;
            this.dgvVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendor,
            this.vendorName,
            this.vendorAddress,
            this.vendorContactPerson,
            this.vendorNumber,
            this.vendorEmail,
            this.vendorEdit,
            this.vendorDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 20F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVendor.EnableHeadersVisualStyles = false;
            this.dgvVendor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVendor.Location = new System.Drawing.Point(12, 191);
            this.dgvVendor.MultiSelect = false;
            this.dgvVendor.Name = "dgvVendor";
            this.dgvVendor.ReadOnly = true;
            this.dgvVendor.RowHeadersVisible = false;
            this.dgvVendor.RowTemplate.Height = 40;
            this.dgvVendor.RowTemplate.ReadOnly = true;
            this.dgvVendor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendor.Size = new System.Drawing.Size(1276, 570);
            this.dgvVendor.TabIndex = 20;
            this.dgvVendor.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvVendor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVendor.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvVendor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvVendor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvVendor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvVendor.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvVendor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVendor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvVendor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVendor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvVendor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVendor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVendor.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvVendor.ThemeStyle.ReadOnly = true;
            this.dgvVendor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVendor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVendor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.dgvVendor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVendor.ThemeStyle.RowsStyle.Height = 40;
            this.dgvVendor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVendor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVendor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendor_CellContentClick);
            this.dgvVendor.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvVendor_CellPainting);
            // 
            // vendor
            // 
            this.vendor.HeaderText = "ID";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // vendorName
            // 
            this.vendorName.FillWeight = 80.4513F;
            this.vendorName.HeaderText = "Vendor";
            this.vendorName.Name = "vendorName";
            this.vendorName.ReadOnly = true;
            // 
            // vendorAddress
            // 
            this.vendorAddress.FillWeight = 80.4513F;
            this.vendorAddress.HeaderText = "Address";
            this.vendorAddress.Name = "vendorAddress";
            this.vendorAddress.ReadOnly = true;
            // 
            // vendorContactPerson
            // 
            this.vendorContactPerson.FillWeight = 80.4513F;
            this.vendorContactPerson.HeaderText = "Contact Person";
            this.vendorContactPerson.Name = "vendorContactPerson";
            this.vendorContactPerson.ReadOnly = true;
            // 
            // vendorNumber
            // 
            this.vendorNumber.FillWeight = 80.4513F;
            this.vendorNumber.HeaderText = "Contact Number";
            this.vendorNumber.Name = "vendorNumber";
            this.vendorNumber.ReadOnly = true;
            // 
            // vendorEmail
            // 
            this.vendorEmail.HeaderText = "E-mail";
            this.vendorEmail.Name = "vendorEmail";
            this.vendorEmail.ReadOnly = true;
            // 
            // vendorEdit
            // 
            this.vendorEdit.FillWeight = 70F;
            this.vendorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vendorEdit.HeaderText = "Edit";
            this.vendorEdit.Name = "vendorEdit";
            this.vendorEdit.ReadOnly = true;
            // 
            // vendorDelete
            // 
            this.vendorDelete.FillWeight = 70F;
            this.vendorDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vendorDelete.HeaderText = "Delete";
            this.vendorDelete.Name = "vendorDelete";
            this.vendorDelete.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.CheckedState.Parent = this.btnAdd;
            this.btnAdd.CustomImages.Parent = this.btnAdd;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.Parent = this.btnAdd;
            this.btnAdd.Image = global::AviariaPOS.Properties.Resources.add_64px;
            this.btnAdd.Location = new System.Drawing.Point(12, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add Vendor";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.CheckedState.Parent = this.btnPrint;
            this.btnPrint.CustomImages.Parent = this.btnPrint;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverState.Parent = this.btnPrint;
            this.btnPrint.Image = global::AviariaPOS.Properties.Resources.print_64px;
            this.btnPrint.Location = new System.Drawing.Point(208, 114);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShadowDecoration.Parent = this.btnPrint;
            this.btnPrint.Size = new System.Drawing.Size(180, 45);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "Print Preview";
            this.btnPrint.Visible = false;
            // 
            // frmVENDOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AviariaPOS.Properties.Resources.Margo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 773);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pbarPrint);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvVendor);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVENDOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVENDOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVENDOR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private System.ComponentModel.BackgroundWorker bworkPrint;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private Guna.UI2.WinForms.Guna2ProgressBar pbarPrint;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorEmail;
        private System.Windows.Forms.DataGridViewButtonColumn vendorEdit;
        private System.Windows.Forms.DataGridViewButtonColumn vendorDelete;
    }
}