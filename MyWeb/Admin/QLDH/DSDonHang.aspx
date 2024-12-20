<%@ Page Title="Quản lý đơn hàng" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSDonHang.aspx.cs" Inherits="MyWeb.Admin.QLDH.DSDonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <div class="mb-3">
                <h4>Quản lý đơn hàng</h4>
            </div>
            <div class="row">
                <div class="col-12 d-flex">
                    <table class="table table-bordered">
                        <thead class="text-center">
                            <tr>
                                <th style="width: 5%;">STT</th>
                                <th style="width: 50%;">Sản phẩm </th>
                                <th style="width: 15%;">Địa chỉ giao hàng</th>
                                <th style="width: 10%;">Người đặt</th>
                                <th style="width: 10%;">Ngày đặt</th>
                                <th style="width: 10%;">Thanh toán</th>
                                <th style="width: 10%;">Trạng thái</th>
                                <th style="width: 15%;">Thao tác</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Đơn hàng 1 -->
                            <tr>
                                <td class="text-center">1</td>
                                <td>
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
                                            <tr>
                                                <td>Giáo trình trí tuệ nhân tạo</td>
                                                <td>2</td>
                                                <td>80,000 VNĐ</td>
                                                <td>160,000 VNĐ</td>
                                            </tr>
                                            <tr>
                                                <td>Xử lý dữ liệu lớn</td>
                                                <td>1</td>
                                                <td>100,000 VNĐ</td>
                                                <td>100,000 VNĐ</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td>Trường ĐH Công Nghiệp Hà Nội</td>
                                <td>Nguyễn Mạnh Hiệp</td>
                                <td>20/12/2024</td>
                                <td>Chuyển khoản</td>
                                <td>Đang vận chuyển</td>
                                <td class="text-center">
                                    <a href="#" class="btn btn-outline-primary btn-sm">Xác nhận</a>
                                    <a href="#" class="btn btn-outline-danger btn-sm">Xóa</a>
                                </td>
                            </tr>
                            <!-- Đơn hàng 2 -->
                            <tr>
                                <td class="text-center">2</td>
                                <td>
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
                                            <tr>
                                                <td>Lập trình Python cơ bản</td>
                                                <td>1</td>
                                                <td>120,000 VNĐ</td>
                                                <td>120,000 VNĐ</td>
                                            </tr>
                                            <tr>
                                                <td>Machine Learning cơ bản</td>
                                                <td>3</td>
                                                <td>150,000 VNĐ</td>
                                                <td>450,000 VNĐ</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td>Ngõ 102, Đống Đa, Hà Nội</td>
                                <td>Trần Văn A</td>
                                <td>18/12/2024</td>
                                <td>COD</td>
                                <td>Đã giao</td>
                                <td class="text-center">
                                    <a href="#" class="btn btn-outline-primary btn-sm">Xác nhận</a>
                                    <a href="#" class="btn btn-outline-danger btn-sm">Xóa</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
