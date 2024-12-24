using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.DTO;
using MyWeb.Model;

namespace MyWeb.Admin.QLDH
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataUltil data= new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu có tham số 'id' trong URL thì tải thông tin sản phẩm
            if (!IsPostBack && Request.QueryString["orderId"] != null)
            {
                int orderId = int.Parse(Request.QueryString["orderId"]);
                DataUltil data = new DataUltil();

                // Load thông tin sản phẩm
                LoadOrderDetails(orderId);
                LoadOrderProducts(orderId);
            }
        }
        private void LoadOrderDetails(int orderId)
        {
            DataUltil data= new DataUltil(); ;
            OrderDTO order = data.GetOrderById(orderId);
            if (order != null)
            {
                lblOrderId.Text = order.orderId.ToString();
                lblCustomerName.Text = order.fullName;
                lblAddress.Text = order.address;
                lblOrderDate.Text = order.dateShip.ToString();
                lblOrderStatus.Text = order.status;
            }

        }
        private void LoadOrderProducts(int orderId)
        {
            try
            {
                // Lấy danh sách sản phẩm trong đơn hàng
                List<ProductDTO> products = data.listOrderItem(orderId);

                // Gán dữ liệu vào GridView
                orderProductRepeater.DataSource = products;
                orderProductRepeater.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi tải danh sách sản phẩm
                Response.Write($"<script>alert('Lỗi khi tải danh sách sản phẩm: {ex.Message}');</script>");
            }
        }

    }
}