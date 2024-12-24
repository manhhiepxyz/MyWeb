using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLSP
{
    public partial class DSSP : System.Web.UI.Page
    {
        private readonly DataUltil data = new DataUltil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            // Lấy danh sách sản phẩm từ database
            List<Product> products = data.listProduct();

            // Gán dữ liệu vào Repeater
            productRepeater.DataSource = products;
            productRepeater.DataBind();
        }

        protected void EditProduct_Click(object sender, EventArgs e)
        {
            // Lấy ID từ CommandArgument của Button
            Button btnEdit = (Button)sender;
            int productId = int.Parse(btnEdit.CommandArgument);

            // Chuyển hướng sang trang sửa sản phẩm
            Response.Redirect($"~/Admin/QLSP/Sua.aspx?id={productId}");
        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDeleteProduct = (Button)sender;
                string commandArg = btnDeleteProduct.CommandArgument;

                if (!string.IsNullOrEmpty(commandArg))
                {
                    int productId = Convert.ToInt32(commandArg);

                    // Gọi phương thức DeleteProduct để xóa sản phẩm
                    data.DeleteProduct(productId);
                    // Reload lại danh sách sản phẩm
                    LoadProducts();
                }
                else
                {
                    msg.Text = "Không tìm thấy ID sản phẩm để xóa.";
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                msg.Text = "Error deleting product: " + ex.Message;
            }
        }
        protected string TruncateDescription(string description, int maxLength)
        {
            if (string.IsNullOrEmpty(description))
                return string.Empty;

            if (description.Length <= maxLength)
                return description;

            return description.Substring(0, maxLength) + "...";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Nếu không có từ khóa tìm kiếm, load lại danh sách sản phẩm đầy đủ
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadProducts();
            }
            else
            {
                // Lọc danh sách sản phẩm dựa trên từ khóa tìm kiếm
                List<Product> filteredProducts = data.listProduct()
                    .Where(p => p.name.ToLower().Contains(searchTerm.ToLower())) // Tìm kiếm không phân biệt chữ hoa chữ thường
                    .ToList();

                // Gán dữ liệu vào Repeater sau khi lọc
                productRepeater.DataSource = filteredProducts;
                productRepeater.DataBind();
            }
        }

        protected void productRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Bạn có thể xử lý các lệnh khác từ Repeater ở đây (nếu cần)
        }
    }
}
