namespace QLBanQuanAo
{
    partial class frmCategory
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
            this.pnlCategoryHeader = new System.Windows.Forms.Panel();
            this.lblCategoryDescription = new System.Windows.Forms.Label();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.pnlCategoryInfo = new System.Windows.Forms.Panel();
            this.btnClearCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.chkCategoryActive = new System.Windows.Forms.CheckBox();
            this.cboParentCategory = new System.Windows.Forms.ComboBox();
            this.lblParentCategory = new System.Windows.Forms.Label();
            this.txtCategorySlug = new System.Windows.Forms.TextBox();
            this.lblCategorySlug = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.pnlCategoryList = new System.Windows.Forms.Panel();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.colCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategorySlug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCategoryHeader.SuspendLayout();
            this.pnlCategoryInfo.SuspendLayout();
            this.pnlCategoryList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCategoryHeader
            // 
            this.pnlCategoryHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlCategoryHeader.Controls.Add(this.lblCategoryDescription);
            this.pnlCategoryHeader.Controls.Add(this.lblCategoryTitle);
            this.pnlCategoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategoryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlCategoryHeader.Name = "pnlCategoryHeader";
            this.pnlCategoryHeader.Size = new System.Drawing.Size(1228, 80);
            this.pnlCategoryHeader.TabIndex = 0;
            // 
            // lblCategoryDescription
            // 
            this.lblCategoryDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryDescription.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCategoryDescription.Location = new System.Drawing.Point(65, 55);
            this.lblCategoryDescription.Name = "lblCategoryDescription";
            this.lblCategoryDescription.Size = new System.Drawing.Size(500, 22);
            this.lblCategoryDescription.TabIndex = 1;
            this.lblCategoryDescription.Text = "Quản lý và phân loại các sản phẩm thời trang";
            this.lblCategoryDescription.Click += new System.EventHandler(this.lblCategoryDescription_Click);
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryTitle.ForeColor = System.Drawing.Color.White;
            this.lblCategoryTitle.Location = new System.Drawing.Point(28, 1);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(476, 54);
            this.lblCategoryTitle.TabIndex = 0;
            this.lblCategoryTitle.Text = "QUẢN LÝ DANH MỤC";
            // 
            // pnlCategoryInfo
            // 
            this.pnlCategoryInfo.BackColor = System.Drawing.Color.White;
            this.pnlCategoryInfo.Controls.Add(this.btnClearCategory);
            this.pnlCategoryInfo.Controls.Add(this.btnDeleteCategory);
            this.pnlCategoryInfo.Controls.Add(this.btnUpdateCategory);
            this.pnlCategoryInfo.Controls.Add(this.btnAddCategory);
            this.pnlCategoryInfo.Controls.Add(this.chkCategoryActive);
            this.pnlCategoryInfo.Controls.Add(this.cboParentCategory);
            this.pnlCategoryInfo.Controls.Add(this.lblParentCategory);
            this.pnlCategoryInfo.Controls.Add(this.txtCategorySlug);
            this.pnlCategoryInfo.Controls.Add(this.lblCategorySlug);
            this.pnlCategoryInfo.Controls.Add(this.txtCategoryName);
            this.pnlCategoryInfo.Controls.Add(this.lblCategoryName);
            this.pnlCategoryInfo.Controls.Add(this.txtCategoryId);
            this.pnlCategoryInfo.Controls.Add(this.lblCategoryId);
            this.pnlCategoryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategoryInfo.Location = new System.Drawing.Point(0, 80);
            this.pnlCategoryInfo.Name = "pnlCategoryInfo";
            this.pnlCategoryInfo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCategoryInfo.Size = new System.Drawing.Size(1228, 195);
            this.pnlCategoryInfo.TabIndex = 1;
            // 
            // btnClearCategory
            // 
            this.btnClearCategory.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClearCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCategory.FlatAppearance.BorderSize = 0;
            this.btnClearCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCategory.ForeColor = System.Drawing.Color.Black;
            this.btnClearCategory.Location = new System.Drawing.Point(914, 156);
            this.btnClearCategory.Name = "btnClearCategory";
            this.btnClearCategory.Size = new System.Drawing.Size(180, 36);
            this.btnClearCategory.TabIndex = 8;
            this.btnClearCategory.Text = "Làm mới";
            this.btnClearCategory.UseVisualStyleBackColor = false;
            this.btnClearCategory.Click += new System.EventHandler(this.btnClearCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCategory.FlatAppearance.BorderSize = 0;
            this.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCategory.Location = new System.Drawing.Point(693, 155);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(180, 36);
            this.btnDeleteCategory.TabIndex = 7;
            this.btnDeleteCategory.Text = "Xóa danh mục";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnUpdateCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCategory.FlatAppearance.BorderSize = 0;
            this.btnUpdateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCategory.Location = new System.Drawing.Point(914, 99);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(180, 36);
            this.btnUpdateCategory.TabIndex = 6;
            this.btnUpdateCategory.Text = "Cập nhật";
            this.btnUpdateCategory.UseVisualStyleBackColor = false;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCategory.FlatAppearance.BorderSize = 0;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(693, 99);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(180, 36);
            this.btnAddCategory.TabIndex = 5;
            this.btnAddCategory.Text = "Thêm danh mục";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // chkCategoryActive
            // 
            this.chkCategoryActive.Checked = true;
            this.chkCategoryActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCategoryActive.Location = new System.Drawing.Point(474, 43);
            this.chkCategoryActive.Name = "chkCategoryActive";
            this.chkCategoryActive.Size = new System.Drawing.Size(183, 40);
            this.chkCategoryActive.TabIndex = 4;
            this.chkCategoryActive.Text = "Đang hoạt động";
            this.chkCategoryActive.UseVisualStyleBackColor = true;
            this.chkCategoryActive.CheckedChanged += new System.EventHandler(this.chkCategoryActive_CheckedChanged);
            // 
            // cboParentCategory
            // 
            this.cboParentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentCategory.FormattingEnabled = true;
            this.cboParentCategory.Location = new System.Drawing.Point(245, 115);
            this.cboParentCategory.Name = "cboParentCategory";
            this.cboParentCategory.Size = new System.Drawing.Size(250, 36);
            this.cboParentCategory.TabIndex = 3;
            this.cboParentCategory.SelectedIndexChanged += new System.EventHandler(this.cboParentCategory_SelectedIndexChanged);
            // 
            // lblParentCategory
            // 
            this.lblParentCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblParentCategory.Location = new System.Drawing.Point(245, 82);
            this.lblParentCategory.Name = "lblParentCategory";
            this.lblParentCategory.Size = new System.Drawing.Size(180, 30);
            this.lblParentCategory.TabIndex = 3;
            this.lblParentCategory.Text = "Danh mục cha";
            // 
            // txtCategorySlug
            // 
            this.txtCategorySlug.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCategorySlug.Location = new System.Drawing.Point(25, 115);
            this.txtCategorySlug.Name = "txtCategorySlug";
            this.txtCategorySlug.ReadOnly = true;
            this.txtCategorySlug.Size = new System.Drawing.Size(180, 34);
            this.txtCategorySlug.TabIndex = 2;
            this.txtCategorySlug.TextChanged += new System.EventHandler(this.txtCategorySlug_TextChanged);
            // 
            // lblCategorySlug
            // 
            this.lblCategorySlug.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorySlug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblCategorySlug.Location = new System.Drawing.Point(25, 82);
            this.lblCategorySlug.Name = "lblCategorySlug";
            this.lblCategorySlug.Size = new System.Drawing.Size(180, 30);
            this.lblCategorySlug.TabIndex = 2;
            this.lblCategorySlug.Text = "Slug";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCategoryName.Location = new System.Drawing.Point(245, 45);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(180, 34);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.TextChanged += new System.EventHandler(this.txtCategoryName_TextChanged);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblCategoryName.Location = new System.Drawing.Point(245, 12);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(180, 30);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Tên danh mục";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCategoryId.Location = new System.Drawing.Point(25, 45);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.ReadOnly = true;
            this.txtCategoryId.Size = new System.Drawing.Size(180, 34);
            this.txtCategoryId.TabIndex = 0;
            this.txtCategoryId.TextChanged += new System.EventHandler(this.txtCategoryId_TextChanged);
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblCategoryId.Location = new System.Drawing.Point(25, 12);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(180, 30);
            this.lblCategoryId.TabIndex = 0;
            this.lblCategoryId.Text = "Mã danh mục";
            // 
            // pnlCategoryList
            // 
            this.pnlCategoryList.BackColor = System.Drawing.Color.White;
            this.pnlCategoryList.Controls.Add(this.dgvCategories);
            this.pnlCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoryList.Location = new System.Drawing.Point(0, 275);
            this.pnlCategoryList.Name = "pnlCategoryList";
            this.pnlCategoryList.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCategoryList.Size = new System.Drawing.Size(1228, 389);
            this.pnlCategoryList.TabIndex = 3;
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.ColumnHeadersHeight = 40;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoryId,
            this.colCategoryName,
            this.colCategorySlug,
            this.colCategoryParent,
            this.colCategoryStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.EnableHeadersVisualStyles = false;
            this.dgvCategories.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCategories.Location = new System.Drawing.Point(15, 15);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 62;
            this.dgvCategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCategories.RowTemplate.Height = 35;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(1198, 359);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            this.dgvCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            // 
            // colCategoryId
            // 
            this.colCategoryId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoryId.DataPropertyName = "id";
            this.colCategoryId.HeaderText = "Mã danh mục";
            this.colCategoryId.MinimumWidth = 8;
            this.colCategoryId.Name = "colCategoryId";
            this.colCategoryId.ReadOnly = true;
            // 
            // colCategoryName
            // 
            this.colCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoryName.DataPropertyName = "name";
            this.colCategoryName.HeaderText = "Tên danh mục";
            this.colCategoryName.MinimumWidth = 8;
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.ReadOnly = true;
            // 
            // colCategorySlug
            // 
            this.colCategorySlug.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategorySlug.DataPropertyName = "slug";
            this.colCategorySlug.HeaderText = "Slug";
            this.colCategorySlug.MinimumWidth = 8;
            this.colCategorySlug.Name = "colCategorySlug";
            this.colCategorySlug.ReadOnly = true;
            // 
            // colCategoryParent
            // 
            this.colCategoryParent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoryParent.DataPropertyName = "parent_name";
            this.colCategoryParent.HeaderText = "Danh mục cha";
            this.colCategoryParent.MinimumWidth = 8;
            this.colCategoryParent.Name = "colCategoryParent";
            this.colCategoryParent.ReadOnly = true;
            // 
            // colCategoryStatus
            // 
            this.colCategoryStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoryStatus.DataPropertyName = "is_active";
            this.colCategoryStatus.HeaderText = "Trạng thái";
            this.colCategoryStatus.MinimumWidth = 8;
            this.colCategoryStatus.Name = "colCategoryStatus";
            this.colCategoryStatus.ReadOnly = true;
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1228, 664);
            this.Controls.Add(this.pnlCategoryList);
            this.Controls.Add(this.pnlCategoryInfo);
            this.Controls.Add(this.pnlCategoryHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh mục";
            this.pnlCategoryHeader.ResumeLayout(false);
            this.pnlCategoryInfo.ResumeLayout(false);
            this.pnlCategoryInfo.PerformLayout();
            this.pnlCategoryList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCategoryHeader;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.Label lblCategoryDescription;
        private System.Windows.Forms.Panel pnlCategoryInfo;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.Label lblCategorySlug;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.ComboBox cboParentCategory;
        private System.Windows.Forms.Label lblParentCategory;
        private System.Windows.Forms.TextBox txtCategorySlug;
        private System.Windows.Forms.CheckBox chkCategoryActive;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnClearCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Panel pnlCategoryList;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategorySlug;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryStatus;
    }
}