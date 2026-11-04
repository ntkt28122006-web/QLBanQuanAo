namespace QLBanQuanAo
{
    partial class frmFogotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFogotPassword));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.txtEmail = new ReaLTaiizor.DungeonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ptx1 = new System.Windows.Forms.PictureBox();
            this.pnlOTP = new System.Windows.Forms.Panel();
            this.lnkResendOTP = new ReaLTaiizor.FoxLinkLabel();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.txtOTP = new ReaLTaiizor.DungeonTextBox();
            this.lblOTP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptb2 = new System.Windows.Forms.PictureBox();
            this.pnlNewPassword = new System.Windows.Forms.Panel();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new ReaLTaiizor.DungeonTextBox();
            this.txtNewPassword = new ReaLTaiizor.DungeonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lnkBackToLogin = new ReaLTaiizor.FoxLinkLabel();
            this.pnlTitle.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptx1)).BeginInit();
            this.pnlOTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb2)).BeginInit();
            this.pnlNewPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Silver;
            this.pnlTitle.Controls.Add(this.label3);
            this.pnlTitle.Controls.Add(this.label2);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(542, 141);
            this.pnlTitle.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label3.Location = new System.Drawing.Point(136, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Làm theo các bước để đặt lại mật khẩu ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label2.Location = new System.Drawing.Point(197, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quên mật khẩu ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label1.Location = new System.Drawing.Point(160, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "FASHION STORE";
            // 
            // pnlEmail
            // 
            this.pnlEmail.Controls.Add(this.lblEmail);
            this.pnlEmail.Controls.Add(this.btnSendOTP);
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.label4);
            this.pnlEmail.Controls.Add(this.ptx1);
            this.pnlEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmail.Location = new System.Drawing.Point(0, 0);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(542, 247);
            this.pnlEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblEmail.Location = new System.Drawing.Point(64, 33);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(190, 24);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Xác minh tài khoản";
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BackColor = System.Drawing.Color.Black;
            this.btnSendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOTP.ForeColor = System.Drawing.Color.LightGray;
            this.btnSendOTP.Location = new System.Drawing.Point(28, 163);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(487, 41);
            this.btnSendOTP.TabIndex = 4;
            this.btnSendOTP.Text = "Gửi mã OTP";
            this.btnSendOTP.UseVisualStyleBackColor = false;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.EdgeColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(28, 105);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(487, 31);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(24, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhập email đã đăng ký tài khoản";
            // 
            // ptx1
            // 
            this.ptx1.Image = ((System.Drawing.Image)(resources.GetObject("ptx1.Image")));
            this.ptx1.Location = new System.Drawing.Point(28, 25);
            this.ptx1.Name = "ptx1";
            this.ptx1.Size = new System.Drawing.Size(30, 32);
            this.ptx1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptx1.TabIndex = 1;
            this.ptx1.TabStop = false;
            // 
            // pnlOTP
            // 
            this.pnlOTP.Controls.Add(this.lnkResendOTP);
            this.pnlOTP.Controls.Add(this.btnVerifyOTP);
            this.pnlOTP.Controls.Add(this.txtOTP);
            this.pnlOTP.Controls.Add(this.lblOTP);
            this.pnlOTP.Controls.Add(this.label5);
            this.pnlOTP.Controls.Add(this.ptb2);
            this.pnlOTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOTP.Location = new System.Drawing.Point(0, 0);
            this.pnlOTP.Name = "pnlOTP";
            this.pnlOTP.Size = new System.Drawing.Size(542, 247);
            this.pnlOTP.TabIndex = 5;
            this.pnlOTP.Visible = false;
            // 
            // lnkResendOTP
            // 
            this.lnkResendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkResendOTP.DownColor = System.Drawing.Color.White;
            this.lnkResendOTP.EnabledCalc = true;
            this.lnkResendOTP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lnkResendOTP.ForeColor = System.Drawing.Color.White;
            this.lnkResendOTP.Location = new System.Drawing.Point(402, 144);
            this.lnkResendOTP.Name = "lnkResendOTP";
            this.lnkResendOTP.OverColor = System.Drawing.Color.White;
            this.lnkResendOTP.Size = new System.Drawing.Size(113, 18);
            this.lnkResendOTP.TabIndex = 6;
            this.lnkResendOTP.Text = "Gửi lại mã OTP";
            this.lnkResendOTP.Click += new ReaLTaiizor.FoxBase.ButtonFoxBase.ClickEventHandler(this.lnkResendOTP_Click);
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.BackColor = System.Drawing.Color.Black;
            this.btnVerifyOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerifyOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyOTP.ForeColor = System.Drawing.Color.LightGray;
            this.btnVerifyOTP.Location = new System.Drawing.Point(28, 183);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(487, 41);
            this.btnVerifyOTP.TabIndex = 5;
            this.btnVerifyOTP.Text = "Xác minh OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = false;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.BackColor = System.Drawing.Color.Transparent;
            this.txtOTP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.EdgeColor = System.Drawing.Color.White;
            this.txtOTP.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtOTP.ForeColor = System.Drawing.Color.DimGray;
            this.txtOTP.Location = new System.Drawing.Point(28, 105);
            this.txtOTP.MaxLength = 32767;
            this.txtOTP.Multiline = false;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.ReadOnly = false;
            this.txtOTP.Size = new System.Drawing.Size(487, 31);
            this.txtOTP.TabIndex = 4;
            this.txtOTP.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOTP.UseSystemPasswordChar = false;
            // 
            // lblOTP
            // 
            this.lblOTP.AutoSize = true;
            this.lblOTP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOTP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOTP.Location = new System.Drawing.Point(64, 37);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(145, 24);
            this.lblOTP.TabIndex = 3;
            this.lblOTP.Text = "Xác minh OTP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(24, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mã xác minh đã được gửi đến email";
            // 
            // ptb2
            // 
            this.ptb2.Image = ((System.Drawing.Image)(resources.GetObject("ptb2.Image")));
            this.ptb2.Location = new System.Drawing.Point(28, 30);
            this.ptb2.Name = "ptb2";
            this.ptb2.Size = new System.Drawing.Size(30, 32);
            this.ptb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb2.TabIndex = 0;
            this.ptb2.TabStop = false;
            // 
            // pnlNewPassword
            // 
            this.pnlNewPassword.Controls.Add(this.btnResetPassword);
            this.pnlNewPassword.Controls.Add(this.label6);
            this.pnlNewPassword.Controls.Add(this.label8);
            this.pnlNewPassword.Controls.Add(this.txtConfirmPassword);
            this.pnlNewPassword.Controls.Add(this.txtNewPassword);
            this.pnlNewPassword.Controls.Add(this.label7);
            this.pnlNewPassword.Controls.Add(this.pictureBox1);
            this.pnlNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNewPassword.Location = new System.Drawing.Point(0, 0);
            this.pnlNewPassword.Name = "pnlNewPassword";
            this.pnlNewPassword.Size = new System.Drawing.Size(542, 247);
            this.pnlNewPassword.TabIndex = 7;
            this.pnlNewPassword.Visible = false;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.Black;
            this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.ForeColor = System.Drawing.Color.LightGray;
            this.btnResetPassword.Location = new System.Drawing.Point(28, 203);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(487, 41);
            this.btnResetPassword.TabIndex = 9;
            this.btnResetPassword.Text = "Đặt lại mật khẩu ";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(24, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mật khẩu mới ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(24, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mật khẩu mới ";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.EdgeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmPassword.Location = new System.Drawing.Point(28, 156);
            this.txtConfirmPassword.MaxLength = 32767;
            this.txtConfirmPassword.Multiline = false;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.ReadOnly = false;
            this.txtConfirmPassword.Size = new System.Drawing.Size(487, 31);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.EdgeColor = System.Drawing.Color.White;
            this.txtNewPassword.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtNewPassword.Location = new System.Drawing.Point(28, 83);
            this.txtNewPassword.MaxLength = 32767;
            this.txtNewPassword.Multiline = false;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.ReadOnly = false;
            this.txtNewPassword.Size = new System.Drawing.Size(487, 31);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(64, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Đặt mật khẩu mới";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlMain.Controls.Add(this.pnlNewPassword);
            this.pnlMain.Controls.Add(this.pnlOTP);
            this.pnlMain.Controls.Add(this.pnlEmail);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 141);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(542, 247);
            this.pnlMain.TabIndex = 7;
            // 
            // lnkBackToLogin
            // 
            this.lnkBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBackToLogin.DownColor = System.Drawing.Color.White;
            this.lnkBackToLogin.EnabledCalc = true;
            this.lnkBackToLogin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lnkBackToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lnkBackToLogin.Location = new System.Drawing.Point(187, 394);
            this.lnkBackToLogin.Name = "lnkBackToLogin";
            this.lnkBackToLogin.OverColor = System.Drawing.Color.White;
            this.lnkBackToLogin.Size = new System.Drawing.Size(223, 18);
            this.lnkBackToLogin.TabIndex = 8;
            this.lnkBackToLogin.Text = "← Quay lại trang đăng nhập";
            this.lnkBackToLogin.Click += new ReaLTaiizor.FoxBase.ButtonFoxBase.ClickEventHandler(this.lnkBackToLogin_Click);
            // 
            // frmFogotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(542, 449);
            this.Controls.Add(this.lnkBackToLogin);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFogotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptx1)).EndInit();
            this.pnlOTP.ResumeLayout(false);
            this.pnlOTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb2)).EndInit();
            this.pnlNewPassword.ResumeLayout(false);
            this.pnlNewPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox ptx1;
        private System.Windows.Forms.Button btnSendOTP;
        private ReaLTaiizor.DungeonTextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlOTP;
        private System.Windows.Forms.PictureBox ptb2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOTP;
        private ReaLTaiizor.FoxLinkLabel lnkResendOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
        private ReaLTaiizor.DungeonTextBox txtOTP;
        private System.Windows.Forms.Panel pnlNewPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.DungeonTextBox txtConfirmPassword;
        private ReaLTaiizor.DungeonTextBox txtNewPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnResetPassword;
        private ReaLTaiizor.FoxLinkLabel lnkBackToLogin;
    }
}