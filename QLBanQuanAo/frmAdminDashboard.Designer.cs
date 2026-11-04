namespace QLBanQuanAo
{
    partial class frmAdminDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminDashboard));
            this.pnlDashboardHeader = new System.Windows.Forms.Panel();
            this.lblDashboardDescription = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.pnlCustomerToolbar = new System.Windows.Forms.Panel();
            this.btnRefreshCustomer = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.cboFilterCustomerStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterCustomerStatus = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.lblSearchCustomer = new System.Windows.Forms.Label();
            this.pnlCustomerList = new System.Windows.Forms.Panel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomerListTitle = new System.Windows.Forms.Label();
            this.pnlCustomerDetail = new System.Windows.Forms.Panel();
            this.btnUnlockCustomer = new System.Windows.Forms.Button();
            this.btnLockCustomer = new System.Windows.Forms.Button();
            this.lblCustomerStatus = new System.Windows.Forms.Label();
            this.txtDetailCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtDetailCustomerEmail = new System.Windows.Forms.TextBox();
            this.lblDetailCustomerEmail = new System.Windows.Forms.Label();
            this.lblDetailCustomerPhone = new System.Windows.Forms.Label();
            this.txtDetailCustomerName = new System.Windows.Forms.TextBox();
            this.lblDetailCustomerName = new System.Windows.Forms.Label();
            this.txtDetailCustomerId = new System.Windows.Forms.TextBox();
            this.lblDetailCustomerId = new System.Windows.Forms.Label();
            this.lblCustomerDetailTitle = new System.Windows.Forms.Label();
            this.pnlDashboardHeader.SuspendLayout();
            this.pnlCustomerToolbar.SuspendLayout();
            this.pnlCustomerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlCustomerDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDashboardHeader
            // 
            this.pnlDashboardHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlDashboardHeader.Controls.Add(this.lblDashboardDescription);
            this.pnlDashboardHeader.Controls.Add(this.lblDashboardTitle);
            this.pnlDashboardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboardHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboardHeader.Name = "pnlDashboardHeader";
            this.pnlDashboardHeader.Size = new System.Drawing.Size(1221, 80);
            this.pnlDashboardHeader.TabIndex = 0;
            // 
            // lblDashboardDescription
            // 
            this.lblDashboardDescription.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDashboardDescription.Location = new System.Drawing.Point(47, 49);
            this.lblDashboardDescription.Name = "lblDashboardDescription";
            this.lblDashboardDescription.Size = new System.Drawing.Size(650, 31);
            this.lblDashboardDescription.TabIndex = 2;
            this.lblDashboardDescription.Text = "Quản lý thông tin và trạng thái tài khoản khách hàng";
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashboardTitle.Location = new System.Drawing.Point(29, 0);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(437, 58);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "QUẢN LÝ TÀI KHOẢN";
            this.lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCustomerToolbar
            // 
            this.pnlCustomerToolbar.BackColor = System.Drawing.Color.White;
            this.pnlCustomerToolbar.Controls.Add(this.btnRefreshCustomer);
            this.pnlCustomerToolbar.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerToolbar.Controls.Add(this.cboFilterCustomerStatus);
            this.pnlCustomerToolbar.Controls.Add(this.lblFilterCustomerStatus);
            this.pnlCustomerToolbar.Controls.Add(this.txtSearchCustomer);
            this.pnlCustomerToolbar.Controls.Add(this.lblSearchCustomer);
            this.pnlCustomerToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerToolbar.Location = new System.Drawing.Point(0, 80);
            this.pnlCustomerToolbar.Name = "pnlCustomerToolbar";
            this.pnlCustomerToolbar.Size = new System.Drawing.Size(1221, 105);
            this.pnlCustomerToolbar.TabIndex = 1;
            // 
            // btnRefreshCustomer
            // 
            this.btnRefreshCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCustomer.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRefreshCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshCustomer.FlatAppearance.BorderSize = 0;
            this.btnRefreshCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshCustomer.Location = new System.Drawing.Point(1099, 45);
            this.btnRefreshCustomer.Name = "btnRefreshCustomer";
            this.btnRefreshCustomer.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshCustomer.TabIndex = 3;
            this.btnRefreshCustomer.Text = "Làm mới";
            this.btnRefreshCustomer.UseVisualStyleBackColor = false;
            this.btnRefreshCustomer.Click += new System.EventHandler(this.btnRefreshCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Red;
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnSearchCustomer.Location = new System.Drawing.Point(963, 45);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(110, 35);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "Tìm kiếm";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // cboFilterCustomerStatus
            // 
            this.cboFilterCustomerStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCustomerStatus.FormattingEnabled = true;
            this.cboFilterCustomerStatus.Location = new System.Drawing.Point(338, 62);
            this.cboFilterCustomerStatus.Name = "cboFilterCustomerStatus";
            this.cboFilterCustomerStatus.Size = new System.Drawing.Size(350, 33);
            this.cboFilterCustomerStatus.TabIndex = 1;
            this.cboFilterCustomerStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterCustomerStatus_SelectedIndexChanged);
            // 
            // lblFilterCustomerStatus
            // 
            this.lblFilterCustomerStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterCustomerStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblFilterCustomerStatus.Location = new System.Drawing.Point(103, 59);
            this.lblFilterCustomerStatus.Name = "lblFilterCustomerStatus";
            this.lblFilterCustomerStatus.Size = new System.Drawing.Size(200, 30);
            this.lblFilterCustomerStatus.TabIndex = 2;
            this.lblFilterCustomerStatus.Text = "\tTrạng thái tài khoản";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(338, 28);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(350, 31);
            this.txtSearchCustomer.TabIndex = 0;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // lblSearchCustomer
            // 
            this.lblSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCustomer.ForeColor = System.Drawing.Color.DimGray;
            this.lblSearchCustomer.Location = new System.Drawing.Point(103, 28);
            this.lblSearchCustomer.Name = "lblSearchCustomer";
            this.lblSearchCustomer.Size = new System.Drawing.Size(250, 31);
            this.lblSearchCustomer.TabIndex = 1;
            this.lblSearchCustomer.Text = "Tìm kiếm khách hàng";
            // 
            // pnlCustomerList
            // 
            this.pnlCustomerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomerList.BackColor = System.Drawing.Color.White;
            this.pnlCustomerList.Controls.Add(this.dgvCustomers);
            this.pnlCustomerList.Controls.Add(this.lblCustomerListTitle);
            this.pnlCustomerList.Location = new System.Drawing.Point(0, 185);
            this.pnlCustomerList.Name = "pnlCustomerList";
            this.pnlCustomerList.Size = new System.Drawing.Size(1312, 274);
            this.pnlCustomerList.TabIndex = 2;
            this.pnlCustomerList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCustomerList_Paint);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeight = 40;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerId,
            this.colCustomerName,
            this.colCustomerEmail,
            this.colCustomerPhone,
            this.colCustomerStatus,
            this.colCustomerCreated});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 41);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowHeadersWidth = 62;
            this.dgvCustomers.RowTemplate.Height = 28;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1309, 335);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellContentClick);
            // 
            // colCustomerId
            // 
            this.colCustomerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerId.DataPropertyName = "id";
            this.colCustomerId.HeaderText = "Mã KH";
            this.colCustomerId.MinimumWidth = 8;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerName.DataPropertyName = "full_name";
            this.colCustomerName.HeaderText = "Họ và tên";
            this.colCustomerName.MinimumWidth = 8;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colCustomerEmail
            // 
            this.colCustomerEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerEmail.DataPropertyName = "email";
            this.colCustomerEmail.HeaderText = "Email";
            this.colCustomerEmail.MinimumWidth = 8;
            this.colCustomerEmail.Name = "colCustomerEmail";
            this.colCustomerEmail.ReadOnly = true;
            // 
            // colCustomerPhone
            // 
            this.colCustomerPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerPhone.DataPropertyName = "phone";
            this.colCustomerPhone.HeaderText = "SĐT";
            this.colCustomerPhone.MinimumWidth = 8;
            this.colCustomerPhone.Name = "colCustomerPhone";
            this.colCustomerPhone.ReadOnly = true;
            // 
            // colCustomerStatus
            // 
            this.colCustomerStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerStatus.DataPropertyName = "status";
            this.colCustomerStatus.HeaderText = "Trạng thái";
            this.colCustomerStatus.MinimumWidth = 8;
            this.colCustomerStatus.Name = "colCustomerStatus";
            this.colCustomerStatus.ReadOnly = true;
            // 
            // colCustomerCreated
            // 
            this.colCustomerCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomerCreated.DataPropertyName = "created_at";
            this.colCustomerCreated.HeaderText = "Ngày tạo tài khoản";
            this.colCustomerCreated.MinimumWidth = 8;
            this.colCustomerCreated.Name = "colCustomerCreated";
            this.colCustomerCreated.ReadOnly = true;
            // 
            // lblCustomerListTitle
            // 
            this.lblCustomerListTitle.Location = new System.Drawing.Point(25, 10);
            this.lblCustomerListTitle.Name = "lblCustomerListTitle";
            this.lblCustomerListTitle.Size = new System.Drawing.Size(400, 28);
            this.lblCustomerListTitle.TabIndex = 0;
            this.lblCustomerListTitle.Text = "\tTHÔNG TIN TÀI KHOẢN KHÁCH HÀNG";
            // 
            // pnlCustomerDetail
            // 
            this.pnlCustomerDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomerDetail.Controls.Add(this.btnUnlockCustomer);
            this.pnlCustomerDetail.Controls.Add(this.btnLockCustomer);
            this.pnlCustomerDetail.Controls.Add(this.lblCustomerStatus);
            this.pnlCustomerDetail.Controls.Add(this.txtDetailCustomerPhone);
            this.pnlCustomerDetail.Controls.Add(this.txtDetailCustomerEmail);
            this.pnlCustomerDetail.Controls.Add(this.lblDetailCustomerEmail);
            this.pnlCustomerDetail.Controls.Add(this.lblDetailCustomerPhone);
            this.pnlCustomerDetail.Controls.Add(this.txtDetailCustomerName);
            this.pnlCustomerDetail.Controls.Add(this.lblDetailCustomerName);
            this.pnlCustomerDetail.Controls.Add(this.txtDetailCustomerId);
            this.pnlCustomerDetail.Controls.Add(this.lblDetailCustomerId);
            this.pnlCustomerDetail.Controls.Add(this.lblCustomerDetailTitle);
            this.pnlCustomerDetail.Location = new System.Drawing.Point(0, 465);
            this.pnlCustomerDetail.Name = "pnlCustomerDetail";
            this.pnlCustomerDetail.Size = new System.Drawing.Size(1309, 201);
            this.pnlCustomerDetail.TabIndex = 2;
            this.pnlCustomerDetail.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCustomerDetail_Paint);
            // 
            // btnUnlockCustomer
            // 
            this.btnUnlockCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnlockCustomer.BackColor = System.Drawing.Color.Lime;
            this.btnUnlockCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnlockCustomer.FlatAppearance.BorderSize = 0;
            this.btnUnlockCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlockCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlockCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnUnlockCustomer.Location = new System.Drawing.Point(996, 97);
            this.btnUnlockCustomer.Name = "btnUnlockCustomer";
            this.btnUnlockCustomer.Size = new System.Drawing.Size(182, 38);
            this.btnUnlockCustomer.TabIndex = 11;
            this.btnUnlockCustomer.Text = "Mở khóa tài khoản";
            this.btnUnlockCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlockCustomer.UseVisualStyleBackColor = false;
            this.btnUnlockCustomer.Click += new System.EventHandler(this.btnUnlockCustomer_Click);
            // 
            // btnLockCustomer
            // 
            this.btnLockCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLockCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLockCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockCustomer.FlatAppearance.BorderSize = 0;
            this.btnLockCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockCustomer.ForeColor = System.Drawing.Color.White;
            this.btnLockCustomer.Location = new System.Drawing.Point(742, 97);
            this.btnLockCustomer.Name = "btnLockCustomer";
            this.btnLockCustomer.Size = new System.Drawing.Size(162, 38);
            this.btnLockCustomer.TabIndex = 10;
            this.btnLockCustomer.Text = "Khóa tài khoản";
            this.btnLockCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLockCustomer.UseVisualStyleBackColor = false;
            this.btnLockCustomer.Click += new System.EventHandler(this.btnLockCustomer_Click);
            // 
            // lblCustomerStatus
            // 
            this.lblCustomerStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblCustomerStatus.Location = new System.Drawing.Point(647, 43);
            this.lblCustomerStatus.Name = "lblCustomerStatus";
            this.lblCustomerStatus.Size = new System.Drawing.Size(316, 31);
            this.lblCustomerStatus.TabIndex = 9;
            this.lblCustomerStatus.Text = "Trạng thái: Chưa chọn tài khoản";
            // 
            // txtDetailCustomerPhone
            // 
            this.txtDetailCustomerPhone.Location = new System.Drawing.Point(304, 152);
            this.txtDetailCustomerPhone.Name = "txtDetailCustomerPhone";
            this.txtDetailCustomerPhone.ReadOnly = true;
            this.txtDetailCustomerPhone.Size = new System.Drawing.Size(220, 31);
            this.txtDetailCustomerPhone.TabIndex = 8;
            // 
            // txtDetailCustomerEmail
            // 
            this.txtDetailCustomerEmail.Location = new System.Drawing.Point(304, 83);
            this.txtDetailCustomerEmail.Name = "txtDetailCustomerEmail";
            this.txtDetailCustomerEmail.ReadOnly = true;
            this.txtDetailCustomerEmail.Size = new System.Drawing.Size(220, 31);
            this.txtDetailCustomerEmail.TabIndex = 7;
            this.txtDetailCustomerEmail.TextChanged += new System.EventHandler(this.txtDetailCustomerEmail_TextChanged);
            // 
            // lblDetailCustomerEmail
            // 
            this.lblDetailCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailCustomerEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetailCustomerEmail.Location = new System.Drawing.Point(301, 43);
            this.lblDetailCustomerEmail.Name = "lblDetailCustomerEmail";
            this.lblDetailCustomerEmail.Size = new System.Drawing.Size(200, 31);
            this.lblDetailCustomerEmail.TabIndex = 6;
            this.lblDetailCustomerEmail.Text = "Email";
            // 
            // lblDetailCustomerPhone
            // 
            this.lblDetailCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailCustomerPhone.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetailCustomerPhone.Location = new System.Drawing.Point(301, 117);
            this.lblDetailCustomerPhone.Name = "lblDetailCustomerPhone";
            this.lblDetailCustomerPhone.Size = new System.Drawing.Size(200, 31);
            this.lblDetailCustomerPhone.TabIndex = 5;
            this.lblDetailCustomerPhone.Text = "SĐT";
            this.lblDetailCustomerPhone.Click += new System.EventHandler(this.lblDetailCustomerPhone_Click);
            // 
            // txtDetailCustomerName
            // 
            this.txtDetailCustomerName.Location = new System.Drawing.Point(30, 151);
            this.txtDetailCustomerName.Name = "txtDetailCustomerName";
            this.txtDetailCustomerName.ReadOnly = true;
            this.txtDetailCustomerName.Size = new System.Drawing.Size(220, 31);
            this.txtDetailCustomerName.TabIndex = 4;
            // 
            // lblDetailCustomerName
            // 
            this.lblDetailCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailCustomerName.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetailCustomerName.Location = new System.Drawing.Point(27, 121);
            this.lblDetailCustomerName.Name = "lblDetailCustomerName";
            this.lblDetailCustomerName.Size = new System.Drawing.Size(338, 27);
            this.lblDetailCustomerName.TabIndex = 3;
            this.lblDetailCustomerName.Text = "Họ và tên";
            this.lblDetailCustomerName.Click += new System.EventHandler(this.lblDetailCustomerName_Click);
            // 
            // txtDetailCustomerId
            // 
            this.txtDetailCustomerId.Location = new System.Drawing.Point(30, 77);
            this.txtDetailCustomerId.Name = "txtDetailCustomerId";
            this.txtDetailCustomerId.ReadOnly = true;
            this.txtDetailCustomerId.Size = new System.Drawing.Size(220, 31);
            this.txtDetailCustomerId.TabIndex = 2;
            this.txtDetailCustomerId.TextChanged += new System.EventHandler(this.txtDetailCustomerId_TextChanged);
            // 
            // lblDetailCustomerId
            // 
            this.lblDetailCustomerId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailCustomerId.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetailCustomerId.Location = new System.Drawing.Point(25, 43);
            this.lblDetailCustomerId.Name = "lblDetailCustomerId";
            this.lblDetailCustomerId.Size = new System.Drawing.Size(200, 31);
            this.lblDetailCustomerId.TabIndex = 1;
            this.lblDetailCustomerId.Text = "Mã khách hàng";
            // 
            // lblCustomerDetailTitle
            // 
            this.lblCustomerDetailTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerDetailTitle.Location = new System.Drawing.Point(25, 8);
            this.lblCustomerDetailTitle.Name = "lblCustomerDetailTitle";
            this.lblCustomerDetailTitle.Size = new System.Drawing.Size(338, 27);
            this.lblCustomerDetailTitle.TabIndex = 0;
            this.lblCustomerDetailTitle.Text = "CHI TIẾT TÀI KHOẢN ĐƯỢC CHỌN";
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1221, 660);
            this.Controls.Add(this.pnlCustomerDetail);
            this.Controls.Add(this.pnlCustomerList);
            this.Controls.Add(this.pnlCustomerToolbar);
            this.Controls.Add(this.pnlDashboardHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.pnlDashboardHeader.ResumeLayout(false);
            this.pnlCustomerToolbar.ResumeLayout(false);
            this.pnlCustomerToolbar.PerformLayout();
            this.pnlCustomerList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlCustomerDetail.ResumeLayout(false);
            this.pnlCustomerDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDashboardHeader;
        private System.Windows.Forms.Label lblDashboardDescription;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel pnlCustomerToolbar;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label lblSearchCustomer;
        private System.Windows.Forms.ComboBox cboFilterCustomerStatus;
        private System.Windows.Forms.Label lblFilterCustomerStatus;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Button btnRefreshCustomer;
        private System.Windows.Forms.Panel pnlCustomerList;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label lblCustomerListTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerCreated;
        private System.Windows.Forms.Panel pnlCustomerDetail;
        private System.Windows.Forms.Label lblCustomerDetailTitle;
        private System.Windows.Forms.TextBox txtDetailCustomerName;
        private System.Windows.Forms.Label lblDetailCustomerName;
        private System.Windows.Forms.TextBox txtDetailCustomerId;
        private System.Windows.Forms.Label lblDetailCustomerId;
        private System.Windows.Forms.Button btnLockCustomer;
        private System.Windows.Forms.Label lblCustomerStatus;
        private System.Windows.Forms.TextBox txtDetailCustomerPhone;
        private System.Windows.Forms.TextBox txtDetailCustomerEmail;
        private System.Windows.Forms.Label lblDetailCustomerEmail;
        private System.Windows.Forms.Label lblDetailCustomerPhone;
        private System.Windows.Forms.Button btnUnlockCustomer;
    }
}