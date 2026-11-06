using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace QLBanQuanAo
{
    partial class FrmProductDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductDetail));
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStockStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDetailSize = new System.Windows.Forms.ComboBox();
            this.lblColorTitle = new System.Windows.Forms.Label();
            this.cboDetailColor = new System.Windows.Forms.ComboBox();
            this.lblQtyTitle = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(28, 27);
            this.picProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(366, 406);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            this.picProduct.Click += new System.EventHandler(this.picProduct_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(428, 37);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(457, 37);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Tên sản phẩm";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblPrice.Location = new System.Drawing.Point(428, 69);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(88, 32);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "0 VNĐ";
            // 
            // lblStockStatus
            // 
            this.lblStockStatus.AutoSize = true;
            this.lblStockStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockStatus.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblStockStatus.Location = new System.Drawing.Point(428, 107);
            this.lblStockStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockStatus.Name = "lblStockStatus";
            this.lblStockStatus.Size = new System.Drawing.Size(178, 23);
            this.lblStockStatus.TabIndex = 3;
            this.lblStockStatus.Text = "Trạng thái: Còn hàng";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(428, 144);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(144, 23);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả sản phẩm:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(428, 171);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(457, 80);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn Size:";
            // 
            // cboDetailSize
            // 
            this.cboDetailSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailSize.FormattingEnabled = true;
            this.cboDetailSize.Location = new System.Drawing.Point(572, 268);
            this.cboDetailSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDetailSize.Name = "cboDetailSize";
            this.cboDetailSize.Size = new System.Drawing.Size(205, 24);
            this.cboDetailSize.TabIndex = 7;
            this.cboDetailSize.SelectedIndexChanged += new System.EventHandler(this.cboDetailSize_SelectedIndexChanged);
            // 
            // lblColorTitle
            // 
            this.lblColorTitle.AutoSize = true;
            this.lblColorTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorTitle.Location = new System.Drawing.Point(428, 315);
            this.lblColorTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColorTitle.Name = "lblColorTitle";
            this.lblColorTitle.Size = new System.Drawing.Size(94, 23);
            this.lblColorTitle.TabIndex = 8;
            this.lblColorTitle.Text = "Chọn màu:";
            // 
            // cboDetailColor
            // 
            this.cboDetailColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailColor.FormattingEnabled = true;
            this.cboDetailColor.Location = new System.Drawing.Point(572, 311);
            this.cboDetailColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDetailColor.Name = "cboDetailColor";
            this.cboDetailColor.Size = new System.Drawing.Size(205, 24);
            this.cboDetailColor.TabIndex = 9;
            this.cboDetailColor.SelectedIndexChanged += new System.EventHandler(this.cboDetailColor_SelectedIndexChanged);
            // 
            // lblQtyTitle
            // 
            this.lblQtyTitle.AutoSize = true;
            this.lblQtyTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyTitle.Location = new System.Drawing.Point(434, 361);
            this.lblQtyTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtyTitle.Name = "lblQtyTitle";
            this.lblQtyTitle.Size = new System.Drawing.Size(82, 23);
            this.lblQtyTitle.TabIndex = 10;
            this.lblQtyTitle.Text = "Số lượng:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(572, 354);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(115, 22);
            this.nudQuantity.TabIndex = 11;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(428, 411);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(252, 48);
            this.btnAddToCart.TabIndex = 12;
            this.btnAddToCart.Text = "🛒 THÊM VÀO GIỎ HÀNG";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(697, 411);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "QUAY LẠI";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 514);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblQtyTitle);
            this.Controls.Add(this.cboDetailColor);
            this.Controls.Add(this.lblColorTitle);
            this.Controls.Add(this.cboDetailSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblStockStatus);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.picProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmProductDetail";
            this.Text = "FrmProductDetail";
            this.Load += new System.EventHandler(this.FrmProductDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picProduct;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblStockStatus;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label label1;
        private ComboBox cboDetailSize;
        private Label lblColorTitle;
        private ComboBox cboDetailColor;
        private Label lblQtyTitle;
        private NumericUpDown nudQuantity;
        private Button btnAddToCart;
        private Button button1;
    }
}