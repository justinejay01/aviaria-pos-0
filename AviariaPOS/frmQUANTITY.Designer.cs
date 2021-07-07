namespace AviariaPOS
{
    partial class frmQUANTITY
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
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.dateManufacture = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dateExpiration = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cboxExpiration = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cboxManufacture = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "";
            this.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.DisabledState.Parent = this.txtQuantity;
            this.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.FocusedState.Parent = this.txtQuantity;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantity.HoverState.Parent = this.txtQuantity;
            this.txtQuantity.Location = new System.Drawing.Point(10, 45);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.ShadowDecoration.Parent = this.txtQuantity;
            this.txtQuantity.Size = new System.Drawing.Size(280, 36);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gunaLabel1.Location = new System.Drawing.Point(5, 13);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(88, 28);
            this.gunaLabel1.TabIndex = 3;
            this.gunaLabel1.Text = "Quantity";
            // 
            // dateManufacture
            // 
            this.dateManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateManufacture.CheckedState.Parent = this.dateManufacture;
            this.dateManufacture.CustomFormat = "MMMM dd, yyyy";
            this.dateManufacture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateManufacture.HoverState.Parent = this.dateManufacture;
            this.dateManufacture.Location = new System.Drawing.Point(10, 116);
            this.dateManufacture.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateManufacture.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateManufacture.Name = "dateManufacture";
            this.dateManufacture.ShadowDecoration.Parent = this.dateManufacture;
            this.dateManufacture.Size = new System.Drawing.Size(280, 36);
            this.dateManufacture.TabIndex = 4;
            this.dateManufacture.Value = new System.DateTime(2021, 7, 6, 23, 7, 41, 686);
            // 
            // dateExpiration
            // 
            this.dateExpiration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateExpiration.CheckedState.Parent = this.dateExpiration;
            this.dateExpiration.CustomFormat = "MMMM dd, yyyy";
            this.dateExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateExpiration.HoverState.Parent = this.dateExpiration;
            this.dateExpiration.Location = new System.Drawing.Point(10, 187);
            this.dateExpiration.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateExpiration.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateExpiration.Name = "dateExpiration";
            this.dateExpiration.ShadowDecoration.Parent = this.dateExpiration;
            this.dateExpiration.Size = new System.Drawing.Size(280, 36);
            this.dateExpiration.TabIndex = 4;
            this.dateExpiration.Value = new System.DateTime(2021, 7, 6, 22, 35, 37, 80);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gunaLabel3.Location = new System.Drawing.Point(5, 156);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(146, 28);
            this.gunaLabel3.TabIndex = 5;
            this.gunaLabel3.Text = "Expiration Date";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gunaLabel2.Location = new System.Drawing.Point(5, 85);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(168, 28);
            this.gunaLabel2.TabIndex = 6;
            this.gunaLabel2.Text = "Manufacture Date";
            // 
            // cboxExpiration
            // 
            this.cboxExpiration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxExpiration.AutoSize = true;
            this.cboxExpiration.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxExpiration.CheckedState.BorderRadius = 2;
            this.cboxExpiration.CheckedState.BorderThickness = 0;
            this.cboxExpiration.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxExpiration.Location = new System.Drawing.Point(238, 167);
            this.cboxExpiration.Name = "cboxExpiration";
            this.cboxExpiration.Size = new System.Drawing.Size(52, 17);
            this.cboxExpiration.TabIndex = 7;
            this.cboxExpiration.Text = "None";
            this.cboxExpiration.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cboxExpiration.UncheckedState.BorderRadius = 2;
            this.cboxExpiration.UncheckedState.BorderThickness = 0;
            this.cboxExpiration.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cboxExpiration.UseVisualStyleBackColor = true;
            this.cboxExpiration.CheckedChanged += new System.EventHandler(this.cboxExpiration_CheckedChanged);
            // 
            // cboxManufacture
            // 
            this.cboxManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxManufacture.AutoSize = true;
            this.cboxManufacture.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxManufacture.CheckedState.BorderRadius = 2;
            this.cboxManufacture.CheckedState.BorderThickness = 0;
            this.cboxManufacture.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxManufacture.Location = new System.Drawing.Point(238, 96);
            this.cboxManufacture.Name = "cboxManufacture";
            this.cboxManufacture.Size = new System.Drawing.Size(52, 17);
            this.cboxManufacture.TabIndex = 7;
            this.cboxManufacture.Text = "None";
            this.cboxManufacture.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cboxManufacture.UncheckedState.BorderRadius = 2;
            this.cboxManufacture.UncheckedState.BorderThickness = 0;
            this.cboxManufacture.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cboxManufacture.UseVisualStyleBackColor = true;
            this.cboxManufacture.CheckedChanged += new System.EventHandler(this.cboxManufacture_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Location = new System.Drawing.Point(10, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(278, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.CheckedState.Parent = this.btnExit;
            this.btnExit.CustomImages.Parent = this.btnExit;
            this.btnExit.FillColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.Image = global::AviariaPOS.Properties.Resources.close;
            this.btnExit.Location = new System.Drawing.Point(268, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.TabIndex = 9;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmQUANTITY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboxManufacture);
            this.Controls.Add(this.cboxExpiration);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.dateExpiration);
            this.Controls.Add(this.dateManufacture);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.txtQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQUANTITY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQUANTITY";
            this.Load += new System.EventHandler(this.frmQUANTITY_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateManufacture;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateExpiration;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI2.WinForms.Guna2CheckBox cboxExpiration;
        private Guna.UI2.WinForms.Guna2CheckBox cboxManufacture;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnExit;

    }
}