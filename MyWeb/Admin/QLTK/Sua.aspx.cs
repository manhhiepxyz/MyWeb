using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLTK
{
    public partial class Sua : System.Web.UI.Page
    {
        DataUltil data = new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRoles();
            if (!IsPostBack && Request.QueryString["id"] != null)
            {

                int userId = int.Parse(Request.QueryString["id"]);
                DataUltil data = new DataUltil();
                LoadUserDetails(userId);
            }
        }
        private void LoadRoles()
        {
            try
            {
                // Lấy danh sách vai trò từ cơ sở dữ liệu
                List<Role> roles = data.GetAllRoles();

                // Gán danh sách vai trò vào DropDownList
                role.DataSource = roles;
                role.DataTextField = "name";  // Hiển thị tên vai trò
                role.DataValueField = "id";  // Giá trị của vai trò
                role.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi tải danh sách vai trò
                errorMessage.Text = "Lỗi khi tải danh sách vai trò: " + ex.Message;
            }
        }
        private void LoadUserDetails(int userId)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu
            DataUltil data = new DataUltil();
            User user = data.getUserById(userId);

            if (user != null)
            {
                fullName.Text = user.fullName;
                email.Text = user.email;
                phone.Text = user.phone;
                address.Text = user.address;

                // Thiết lập vai trò
                if (role.Items.FindByValue(user.role.ToString()) != null)
                {
                    role.SelectedValue = user.role.ToString();
                }
            }
        }
        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = int.Parse(Request.QueryString["id"]);

                User user = new User
                {
                    id = userId,
                    fullName = fullName.Text,
                    email = email.Text.Trim(),
                    phone = phone.Text.Trim(),
                    address = address.Text,
                    role = int.Parse(role.SelectedValue) // Chuyển đổi giá trị vai trò
                };

                DataUltil data = new DataUltil();
                data.updateUser(user);
                Response.Redirect("~/Admin/QLTK/QLTaiKhoan.aspx");
            }
            catch (Exception ex)
            {
                errorMessage.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }
}