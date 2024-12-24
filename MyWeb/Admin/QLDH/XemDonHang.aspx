<%@ Page Title="Chi tiết đơn hàng" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="XemDonHang.aspx.cs" Inherits="MyWeb.Admin.QLDH.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <!-- Tiêu đề -->
            <div class="mb-4">
                <h4 class="text-primary">Chi tiết đơn hàng</h4>
            </div>

            <!-- Thông tin đơn hàng -->
            <div class="row mb-4">
                <div class="col-md-6">
                    <p><strong>Mã đơn hàng:</strong> <asp:Label ID="lblOrderId" runat="server"></asp:Label></p>
                    <p><strong>Người đặt hàng:</strong> <asp:Label ID="lblCustomerName" runat="server"></asp:Label></p>
                    <p><strong>Địa chỉ giao hàng:</strong> <asp:Label ID="lblAddress" runat="server"></asp:Label></p>
                </div>
                <div class="col-md-6">
                    <p><strong>Ngày đặt:</strong> <asp:Label ID="lblOrderDate" runat="server"></asp:Label></p>
                    <p><strong>Trạng thái:</strong> <asp:Label ID="lblOrderStatus" runat="server"></asp:Label></p>
                </div>
            </div>
            <!--aa-->
            <asp:Repeater ID="orderProductRepeater" runat="server">
    <HeaderTemplate>
        <table class="table text-center">
            <thead>
                <tr>
                    <th scope="col">STT</th>
                    <th scope="col">Ảnh</th>
                    <th scope="col">Tên sản phẩm</th>
                    <th scope="col">Số lượng</th>
                    <th scope="col">Đơn giá</th>
                    <th scope="col">Thành tiền</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Container.ItemIndex + 1 %></td>
            <td>
                <img src='<%# ResolveUrl($"~/Image/{Eval("image")}") %>' 
                     alt="Hình ảnh" style="height: 50px; width: 50px; border-radius: 10px;" />
            </td>
            <td><%# Eval("productName") %></td>
            <td><%# Eval("quantity") %></td>
            <td><%# String.Format("{0:N0} VNĐ", Eval("donGia")) %></td>
            <td><%# String.Format("{0:N0} VNĐ", Eval("thanhTien")) %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>



        </div>
    </main>
</asp:Content>
