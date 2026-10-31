namespace QLBanQuanAo
{
    partial class frmSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFullName = new ReaLTaiizor.DungeonTextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dungeonTextBox1 = new ReaLTaiizor.DungeonTextBox();
            this.dungeonTextBox2 = new ReaLTaiizor.DungeonTextBox();
            this.dungeonTextBox3 = new ReaLTaiizor.DungeonTextBox();
            this.dungeonTextBox4 = new ReaLTaiizor.DungeonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.foxLinkLabel1 = new ReaLTaiizor.FoxLinkLabel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(276, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 163);
            this.panel1.TabIndex = 0;
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.Transparent;
            this.txtFullName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.EdgeColor = System.Drawing.Color.White;
            this.txtFullName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtFullName.ForeColor = System.Drawing.Color.DimGray;
            this.txtFullName.Location = new System.Drawing.Point(71, 335);
            this.txtFullName.MaxLength = 32767;
            this.txtFullName.Multiline = false;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = false;
            this.txtFullName.Size = new System.Drawing.Size(591, 33);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.UseSystemPasswordChar = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFullName.Location = new System.Drawing.Point(67, 309);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 23);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ và tên ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblEmail.Location = new System.Drawing.Point(67, 388);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(58, 23);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(67, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(67, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(67, 623);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // dungeonTextBox1
            // 
            this.dungeonTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dungeonTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dungeonTextBox1.EdgeColor = System.Drawing.Color.White;
            this.dungeonTextBox1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dungeonTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.dungeonTextBox1.Location = new System.Drawing.Point(71, 414);
            this.dungeonTextBox1.MaxLength = 32767;
            this.dungeonTextBox1.Multiline = false;
            this.dungeonTextBox1.Name = "dungeonTextBox1";
            this.dungeonTextBox1.ReadOnly = false;
            this.dungeonTextBox1.Size = new System.Drawing.Size(591, 33);
            this.dungeonTextBox1.TabIndex = 7;
            this.dungeonTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.dungeonTextBox1.UseSystemPasswordChar = false;
            this.dungeonTextBox1.TextChanged += new System.EventHandler(this.dungeonTextBox1_TextChanged);
            // 
            // dungeonTextBox2
            // 
            this.dungeonTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.dungeonTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dungeonTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dungeonTextBox2.EdgeColor = System.Drawing.Color.White;
            this.dungeonTextBox2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dungeonTextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.dungeonTextBox2.Location = new System.Drawing.Point(71, 493);
            this.dungeonTextBox2.MaxLength = 32767;
            this.dungeonTextBox2.Multiline = false;
            this.dungeonTextBox2.Name = "dungeonTextBox2";
            this.dungeonTextBox2.ReadOnly = false;
            this.dungeonTextBox2.Size = new System.Drawing.Size(591, 33);
            this.dungeonTextBox2.TabIndex = 8;
            this.dungeonTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.dungeonTextBox2.UseSystemPasswordChar = false;
            // 
            // dungeonTextBox3
            // 
            this.dungeonTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.dungeonTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dungeonTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dungeonTextBox3.EdgeColor = System.Drawing.Color.White;
            this.dungeonTextBox3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dungeonTextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.dungeonTextBox3.Location = new System.Drawing.Point(71, 570);
            this.dungeonTextBox3.MaxLength = 32767;
            this.dungeonTextBox3.Multiline = false;
            this.dungeonTextBox3.Name = "dungeonTextBox3";
            this.dungeonTextBox3.ReadOnly = false;
            this.dungeonTextBox3.Size = new System.Drawing.Size(591, 33);
            this.dungeonTextBox3.TabIndex = 9;
            this.dungeonTextBox3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.dungeonTextBox3.UseSystemPasswordChar = true;
            // 
            // dungeonTextBox4
            // 
            this.dungeonTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.dungeonTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dungeonTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dungeonTextBox4.EdgeColor = System.Drawing.Color.White;
            this.dungeonTextBox4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dungeonTextBox4.ForeColor = System.Drawing.Color.DimGray;
            this.dungeonTextBox4.Location = new System.Drawing.Point(71, 649);
            this.dungeonTextBox4.MaxLength = 32767;
            this.dungeonTextBox4.Multiline = false;
            this.dungeonTextBox4.Name = "dungeonTextBox4";
            this.dungeonTextBox4.ReadOnly = false;
            this.dungeonTextBox4.Size = new System.Drawing.Size(591, 33);
            this.dungeonTextBox4.TabIndex = 10;
            this.dungeonTextBox4.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.dungeonTextBox4.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(240, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 35);
            this.label4.TabIndex = 11;
            this.label4.Text = "FASHION STORE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(262, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Đăng ký tài khoản mới";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(246, 705);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 60);
            this.button1.TabIndex = 13;
            this.button1.Text = "ĐĂNG KÝ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // foxLinkLabel1
            // 
            this.foxLinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foxLinkLabel1.DownColor = System.Drawing.Color.White;
            this.foxLinkLabel1.EnabledCalc = true;
            this.foxLinkLabel1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.foxLinkLabel1.ForeColor = System.Drawing.Color.Silver;
            this.foxLinkLabel1.Location = new System.Drawing.Point(223, 771);
            this.foxLinkLabel1.Name = "foxLinkLabel1";
            this.foxLinkLabel1.OverColor = System.Drawing.Color.White;
            this.foxLinkLabel1.Size = new System.Drawing.Size(338, 18);
            this.foxLinkLabel1.TabIndex = 15;
            this.foxLinkLabel1.Text = "Bạn đã có tài khoản? Đăng nhập ngay";
            this.foxLinkLabel1.Click += new ReaLTaiizor.FoxBase.ButtonFoxBase.ClickEventHandler(this.foxLinkLabel1_Click);
            // 
            // frmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 845);
            this.Controls.Add(this.foxLinkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dungeonTextBox4);
            this.Controls.Add(this.dungeonTextBox3);
            this.Controls.Add(this.dungeonTextBox2);
            this.Controls.Add(this.dungeonTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSignIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.DungeonTextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.DungeonTextBox dungeonTextBox1;
        private ReaLTaiizor.DungeonTextBox dungeonTextBox2;
        private ReaLTaiizor.DungeonTextBox dungeonTextBox3;
        private ReaLTaiizor.DungeonTextBox dungeonTextBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private ReaLTaiizor.FoxLinkLabel foxLinkLabel1;
    }
}