namespace ProjectPPK
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBoxPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtBoxNomor = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblIndukerror = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblPasserror = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 768);
            this.panel2.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(12, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 43);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack.TabIndex = 13;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.lblPasserror);
            this.panel4.Controls.Add(this.lblIndukerror);
            this.panel4.Controls.Add(this.txtBoxPass);
            this.panel4.Controls.Add(this.txtBoxNomor);
            this.panel4.Controls.Add(this.btnLogin);
            this.panel4.Location = new System.Drawing.Point(398, 461);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(571, 273);
            this.panel4.TabIndex = 12;
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPass.ForeColor = System.Drawing.Color.White;
            this.txtBoxPass.HintForeColor = System.Drawing.Color.White;
            this.txtBoxPass.HintText = "Password";
            this.txtBoxPass.isPassword = false;
            this.txtBoxPass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(119)))));
            this.txtBoxPass.LineIdleColor = System.Drawing.Color.White;
            this.txtBoxPass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(119)))));
            this.txtBoxPass.LineThickness = 3;
            this.txtBoxPass.Location = new System.Drawing.Point(96, 120);
            this.txtBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(379, 33);
            this.txtBoxPass.TabIndex = 7;
            this.txtBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPass.OnValueChanged += new System.EventHandler(this.txtBoxPass_OnValueChanged);
            // 
            // txtBoxNomor
            // 
            this.txtBoxNomor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxNomor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNomor.ForeColor = System.Drawing.Color.White;
            this.txtBoxNomor.HintForeColor = System.Drawing.Color.White;
            this.txtBoxNomor.HintText = "NIS/NIP";
            this.txtBoxNomor.isPassword = false;
            this.txtBoxNomor.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(119)))));
            this.txtBoxNomor.LineIdleColor = System.Drawing.Color.White;
            this.txtBoxNomor.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(119)))));
            this.txtBoxNomor.LineThickness = 3;
            this.txtBoxNomor.Location = new System.Drawing.Point(96, 55);
            this.txtBoxNomor.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxNomor.Name = "txtBoxNomor";
            this.txtBoxNomor.Size = new System.Drawing.Size(379, 33);
            this.txtBoxNomor.TabIndex = 6;
            this.txtBoxNomor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            this.btnLogin.Activecolor = System.Drawing.Color.White;
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.ButtonText = "LOGIN";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogin.Iconimage = null;
            this.btnLogin.Iconimage_right = null;
            this.btnLogin.Iconimage_right_Selected = null;
            this.btnLogin.Iconimage_Selected = null;
            this.btnLogin.IconMarginLeft = 0;
            this.btnLogin.IconMarginRight = 0;
            this.btnLogin.IconRightVisible = true;
            this.btnLogin.IconRightZoom = 0D;
            this.btnLogin.IconVisible = true;
            this.btnLogin.IconZoom = 90D;
            this.btnLogin.IsTab = false;
            this.btnLogin.Location = new System.Drawing.Point(47, 183);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Normalcolor = System.Drawing.Color.White;
            this.btnLogin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(119)))));
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogin.selected = false;
            this.btnLogin.Size = new System.Drawing.Size(477, 74);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLogin.TextFont = new System.Drawing.Font("Humanst521 BT", 16.2F);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1308, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 43);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Location = new System.Drawing.Point(416, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 442);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(114, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 284);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Humanst521 BT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.Window;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(75, 369);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(372, 40);
            this.bunifuCustomLabel2.TabIndex = 12;
            this.bunifuCustomLabel2.Text = "BERBASIS KOMPUTER";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Humanst521 BT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.Window;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(142, 331);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(244, 40);
            this.bunifuCustomLabel1.TabIndex = 11;
            this.bunifuCustomLabel1.Text = "SISTEM UJIAN";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblIndukerror
            // 
            this.lblIndukerror.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIndukerror.AutoSize = true;
            this.lblIndukerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndukerror.ForeColor = System.Drawing.Color.White;
            this.lblIndukerror.Location = new System.Drawing.Point(482, 68);
            this.lblIndukerror.Name = "lblIndukerror";
            this.lblIndukerror.Size = new System.Drawing.Size(82, 20);
            this.lblIndukerror.TabIndex = 17;
            this.lblIndukerror.Text = "wajib diisi";
            this.lblIndukerror.Visible = false;
            // 
            // lblPasserror
            // 
            this.lblPasserror.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasserror.AutoSize = true;
            this.lblPasserror.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasserror.ForeColor = System.Drawing.Color.White;
            this.lblPasserror.Location = new System.Drawing.Point(482, 133);
            this.lblPasserror.Name = "lblPasserror";
            this.lblPasserror.Size = new System.Drawing.Size(82, 20);
            this.lblPasserror.TabIndex = 18;
            this.lblPasserror.Text = "wajib diisi";
            this.lblPasserror.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtBoxPass;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtBoxNomor;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogin;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox btnBack;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPasserror;
        private Bunifu.Framework.UI.BunifuCustomLabel lblIndukerror;
    }
}