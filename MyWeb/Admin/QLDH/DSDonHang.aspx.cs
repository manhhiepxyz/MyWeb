using System;
using System.Collections.Generic;
using System.Web.UI;
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
        private void LoadOrders()
        {
            try
            {
                List<OrderDTO> orders = data.listOrder(); 
                BindOrdersToRepeater(orders);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi tải đơn hàng: {ex.Message}");
            }
        }

        // Phương thức gán dữ liệu vào Repeater
        private void BindOrdersToRepeater(List<OrderDTO> orders)
        {
            OrdersRepeater.DataSource = orders;
            OrdersRepeater.DataBind();
        }

        private void ShowErrorMessage(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}
