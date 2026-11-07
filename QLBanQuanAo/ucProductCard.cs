using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class ucProductCard : UserControl
    {
        private int _productId;
        public ucProductCard()
        {
            InitializeComponent();
        }
        public void SetData(product sp)
        {
            _productId = sp.id;
            lblTen.Text = sp.name;

            decimal giaHienThi = (sp.is_sale && sp.sale_price.HasValue) ? sp.sale_price.Value : sp.price;
            lblGia.Text = string.Format("{0:N0} VNĐ", giaHienThi);

           using (var db = new QLBanHangDataContext())
            {
                var listSizes = (from v in db.product_variants
                                 join s in db.product_sizes on v.size_id equals s.id
                                 where v.product_id == sp.id && v.is_active == true
                                 orderby s.sort_order
                                 select s.name).Distinct().ToList();
                var maMauHex = (from v in db.product_variants
                                join c in db.product_colors on v.color_id equals c.id
                                where v.product_id == sp.id && v.is_active == true
                                select c.hex_code).FirstOrDefault();
                lblDetail.Text = "Size: " + (listSizes.Any() ? string.Join(",", listSizes) : "Free size");

                if (!string.IsNullOrEmpty(maMauHex))
                {
                    picProduct.BackColor = ColorTranslator.FromHtml(maMauHex.Trim());
                }
                else
                {
                    picProduct.BackColor = Color.Gainsboro;
                }
                picProduct.Image = null;

                string dbImagePath = (from img in db.product_images
                                      where img.product_id == sp.id 
                                      orderby img.is_primary descending, img.sort_order
                                      select img.image_url).FirstOrDefault();
                if (!string.IsNullOrEmpty(dbImagePath))
                {
                    string cleanPath = dbImagePath.TrimStart('/', '\\').Replace("/", "\\");
                    if (!cleanPath.StartsWith("Uploads\\Products", StringComparison.OrdinalIgnoreCase))
                    {
                        cleanPath = Path.Combine("Uploads", "Products", cleanPath);
                    }
                    string fullPath = Path.Combine(Application.StartupPath, cleanPath);
                    if (!File.Exists(fullPath))
                    {
                        string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                        fullPath = Path.Combine(projectRoot, cleanPath);
                    }
                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                picProduct.Image = Image.FromStream(stream);
                            }
                            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch
                        {

                        }
                    }
                }

            }
        }

        private void ucProductCard_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
          
            FrmProductDetail frm = new FrmProductDetail(_productId);
            frm.ShowDialog();
        }

        private void lblTen_Click(object sender, EventArgs e)
        {

        }

        private void lblTen_Click_1(object sender, EventArgs e)
        {

        }
    }
}
