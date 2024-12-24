<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="QLTaiKhoan.aspx.cs" Inherits="MyWeb.Admin.QLTK.QLTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="mb-3">
                <h4>Danh sách tài khoản</h4>

                <!-- Nút Thêm Tài Khoản -->
                <div class="mb-3 text-end">
                    <asp:Button ID="btnAddUser" runat="server" Text="Thêm Tài Khoản" CssClass="btn btn-primary" OnClick="btnAddUserr_Click" />
                </div>
            </div>

            <!-- Hiển thị danh sách tài khoản -->
            <asp:Repeater ID="accountRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table text-center">
                        <thead>
                            <tr>
                                <th scope="col" style="width: 5%;">ID</th>
                                <th scope="col" style="width: 5%;">Username</th>
                                <th scope="col" style="width: 5%;">Password</th>
                                <th scope="col" style="width: 10%;">Tên</th>
                                <th scope="col" style="width: 15%;">Email</th>
                                <th scope="col" style="width: 10%;">SĐT</th>
                                <th scope="col" style="width: 10%;">Địa chỉ</th>
                                <th scope="col" style="width: 5%;">Vai trò</th>
                                <th colspan="2" scope="col" style="width: 20%;">Chỉnh sửa</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("userName") %></td>
                        <td><%# Eval("pass") %></td>
                        <td><%# Eval("fullName") %></td>
                        <td><%# Eval("email") %></td>
                        <td><%# Eval("phone") %></td>
                        <td><%# Eval("address") %></td>
                        <td><%# Eval("roleName") %></td>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="btn btn-success"
                                CommandArgument='<%# Eval("id") %>' OnClick="EditAccount_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnDeletet" runat="server" Text="Xóa" CssClass="btn btn-danger"
                                CommandArgument='<%# Eval("id") %>' OnClick="DeleteAccount_Click" />
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
