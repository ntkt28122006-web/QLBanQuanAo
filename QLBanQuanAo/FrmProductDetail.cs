
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
           // this.Load += FrmProductDetail_Load;

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

                var arrSizes = (from v in db.product_variants
                                join s in db.product_sizes on v.size_id equals s.id
                                where v.product_id == _productId && v.is_active == true
                                orderby s.sort_order
                                select s.name).Distinct().ToArray();
                cboDetailSize.Items.Clear();
                cboDetailSize.Items.AddRange(arrSizes);
                if (cboDetailSize.Items.Count > 0) cboDetailSize.SelectedIndex = 0;

                var arrColors = (from v in db.product_variants
                                 join c in db.product_colors on v.color_id equals c.id
                                 where v.product_id == _productId && v.is_active == true
                                 select c.name).Distinct().ToArray();
                cboDetailColor.Items.Clear();
                cboDetailColor.Items.AddRange(arrColors);
                if ( cboDetailColor.Items.Count > 0) cboDetailColor.SelectedIndex = 0;
                                 
            }
            _isLoaded = true;
            CapNhatTonKhoTheoBienThe();
        }
        private void CapNhatTonKhoTheoBienThe()
        {
            if (!_isLoaded) return;

            string sizeChon = cboDetailSize.SelectedItem != null ? cboDetailSize.SelectedItem.ToString() : "";
            string mauChon = cboDetailColor.SelectedItem != null ? cboDetailColor.SelectedItem.ToString() : "";

            using (var db = new QLBanHangDataContext())
            {
                var bienThe = (from v in db.product_variants
                               join s in db.product_sizes on v.size_id equals s.id into gjS
                               from subS in gjS.DefaultIfEmpty()
                               join c in db.product_colors on v.color_id equals c.id into gjC
                               from subC in gjC.DefaultIfEmpty()
                               join inv in db.inventories on v.id equals inv.variant_id into gjInv
                               from subInv in gjInv.DefaultIfEmpty()
                               where v.product_id == _productId
                                   && (sizeChon == "" || subS.name == sizeChon)
                                   && (mauChon == "" || subC.name == mauChon)
                               select new
                               {
                                   Variant = v,
                                   HexCode = subC != null ? subC.hex_code : null,
                                   SoLuongTon = subInv != null ? subInv.stock_quantity : 0
                               }).FirstOrDefault();
                if (bienThe != null)
                {
                    decimal giaBan = bienThe.Variant.price_override
                        ?? ((_currentProduct.is_sale && _currentProduct.sale_price.HasValue) ? _currentProduct.sale_price.Value : _currentProduct.price);
                    lblPrice.Text = string.Format("{0:N)} VNĐ", giaBan);

                    if (!string.IsNullOrEmpty(bienThe.HexCode))
                        picProduct.BackColor = ColorTranslator.FromHtml(bienThe.HexCode.Trim());
                    if (bienThe.SoLuongTon > 0)
                    {
                        lblStockStatus.Text = "Trạng thái: Còn Hàng (" + bienThe.SoLuongTon + " sản phẩm)";
                        lblStockStatus.ForeColor = Color.SeaGreen;

                        nudQuantity.Minimum = 1;
                        nudQuantity.Maximum = bienThe.SoLuongTon;
                        nudQuantity.Value = 1;
                        nudQuantity.Enabled = true;

                        btnAddToCart.Enabled = true;
                        btnAddToCart.BackColor = Color.FromArgb(238, 77, 45);
                        btnAddToCart.Text = "🛒 THÊM VÀO GIỎ HÀNG";
                    }
                    else
                    {
                        DatTrangThaiHetHang("Trạng Thái: Hết hàng");
                    }
                }
                else
                {
                    DatTrangThaiHetHang("Trạng thái: Tạm hết mẫu Size/Màu này");
                }


            }
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

            using (var db = new QLBanHangDataContext())
            {
                var variant = (from v in db.product_variants
                               join s in db.product_sizes on v.size_id equals s.id into gjS
                               from subS in gjS.DefaultIfEmpty()
                               join c in db.product_colors on v.color_id equals c.id into gjC
                               from subC in gjC.DefaultIfEmpty()
                               where v.product_id == _productId
                                    && (sizeChon == "" || subS.name == sizeChon)
                                    && (mauChon == "" || subC.name == mauChon)
                               select v).FirstOrDefault();
                if (variant == null)
                {
                    MessageBox.Show("Không tìm thấy biến thể sản phẩm!", "Lỗi");
                    return;
                }

                var tonKho = (from inv in db.inventories
                              where inv.variant_id == variant.id
                              select inv).FirstOrDefault();
                int slTon = tonKho != null ? tonKho.stock_quantity : 0;

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
    }
}
