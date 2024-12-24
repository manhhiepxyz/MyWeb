<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="UpdateCategory.aspx.cs" Inherits="MyWeb.Admin.QLDM.UpdateCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12 col-md d-flex">
                    <div class="card">
                        <div class="card-header">
                            <h5>Cập Nhập Danh Mục</h5>
                        </div>
                        <div class="card-body">
                            <!-- Ảnh danh mục -->
                            <div class="mb-3">
                                <label for="categoryImage" class="form-label">Chọn ảnh danh mục:</label>
                                <asp:FileUpload ID="categoryImage" runat="server" CssClass="form-control" />
                            </div>

                            <!-- Tên danh mục -->
                            <div class="mb-3">
                                <label for="categoryName" class="form-label">Tên danh mục (*)</label>
                                <asp:TextBox ID="categoryName" runat="server" CssClass="form-control" placeholder="Nhập tên danh mục" required="true" />
                            </div>
                            <!-- Nút gửi -->
                            <asp:Button ID="btnAddCategory" runat="server" Text="Cập nhập" CssClass="btn btn-primary" OnClick="UpdateCategoryy" />
                            <asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>