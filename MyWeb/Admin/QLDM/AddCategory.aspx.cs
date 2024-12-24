using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MyWeb.Model;

namespace MyWeb.Admin.QLDM
{
    public partial class AddCategory : System.Web.UI.Page
    {
        DataUltil data= new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddCategoryy(object sender, EventArgs e)
        {
            if (categoryImage.HasFile && !string.IsNullOrEmpty(categoryName.Text))
            {
                try
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryImage.FileName);
                    string folderPath = Server.MapPath("~/Image/");
                    string filePath = Path.Combine(folderPath, fileName);
                    categoryImage.SaveAs(filePath);
                    Category newCategory = new Category
                    {
                        name = categoryName.Text,
                        image = fileName
                    };
                    data.addCategory(newCategory);
                    Response.Redirect("QLDM.aspx");
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