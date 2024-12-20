<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSSP.aspx.cs" Inherits="MyWeb.Admin.QLSP.DSSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="mb-3">
                <h4>Danh sách sản phẩm</h4>
                
                <!-- Form tìm kiếm -->
                <div class="form-group mb-3">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Nhập tên sản phẩm để tìm kiếm..." />
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary mt-2" OnClick="btnSearch_Click" />
                </div>
            </div>

            <!-- Hiển thị danh sách sản phẩm -->
            <asp:Repeater ID="productRepeater" runat="server" OnItemCommand="productRepeater_ItemCommand">
                <HeaderTemplate>
                    <table class="table text-center">
                        <thead>
                            <tr>
                                <th scope="col" style="width: 5%;">ID</th>
                                <th scope="col" style="width: 5%;">Sách</th>
                                <th scope="col" style="width: 15%;">Tên sách</th>
                                <th scope="col" style="width: 5%;">Giá</th>
                                <th scope="col" style="width: 10%;">Số trang</th>
                                <th scope="col" style="width: 20%;">Mô tả</th>
                                <th scope="col" style="width: 10%;">Tác giả</th>
                                <th scope="col" style="width: 10%;">Thể loại</th>
                                <th scope="col" style="width: 10%;">Số lượng</th>
                                <th colspan="2" scope="col" style="width: 15%;">Chỉnh sửa</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td>
                            <img src='<%# ResolveUrl($"~/Image/{(Eval("image") != DBNull.Value && !string.IsNullOrEmpty(Eval("image").ToString()) ? Eval("image") : "default.jpg")}") %>' 
                                 alt="Hình ảnh" style="height: 50px; width: 50px; border-radius: 10px;" />
                        </td>
                        <td><%# Eval("name") %></td>
                        <td><%# String.Format("{0:N0} VNĐ", Eval("price")) %></td>
                        <td><%# Eval("totalpage") %></td>
                        <td><%# Eval("description") %></td>
                        <td><%# Eval("author") %></td>
                        <td><%# Eval("categoryName") %></td>
                        <td><%# Eval("quantity") %></td>
                        <td>
                            <asp:Button ID="btnEditProduct" runat="server" Text="Sửa" CssClass="btn btn-success"
                                CommandArgument='<%# Eval("id") %>' OnClick="EditProduct_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnDeleteProduct" runat="server" Text="Xóa" CssClass="btn btn-danger"
                                CommandArgument='<%# Eval("id") %>' OnClick="DeleteProduct_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Label ID="msg" runat="server" Font-Italic="true" CssClass="text-danger"></asp:Label>
        </div>
    </main>
</asp:Content>
