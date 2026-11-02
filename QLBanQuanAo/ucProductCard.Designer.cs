using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace QLBanQuanAo
{
    partial class ucProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picProduct = new PictureBox();
            lblTen = new Label();
            lblGia = new Label();
            lblDetail = new Label();
            btnXem = new Button();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // picProduct
            // 
            picProduct.Location = new Point(10, 10);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(183, 140);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            // 
            // lblTen
            // 
            lblTen.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTen.Location = new Point(10, 158);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(190, 40);
            lblTen.TabIndex = 1;
            lblTen.Text = "Tên";
            lblTen.Click += lblTen_Click;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGia.ForeColor = Color.FromArgb(238, 77, 45);
            lblGia.Location = new Point(10, 198);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(32, 20);
            lblGia.TabIndex = 2;
            lblGia.Text = "Giá";
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetail.ForeColor = Color.DimGray;
            lblDetail.Location = new Point(10, 222);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(57, 13);
            lblDetail.TabIndex = 3;
            lblDetail.Text = "Thông tin";
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(238, 77, 45);
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(10, 245);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(183, 30);
            btnXem.TabIndex = 4;
            btnXem.Text = "Xem chi tiết";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // ucProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXem);
            Controls.Add(lblDetail);
            Controls.Add(lblGia);
            Controls.Add(lblTen);
            Controls.Add(picProduct);
            Name = "ucProductCard";
            Size = new Size(205, 285);
            Load += ucProductCard_Load;
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProduct;
        private Label lblTen;
        private Label lblGia;
        private Label lblDetail;
        private Button btnXem;
    }
}
