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
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.Location = new System.Drawing.Point(9, 9);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(157, 121);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(9, 137);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(163, 35);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Tên";
            this.lblTen.Click += new System.EventHandler(this.lblTen_Click_1);
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblGia.Location = new System.Drawing.Point(9, 172);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(32, 20);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetail.Location = new System.Drawing.Point(9, 192);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(57, 13);
            this.lblDetail.TabIndex = 3;
            this.lblDetail.Text = "Thông tin";
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(9, 212);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(157, 26);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem chi tiết";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // ucProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.picProduct);
            this.Name = "ucProductCard";
            this.Size = new System.Drawing.Size(176, 247);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picProduct;
        private Label lblTen;
        private Label lblGia;
        private Label lblDetail;
        private Button btnXem;
    }
}
