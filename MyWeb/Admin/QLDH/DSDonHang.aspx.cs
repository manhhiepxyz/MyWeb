using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.DTO;
using MyWeb.Model;

namespace MyWeb.Admin.QLDH
{
    public partial class DSDonHang : System.Web.UI.Page
    {
        private DataUltil data = new DataUltil();

        // Phương thức Page_Load để kiểm tra lần đầu tiên tải trang
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }
        private void LoadFakeData()
        {
            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("ShippingAddress");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("OrderDate", typeof(DateTime));
            dt.Columns.Add("PaymentStatus");
            dt.Columns.Add("OrderStatus");

            // Thêm dữ liệu mẫu
            dt.Rows.Add("123 Trần Hưng Đạo, Hà Nội", "Nguyễn Văn A", DateTime.Now.AddDays(-3), "Đã thanh toán", "Chờ xử lý");
            dt.Rows.Add("456 Lê Lợi, TP. Hồ Chí Minh", "Trần Thị B", DateTime.Now.AddDays(-2), "Chưa thanh toán", "Hoàn thành");
            dt.Rows.Add("789 Nguyễn Huệ, Đà Nẵng", "Phạm Văn C", DateTime.Now.AddDays(-1), "Đã thanh toán", "Đã hủy");

            // Gán dữ liệu cho Repeater
            OrdersRepeater.DataSource = dt;
            OrdersRepeater.DataBind();
        }
        private void LoadOrders()
        {
            try
            {
                BindOrdersToRepeater();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi tải đơn hàng: {ex.Message}");
            }
        }
        protected void FilterOrders_Click(object sender, EventArgs e)
        {
            // Lấy trạng thái được chọn từ dropdown
            string statusFilter = ddlStatuFilter.Value; // Dùng SelectedValue thay vì Value

            // Nếu không chọn trạng thái nào (trạng thái mặc định "Tất cả trạng thái"), thì tải lại tất cả đơn hàng
            if (string.IsNullOrEmpty(statusFilter))
            {
                LoadOrders(); // Load tất cả đơn hàng nếu không có trạng thái nào được chọn
            }
            else
            {
                // Lọc các đơn hàng theo trạng thái đã chọn
                List<OrderDTO> filteredOrders = data.listOrder()
                    .Where(order => order.status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)) // So sánh không phân biệt chữ hoa chữ thường
                    .ToList();

                // Gán danh sách đơn hàng đã lọc vào Repeater và cập nhật giao diện
                OrdersRepeater.DataSource = filteredOrders;
                OrdersRepeater.DataBind();
            }
        }





        protected void ViewOrder_Click(object sender, EventArgs e)
        {
                Button btnXemDonHang = (Button)sender;
            int orderId = int.Parse(btnXemDonHang.CommandArgument);
                
                    Response.Redirect($"~/Admin/QLDH/XemDonHang.aspx?orderId={orderId}");
        }


        protected void ConfirmOrder_Click(object sender, EventArgs e)
        {
            // Lấy Button vừa được click
            Button btn = sender as Button;
            if (btn != null)
            {
                // Lấy orderId từ CommandArgument
                int orderId = Convert.ToInt32(btn.CommandArgument);
            }
        }
        protected void UpdateStatus_Click(object sender, EventArgs e)
        {
            // Lấy nút đã được nhấn
            Button btn = (Button)sender;

            // Lấy CommandArgument (orderId) từ nút nhấn
            int orderId = Convert.ToInt32(btn.CommandArgument);

            // Lấy DropDownList trong cùng một hàng
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            DropDownList ddlStatus = (DropDownList)item.FindControl("ddlStatus");
            // Lấy giá trị trạng thái đã chọn
            string selectedStatus = ddlStatus.SelectedValue;
            data.CapNhapDonHang(selectedStatus, orderId);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật trạng thái thành công!');", true);
        }

        // Phương thức gán dữ liệu vào Repeater
        private void BindOrdersToRepeater()
        {
            List<OrderDTO> orders = data.listOrder();
            OrdersRepeater.DataSource = orders;
            OrdersRepeater.DataBind();
        }
        protected void DeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy nút đã được nhấn
                Button btnDeleteOrder = (Button)sender;

                // Lấy CommandArgument (orderId) từ nút nhấn
                int orderId = Convert.ToInt32(btnDeleteOrder.CommandArgument);
                data.DeleteOrder(orderId);
                LoadOrders();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi : {ex.Message}");
            }
        }

        private void ShowErrorMessage(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }

    }
}
