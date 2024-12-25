<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="ThongKeAdmin.aspx.cs" Inherits="MyWeb.Admin.ThongKe.ThongKeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container mt-4">
        <h1>Thống kê</h1>

        <!-- Statistics Overview -->
        <div class="row mb-4">
            <div class="col-lg-3 col-md-6">
                <div class="card text-white bg-primary mb-3">
                    <div class="card-header">Tổng số đơn hàng</div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblTotalOrders" runat="server" Text="0"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="card text-white bg-success mb-3">
                    <div class="card-header">Tổng doanh thu</div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblTotalRevenue" runat="server" Text="0 VND"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="card text-white bg-warning mb-3">
                    <div class="card-header">Sản phẩm bán chạy</div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblBestSellingProduct" runat="server" Text="N/A"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="card text-white bg-danger mb-3">
                    <div class="card-header">Đơn hàng chưa xử lý</div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblPendingOrders" runat="server" Text="0"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
        </div>

        <!-- Detailed Statistics -->
        <div class="row">
            <div class="col-12">
                <h2>Thống kê chi tiết</h2>
<asp:GridView ID="gvDetailedStatistics" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" EmptyDataText="Không có dữ liệu">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="QuantitySold" HeaderText="Số lượng bán" />
        <asp:BoundField DataField="Revenue" HeaderText="Doanh thu" DataFormatString="{0:N0} VND" />
    </Columns>
</asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>