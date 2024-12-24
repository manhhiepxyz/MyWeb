using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLDM
{
    public partial class UpdateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int categoryId = int.Parse(Request.QueryString["id"]);
                DataUltil data = new DataUltil();
                // Load thông tin sản phẩm
                LoadCategoryDetails(categoryId);
            }
        }
        private void LoadCategoryDetails(int categoryId)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu
            DataUltil data = new DataUltil();
            Category category = data.getCategoryById(categoryId); 

            if (category != null)
            {
                categoryName.Text = category.name;
            }
        }
        protected void UpdateCategoryy(object sender, EventArgs e)
        {
            try
            {
                int categoryId = int.Parse(Request.QueryString["id"]);
                string name = categoryName.Text;
                string image = null;
                if (categoryImage.HasFile)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryImage.FileName);
                    string folderPath = Server.MapPath("~/Image/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filePath = Path.Combine(folderPath, fileName);
                    categoryImage.SaveAs(filePath);
                    image = fileName;
                }
                else
                {
                    image = null;
                }
                Category category = new Category
                {
                    id = categoryId,
                    name = name,
                    image = image 
                };

                DataUltil data = new DataUltil();
                data.updateCategory(category);
                Response.Redirect("~/Admin/QLDM/QLDM.aspx");
            }
            catch (Exception ex)
            {
                errorMessage.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }
}