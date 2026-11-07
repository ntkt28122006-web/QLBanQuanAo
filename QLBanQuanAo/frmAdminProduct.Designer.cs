namespace QLBanQuanAo
{
    partial class frmAdminProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminProduct));
            this.pnlProductHeader = new System.Windows.Forms.Panel();
            this.lblPageDescription = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlProductFilter = new System.Windows.Forms.Panel();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.pnlProductBody = new System.Windows.Forms.Panel();
            this.splitProductContent = new System.Windows.Forms.SplitContainer();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.tabProductInfo = new System.Windows.Forms.TabControl();
            this.tabProductGeneral = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.chkIsSale = new System.Windows.Forms.CheckBox();
            this.chkIsHot = new System.Windows.Forms.CheckBox();
            this.cboProductStatus = new System.Windows.Forms.ComboBox();
            this.lblProductStatus = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.numProductSalePrice = new System.Windows.Forms.NumericUpDown();
            this.lblProductSalePrice = new System.Windows.Forms.Label();
            this.numProductPrice = new System.Windows.Forms.NumericUpDown();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.txtProductBrand = new System.Windows.Forms.TextBox();
            this.lblProductBrand = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductInfoTitle = new System.Windows.Forms.Label();
            this.tabProductVariants = new System.Windows.Forms.TabPage();
            this.lblVariantHint = new System.Windows.Forms.Label();
            this.dgvVariants = new System.Windows.Forms.DataGridView();
            this.btnClearVariant = new System.Windows.Forms.Button();
            this.btnDisableVariant = new System.Windows.Forms.Button();
            this.btnUpdateVariant = new System.Windows.Forms.Button();
            this.btnAddVariant = new System.Windows.Forms.Button();
            this.chkVariantActive = new System.Windows.Forms.CheckBox();
            this.numVariantStock = new System.Windows.Forms.NumericUpDown();
            this.lblVariantStock = new System.Windows.Forms.Label();
            this.numVariantPrice = new System.Windows.Forms.NumericUpDown();
            this.lblVariantPrice = new System.Windows.Forms.Label();
            this.txtVariantSku = new System.Windows.Forms.TextBox();
            this.lblVariantSku = new System.Windows.Forms.Label();
            this.cboVariantSize = new System.Windows.Forms.ComboBox();
            this.lblVariantSize = new System.Windows.Forms.Label();
            this.cboVariantColor = new System.Windows.Forms.ComboBox();
            this.lblVariantColor = new System.Windows.Forms.Label();
            this.lblVariantTitle = new System.Windows.Forms.Label();
            this.pnlProductHeader.SuspendLayout();
            this.pnlProductFilter.SuspendLayout();
            this.pnlProductBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProductContent)).BeginInit();
            this.splitProductContent.Panel1.SuspendLayout();
            this.splitProductContent.Panel2.SuspendLayout();
            this.splitProductContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlProductInfo.SuspendLayout();
            this.tabProductInfo.SuspendLayout();
            this.tabProductGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductPrice)).BeginInit();
            this.tabProductVariants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariantStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariantPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProductHeader
            // 
            this.pnlProductHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.pnlProductHeader.Controls.Add(this.lblPageDescription);
            this.pnlProductHeader.Controls.Add(this.lblPageTitle);
            this.pnlProductHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlProductHeader.Name = "pnlProductHeader";
            this.pnlProductHeader.Size = new System.Drawing.Size(1190, 90);
            this.pnlProductHeader.TabIndex = 0;
            // 
            // lblPageDescription
            // 
            this.lblPageDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblPageDescription.ForeColor = System.Drawing.Color.Black;
            this.lblPageDescription.Location = new System.Drawing.Point(28, 65);
            this.lblPageDescription.Name = "lblPageDescription";
            this.lblPageDescription.Size = new System.Drawing.Size(700, 22);
            this.lblPageDescription.TabIndex = 0;
            this.lblPageDescription.Text = "Quản lý thông tin, giá bán và trạng thái kinh doanh";
            this.lblPageDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(3, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1280, 90);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Quản lí sản phầm";
            // 
            // pnlProductFilter
            // 
            this.pnlProductFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProductFilter.Controls.Add(this.cboFilterStatus);
            this.pnlProductFilter.Controls.Add(this.cboFilterCategory);
            this.pnlProductFilter.Controls.Add(this.btnSearchProduct);
            this.pnlProductFilter.Controls.Add(this.txtSearchProduct);
            this.pnlProductFilter.Controls.Add(this.btnResetFilter);
            this.pnlProductFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlProductFilter.Location = new System.Drawing.Point(0, 90);
            this.pnlProductFilter.Name = "pnlProductFilter";
            this.pnlProductFilter.Size = new System.Drawing.Size(1190, 70);
            this.pnlProductFilter.TabIndex = 1;
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Items.AddRange(new object[] {
            "Đang kinh doanh (active)"});
            this.cboFilterStatus.Location = new System.Drawing.Point(512, 18);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(220, 36);
            this.cboFilterStatus.TabIndex = 3;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // cboFilterCategory
            // 
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(264, 18);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(220, 36);
            this.cboFilterCategory.TabIndex = 2;
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cboFilterCategory_SelectedIndexChanged);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearchProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Location = new System.Drawing.Point(760, 14);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(110, 38);
            this.btnSearchProduct.TabIndex = 1;
            this.btnSearchProduct.Text = "Tìm kiếm";
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchProduct.Location = new System.Drawing.Point(20, 18);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(216, 34);
            this.txtSearchProduct.TabIndex = 0;
            this.txtSearchProduct.Text = "Tìm kiếm sản phẩm...";
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.Black;
            this.btnResetFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.Location = new System.Drawing.Point(898, 14);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(110, 38);
            this.btnResetFilter.TabIndex = 4;
            this.btnResetFilter.Text = "Làm mới";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // pnlProductBody
            // 
            this.pnlProductBody.AutoScroll = true;
            this.pnlProductBody.AutoScrollMinSize = new System.Drawing.Size(0, 900);
            this.pnlProductBody.Controls.Add(this.splitProductContent);
            this.pnlProductBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductBody.Location = new System.Drawing.Point(0, 160);
            this.pnlProductBody.Name = "pnlProductBody";
            this.pnlProductBody.Size = new System.Drawing.Size(1190, 480);
            this.pnlProductBody.TabIndex = 2;
            // 
            // splitProductContent
            // 
            this.splitProductContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProductContent.Location = new System.Drawing.Point(0, 0);
            this.splitProductContent.Name = "splitProductContent";
            // 
            // splitProductContent.Panel1
            // 
            this.splitProductContent.Panel1.Controls.Add(this.dgvProducts);
            this.splitProductContent.Panel1MinSize = 600;
            // 
            // splitProductContent.Panel2
            // 
            this.splitProductContent.Panel2.Controls.Add(this.pnlProductInfo);
            this.splitProductContent.Panel2MinSize = 400;
            this.splitProductContent.Size = new System.Drawing.Size(1164, 900);
            this.splitProductContent.SplitterDistance = 656;
            this.splitProductContent.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeight = 38;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colProductCategory,
            this.colProductPrice,
            this.colProductSalePrice,
            this.colProductStock,
            this.colProductStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(656, 900);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // colProductId
            // 
            this.colProductId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductId.DataPropertyName = "id";
            this.colProductId.HeaderText = "Mã SP";
            this.colProductId.MinimumWidth = 8;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.DataPropertyName = "name";
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colProductCategory
            // 
            this.colProductCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductCategory.DataPropertyName = "CategoryName";
            this.colProductCategory.HeaderText = "Danh mục sản phẩm";
            this.colProductCategory.MinimumWidth = 8;
            this.colProductCategory.Name = "colProductCategory";
            this.colProductCategory.ReadOnly = true;
            // 
            // colProductPrice
            // 
            this.colProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductPrice.DataPropertyName = "price";
            this.colProductPrice.HeaderText = "Giá bán";
            this.colProductPrice.MinimumWidth = 8;
            this.colProductPrice.Name = "colProductPrice";
            this.colProductPrice.ReadOnly = true;
            // 
            // colProductSalePrice
            // 
            this.colProductSalePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductSalePrice.DataPropertyName = "sale_price";
            this.colProductSalePrice.HeaderText = "Giá khuyến mãi";
            this.colProductSalePrice.MinimumWidth = 8;
            this.colProductSalePrice.Name = "colProductSalePrice";
            this.colProductSalePrice.ReadOnly = true;
            // 
            // colProductStock
            // 
            this.colProductStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductStock.DataPropertyName = "StockQuantity";
            this.colProductStock.HeaderText = "Tồn kho";
            this.colProductStock.MinimumWidth = 8;
            this.colProductStock.Name = "colProductStock";
            this.colProductStock.ReadOnly = true;
            // 
            // colProductStatus
            // 
            this.colProductStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductStatus.DataPropertyName = "status";
            this.colProductStatus.HeaderText = "Trạng thái";
            this.colProductStatus.MinimumWidth = 8;
            this.colProductStatus.Name = "colProductStatus";
            this.colProductStatus.ReadOnly = true;
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Controls.Add(this.tabProductInfo);
            this.pnlProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Padding = new System.Windows.Forms.Padding(12);
            this.pnlProductInfo.Size = new System.Drawing.Size(504, 900);
            this.pnlProductInfo.TabIndex = 0;
            this.pnlProductInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProductInfo_Paint);
            // 
            // tabProductInfo
            // 
            this.tabProductInfo.Controls.Add(this.tabProductGeneral);
            this.tabProductInfo.Controls.Add(this.tabProductVariants);
            this.tabProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProductInfo.Location = new System.Drawing.Point(12, 12);
            this.tabProductInfo.Name = "tabProductInfo";
            this.tabProductInfo.SelectedIndex = 0;
            this.tabProductInfo.Size = new System.Drawing.Size(480, 876);
            this.tabProductInfo.TabIndex = 0;
            // 
            // tabProductGeneral
            // 
            this.tabProductGeneral.AutoScroll = true;
            this.tabProductGeneral.AutoScrollMinSize = new System.Drawing.Size(0, 840);
            this.tabProductGeneral.Controls.Add(this.btnExit);
            this.tabProductGeneral.Controls.Add(this.btnClearProduct);
            this.tabProductGeneral.Controls.Add(this.btnUpdateProduct);
            this.tabProductGeneral.Controls.Add(this.btnDeleteProduct);
            this.tabProductGeneral.Controls.Add(this.btnAddProduct);
            this.tabProductGeneral.Controls.Add(this.btnChooseImage);
            this.tabProductGeneral.Controls.Add(this.picProductImage);
            this.tabProductGeneral.Controls.Add(this.chkIsSale);
            this.tabProductGeneral.Controls.Add(this.chkIsHot);
            this.tabProductGeneral.Controls.Add(this.cboProductStatus);
            this.tabProductGeneral.Controls.Add(this.lblProductStatus);
            this.tabProductGeneral.Controls.Add(this.txtProductDescription);
            this.tabProductGeneral.Controls.Add(this.lblProductDescription);
            this.tabProductGeneral.Controls.Add(this.numProductSalePrice);
            this.tabProductGeneral.Controls.Add(this.lblProductSalePrice);
            this.tabProductGeneral.Controls.Add(this.numProductPrice);
            this.tabProductGeneral.Controls.Add(this.lblProductPrice);
            this.tabProductGeneral.Controls.Add(this.txtProductBrand);
            this.tabProductGeneral.Controls.Add(this.lblProductBrand);
            this.tabProductGeneral.Controls.Add(this.cboCategory);
            this.tabProductGeneral.Controls.Add(this.lblProductCategory);
            this.tabProductGeneral.Controls.Add(this.txtProductName);
            this.tabProductGeneral.Controls.Add(this.txtProductId);
            this.tabProductGeneral.Controls.Add(this.lblProductId);
            this.tabProductGeneral.Controls.Add(this.lblProductName);
            this.tabProductGeneral.Controls.Add(this.lblProductInfoTitle);
            this.tabProductGeneral.Location = new System.Drawing.Point(4, 34);
            this.tabProductGeneral.Name = "tabProductGeneral";
            this.tabProductGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductGeneral.Size = new System.Drawing.Size(472, 838);
            this.tabProductGeneral.TabIndex = 0;
            this.tabProductGeneral.Text = "Thông tin chung";
            this.tabProductGeneral.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(375, 727);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 81);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Location = new System.Drawing.Point(210, 770);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(180, 38);
            this.btnClearProduct.TabIndex = 25;
            this.btnClearProduct.Text = "Làm trống";
            this.btnClearProduct.UseVisualStyleBackColor = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(15, 770);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(180, 38);
            this.btnUpdateProduct.TabIndex = 24;
            this.btnUpdateProduct.Text = "Cập nhật";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(210, 720);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(180, 38);
            this.btnDeleteProduct.TabIndex = 23;
            this.btnDeleteProduct.Text = "Ngừng bán";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(15, 720);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(180, 38);
            this.btnAddProduct.TabIndex = 22;
            this.btnAddProduct.Text = "Thêm mới";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.Color.Black;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(150, 620);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(180, 36);
            this.btnChooseImage.TabIndex = 21;
            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // picProductImage
            // 
            this.picProductImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.Location = new System.Drawing.Point(15, 600);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(120, 100);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 20;
            this.picProductImage.TabStop = false;
            this.picProductImage.Click += new System.EventHandler(this.picProductImage_Click);
            // 
            // chkIsSale
            // 
            this.chkIsSale.Location = new System.Drawing.Point(200, 560);
            this.chkIsSale.Name = "chkIsSale";
            this.chkIsSale.Size = new System.Drawing.Size(190, 30);
            this.chkIsSale.TabIndex = 19;
            this.chkIsSale.Text = "Đang khuyến mãi";
            this.chkIsSale.UseVisualStyleBackColor = true;
            // 
            // chkIsHot
            // 
            this.chkIsHot.Location = new System.Drawing.Point(15, 560);
            this.chkIsHot.Name = "chkIsHot";
            this.chkIsHot.Size = new System.Drawing.Size(190, 30);
            this.chkIsHot.TabIndex = 17;
            this.chkIsHot.Text = "Sản phẩm nổi bật";
            this.chkIsHot.UseVisualStyleBackColor = true;
            // 
            // cboProductStatus
            // 
            this.cboProductStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductStatus.FormattingEnabled = true;
            this.cboProductStatus.Location = new System.Drawing.Point(15, 520);
            this.cboProductStatus.Name = "cboProductStatus";
            this.cboProductStatus.Size = new System.Drawing.Size(380, 33);
            this.cboProductStatus.TabIndex = 16;
            // 
            // lblProductStatus
            // 
            this.lblProductStatus.Location = new System.Drawing.Point(15, 490);
            this.lblProductStatus.Name = "lblProductStatus";
            this.lblProductStatus.Size = new System.Drawing.Size(380, 31);
            this.lblProductStatus.TabIndex = 15;
            this.lblProductStatus.Text = "Trạng thái kinh doanh";
            this.lblProductStatus.Click += new System.EventHandler(this.lblProductStatus_Click);
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(15, 460);
            this.txtProductDescription.MaxLength = 2000;
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProductDescription.Size = new System.Drawing.Size(380, 31);
            this.txtProductDescription.TabIndex = 14;
            this.txtProductDescription.TextChanged += new System.EventHandler(this.txtProductDescription_TextChanged);
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.Location = new System.Drawing.Point(15, 430);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(380, 31);
            this.lblProductDescription.TabIndex = 13;
            this.lblProductDescription.Text = "Mô tả sản phẩm";
            // 
            // numProductSalePrice
            // 
            this.numProductSalePrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numProductSalePrice.Location = new System.Drawing.Point(15, 390);
            this.numProductSalePrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numProductSalePrice.Name = "numProductSalePrice";
            this.numProductSalePrice.Size = new System.Drawing.Size(380, 31);
            this.numProductSalePrice.TabIndex = 12;
            this.numProductSalePrice.ThousandsSeparator = true;
            this.numProductSalePrice.ValueChanged += new System.EventHandler(this.numProductSalePrice_ValueChanged);
            // 
            // lblProductSalePrice
            // 
            this.lblProductSalePrice.Location = new System.Drawing.Point(15, 364);
            this.lblProductSalePrice.Name = "lblProductSalePrice";
            this.lblProductSalePrice.Size = new System.Drawing.Size(380, 31);
            this.lblProductSalePrice.TabIndex = 11;
            this.lblProductSalePrice.Text = " Giá khuyến mãi (VNĐ)";
            this.lblProductSalePrice.Click += new System.EventHandler(this.lblProductSalePrice_Click);
            // 
            // numProductPrice
            // 
            this.numProductPrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numProductPrice.Location = new System.Drawing.Point(15, 330);
            this.numProductPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numProductPrice.Name = "numProductPrice";
            this.numProductPrice.Size = new System.Drawing.Size(380, 31);
            this.numProductPrice.TabIndex = 10;
            this.numProductPrice.ThousandsSeparator = true;
            this.numProductPrice.ValueChanged += new System.EventHandler(this.numProductPrice_ValueChanged);
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Location = new System.Drawing.Point(15, 300);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(380, 31);
            this.lblProductPrice.TabIndex = 9;
            this.lblProductPrice.Text = " Giá bán (VNĐ)*";
            // 
            // txtProductBrand
            // 
            this.txtProductBrand.Location = new System.Drawing.Point(15, 260);
            this.txtProductBrand.MaxLength = 100;
            this.txtProductBrand.Name = "txtProductBrand";
            this.txtProductBrand.Size = new System.Drawing.Size(380, 31);
            this.txtProductBrand.TabIndex = 8;
            this.txtProductBrand.TextChanged += new System.EventHandler(this.txtProductBrand_TextChanged);
            // 
            // lblProductBrand
            // 
            this.lblProductBrand.Location = new System.Drawing.Point(15, 230);
            this.lblProductBrand.Name = "lblProductBrand";
            this.lblProductBrand.Size = new System.Drawing.Size(380, 31);
            this.lblProductBrand.TabIndex = 7;
            this.lblProductBrand.Text = "Thương hiệu";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(15, 190);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(380, 33);
            this.cboCategory.TabIndex = 6;
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.Location = new System.Drawing.Point(15, 165);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(380, 31);
            this.lblProductCategory.TabIndex = 5;
            this.lblProductCategory.Text = "Danh mục*";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(15, 132);
            this.txtProductName.MaxLength = 200;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(380, 31);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(15, 80);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(380, 31);
            this.txtProductId.TabIndex = 3;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // lblProductId
            // 
            this.lblProductId.Location = new System.Drawing.Point(15, 55);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(380, 31);
            this.lblProductId.TabIndex = 2;
            this.lblProductId.Text = "Mã sản phẩm ";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(15, 110);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(380, 31);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Tên sản phẩm*";
            // 
            // lblProductInfoTitle
            // 
            this.lblProductInfoTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProductInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblProductInfoTitle.Name = "lblProductInfoTitle";
            this.lblProductInfoTitle.Size = new System.Drawing.Size(380, 40);
            this.lblProductInfoTitle.TabIndex = 0;
            this.lblProductInfoTitle.Text = "Thông tin sản phẩm";
            this.lblProductInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabProductVariants
            // 
            this.tabProductVariants.AutoScroll = true;
            this.tabProductVariants.AutoScrollMinSize = new System.Drawing.Size(0, 690);
            this.tabProductVariants.Controls.Add(this.lblVariantHint);
            this.tabProductVariants.Controls.Add(this.dgvVariants);
            this.tabProductVariants.Controls.Add(this.btnClearVariant);
            this.tabProductVariants.Controls.Add(this.btnDisableVariant);
            this.tabProductVariants.Controls.Add(this.btnUpdateVariant);
            this.tabProductVariants.Controls.Add(this.btnAddVariant);
            this.tabProductVariants.Controls.Add(this.chkVariantActive);
            this.tabProductVariants.Controls.Add(this.numVariantStock);
            this.tabProductVariants.Controls.Add(this.lblVariantStock);
            this.tabProductVariants.Controls.Add(this.numVariantPrice);
            this.tabProductVariants.Controls.Add(this.lblVariantPrice);
            this.tabProductVariants.Controls.Add(this.txtVariantSku);
            this.tabProductVariants.Controls.Add(this.lblVariantSku);
            this.tabProductVariants.Controls.Add(this.cboVariantSize);
            this.tabProductVariants.Controls.Add(this.lblVariantSize);
            this.tabProductVariants.Controls.Add(this.cboVariantColor);
            this.tabProductVariants.Controls.Add(this.lblVariantColor);
            this.tabProductVariants.Controls.Add(this.lblVariantTitle);
            this.tabProductVariants.Location = new System.Drawing.Point(4, 29);
            this.tabProductVariants.Name = "tabProductVariants";
            this.tabProductVariants.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductVariants.Size = new System.Drawing.Size(472, 843);
            this.tabProductVariants.TabIndex = 1;
            this.tabProductVariants.Text = "Biến thể & tồn kho";
            this.tabProductVariants.UseVisualStyleBackColor = true;
            // 
            // lblVariantHint
            // 
            this.lblVariantHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblVariantHint.Location = new System.Drawing.Point(15, 644);
            this.lblVariantHint.Name = "lblVariantHint";
            this.lblVariantHint.Size = new System.Drawing.Size(435, 42);
            this.lblVariantHint.TabIndex = 17;
            this.lblVariantHint.Text = "Chọn một sản phẩm ở danh sách bên trái trước khi thêm hoặc cập nhật biến thể.";
            // 
            // dgvVariants
            // 
            this.dgvVariants.AllowUserToAddRows = false;
            this.dgvVariants.AllowUserToDeleteRows = false;
            this.dgvVariants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVariants.BackgroundColor = System.Drawing.Color.White;
            this.dgvVariants.ColumnHeadersHeight = 34;
            this.dgvVariants.Location = new System.Drawing.Point(15, 286);
            this.dgvVariants.MultiSelect = false;
            this.dgvVariants.Name = "dgvVariants";
            this.dgvVariants.ReadOnly = true;
            this.dgvVariants.RowHeadersVisible = false;
            this.dgvVariants.RowHeadersWidth = 62;
            this.dgvVariants.RowTemplate.Height = 28;
            this.dgvVariants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVariants.Size = new System.Drawing.Size(435, 350);
            this.dgvVariants.TabIndex = 16;
            this.dgvVariants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVariants_CellClick);
            // 
            // btnClearVariant
            // 
            this.btnClearVariant.Location = new System.Drawing.Point(345, 238);
            this.btnClearVariant.Name = "btnClearVariant";
            this.btnClearVariant.Size = new System.Drawing.Size(95, 34);
            this.btnClearVariant.TabIndex = 15;
            this.btnClearVariant.Text = "Tạo mới";
            this.btnClearVariant.UseVisualStyleBackColor = true;
            this.btnClearVariant.Click += new System.EventHandler(this.btnClearVariant_Click);
            // 
            // btnDisableVariant
            // 
            this.btnDisableVariant.Location = new System.Drawing.Point(235, 238);
            this.btnDisableVariant.Name = "btnDisableVariant";
            this.btnDisableVariant.Size = new System.Drawing.Size(100, 34);
            this.btnDisableVariant.TabIndex = 14;
            this.btnDisableVariant.Text = "Ngừng bán";
            this.btnDisableVariant.UseVisualStyleBackColor = true;
            this.btnDisableVariant.Click += new System.EventHandler(this.btnDisableVariant_Click);
            // 
            // btnUpdateVariant
            // 
            this.btnUpdateVariant.Location = new System.Drawing.Point(125, 238);
            this.btnUpdateVariant.Name = "btnUpdateVariant";
            this.btnUpdateVariant.Size = new System.Drawing.Size(100, 34);
            this.btnUpdateVariant.TabIndex = 13;
            this.btnUpdateVariant.Text = "Cập nhật";
            this.btnUpdateVariant.UseVisualStyleBackColor = true;
            this.btnUpdateVariant.Click += new System.EventHandler(this.btnUpdateVariant_Click);
            // 
            // btnAddVariant
            // 
            this.btnAddVariant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnAddVariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVariant.ForeColor = System.Drawing.Color.White;
            this.btnAddVariant.Location = new System.Drawing.Point(15, 238);
            this.btnAddVariant.Name = "btnAddVariant";
            this.btnAddVariant.Size = new System.Drawing.Size(100, 34);
            this.btnAddVariant.TabIndex = 12;
            this.btnAddVariant.Text = "Thêm";
            this.btnAddVariant.UseVisualStyleBackColor = false;
            this.btnAddVariant.Click += new System.EventHandler(this.btnAddVariant_Click);
            // 
            // chkVariantActive
            // 
            this.chkVariantActive.AutoSize = true;
            this.chkVariantActive.Checked = true;
            this.chkVariantActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVariantActive.Location = new System.Drawing.Point(235, 198);
            this.chkVariantActive.Name = "chkVariantActive";
            this.chkVariantActive.Size = new System.Drawing.Size(175, 29);
            this.chkVariantActive.TabIndex = 11;
            this.chkVariantActive.Text = "Đang kinh doanh";
            this.chkVariantActive.UseVisualStyleBackColor = true;
            // 
            // numVariantStock
            // 
            this.numVariantStock.Location = new System.Drawing.Point(15, 196);
            this.numVariantStock.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numVariantStock.Name = "numVariantStock";
            this.numVariantStock.Size = new System.Drawing.Size(205, 31);
            this.numVariantStock.TabIndex = 10;
            this.numVariantStock.ThousandsSeparator = true;
            // 
            // lblVariantStock
            // 
            this.lblVariantStock.Location = new System.Drawing.Point(15, 172);
            this.lblVariantStock.Name = "lblVariantStock";
            this.lblVariantStock.Size = new System.Drawing.Size(205, 22);
            this.lblVariantStock.TabIndex = 9;
            this.lblVariantStock.Text = "Số lượng tồn kho";
            // 
            // numVariantPrice
            // 
            this.numVariantPrice.Location = new System.Drawing.Point(235, 136);
            this.numVariantPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numVariantPrice.Name = "numVariantPrice";
            this.numVariantPrice.Size = new System.Drawing.Size(205, 31);
            this.numVariantPrice.TabIndex = 8;
            this.numVariantPrice.ThousandsSeparator = true;
            // 
            // lblVariantPrice
            // 
            this.lblVariantPrice.Location = new System.Drawing.Point(235, 112);
            this.lblVariantPrice.Name = "lblVariantPrice";
            this.lblVariantPrice.Size = new System.Drawing.Size(205, 22);
            this.lblVariantPrice.TabIndex = 7;
            this.lblVariantPrice.Text = "Giá riêng (0 = dùng giá SP)";
            // 
            // txtVariantSku
            // 
            this.txtVariantSku.Location = new System.Drawing.Point(15, 136);
            this.txtVariantSku.MaxLength = 64;
            this.txtVariantSku.Name = "txtVariantSku";
            this.txtVariantSku.Size = new System.Drawing.Size(205, 31);
            this.txtVariantSku.TabIndex = 6;
            // 
            // lblVariantSku
            // 
            this.lblVariantSku.Location = new System.Drawing.Point(15, 112);
            this.lblVariantSku.Name = "lblVariantSku";
            this.lblVariantSku.Size = new System.Drawing.Size(205, 22);
            this.lblVariantSku.TabIndex = 5;
            this.lblVariantSku.Text = "Mã SKU (để trống tự tạo)";
            // 
            // cboVariantSize
            // 
            this.cboVariantSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVariantSize.FormattingEnabled = true;
            this.cboVariantSize.Location = new System.Drawing.Point(235, 76);
            this.cboVariantSize.Name = "cboVariantSize";
            this.cboVariantSize.Size = new System.Drawing.Size(205, 33);
            this.cboVariantSize.TabIndex = 4;
            // 
            // lblVariantSize
            // 
            this.lblVariantSize.Location = new System.Drawing.Point(235, 52);
            this.lblVariantSize.Name = "lblVariantSize";
            this.lblVariantSize.Size = new System.Drawing.Size(205, 22);
            this.lblVariantSize.TabIndex = 3;
            this.lblVariantSize.Text = "Kích thước";
            // 
            // cboVariantColor
            // 
            this.cboVariantColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVariantColor.FormattingEnabled = true;
            this.cboVariantColor.Location = new System.Drawing.Point(15, 76);
            this.cboVariantColor.Name = "cboVariantColor";
            this.cboVariantColor.Size = new System.Drawing.Size(205, 33);
            this.cboVariantColor.TabIndex = 2;
            // 
            // lblVariantColor
            // 
            this.lblVariantColor.Location = new System.Drawing.Point(15, 52);
            this.lblVariantColor.Name = "lblVariantColor";
            this.lblVariantColor.Size = new System.Drawing.Size(205, 22);
            this.lblVariantColor.TabIndex = 1;
            this.lblVariantColor.Text = "Màu sắc";
            // 
            // lblVariantTitle
            // 
            this.lblVariantTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVariantTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblVariantTitle.Location = new System.Drawing.Point(15, 14);
            this.lblVariantTitle.Name = "lblVariantTitle";
            this.lblVariantTitle.Size = new System.Drawing.Size(420, 30);
            this.lblVariantTitle.TabIndex = 0;
            this.lblVariantTitle.Text = "Quản lý màu sắc, kích thước và tồn kho";
            // 
            // frmAdminProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 640);
            this.Controls.Add(this.pnlProductBody);
            this.Controls.Add(this.pnlProductFilter);
            this.Controls.Add(this.pnlProductHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdminProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lí sản phẩm";
            this.Load += new System.EventHandler(this.frmAdminProduct_Load);
            this.pnlProductHeader.ResumeLayout(false);
            this.pnlProductFilter.ResumeLayout(false);
            this.pnlProductFilter.PerformLayout();
            this.pnlProductBody.ResumeLayout(false);
            this.splitProductContent.Panel1.ResumeLayout(false);
            this.splitProductContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitProductContent)).EndInit();
            this.splitProductContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlProductInfo.ResumeLayout(false);
            this.tabProductInfo.ResumeLayout(false);
            this.tabProductGeneral.ResumeLayout(false);
            this.tabProductGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductPrice)).EndInit();
            this.tabProductVariants.ResumeLayout(false);
            this.tabProductVariants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariantStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariantPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProductHeader;
        private System.Windows.Forms.Panel pnlProductFilter;
        private System.Windows.Forms.Panel pnlProductBody;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageDescription;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.SplitContainer splitProductContent;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.TabControl tabProductInfo;
        private System.Windows.Forms.TabPage tabProductGeneral;
        private System.Windows.Forms.TabPage tabProductVariants;
        private System.Windows.Forms.Label lblVariantTitle;
        private System.Windows.Forms.Label lblVariantColor;
        private System.Windows.Forms.ComboBox cboVariantColor;
        private System.Windows.Forms.Label lblVariantSize;
        private System.Windows.Forms.ComboBox cboVariantSize;
        private System.Windows.Forms.Label lblVariantSku;
        private System.Windows.Forms.TextBox txtVariantSku;
        private System.Windows.Forms.Label lblVariantPrice;
        private System.Windows.Forms.NumericUpDown numVariantPrice;
        private System.Windows.Forms.Label lblVariantStock;
        private System.Windows.Forms.NumericUpDown numVariantStock;
        private System.Windows.Forms.CheckBox chkVariantActive;
        private System.Windows.Forms.Button btnAddVariant;
        private System.Windows.Forms.Button btnUpdateVariant;
        private System.Windows.Forms.Button btnDisableVariant;
        private System.Windows.Forms.Button btnClearVariant;
        private System.Windows.Forms.DataGridView dgvVariants;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantSku;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariantStatus;
        private System.Windows.Forms.Label lblVariantHint;
        private System.Windows.Forms.Label lblProductInfoTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductStatus;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.TextBox txtProductBrand;
        private System.Windows.Forms.Label lblProductBrand;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.NumericUpDown numProductSalePrice;
        private System.Windows.Forms.Label lblProductSalePrice;
        private System.Windows.Forms.NumericUpDown numProductPrice;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.Label lblProductStatus;
        private System.Windows.Forms.ComboBox cboProductStatus;
        private System.Windows.Forms.CheckBox chkIsSale;
        private System.Windows.Forms.CheckBox chkIsHot;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnExit;
    }
}