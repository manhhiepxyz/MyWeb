using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLSP
{
    public partial class Sua : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu có tham số 'id' trong URL thì tải thông tin sản phẩm
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int productId = int.Parse(Request.QueryString["id"]);
                DataUltil data = new DataUltil();
                List<Category> categories = data.listCategory();

                category.DataSource = categories;
                category.DataTextField = "name";  // Hiển thị tên thể loại
                category.DataValueField = "id";  // Lưu ID thể loại
                category.DataBind();

                // Đảm bảo có một lựa chọn mặc định
                category.Items.Insert(0, new ListItem("-- Chọn thể loại --", "0"));

                // Load thông tin sản phẩm
                LoadProductDetails(productId);
            }
        }

        private void LoadProductDetails(int productId)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu
            DataUltil data = new DataUltil();
            Product product = data.GetProductById(productId); // Thêm phương thức GetProductById trong DataUltil để lấy thông tin sản phẩm
            
            if (product != null)
            {
                productName.Text = product.name;
                price.Text = product.price.ToString();
                totalPages.Text = product.totalpage.ToString();
                description.Text = product.description;
                author.Text = product.author;
                quantity.Text = product.quantity.ToString();
                category.SelectedValue = product.idCategory.ToString(); // Giả sử bạn đã load danh sách thể loại vào dropdown
            }
        }

        protected void UpdateProduct(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các điều khiển
                int productId = int.Parse(Request.QueryString["id"]);
                string name = productName.Text;
                decimal productPrice = decimal.Parse(price.Text);
                int totalpage = int.Parse(totalPages.Text);
                string desc = description.Text;
                string authorName = author.Text;
                int qty = int.Parse(quantity.Text);
                int categoryId = int.Parse(category.SelectedValue);

                // Kiểm tra nếu người dùng có tải ảnh mới lên
                string image = null;
                if (productImage.HasFile)
                {
                    // Tạo tên file duy nhất bằng GUID để tránh trùng lặp
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);

                    // Đảm bảo thư mục ~/Images/ tồn tại
                    string folderPath = Server.MapPath("~/Image/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    
                    string filePath = Path.Combine(folderPath, fileName);

                    // Lưu ảnh vào thư mục
                    productImage.SaveAs(filePath);

                    // Lưu đường dẫn ảnh vào biến image
                    image = fileName; // Đường dẫn sẽ sử dụng khi lưu vào CSDL
                }
                // Nếu không có ảnh tải lên, giá trị image sẽ là null
                else
                {
                    image = null;
                }


                // Tạo đối tượng Product và cập nhật vào cơ sở dữ liệu
                Product product = new Product
                {
                    id = productId,
                    name = name,
                    price = productPrice,
                    totalpage = totalpage,
                    description = desc,
                    author = authorName,
                    quantity = qty,
                    idCategory = categoryId,
                    image = image // Nếu có ảnh mới
                };

                DataUltil data = new DataUltil();
                data.updateProduct(product); // Gọi phương thức updateProduct để lưu vào cơ sở dữ liệu

                // Chuyển hướng về trang danh sách sản phẩm
                Response.Redirect("~/Admin/QLSP/DSSP.aspx");
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                errorMessage.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }
}
