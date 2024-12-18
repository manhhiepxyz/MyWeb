<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="ThemDH.aspx.cs" Inherits="MyWeb.Admin.QLDH.ThemDH" %>
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
                                        <label for="productName" class="form-label">Chọn sản phẩm (*)</label>
                                        <input type="text" class="form-control" id="productName" placeholder="Nhập tên sản phẩm" required>
                                        <ul id="suggestions" class="list-group"></ul>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="price" class="form-label">Đơn giá</label>
                                        <input type="number" class="form-control" id="price" placeholder="Đơn giá tự động" readonly>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="quantity" class="form-label">Số lượng (*)</label>
                                        <input type="number" class="form-control" id="quantity" placeholder="Nhập số lượng" required>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="totalPrice" class="form-label">Giá tiền</label>
                                        <input type="number" class="form-control" id="totalPrice" placeholder="Giá tiền tự động" readonly>
                                    </div>
        
                                    <!-- Địa chỉ -->
                                    <div class="mb-3">
                                        <label for="address" class="form-label">Địa chỉ nhận hàng (*)</label>
                                        <input type="text" class="form-control" id="address" placeholder="Nhập địa chỉ" required>
                                    </div>
                                    <div class="mb-3">
                                        <label for="customerName" class="form-label">Tài khoản đặt hàng (Username) (*)</label>
                                        <input type="text" class="form-control" id="customerName" placeholder="Nhập username" required>
                                        <ul id="usernameSuggestions" class="list-group"></ul>
                                    </div>
                                    <!-- Họ và tên người nhận -->
                                     <div class="mb-3">
                                        <label for="recipientName" class="form-label">Họ và Tên người nhận (*)</label>
                                        <input type="text" class="form-control" id="recipientName" placeholder="Họ và tên người nhận" readonly>
                                    </div>
                                    <!-- Số điện thoại -->
                                    <div class="mb-3">
                                        <label for="phone" class="form-label">Số điện thoại (*)</label>
                                        <input type="text" class="form-control" id="phone" placeholder="Số điện thoại" readonly>
                                    </div>
                                    <div class="mb-3">
                                        <label for="notes" class="form-label">Ghi chú</label>
                                        <textarea class="form-control" id="notes" rows="3" placeholder="Thêm ghi chú"></textarea>
                                    </div>
        
                                    <div class="mb-3">
                                        <label for="status" class="form-label">Trạng thái</label>
                                        <select class="form-control" id="status" name="status">
                                            <option value="processing">Đang xử lý</option>
                                            <option value="shipped">Đã giao hàng</option>
                                            <option value="cancelled">Đã hủy</option>
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
    <script src="<%= ResolveUrl("~/JS/themDH.js") %>"></script>

</asp:Content>
