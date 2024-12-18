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
                    <td>{GetCategoryName(product.idCategory)}</td>
                    <td>{}</td>
                    <td><a href='Detail.aspx?id={product.id}' class='btn btn-outline-primary'>Xem</a></td>
                    <td><a href='Edit.aspx?id={product.id}' class='btn btn-outline-primary'>Sửa</a></td>
                    <td><a href='Delete.aspx?id={product.id}' class='btn btn-outline-danger'>Xóa</a></td>
                </tr>";
            }
            tableBody.InnerHtml = tableContent;
        }
        private string GetCategoryName(int categoryId)
        {

        }

      

    }
}