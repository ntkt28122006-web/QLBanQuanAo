using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QLBanQuanAo
{
    public partial class frmAdminProduct : Form
    {
        public frmAdminProduct()
        {
            InitializeComponent();
        }

        private void lblPageDescription_Click(object sender, EventArgs e)
        {

        }






        private void pnlProductInfo_Paint(object sender, PaintEventArgs e)
        {

        }











        private void btnResetFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {

        }

        private string selectedImagePath = "";
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn hình ảnh sản phẩm";
                dialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;

                    using (Image source = Image.FromFile(selectedImagePath))
                    {
                        picProductImage.Image = new Bitmap(source);
                    }
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductBrand.Clear();
            txtProductDescription.Clear();

            cboCategory.SelectedIndex = -1;
            cboProductStatus.SelectedIndex = -1;

            numProductPrice.Value = 0;
            numProductSalePrice.Value = 0;

            chkIsHot.Checked = false;
            chkIsSale.Checked = false;

            selectedImagePath = "";

            if (picProductImage.Image != null)
            {
                picProductImage.Image.Dispose();
                picProductImage.Image = null;
            }

            dgvProducts.ClearSelection();
            txtProductName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
