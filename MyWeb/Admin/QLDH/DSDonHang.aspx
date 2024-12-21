<%@ Page Title="Quản lý đơn hàng" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSDonHang.aspx.cs" Inherits="MyWeb.Admin.QLDH.DSDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="mb-3">
                <h4>Quản lý đơn hàng</h4>
            </div>
            <div class="row">
                <div class="col-12 d-flex">
                    <asp:Repeater ID="OrdersRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <thead class="text-center">
                                    <tr>
                                        <th style="width: 5%;">STT</th>
                                        <th style="width: 50%;">Sản phẩm</th>
                                        <th style="width: 15%;">Địa chỉ giao hàng</th>
                                        <th style="width: 10%;">Người đặt</th>
                                        <th style="width: 10%;">Ngày đặt</th>
                                        <th style="width: 10%;">Thanh toán</th>
                                        <th style="width: 10%;">Trạng thái</th>
                                        <th style="width: 15%;">Thao tác</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><%# Container.ItemIndex + 1 %></td>
                                <td>
                                    <!-- Bảng chi tiết sản phẩm -->
                                    <table class="table mb-0">
                                        <thead>
                                            <tr>
                                                <th>Tên sách</th>
                                                <th>SL</th>
                                                <th>Đơn giá</th>
                                                <th>Thành tiền</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <!-- Lặp qua các chi tiết sản phẩm trong đơn hàng -->
                                            <%# Eval("ProductDetails") != null ? Eval("ProductDetails").ToString() : "Không có sản phẩm" %>
                                        </tbody>
                                    </table>
                                </td>
                                <td><%# Eval("DeliveryAddress") %></td>
                                <td><%# Eval("CustomerName") %></td>
                                <td><%# Eval("OrderDate", "{0:dd/MM/yyyy}") %></td>
                                <td><%# Eval("PaymentMethod") %></td>
                                <td><%# Eval("Status") %></td>
                                <td class="text-center">
                                    <!-- Các thao tác: Xem, Xác nhận, Xóa -->
                                    <a href="#" class="btn btn-outline-primary btn-sm">Xem</a>
                                    <a href="#" class="btn btn-outline-success btn-sm">Xác nhận</a>
                                    <a href="#" class="btn btn-outline-danger btn-sm">Xóa</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
