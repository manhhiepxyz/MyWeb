using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLSP
{
    public partial class ThemSP : System.Web.UI.Page
    {
        // Đối tượng DataUltil để thao tác với cơ sở dữ liệu
        DataUltil data = new DataUltil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Chỉ thực hiện khi lần đầu tải trang
            {
                List<Category> categories = data.listCategory();
                category.DataSource = categories;
                category.DataTextField = "name";
                category.DataValueField = "id";
                category.DataBind();

                // Đảm bảo có một lựa chọn mặc định trong DropDownList
                category.Items.Insert(0, new ListItem("-- Chọn thể loại --", "0"));
            }
        }

        // Phương thức xử lý khi người dùng nhấn nút Thêm sản phẩm
        protected void AddProduct(object sender, EventArgs e)
        {
            if (productImage.HasFile && !string.IsNullOrEmpty(productName.Text) &&
                !string.IsNullOrEmpty(price.Text) && !string.IsNullOrEmpty(totalPages.Text) &&
                !string.IsNullOrEmpty(author.Text) && category.SelectedValue != null)
            {
                try
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);
                    string folderPath = Server.MapPath("~/Image/");
                    string filePath = Path.Combine(folderPath, fileName);
                    productImage.SaveAs(filePath);
                    Product newProduct = new Product
                    {
                        name = productName.Text,
                        price = decimal.Parse(price.Text),
                        totalpage = int.Parse(totalPages.Text),
                        description = description.Text,
                        author = author.Text,
                        idCategory = int.Parse(category.SelectedValue),
                        quantity = Convert.ToInt32(quantity.Text),
                        image =  fileName
                    };
                    data.addProduct(newProduct);
                    Response.Redirect("DSSP.aspx");
                }
                catch (Exception ex)
                {
                    errorMessage.Text = "Đã có lỗi xảy ra: " + ex.Message;
                }
            }
            else
            {
                errorMessage.Text = "Vui lòng điền đầy đủ thông tin!";
            }
        }
    }
}
