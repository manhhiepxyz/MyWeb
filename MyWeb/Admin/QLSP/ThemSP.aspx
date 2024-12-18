<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="ThemSP.aspx.cs" Inherits="MyWeb.Admin.QLSP.ThemSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <main class="content px-3 py-2">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12 col-md d-flex">
                        <div class="card">
                            <div class="card-header">
                                <h5>Thêm đơn hàng</h5>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="mb-3">
                                        <label for="productImage" class="form-label">Chọn ảnh sản phẩm:</label>
                                        <input class="form-control" type="file" id="productImage" required>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="productName" class="form-label">Tên sản phẩm (*)</label>
                                        <input type="text" class="form-control" id="productName" placeholder="Nhập tên sản phẩm" required>
                                    </div>
                                    <div class="mb-3">
                                        <label for="price" class="form-label">Đơn giá (*)</label>
                                        <input type="number" class="form-control" id="price" placeholder="Nhập giá tiền" required>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="totalPages" class="form-label">Số trang (*)</label>
                                        <input type="text" class="form-control" id="totalPages" placeholder="Nhập số trang" required>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="description" class="form-label">Mô tả</label>
                                        <textarea class="form-control" id="description" rows="3" placeholder="Nhập mô tả"></textarea>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="author" class="form-label">Tác giả</label>
                                        <input type="text" class="form-control" id="author" placeholder="Nhập tên tác giả" required>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="categoty" class="form-label">Thể loại</label>
                                        <select class="form-control" id="categoty" name="categoty">
                                            <option value="1">Trinh thám</option>
                                            <option value="2">Giáo trình</option>
                                            <option value="3">Tài liệu tham khảo</option>
                                        </select>
                                    </div>
        
                                    <button type="submit" class="btn btn-primary">Thêm đơn hàng</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
</asp:Content>
