using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLTK
{
    public partial class AddUser : System.Web.UI.Page
    {
        DataUltil data = new DataUltil();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }
        private void LoadRoles()
        {
            try
            {
                DataUltil data = new DataUltil();
                List<Role> roles = data.GetAllRoles();

                // Gán dữ liệu vào DropDownList
                role.DataSource = roles;
                role.DataTextField = "name"; // Thuộc tính hiển thị
                role.DataValueField = "id";  // Giá trị
                role.DataBind();
            }
            catch (Exception ex)
            {
                errorMessage.Text = "Lỗi khi tải danh sách vai trò: " + ex.Message;
            }
        }
        protected void AddUserr_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userName.Text) &&
            !string.IsNullOrEmpty(fullName.Text) &&
            !string.IsNullOrEmpty(email.Text) &&
            !string.IsNullOrEmpty(phone.Text) &&
            !string.IsNullOrEmpty(address.Text))
            {
                try
                {
                    User newUser = new User
                    {
                        userName = userName.Text.Trim(),
                        fullName = fullName.Text,
                        email = email.Text.Trim(),
                        phone = phone.Text.Trim(),
                        address = address.Text,
                        role = int.Parse(role.SelectedValue) // Chuyển đổi vai trò sang số nguyên
                    };
                    data.addUser(newUser);
                    Response.Redirect("QLTaiKhoan.aspx");
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