using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.DTO;

namespace MyWeb.Admin.ThongKe
{
    public partial class ThongKeAdmin : System.Web.UI.Page
    {
        DataUltil data= new DataUltil();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only load data once when the page loads initially
            if (!IsPostBack)
            {
                LoadStatistics();
                LoadDetailedStatistics();
            }
        }

        private void LoadStatistics()
        {
            int totalOrders = data.GetTongDonHang();
            lblTotalOrders.Text = $"{totalOrders}";
            decimal totalRevenue = data.GetTongDoanhThu();
            lblTotalRevenue.Text = $"{totalRevenue} VNĐ";  
            string bestSellingProduct = data.GetSanPhamBanChayNhat();
            lblBestSellingProduct.Text = $"{bestSellingProduct}";  
            int pendingOrders = data.GetDonHangChuaXuLy(); 
            lblPendingOrders.Text = $"{pendingOrders}"; 
        }

        private void LoadDetailedStatistics()
        {
            // Lấy danh sách thống kê chi tiết
            List<ThongKeDTO> listThongKe = data.listThongKe();

            // Đổ dữ liệu vào GridView
            gvDetailedStatistics.DataSource = listThongKe;
            gvDetailedStatistics.DataBind();
        }

    }
}