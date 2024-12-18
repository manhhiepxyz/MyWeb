<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSDonHang.aspx.cs" Inherits="MyWeb.Admin.QLDH.DSDonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <main class="content px-3 py-2">
            <div class="container-fluid">
              <div class="mb-3">
                <h4>Danh sách đơn hàng</h4>
              </div>
              <div class="row">
                <div class="col-12 d-flex">
                    <table class="table text-center ">
                      <thead>
                        <tr>
                            <th scope="col" style="width: 5%;">STT</th>
                            <th scope="col" style="width: 5%;">Sách</th>
                            <th scope="col" style="width: 15%;">Tên sách</th>
                            <th scope="col" style="width: 5%;">SL</th>
                            <th scope="col" style="width: 10%;">Giá</th>
                            <th scope="col" style="width: 20%;">Địa chỉ nhận</th>
                            <th scope="col" style="width: 10%;">Người đặt</th>
                            <th scope="col" style="width: 10%;">Ghi chú</th>
                            <th scope="col" style="width: 10%;">Trạng thái</th>
                            <th colspan="3" scope="col" style="width: 15%;" class="text-center">Chỉnh sửa</th>
                          </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td><img src="../image/logo.jpg" alt="loi" style="height: 50px; width: 50px; border-radius: 10px"></td>
                          <td>Giáo trình trí tuệ nhân tạo</td>
                          <td>2</td>
                          <td>80000 VNĐ</td>
                          <td>Trường ĐH Công Nghiệp Hà Nội</td>
                          <td>Nguyễn Mạnh Hiệp</td>
                          <td>Hãy giao hàng sớm nhất cho tôi</td>
                          <td>Đang vận chuyển</td>
                          <td><a href="" class="btn btn-outline-primary">Xem</a></td>
                          <td><a href="" class="btn btn-outline-primary">Sửa</a></td>
                          <td><a href="" class="btn btn-outline-danger">Xóa</a></td>
                        </tr>
                      </tbody>
                    </table>
                </div>
                </div>
            </div>
          </main>
</asp:Content>
