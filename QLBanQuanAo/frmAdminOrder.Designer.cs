namespace QLBanQuanAo
{
    partial class frmAdminOrder
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
            this.pnlOrderHeader = new System.Windows.Forms.Panel();
            this.lblOrderDescription = new System.Windows.Forms.Label();
            this.lblOrderTitle = new System.Windows.Forms.Label();
            this.pnlOrderFilter = new System.Windows.Forms.Panel();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnUpdateOrderStatus = new System.Windows.Forms.Button();
            this.btnViewOrderDetail = new System.Windows.Forms.Button();
            this.btnResetOrderFilter = new System.Windows.Forms.Button();
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cboFilterPaymentStatus = new System.Windows.Forms.ComboBox();
            this.txtSearchOrder = new System.Windows.Forms.TextBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlOrderBody = new System.Windows.Forms.Panel();
            this.splitOrderContent = new System.Windows.Forms.SplitContainer();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.colDetailProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOrderHeader.SuspendLayout();
            this.pnlOrderFilter.SuspendLayout();
            this.pnlOrderBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitOrderContent)).BeginInit();
            this.splitOrderContent.Panel1.SuspendLayout();
            this.splitOrderContent.Panel2.SuspendLayout();
            this.splitOrderContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrderHeader
            // 
            this.pnlOrderHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.pnlOrderHeader.Controls.Add(this.lblOrderDescription);
            this.pnlOrderHeader.Controls.Add(this.lblOrderTitle);
            this.pnlOrderHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderHeader.Name = "pnlOrderHeader";
            this.pnlOrderHeader.Size = new System.Drawing.Size(1528, 85);
            this.pnlOrderHeader.TabIndex = 0;
            // 
            // lblOrderDescription
            // 
            this.lblOrderDescription.AutoSize = true;
            this.lblOrderDescription.ForeColor = System.Drawing.Color.White;
            this.lblOrderDescription.Location = new System.Drawing.Point(30, 53);
            this.lblOrderDescription.Name = "lblOrderDescription";
            this.lblOrderDescription.Size = new System.Drawing.Size(367, 25);
            this.lblOrderDescription.TabIndex = 1;
            this.lblOrderDescription.Text = "Theo dõi đơn hàng, thanh toán và giao hàng";
            // 
            // lblOrderTitle
            // 
            this.lblOrderTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTitle.ForeColor = System.Drawing.Color.White;
            this.lblOrderTitle.Location = new System.Drawing.Point(26, -7);
            this.lblOrderTitle.Name = "lblOrderTitle";
            this.lblOrderTitle.Size = new System.Drawing.Size(600, 60);
            this.lblOrderTitle.TabIndex = 0;
            this.lblOrderTitle.Text = "Quản lý đơn hàng";
            this.lblOrderTitle.Click += new System.EventHandler(this.lblOrderTitle_Click);
            // 
            // pnlOrderFilter
            // 
            this.pnlOrderFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlOrderFilter.Controls.Add(this.btnPrintInvoice);
            this.pnlOrderFilter.Controls.Add(this.btnUpdateOrderStatus);
            this.pnlOrderFilter.Controls.Add(this.btnViewOrderDetail);
            this.pnlOrderFilter.Controls.Add(this.btnResetOrderFilter);
            this.pnlOrderFilter.Controls.Add(this.btnSearchOrder);
            this.pnlOrderFilter.Controls.Add(this.dtpToDate);
            this.pnlOrderFilter.Controls.Add(this.cboFilterPaymentStatus);
            this.pnlOrderFilter.Controls.Add(this.txtSearchOrder);
            this.pnlOrderFilter.Controls.Add(this.cboFilterStatus);
            this.pnlOrderFilter.Controls.Add(this.dtpFromDate);
            this.pnlOrderFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderFilter.Location = new System.Drawing.Point(0, 85);
            this.pnlOrderFilter.Name = "pnlOrderFilter";
            this.pnlOrderFilter.Size = new System.Drawing.Size(1528, 100);
            this.pnlOrderFilter.TabIndex = 1;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(1138, 12);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(200, 35);
            this.btnPrintInvoice.TabIndex = 12;
            this.btnPrintInvoice.Text = "In Hóa Đơn";
            this.btnPrintInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnUpdateOrderStatus
            // 
            this.btnUpdateOrderStatus.Location = new System.Drawing.Point(912, 53);
            this.btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
            this.btnUpdateOrderStatus.Size = new System.Drawing.Size(200, 35);
            this.btnUpdateOrderStatus.TabIndex = 7;
            this.btnUpdateOrderStatus.Text = "Cập nhật trạng thái";
            this.btnUpdateOrderStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateOrderStatus.UseVisualStyleBackColor = true;
            this.btnUpdateOrderStatus.Click += new System.EventHandler(this.btnUpdateOrderStatus_Click);
            // 
            // btnViewOrderDetail
            // 
            this.btnViewOrderDetail.Location = new System.Drawing.Point(912, 12);
            this.btnViewOrderDetail.Name = "btnViewOrderDetail";
            this.btnViewOrderDetail.Size = new System.Drawing.Size(200, 35);
            this.btnViewOrderDetail.TabIndex = 11;
            this.btnViewOrderDetail.Text = "Xem chi tiết";
            this.btnViewOrderDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewOrderDetail.UseVisualStyleBackColor = true;
            this.btnViewOrderDetail.Click += new System.EventHandler(this.btnViewOrderDetail_Click);
            // 
            // btnResetOrderFilter
            // 
            this.btnResetOrderFilter.Location = new System.Drawing.Point(685, 53);
            this.btnResetOrderFilter.Name = "btnResetOrderFilter";
            this.btnResetOrderFilter.Size = new System.Drawing.Size(200, 35);
            this.btnResetOrderFilter.TabIndex = 9;
            this.btnResetOrderFilter.Text = "Reset";
            this.btnResetOrderFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetOrderFilter.UseVisualStyleBackColor = true;
            this.btnResetOrderFilter.Click += new System.EventHandler(this.btnResetOrderFilter_Click);
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Location = new System.Drawing.Point(685, 10);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(200, 35);
            this.btnSearchOrder.TabIndex = 6;
            this.btnSearchOrder.Text = "Tìm kiếm đơn hàng";
            this.btnSearchOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchOrder.UseVisualStyleBackColor = true;
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(465, 55);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(180, 31);
            this.dtpToDate.TabIndex = 8;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // cboFilterPaymentStatus
            // 
            this.cboFilterPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterPaymentStatus.FormattingEnabled = true;
            this.cboFilterPaymentStatus.Location = new System.Drawing.Point(465, 10);
            this.cboFilterPaymentStatus.Name = "cboFilterPaymentStatus";
            this.cboFilterPaymentStatus.Size = new System.Drawing.Size(180, 33);
            this.cboFilterPaymentStatus.TabIndex = 7;
            this.cboFilterPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterPaymentStatus_SelectedIndexChanged);
            // 
            // txtSearchOrder
            // 
            this.txtSearchOrder.Location = new System.Drawing.Point(15, 10);
            this.txtSearchOrder.Name = "txtSearchOrder";
            this.txtSearchOrder.Size = new System.Drawing.Size(240, 31);
            this.txtSearchOrder.TabIndex = 0;
            this.txtSearchOrder.TextChanged += new System.EventHandler(this.txtSearchOrder_TextChanged);
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(270, 10);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(180, 33);
            this.cboFilterStatus.TabIndex = 1;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(270, 55);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 31);
            this.dtpFromDate.TabIndex = 4;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // pnlOrderBody
            // 
            this.pnlOrderBody.Controls.Add(this.splitOrderContent);
            this.pnlOrderBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderBody.Location = new System.Drawing.Point(0, 185);
            this.pnlOrderBody.Name = "pnlOrderBody";
            this.pnlOrderBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlOrderBody.Size = new System.Drawing.Size(1528, 503);
            this.pnlOrderBody.TabIndex = 1;
            // 
            // splitOrderContent
            // 
            this.splitOrderContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOrderContent.Location = new System.Drawing.Point(0, 0);
            this.splitOrderContent.Name = "splitOrderContent";
            this.splitOrderContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitOrderContent.Panel1
            // 
            this.splitOrderContent.Panel1.Controls.Add(this.dgvOrders);
            this.splitOrderContent.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitOrderContent.Panel2
            // 
            this.splitOrderContent.Panel2.Controls.Add(this.dgvOrderDetails);
            this.splitOrderContent.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitOrderContent.Size = new System.Drawing.Size(1528, 503);
            this.splitOrderContent.SplitterDistance = 242;
            this.splitOrderContent.TabIndex = 0;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderId,
            this.colOrderCustomer,
            this.colOrderPhone,
            this.colOrderDate,
            this.colOrderTotal,
            this.colOrderPaymentStatus,
            this.colOrderStatus});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 28;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1528, 242);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // colOrderId
            // 
            this.colOrderId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderId.DataPropertyName = "id";
            this.colOrderId.HeaderText = "Mã đơn";
            this.colOrderId.MinimumWidth = 8;
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            // 
            // colOrderCustomer
            // 
            this.colOrderCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderCustomer.DataPropertyName = "recipient_name";
            this.colOrderCustomer.HeaderText = "Người nhận";
            this.colOrderCustomer.MinimumWidth = 8;
            this.colOrderCustomer.Name = "colOrderCustomer";
            this.colOrderCustomer.ReadOnly = true;
            // 
            // colOrderPhone
            // 
            this.colOrderPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderPhone.DataPropertyName = "recipient_phone";
            this.colOrderPhone.HeaderText = "Số điện thoại";
            this.colOrderPhone.MinimumWidth = 8;
            this.colOrderPhone.Name = "colOrderPhone";
            this.colOrderPhone.ReadOnly = true;
            // 
            // colOrderDate
            // 
            this.colOrderDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderDate.DataPropertyName = "created_at";
            this.colOrderDate.HeaderText = "Ngày đặt";
            this.colOrderDate.MinimumWidth = 8;
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            // 
            // colOrderTotal
            // 
            this.colOrderTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderTotal.DataPropertyName = "total_amount";
            this.colOrderTotal.HeaderText = "Tổng tiền";
            this.colOrderTotal.MinimumWidth = 8;
            this.colOrderTotal.Name = "colOrderTotal";
            this.colOrderTotal.ReadOnly = true;
            // 
            // colOrderPaymentStatus
            // 
            this.colOrderPaymentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderPaymentStatus.DataPropertyName = "payment_status";
            this.colOrderPaymentStatus.HeaderText = "Thanh toán";
            this.colOrderPaymentStatus.MinimumWidth = 8;
            this.colOrderPaymentStatus.Name = "colOrderPaymentStatus";
            this.colOrderPaymentStatus.ReadOnly = true;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderStatus.DataPropertyName = "status";
            this.colOrderStatus.HeaderText = "Trạng thái";
            this.colOrderStatus.MinimumWidth = 8;
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailProductName,
            this.colDetailSKU,
            this.colDetailColor,
            this.colDetailSize,
            this.colDetailQuantity,
            this.colDetailUnitPrice,
            this.colDetailLineTotal});
            this.dgvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersVisible = false;
            this.dgvOrderDetails.RowHeadersWidth = 62;
            this.dgvOrderDetails.RowTemplate.Height = 28;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(1528, 257);
            this.dgvOrderDetails.TabIndex = 1;
            this.dgvOrderDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellContentClick);
            // 
            // colDetailProductName
            // 
            this.colDetailProductName.DataPropertyName = "product_name";
            this.colDetailProductName.HeaderText = "Sản phẩm";
            this.colDetailProductName.MinimumWidth = 8;
            this.colDetailProductName.Name = "colDetailProductName";
            this.colDetailProductName.ReadOnly = true;
            // 
            // colDetailSKU
            // 
            this.colDetailSKU.DataPropertyName = "sku";
            this.colDetailSKU.HeaderText = "SKU";
            this.colDetailSKU.MinimumWidth = 8;
            this.colDetailSKU.Name = "colDetailSKU";
            this.colDetailSKU.ReadOnly = true;
            // 
            // colDetailColor
            // 
            this.colDetailColor.DataPropertyName = "color_name";
            this.colDetailColor.HeaderText = "Màu sắc";
            this.colDetailColor.MinimumWidth = 8;
            this.colDetailColor.Name = "colDetailColor";
            this.colDetailColor.ReadOnly = true;
            // 
            // colDetailSize
            // 
            this.colDetailSize.DataPropertyName = "size_name";
            this.colDetailSize.HeaderText = "Kích cỡ";
            this.colDetailSize.MinimumWidth = 8;
            this.colDetailSize.Name = "colDetailSize";
            this.colDetailSize.ReadOnly = true;
            // 
            // colDetailQuantity
            // 
            this.colDetailQuantity.DataPropertyName = "quantity";
            this.colDetailQuantity.HeaderText = "Số lượng";
            this.colDetailQuantity.MinimumWidth = 8;
            this.colDetailQuantity.Name = "colDetailQuantity";
            this.colDetailQuantity.ReadOnly = true;
            // 
            // colDetailUnitPrice
            // 
            this.colDetailUnitPrice.DataPropertyName = "unit_price";
            this.colDetailUnitPrice.HeaderText = "Đơn giá";
            this.colDetailUnitPrice.MinimumWidth = 8;
            this.colDetailUnitPrice.Name = "colDetailUnitPrice";
            this.colDetailUnitPrice.ReadOnly = true;
            // 
            // colDetailLineTotal
            // 
            this.colDetailLineTotal.DataPropertyName = "line_total";
            this.colDetailLineTotal.HeaderText = "Thành tiền";
            this.colDetailLineTotal.MinimumWidth = 8;
            this.colDetailLineTotal.Name = "colDetailLineTotal";
            this.colDetailLineTotal.ReadOnly = true;
            // 
            // frmAdminOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1528, 688);
            this.Controls.Add(this.pnlOrderBody);
            this.Controls.Add(this.pnlOrderFilter);
            this.Controls.Add(this.pnlOrderHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "frmAdminOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí đơn hàng";
            this.Load += new System.EventHandler(this.frmAdminOrder_Load);
            this.pnlOrderHeader.ResumeLayout(false);
            this.pnlOrderHeader.PerformLayout();
            this.pnlOrderFilter.ResumeLayout(false);
            this.pnlOrderFilter.PerformLayout();
            this.pnlOrderBody.ResumeLayout(false);
            this.splitOrderContent.Panel1.ResumeLayout(false);
            this.splitOrderContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitOrderContent)).EndInit();
            this.splitOrderContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrderHeader;
        private System.Windows.Forms.Panel pnlOrderFilter;
        private System.Windows.Forms.Panel pnlOrderBody;
        private System.Windows.Forms.Label lblOrderDescription;
        private System.Windows.Forms.Label lblOrderTitle;
        private System.Windows.Forms.Button btnSearchOrder;
        private System.Windows.Forms.TextBox txtSearchOrder;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cboFilterPaymentStatus;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnResetOrderFilter;
        private System.Windows.Forms.SplitContainer splitOrderContent;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailLineTotal;
        private System.Windows.Forms.Button btnUpdateOrderStatus;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnViewOrderDetail;
    }
}