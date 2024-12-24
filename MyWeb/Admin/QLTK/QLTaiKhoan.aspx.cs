using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Model;

namespace MyWeb.Admin.QLTK
{
    public partial class QLTaiKhoan : System.Web.UI.Page
    {
        DataUltil data = new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
            }
        }
        private void LoadUser()
        {
            // Lấy danh sách sản phẩm từ database
            List<User> users = data.listUser();

            // Gán dữ liệu vào Repeater
            accountRepeater.DataSource = users;
            accountRepeater.DataBind();
        }
        protected void btnAddUserr_Click(object sender, EventArgs e)
        {
            // Logic thêm tài khoản tại đây
            Response.Redirect("~/Admin/QLTK/AddUser.aspx"); // Điều hướng đến trang AddUser
        }
        protected void EditAccount_Click(object sender, EventArgs e)
        {
            // Lấy ID từ CommandArgument của Button
            Button btnEdit = (Button)sender;
            int userId = int.Parse(btnEdit.CommandArgument);

            // Chuyển hướng sang trang sửa sản phẩm
            Response.Redirect($"~/Admin/QLTK/Sua.aspx?id={userId}");
        }
        protected void DeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDelete = (Button)sender;
                string commandArg = btnDelete.CommandArgument;

                if (!string.IsNullOrEmpty(commandArg))
                {
                    int userId = Convert.ToInt32(commandArg);
                    data.deleteUser(userId);
                    LoadUser();
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