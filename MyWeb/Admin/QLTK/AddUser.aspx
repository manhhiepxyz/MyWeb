<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="MyWeb.Admin.QLTK.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12 col-md d-flex">
                    <div class="card">
                        <div class="card-header">
                            <h5>Tạo tài khoản</h5>
                        </div>
                        <div class="card-body">
                            
                            <!-- Tên tài khoản -->
                            <div class="mb-3">
                                <label for="userName" class="form-label">Tên tài khoản (*)</label>
                                <asp:TextBox ID="userName" runat="server" CssClass="form-control" placeholder="Nhập tài khoản" required="true" />
                            </div>
                            <!-- Tên người dùng -->
                            <div class="mb-3">
                                <label for="fullName" class="form-label">Tên người dùng (*)</label>
                                <asp:TextBox ID="fullName" runat="server" CssClass="form-control" placeholder="Nhập tên người dùng" required="true" />
                            </div>

                            <!-- Email -->
                            <div class="mb-3">
                                <label for="email" class="form-label">Email (*)</label>
                                <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Nhập email" required="true" />
                            </div>
                            <!-- Số điện thoại -->
                            <div class="mb-3">
                                <label for="phone" class="form-label">Số điện thoại (*)</label>
                                <asp:TextBox ID="phone" runat="server" CssClass="form-control" placeholder="Nhập số điện thoại" required="true" />
                            </div>

                            <!-- Địa chỉ -->
                            <div class="mb-3">
                                <label for="address" class="form-label">Địa chỉ</label>
                                <asp:TextBox ID="address" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ" />
                            </div>

                            <!-- Vai trò -->
                            <div class="mb-3">
                                <label for="role" class="form-label">Vai trò (*)</label>
                                <asp:DropDownList ID="role" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </div>

                            <!-- Nút gửi -->
                            <asp:Button ID="btnAddUser" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="AddUserr_Click" />
                            <asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>