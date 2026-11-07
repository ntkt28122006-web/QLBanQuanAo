
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanQuanAo
{
    public partial class FrmProductDetail : Form
    {
        private int _productId;
        private product _currentProduct;
        private bool _isLoaded = false;
        public FrmProductDetail(int productId)
        {
            InitializeComponent();
            _productId = productId;

        }

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            _isLoaded = false;
            using (var db = new QLBanHangDataContext())
            {
                _currentProduct = (from p in db.products
                                   where p.id == _productId
                                   select p).FirstOrDefault();
                if (_currentProduct == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!");
                    this.Close();
                    return;
                }

                lblProductName.Text = _currentProduct.name;
                txtDescription.Text = _currentProduct.description;

                decimal giaMacDinh = (_currentProduct.is_sale && _currentProduct.sale_price.HasValue)
                                     ? _currentProduct.sale_price.Value : _currentProduct.price;
                lblPrice.Text = string.Format("{0:N0} VNĐ", giaMacDinh);

                HienThiAnhSanPham(db, _currentProduct.id);


                var arrSizes = (from v in db.product_variants
                                join s in db.product_sizes on v.size_id equals s.id
                                where v.product_id == _productId && v.is_active == true
                                orderby s.sort_order
                                select s.name).Distinct().ToArray();
                cboDetailSize.Items.Clear();
                if (arrSizes.Length > 0)
                {
                    cboDetailSize.Items.AddRange(arrSizes);
                }
                else
                {
                    cboDetailSize.Items.Add("Free size");
                }
                cboDetailSize.SelectedIndex = 0;

                var arrColors = (from v in db.product_variants
                                 join c in db.product_colors on v.color_id equals c.id
                                 where v.product_id == _productId && v.is_active == true
                                 select c.name).Distinct().ToArray();
                cboDetailColor.Items.Clear();
                if (arrColors.Length > 0)
                    cboDetailColor.Items.AddRange(arrColors);
                else
                {
                    cboDetailColor.Items.Add("Mặc định");
                    cboDetailColor.SelectedIndex = 0;
                }
            }
            _isLoaded = true;
            CapNhatTonKhoTheoBienThe();
        }
        private void HienThiAnhSanPham(QLBanHangDataContext db, int productId)
        {
            picProduct.Image = null;
            string dbImagePath = (from img in db.product_images
                                  where img.product_id == productId
                                  orderby img.is_primary descending, img.sort_order
                                  select img.image_url).FirstOrDefault();
            if (!string.IsNullOrEmpty(dbImagePath))
            {
                string cleanPath = dbImagePath.TrimStart('/', '\\').Replace("/", "\\");
                if (!cleanPath.StartsWith("uploads", StringComparison.OrdinalIgnoreCase))
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
        private void CapNhatTonKhoTheoBienThe()
        {
            if (!_isLoaded) return;

            string sizeChon = cboDetailSize.SelectedItem != null ? cboDetailSize.SelectedItem.ToString() : "";
            string mauChon = cboDetailColor.SelectedItem != null ? cboDetailColor.SelectedItem.ToString() : "";

            decimal giaGoc = (_currentProduct.is_sale && _currentProduct.sale_price.HasValue)
                            ? _currentProduct.sale_price.Value : _currentProduct.price;
            lblPrice.Text = string.Format("{0:N0} VNĐ", giaGoc);

            using (var db = new QLBanHangDataContext())
            {
                var spDb = db.products.FirstOrDefault(p => p.id == _productId);
                if (spDb != null && spDb.status != "active")
                {
                    DatTrangThaiHetHang("Trạng thái: Hết hàng");
                    return;
                }
                var bienThe = (from v in db.product_variants
                               join s in db.product_sizes on v.size_id equals s.id into gjS
                               from subS in gjS.DefaultIfEmpty()
                               join c in db.product_colors on v.color_id equals c.id into gjC
                               from subC in gjC.DefaultIfEmpty()
                               join inv in db.inventories on v.id equals inv.variant_id into gjInv
                               from subInv in gjInv.DefaultIfEmpty()
                               where v.product_id == _productId && v.is_active == true
                                   && (sizeChon == "" || sizeChon == "Free size" || (subS != null && subS.name == sizeChon))
                                   && (mauChon == "" || mauChon == "Mặc định" || (subC != null && subC.name == mauChon))
                               select new
                               {
                                   Variant = v,
                                   HexCode = subC != null ? subC.hex_code : null,
                                   SoLuongTon = subInv != null ? subInv.stock_quantity : 0
                               }).FirstOrDefault();
                if (bienThe != null)
                {
                    decimal giaBan = bienThe.Variant.price_override ?? giaGoc;
                    lblPrice.Text = string.Format("{0:N0} VNĐ", giaBan);
                       
                    if (picProduct.Image == null && !string.IsNullOrEmpty(bienThe.HexCode))
                    {
                        picProduct.BackColor = ColorTranslator.FromHtml(bienThe.HexCode.Trim());
                    }
                    
                    if (bienThe.SoLuongTon > 0)
                    {
                        HienThiConHang(bienThe.SoLuongTon);
                    }
                    else
                    {
                        DatTrangThaiHetHang("Trạng Thái: Hết hàng");
                    }
                }
                else
                {
                    bool coBienTheNaoKhong = db.product_variants.Any(v => v.product_id == _productId);
                    if (!coBienTheNaoKhong && _currentProduct.status == "active")
                    {
                        HienThiConHang(100);
                    }
                    else
                    {
                        DatTrangThaiHetHang("Trạng thái: Hết hàng");
                    }
                }


            }
        }
        private void HienThiConHang(int soLuongTon)
        {
            lblStockStatus.Text = "Trang thái: Còn hàng (" + soLuongTon + " Sản phẩm)";
            lblStockStatus.ForeColor = Color.Green;

            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = soLuongTon;
            nudQuantity.Value = 1;
            nudQuantity.Enabled = true;

            btnAddToCart.Enabled = true;
            btnAddToCart.BackColor = Color.FromArgb(238, 77, 45);
            btnAddToCart.Text = "🛒 THÊM VÀO GIỎ HÀNG";
        }
        private void DatTrangThaiHetHang(string msg)
        {
            lblStockStatus.Text = msg;
            lblStockStatus.ForeColor = Color.Crimson;

            nudQuantity.Minimum = 0;
            nudQuantity.Value = 0;
            nudQuantity.Enabled = false;

            btnAddToCart.Enabled = false;
            btnAddToCart.BackColor = Color.Gray;
            btnAddToCart.Text = "TẠM HẾT HÀNG";
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            string sizeChon = cboDetailSize.SelectedItem != null ? cboDetailSize.SelectedItem.ToString() : "Mặc định";
            string mauChon = cboDetailColor.SelectedItem != null ? cboDetailColor.SelectedItem.ToString() : "Mặc định";
            int soLuongMua = (int)nudQuantity.Value;

            MessageBox.Show(
                "Đã thêm sản phẩm vào giỏ hàng thành công!\n\n" +
                "_ Tên sản phẩm: " + _currentProduct.name + "\n" +
                "_ Phân loại Size: " + sizeChon + "\n" +
                "_ Phân loại màu: " + mauChon + "\n" +
                "_ Tổng tiền tạm tính: " + string.Format("{0:N0} VNĐ", _currentProduct.price * soLuongMua),
                "Giỏ hàng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboDetailSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTonKhoTheoBienThe();
        }

        private void cboDetailColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTonKhoTheoBienThe();
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            string sizeChon = cboDetailSize.SelectedItem != null ? cboDetailSize.SelectedItem.ToString() : "";
            string mauChon = cboDetailColor.SelectedItem != null ? cboDetailSize.SelectedItem.ToString() : "";
            int soLuongMua = (int)nudQuantity.Value;

            if (soLuongMua <= 0) return;

            using (var db = new QLBanHangDataContext())
            {
                if (!UserSession.IsLoggedIn)
                {
                    MessageBox.Show("Vui lòng đăng nhập để thêm sản phẩm vào giỏ hàng!", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var variant = (from v in db.product_variants
                               join s in db.product_sizes on v.size_id equals s.id into gjS
                               from subS in gjS.DefaultIfEmpty()
                               join c in db.product_colors on v.color_id equals c.id into gjC
                               from subC in gjC.DefaultIfEmpty()
                               where v.product_id == _productId && v.is_active == true
                                    && (sizeChon == "" || sizeChon == "Free size" || (subS != null && subS.name == sizeChon))
                                    && (mauChon == "" || mauChon == "Mặc định" || (subC != null && subC.name == mauChon))
                               select v).FirstOrDefault();
                if (variant == null)
                {
                    variant = db.product_variants.FirstOrDefault(v => v.product_id == _productId && v.color_id == null && v.size_id == null)
                              ?? db.product_variants.FirstOrDefault(v => v.product_id == _productId);

                    if (variant != null)
                    {
                        variant.is_active = true;
                        db.SubmitChanges();
                    }
                    else
                    {
                        variant = new product_variant
                        {
                            product_id = _productId,
                            sku = "SKU-" + _productId + "-" + DateTime.Now.Ticks.ToString().Substring(10),
                            price_override = null,
                            is_active = true,
                        };
                        db.product_variants.InsertOnSubmit(variant);
                        db.SubmitChanges();
                        inventory newInv = new inventory
                        {
                            variant_id = variant.id,
                            stock_quantity = 100,
                            updated_at = DateTime.Now
                        };
                        db.inventories.InsertOnSubmit(newInv);
                        db.SubmitChanges();
                    }


                }
                var tonKho = (from inv in db.inventories
                              where inv.variant_id == variant.id
                              select inv).FirstOrDefault();
                int slTon = tonKho != null ? tonKho.stock_quantity :100;

                var gioHang = (from c in db.carts
                               where c.user_id == UserSession.CurrentUserId
                               select c).FirstOrDefault();
                if (gioHang == null)
                {
                    gioHang = new cart
                    {
                        user_id = UserSession.CurrentUserId,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    db.carts.InsertOnSubmit(gioHang);
                    db.SubmitChanges();
                }
                var itemTrongGio = (from ci in db.cart_items
                                    where ci.cart_id == gioHang.id && ci.variant_id == variant.id
                                    select ci).FirstOrDefault();
                if (itemTrongGio != null)
                {
                    if (itemTrongGio.quantity + soLuongMua > slTon)
                    {
                        MessageBox.Show("Tổng số lượng trong giỏ vượt quá tồn kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    itemTrongGio.quantity += soLuongMua;
                }
                else
                {
                    cart_item itemMoi = new cart_item
                    {
                        cart_id = gioHang.id,
                        variant_id = variant.id,
                        quantity = soLuongMua,
                        added_at = DateTime.Now
                    };
                    db.cart_items.InsertOnSubmit(itemMoi);
                }
                db.SubmitChanges();

            }
            MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng thành công!", "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void picProduct_Click(object sender, EventArgs e)
        {

        }

        private void lblProductName_Click_1(object sender, EventArgs e)
        {

        }
    }
}
