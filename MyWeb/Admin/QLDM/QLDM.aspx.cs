using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLDM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataUltil data= new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
            }
        }
        private void LoadCategory()
        {
            // Lấy danh sách sản phẩm từ database
            List<Category> categories = data.listCategory();

            // Gán dữ liệu vào Repeater
            categoryRepeater.DataSource = categories;
            categoryRepeater.DataBind();
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Điều hướng đến trang thêm danh mục (nếu có)
            Response.Redirect("~/Admin/QLDM/AddCategory.aspx");

        }
        protected void EditCategory_Click(object sender, EventArgs e)
        {
            // Lấy ID từ CommandArgument của Button
            Button btnEdit = (Button)sender;
            int categoryId = int.Parse(btnEdit.CommandArgument);

            // Chuyển hướng sang trang sửa sản phẩm
            Response.Redirect($"~/Admin/QLDM/UpdateCategory.aspx?id={categoryId}");
        }
        protected void DeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDeleteCategory = (Button)sender;
                string commandArg = btnDeleteCategory.CommandArgument;

                if (!string.IsNullOrEmpty(commandArg))
                {
                    int categoryId = Convert.ToInt32(commandArg);

                    // Gọi phương thức DeleteProduct để xóa sản phẩm
                    data.deleteCategory(categoryId);
                    // Reload lại danh sách sản phẩm
                    LoadCategory();
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
    }
}