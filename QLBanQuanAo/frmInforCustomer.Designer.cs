namespace QLBanQuanAo
{
    partial class frmInforCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInforCustomer));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlPersonalInfo = new System.Windows.Forms.Panel();
            this.lblPersonalSection = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblCreatedAtValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblEmailStatus = new System.Windows.Forms.Label();
            this.lblEmailStatusValue = new System.Windows.Forms.Label();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.lblAddressSection = new System.Windows.Forms.Label();
            this.lblRecipientName = new System.Windows.Forms.Label();
            this.txtRecipientName = new System.Windows.Forms.TextBox();
            this.lblAddressPhone = new System.Windows.Forms.Label();
            this.txtAddressPhone = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.txtWard = new System.Windows.Forms.TextBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblFooterNote = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPersonalInfo.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 92);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(35, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // pnlPersonalInfo
            // 
            this.pnlPersonalInfo.BackColor = System.Drawing.Color.White;
            this.pnlPersonalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPersonalInfo.Controls.Add(this.lblPersonalSection);
            this.pnlPersonalInfo.Controls.Add(this.lblCustomerId);
            this.pnlPersonalInfo.Controls.Add(this.txtCustomerId);
            this.pnlPersonalInfo.Controls.Add(this.lblFullName);
            this.pnlPersonalInfo.Controls.Add(this.txtFullName);
            this.pnlPersonalInfo.Controls.Add(this.lblEmail);
            this.pnlPersonalInfo.Controls.Add(this.txtEmail);
            this.pnlPersonalInfo.Controls.Add(this.lblPhone);
            this.pnlPersonalInfo.Controls.Add(this.txtPhone);
            this.pnlPersonalInfo.Controls.Add(this.lblCreatedAt);
            this.pnlPersonalInfo.Controls.Add(this.lblCreatedAtValue);
            this.pnlPersonalInfo.Controls.Add(this.lblStatus);
            this.pnlPersonalInfo.Controls.Add(this.lblStatusValue);
            this.pnlPersonalInfo.Controls.Add(this.lblEmailStatus);
            this.pnlPersonalInfo.Controls.Add(this.lblEmailStatusValue);
            this.pnlPersonalInfo.Location = new System.Drawing.Point(42, 112);
            this.pnlPersonalInfo.Name = "pnlPersonalInfo";
            this.pnlPersonalInfo.Size = new System.Drawing.Size(956, 212);
            this.pnlPersonalInfo.TabIndex = 1;
            // 
            // lblPersonalSection
            // 
            this.lblPersonalSection.AutoSize = true;
            this.lblPersonalSection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPersonalSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblPersonalSection.Location = new System.Drawing.Point(21, 12);
            this.lblPersonalSection.Name = "lblPersonalSection";
            this.lblPersonalSection.Size = new System.Drawing.Size(167, 25);
            this.lblPersonalSection.TabIndex = 0;
            this.lblPersonalSection.Text = "Thông tin cá nhân";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomerId.Location = new System.Drawing.Point(24, 52);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(78, 15);
            this.lblCustomerId.TabIndex = 1;
            this.lblCustomerId.Text = "Mã tài khoản";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.txtCustomerId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerId.Location = new System.Drawing.Point(25, 73);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(125, 25);
            this.txtCustomerId.TabIndex = 2;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Location = new System.Drawing.Point(174, 52);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(69, 15);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Họ và tên *";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(175, 73);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(325, 25);
            this.txtFullName.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(524, 52);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 15);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(525, 73);
            this.txtEmail.MaxLength = 254;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 25);
            this.txtEmail.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(24, 119);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(80, 15);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(25, 140);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(225, 25);
            this.txtPhone.TabIndex = 2;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedAt.Location = new System.Drawing.Point(282, 119);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(86, 15);
            this.lblCreatedAt.TabIndex = 9;
            this.lblCreatedAt.Text = "Ngày tham gia";
            // 
            // lblCreatedAtValue
            // 
            this.lblCreatedAtValue.AutoSize = true;
            this.lblCreatedAtValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCreatedAtValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(78)))));
            this.lblCreatedAtValue.Location = new System.Drawing.Point(282, 143);
            this.lblCreatedAtValue.Name = "lblCreatedAtValue";
            this.lblCreatedAtValue.Size = new System.Drawing.Size(67, 19);
            this.lblCreatedAtValue.TabIndex = 10;
            this.lblCreatedAtValue.Text = "--/--/----";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(500, 119);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 15);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Trạng thái";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(140)))), ((int)(((byte)(85)))));
            this.lblStatusValue.Location = new System.Drawing.Point(500, 143);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(117, 19);
            this.lblStatusValue.TabIndex = 12;
            this.lblStatusValue.Text = "Đang hoạt động";
            // 
            // lblEmailStatus
            // 
            this.lblEmailStatus.AutoSize = true;
            this.lblEmailStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmailStatus.Location = new System.Drawing.Point(700, 119);
            this.lblEmailStatus.Name = "lblEmailStatus";
            this.lblEmailStatus.Size = new System.Drawing.Size(91, 15);
            this.lblEmailStatus.TabIndex = 13;
            this.lblEmailStatus.Text = "Xác minh email";
            // 
            // lblEmailStatusValue
            // 
            this.lblEmailStatusValue.AutoSize = true;
            this.lblEmailStatusValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblEmailStatusValue.Location = new System.Drawing.Point(700, 143);
            this.lblEmailStatusValue.Name = "lblEmailStatusValue";
            this.lblEmailStatusValue.Size = new System.Drawing.Size(99, 19);
            this.lblEmailStatusValue.TabIndex = 14;
            this.lblEmailStatusValue.Text = "Chưa xác minh";
            // 
            // pnlAddress
            // 
            this.pnlAddress.BackColor = System.Drawing.Color.White;
            this.pnlAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddress.Controls.Add(this.lblAddressSection);
            this.pnlAddress.Controls.Add(this.lblRecipientName);
            this.pnlAddress.Controls.Add(this.txtRecipientName);
            this.pnlAddress.Controls.Add(this.lblAddressPhone);
            this.pnlAddress.Controls.Add(this.txtAddressPhone);
            this.pnlAddress.Controls.Add(this.lblStreet);
            this.pnlAddress.Controls.Add(this.txtStreet);
            this.pnlAddress.Controls.Add(this.lblWard);
            this.pnlAddress.Controls.Add(this.txtWard);
            this.pnlAddress.Controls.Add(this.lblDistrict);
            this.pnlAddress.Controls.Add(this.txtDistrict);
            this.pnlAddress.Controls.Add(this.lblCity);
            this.pnlAddress.Controls.Add(this.txtCity);
            this.pnlAddress.Controls.Add(this.lblPostalCode);
            this.pnlAddress.Controls.Add(this.txtPostalCode);
            this.pnlAddress.Location = new System.Drawing.Point(42, 338);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(956, 252);
            this.pnlAddress.TabIndex = 2;
            // 
            // lblAddressSection
            // 
            this.lblAddressSection.AutoSize = true;
            this.lblAddressSection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAddressSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblAddressSection.Location = new System.Drawing.Point(21, 10);
            this.lblAddressSection.Name = "lblAddressSection";
            this.lblAddressSection.Size = new System.Drawing.Size(249, 25);
            this.lblAddressSection.TabIndex = 0;
            this.lblAddressSection.Text = "Địa chỉ nhận hàng mặc định";
            // 
            // lblRecipientName
            // 
            this.lblRecipientName.AutoSize = true;
            this.lblRecipientName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecipientName.Location = new System.Drawing.Point(24, 65);
            this.lblRecipientName.Name = "lblRecipientName";
            this.lblRecipientName.Size = new System.Drawing.Size(101, 15);
            this.lblRecipientName.TabIndex = 2;
            this.lblRecipientName.Text = "Tên người nhận *";
            // 
            // txtRecipientName
            // 
            this.txtRecipientName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecipientName.Location = new System.Drawing.Point(25, 86);
            this.txtRecipientName.MaxLength = 100;
            this.txtRecipientName.Name = "txtRecipientName";
            this.txtRecipientName.Size = new System.Drawing.Size(435, 25);
            this.txtRecipientName.TabIndex = 3;
            // 
            // lblAddressPhone
            // 
            this.lblAddressPhone.AutoSize = true;
            this.lblAddressPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddressPhone.Location = new System.Drawing.Point(484, 65);
            this.lblAddressPhone.Name = "lblAddressPhone";
            this.lblAddressPhone.Size = new System.Drawing.Size(104, 15);
            this.lblAddressPhone.TabIndex = 4;
            this.lblAddressPhone.Text = "SĐT người nhận *";
            // 
            // txtAddressPhone
            // 
            this.txtAddressPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddressPhone.Location = new System.Drawing.Point(485, 86);
            this.txtAddressPhone.MaxLength = 20;
            this.txtAddressPhone.Name = "txtAddressPhone";
            this.txtAddressPhone.Size = new System.Drawing.Size(440, 25);
            this.txtAddressPhone.TabIndex = 4;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStreet.Location = new System.Drawing.Point(24, 119);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(133, 15);
            this.lblStreet.TabIndex = 5;
            this.lblStreet.Text = "Địa chỉ đường/số nhà *";
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStreet.Location = new System.Drawing.Point(25, 140);
            this.txtStreet.MaxLength = 200;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(900, 25);
            this.txtStreet.TabIndex = 5;
            // 
            // lblWard
            // 
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWard.Location = new System.Drawing.Point(24, 174);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(69, 15);
            this.lblWard.TabIndex = 6;
            this.lblWard.Text = "Phường/xã";
            // 
            // txtWard
            // 
            this.txtWard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWard.Location = new System.Drawing.Point(25, 195);
            this.txtWard.MaxLength = 100;
            this.txtWard.Name = "txtWard";
            this.txtWard.Size = new System.Drawing.Size(190, 25);
            this.txtWard.TabIndex = 6;
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDistrict.Location = new System.Drawing.Point(236, 174);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(75, 15);
            this.lblDistrict.TabIndex = 7;
            this.lblDistrict.Text = "Quận/huyện";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDistrict.Location = new System.Drawing.Point(237, 195);
            this.txtDistrict.MaxLength = 100;
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(190, 25);
            this.txtDistrict.TabIndex = 7;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCity.Location = new System.Drawing.Point(448, 174);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(100, 15);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "Tỉnh/thành phố *";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCity.Location = new System.Drawing.Point(449, 195);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(275, 25);
            this.txtCity.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPostalCode.Location = new System.Drawing.Point(745, 174);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(82, 15);
            this.lblPostalCode.TabIndex = 9;
            this.lblPostalCode.Text = "Mã bưu chính";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPostalCode.Location = new System.Drawing.Point(746, 195);
            this.txtPostalCode.MaxLength = 20;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(179, 25);
            this.txtPostalCode.TabIndex = 9;
            // 
            // lblFooterNote
            // 
            this.lblFooterNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooterNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblFooterNote.Location = new System.Drawing.Point(44, 604);
            this.lblFooterNote.Name = "lblFooterNote";
            this.lblFooterNote.Size = new System.Drawing.Size(520, 46);
            this.lblFooterNote.TabIndex = 3;
            this.lblFooterNote.Text = "Thông tin địa chỉ được lưu tại sổ địa chỉ của tài khoản. Đơn hàng đã đặt vẫn giữ " +
    "nguyên địa chỉ tại thời điểm mua.";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(54)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(602, 608);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 42);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(54)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(54)))));
            this.btnReset.Location = new System.Drawing.Point(753, 608);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 42);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(68)))));
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(874, 608);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 42);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmInforCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(1040, 844);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFooterNote);
            this.Controls.Add(this.pnlAddress);
            this.Controls.Add(this.pnlPersonalInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInforCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hồ sơ khách hàng - FASHION STORE";
            this.Load += new System.EventHandler(this.frmInforCustomer_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPersonalInfo.ResumeLayout(false);
            this.pnlPersonalInfo.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlPersonalInfo;
        private System.Windows.Forms.Label lblPersonalSection;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblCreatedAtValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblEmailStatus;
        private System.Windows.Forms.Label lblEmailStatusValue;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.Label lblAddressSection;
        private System.Windows.Forms.Label lblRecipientName;
        private System.Windows.Forms.TextBox txtRecipientName;
        private System.Windows.Forms.Label lblAddressPhone;
        private System.Windows.Forms.TextBox txtAddressPhone;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.TextBox txtWard;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblFooterNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
    }
}
