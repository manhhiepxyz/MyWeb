<%@ Page Title="Quản Lý Danh Mục" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="QLDM.aspx.cs" Inherits="MyWeb.Admin.QLDM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="mb-3">
                <h4>Danh sách danh mục</h4>

                <!-- Nút Thêm Danh Mục -->
                <div class="mb-3 text-end">
                    <asp:Button ID="btnAddCategory" runat="server" Text="Thêm Danh Mục" CssClass="btn btn-primary" OnClick="btnAddCategory_Click" />
                </div>
            </div>

            <!-- Hiển thị danh sách danh mục -->
            <asp:Repeater ID="categoryRepeater" runat="server" >
                <HeaderTemplate>
                    <table class="table text-center">
                        <thead>
                            <tr>
                                <th scope="col" style="width: 5%;">ID</th>
                                <th scope="col" style="width: 15%;">Ảnh</th>
                                <th scope="col" style="width: 50%;">Tên</th>
                                <th colspan="2" scope="col" style="width: 20%;">Chỉnh sửa</th>
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
                        <td>
                            <asp:Button ID="btnEditCategory" runat="server" Text="Sửa" CssClass="btn btn-success"
                                CommandArgument='<%# Eval("id") %>' OnClick="EditCategory_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnDeleteCategory" runat="server" Text="Xóa" CssClass="btn btn-danger"
                                CommandArgument='<%# Eval("id") %>' OnClick="DeleteCategory_Click" />
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
