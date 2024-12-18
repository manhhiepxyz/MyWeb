using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLSP
{
    public partial class DSSP : System.Web.UI.Page
    {
        DataUltil data= new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }

        }
        private void LoadProducts()
        {
            //Lấy danh sách sản phẩm
            List<Product> products = data.listProduct();
            string tableContent= string.Empty;

            //Duyệt qua từng sản phẩm
            foreach (var product in products)
            {
                string imageUrl = string.IsNullOrEmpty(product.image) ? "default.jpg" : product.image;
                string fullImageUrl = ResolveUrl("~/Image/" + imageUrl);
                tableContent +=$@"
                <tr>
                    <th scope='row'>{product.id}</th>
                    <td><img src='{fullImageUrl}' alt='error' style='height: 50px; width: 50px; border-radius: 10px'></td>
                    <td>{product.name}</td>
                    <td>{product.price:N0} VNĐ</td>
                    <td>{product.totalpage}</td>
                    <td>{product.description}</td>
                    <td>{product.author}</td>
                    <td>{product.categoryName}</td>
                    <td>{product.quantity}</td>
                    <td>
                        
                    </td>   

                </tr>";
            }
            tableBody.InnerHtml = tableContent;
        }
        protected void EditProduct(int id)
        {
            // Chuyển hướng tới trang sửa sản phẩm, truyền id sản phẩm qua query string
            Response.Redirect($"~/Admin/QLSP/EditProduct.aspx?id={id}");
        }
        protected void DeleteProduct(int id)    
        {
            try
            {
                data.deleteProduct(id); // Giả sử bạn đã có hàm này trong lớp `DataUltil`
                LoadProducts(); // Refresh lại danh sách sản phẩm
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, nếu có
                Console.WriteLine($"Error deleting product: {ex.Message}");
            }
        }

        protected void Xoa_Click(object sender, EventArgs e)
        {

        }
    }
}