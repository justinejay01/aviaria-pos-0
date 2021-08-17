namespace AviariaPOS
{
    partial class frmLOGIN
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
            this.components = new System.ComponentModel.Container();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.pnlLogin = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblViewPass = new System.Windows.Forms.Label();
            this.cboxViewPass = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnForgotPass = new Guna.UI2.WinForms.Guna2Button();
            this.pnlForgotPass = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblForgotPass = new System.Windows.Forms.Label();
            this.btnForgotPass1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogin1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtForgotPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlForgotPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.Black;
            this.txtUsername.BorderRadius = 15;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.Parent = this.txtUsername;
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.Aqua;
            this.txtUsername.FocusedState.Parent = this.txtUsername;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.HoverState.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUsername.HoverState.Parent = this.txtUsername;
            this.txtUsername.IconLeft = global::AviariaPOS.Properties.Resources.vendor;
            this.txtUsername.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtUsername.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtUsername.Location = new System.Drawing.Point(42, 186);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.SelectedText = "";
            this.txtUsername.ShadowDecoration.Parent = this.txtUsername;
            this.txtUsername.Size = new System.Drawing.Size(222, 45);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.Black;
            this.txtPassword.BorderRadius = 15;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.Aqua;
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.IconLeft = global::AviariaPOS.Properties.Resources.account;
            this.txtPassword.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtPassword.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtPassword.Location = new System.Drawing.Point(42, 237);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(222, 45);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BorderRadius = 25;
            this.pnlLogin.Controls.Add(this.lblViewPass);
            this.pnlLogin.Controls.Add(this.cboxViewPass);
            this.pnlLogin.Controls.Add(this.guna2Separator1);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Controls.Add(this.btnForgotPass);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.FillColor = System.Drawing.Color.Transparent;
            this.pnlLogin.FillColor2 = System.Drawing.Color.White;
            this.pnlLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLogin.Location = new System.Drawing.Point(16, 78);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.ShadowDecoration.Parent = this.pnlLogin;
            this.pnlLogin.Size = new System.Drawing.Size(314, 448);
            this.pnlLogin.TabIndex = 6;
            // 
            // lblViewPass
            // 
            this.lblViewPass.AutoSize = true;
            this.lblViewPass.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewPass.Location = new System.Drawing.Point(152, 290);
            this.lblViewPass.Name = "lblViewPass";
            this.lblViewPass.Size = new System.Drawing.Size(88, 16);
            this.lblViewPass.TabIndex = 8;
            this.lblViewPass.Text = "View Password";
            // 
            // cboxViewPass
            // 
            this.cboxViewPass.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxViewPass.CheckedState.BorderRadius = 2;
            this.cboxViewPass.CheckedState.BorderThickness = 0;
            this.cboxViewPass.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxViewPass.CheckedState.Parent = this.cboxViewPass;
            this.cboxViewPass.CheckMarkColor = System.Drawing.Color.Black;
            this.cboxViewPass.Location = new System.Drawing.Point(243, 288);
            this.cboxViewPass.Name = "cboxViewPass";
            this.cboxViewPass.ShadowDecoration.Parent = this.cboxViewPass;
            this.cboxViewPass.Size = new System.Drawing.Size(20, 20);
            this.cboxViewPass.TabIndex = 7;
            this.cboxViewPass.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.cboxViewPass.UncheckedState.BorderRadius = 4;
            this.cboxViewPass.UncheckedState.BorderThickness = 0;
            this.cboxViewPass.UncheckedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.cboxViewPass.UncheckedState.Parent = this.cboxViewPass;
            this.cboxViewPass.UseTransparentBackground = true;
            this.cboxViewPass.CheckedChanged += new System.EventHandler(this.cboxViewPass_CheckedChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Azure;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(10, 87);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(291, 17);
            this.guna2Separator1.TabIndex = 6;
            this.guna2Separator1.UseTransparentBackground = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLogin.Location = new System.Drawing.Point(12, 113);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(138, 44);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "LOGIN";
            // 
            // btnLogin
            // 
            this.btnLogin.AutoRoundedCorners = true;
            this.btnLogin.BorderRadius = 19;
            this.btnLogin.CheckedState.Parent = this.btnLogin;
            this.btnLogin.CustomImages.Parent = this.btnLogin;
            this.btnLogin.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.Parent = this.btnLogin;
            this.btnLogin.Location = new System.Drawing.Point(184, 335);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ShadowDecoration.Parent = this.btnLogin;
            this.btnLogin.Size = new System.Drawing.Size(96, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 84);
            this.label2.TabIndex = 5;
            this.label2.Text = "Welcome to \r\nAviaria Padua";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderRadius = 5;
            this.btnExit.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(865, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(45, 29);
            this.btnExit.TabIndex = 5;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = null;
            // 
            // btnForgotPass
            // 
            this.btnForgotPass.AutoRoundedCorners = true;
            this.btnForgotPass.BorderRadius = 19;
            this.btnForgotPass.CheckedState.Parent = this.btnForgotPass;
            this.btnForgotPass.CustomImages.Parent = this.btnForgotPass;
            this.btnForgotPass.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnForgotPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotPass.ForeColor = System.Drawing.Color.White;
            this.btnForgotPass.HoverState.Parent = this.btnForgotPass;
            this.btnForgotPass.Location = new System.Drawing.Point(92, 381);
            this.btnForgotPass.Name = "btnForgotPass";
            this.btnForgotPass.ShadowDecoration.Parent = this.btnForgotPass;
            this.btnForgotPass.Size = new System.Drawing.Size(188, 40);
            this.btnForgotPass.TabIndex = 2;
            this.btnForgotPass.Text = "FORGOT PASSWORD";
            this.btnForgotPass.Click += new System.EventHandler(this.btnForgotPass_Click);
            // 
            // pnlForgotPass
            // 
            this.pnlForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.pnlForgotPass.BorderRadius = 25;
            this.pnlForgotPass.Controls.Add(this.guna2Separator2);
            this.pnlForgotPass.Controls.Add(this.lblForgotPass);
            this.pnlForgotPass.Controls.Add(this.btnForgotPass1);
            this.pnlForgotPass.Controls.Add(this.btnLogin1);
            this.pnlForgotPass.Controls.Add(this.txtForgotPass);
            this.pnlForgotPass.Controls.Add(this.label5);
            this.pnlForgotPass.FillColor = System.Drawing.Color.Transparent;
            this.pnlForgotPass.FillColor2 = System.Drawing.Color.White;
            this.pnlForgotPass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlForgotPass.Location = new System.Drawing.Point(353, 78);
            this.pnlForgotPass.Name = "pnlForgotPass";
            this.pnlForgotPass.ShadowDecoration.Parent = this.pnlForgotPass;
            this.pnlForgotPass.Size = new System.Drawing.Size(314, 448);
            this.pnlForgotPass.TabIndex = 6;
            this.pnlForgotPass.Visible = false;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.Azure;
            this.guna2Separator2.FillThickness = 2;
            this.guna2Separator2.Location = new System.Drawing.Point(10, 87);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(291, 17);
            this.guna2Separator2.TabIndex = 6;
            this.guna2Separator2.UseTransparentBackground = true;
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPass.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPass.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblForgotPass.Location = new System.Drawing.Point(12, 113);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(277, 33);
            this.lblForgotPass.TabIndex = 3;
            this.lblForgotPass.Text = "FORGOT PASSWORD";
            // 
            // btnForgotPass1
            // 
            this.btnForgotPass1.AutoRoundedCorners = true;
            this.btnForgotPass1.BorderRadius = 19;
            this.btnForgotPass1.CheckedState.Parent = this.btnForgotPass1;
            this.btnForgotPass1.CustomImages.Parent = this.btnForgotPass1;
            this.btnForgotPass1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnForgotPass1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotPass1.ForeColor = System.Drawing.Color.White;
            this.btnForgotPass1.HoverState.Parent = this.btnForgotPass1;
            this.btnForgotPass1.Location = new System.Drawing.Point(92, 335);
            this.btnForgotPass1.Name = "btnForgotPass1";
            this.btnForgotPass1.ShadowDecoration.Parent = this.btnForgotPass1;
            this.btnForgotPass1.Size = new System.Drawing.Size(188, 40);
            this.btnForgotPass1.TabIndex = 2;
            this.btnForgotPass1.Text = "FORGOT PASSWORD";
            this.btnForgotPass1.Click += new System.EventHandler(this.btnForgotPass1_Click);
            // 
            // btnLogin1
            // 
            this.btnLogin1.AutoRoundedCorners = true;
            this.btnLogin1.BorderRadius = 19;
            this.btnLogin1.CheckedState.Parent = this.btnLogin1;
            this.btnLogin1.CustomImages.Parent = this.btnLogin1;
            this.btnLogin1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin1.ForeColor = System.Drawing.Color.White;
            this.btnLogin1.HoverState.Parent = this.btnLogin1;
            this.btnLogin1.Location = new System.Drawing.Point(184, 381);
            this.btnLogin1.Name = "btnLogin1";
            this.btnLogin1.ShadowDecoration.Parent = this.btnLogin1;
            this.btnLogin1.Size = new System.Drawing.Size(96, 40);
            this.btnLogin1.TabIndex = 2;
            this.btnLogin1.Text = "LOGIN";
            this.btnLogin1.Click += new System.EventHandler(this.btnLogin1_Click);
            // 
            // txtForgotPass
            // 
            this.txtForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.txtForgotPass.BorderColor = System.Drawing.Color.Black;
            this.txtForgotPass.BorderRadius = 15;
            this.txtForgotPass.BorderThickness = 2;
            this.txtForgotPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtForgotPass.DefaultText = "";
            this.txtForgotPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtForgotPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtForgotPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtForgotPass.DisabledState.Parent = this.txtForgotPass;
            this.txtForgotPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtForgotPass.FocusedState.BorderColor = System.Drawing.Color.Aqua;
            this.txtForgotPass.FocusedState.Parent = this.txtForgotPass;
            this.txtForgotPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtForgotPass.ForeColor = System.Drawing.Color.Black;
            this.txtForgotPass.HoverState.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtForgotPass.HoverState.Parent = this.txtForgotPass;
            this.txtForgotPass.IconLeft = global::AviariaPOS.Properties.Resources.account;
            this.txtForgotPass.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtForgotPass.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtForgotPass.Location = new System.Drawing.Point(42, 186);
            this.txtForgotPass.Multiline = true;
            this.txtForgotPass.Name = "txtForgotPass";
            this.txtForgotPass.PasswordChar = '\0';
            this.txtForgotPass.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtForgotPass.PlaceholderText = "Recovery String";
            this.txtForgotPass.SelectedText = "";
            this.txtForgotPass.ShadowDecoration.Parent = this.txtForgotPass;
            this.txtForgotPass.Size = new System.Drawing.Size(222, 96);
            this.txtForgotPass.TabIndex = 1;
            this.txtForgotPass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 84);
            this.label5.TabIndex = 5;
            this.label5.Text = "Welcome to \r\nAviaria Padua";
            // 
            // frmLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AviariaPOS.Properties.Resources.BACKGROUND;
            this.ClientSize = new System.Drawing.Size(926, 562);
            this.Controls.Add(this.pnlForgotPass);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLOGIN";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlForgotPass.ResumeLayout(false);
            this.pnlForgotPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLogin;
        private System.Windows.Forms.Label lblViewPass;
        private Guna.UI2.WinForms.Guna2CustomCheckBox cboxViewPass;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblLogin;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnForgotPass;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlForgotPass;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private System.Windows.Forms.Label lblForgotPass;
        private Guna.UI2.WinForms.Guna2Button btnForgotPass1;
        private Guna.UI2.WinForms.Guna2Button btnLogin1;
        private Guna.UI2.WinForms.Guna2TextBox txtForgotPass;
        private System.Windows.Forms.Label label5;
    }
}