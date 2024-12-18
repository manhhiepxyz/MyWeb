<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="ThemSP.aspx.cs" Inherits="MyWeb.Admin.QLSP.ThemSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12 col-md d-flex">
                    <div class="card">
                        <div class="card-header">
                            <h5>Thêm sản phẩm</h5>
                        </div>
                        <div class="card-body">
                            <!-- Ảnh sản phẩm -->
                            <div class="mb-3">
                                <label for="productImage" class="form-label">Chọn ảnh sản phẩm:</label>
                                <asp:FileUpload ID="productImage" runat="server" CssClass="form-control" />
                            </div>

                            <!-- Tên sản phẩm -->
                            <div class="mb-3">
                                <label for="productName" class="form-label">Tên sản phẩm (*)</label>
                                <asp:TextBox ID="productName" runat="server" CssClass="form-control" placeholder="Nhập tên sản phẩm" required="true" />
                            </div>

                            <!-- Đơn giá -->
                            <div class="mb-3">
                                <label for="price" class="form-label">Đơn giá (*)</label>
                                <asp:TextBox ID="price" runat="server" CssClass="form-control" placeholder="Nhập giá tiền" required="true" type="number" min="0" />
                            </div>

                            <!-- Số trang -->
                            <div class="mb-3">
                                <label for="totalPages" class="form-label">Số trang (*)</label>
                                <asp:TextBox ID="totalPages" runat="server" CssClass="form-control" placeholder="Nhập số trang" required="true" type="number" min="1" />
                            </div>

                            <!-- Mô tả -->
                            <div class="mb-3">
                                <label for="description" class="form-label">Mô tả</label>
                                <asp:TextBox ID="description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Nhập mô tả"></asp:TextBox>
                            </div>

                            <!-- Tác giả -->
                            <div class="mb-3">
                                <label for="author" class="form-label">Tác giả</label>
                                <asp:TextBox ID="author" runat="server" CssClass="form-control" placeholder="Nhập tên tác giả" required="true" />
                            </div>
                            <!-- Số lượng -->
                            <div class="mb-3">
                                <label for="quantity" class="form-label">Số lượng</label>
                                <asp:TextBox ID="quantity" runat="server" CssClass="form-control" placeholder="Nhập số lượng" required="true" />
                            </div>

                            <!-- Thể loại -->
                            <div class="mb-3">
                                <label for="category" class="form-label">Thể loại</label>
                                <asp:DropDownList ID="category" runat="server" CssClass="form-control" required="true">
                                    <asp:ListItem Text="-- Chưa phân loại --" Value="0" />
                                </asp:DropDownList>
                            </div>

                            <!-- Nút gửi -->
                            <asp:Button ID="btnAddProduct" runat="server" Text="Thêm sản phẩm" CssClass="btn btn-primary" OnClick="AddProduct" />
                            <asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
