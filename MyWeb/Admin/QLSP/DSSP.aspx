<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSSP.aspx.cs" Inherits="MyWeb.Admin.QLSP.DSSP" %>
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
                            <th scope="col" style="width: 5%;">ID</th>
                            <th scope="col" style="width: 5%;">Sách</th>
                            <th scope="col" style="width: 15%;">Tên sách</th>
                            <th scope="col" style="width: 5%;">Giá</th>
                            <th scope="col" style="width: 10%;">Số trang</th>
                            <th scope="col" style="width: 20%;">Mô tả</th>
                            <th scope="col" style="width: 10%;">Tác giả</th>
                            <th scope="col" style="width: 10%;">Thể loại</th>
                            <th scope="col" style="width: 10%;">Trạng thái</th>
                            <th colspan="3" scope="col" style="width: 15%;" class="text-center">Chỉnh sửa</th>
                          </tr>
                      </thead>
                      <tbody id="tableBody" runat="server">
                        <tr>
                          <th scope="row">1</th>
                          <td><img src="" alt="loi" style="height: 50px; width: 50px; border-radius: 10px"></td>
                          <td>Giáo trình hệ thống nhúng</td>
                          <td>50000</td>
                          <td>120</td>
                          <td>Đây là giáo trình....</td>
                          <td>Nguyễn Thanh Hải</td>
                          <td>Học là nhót</td>
                          <td>Cháy hàng</td>
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
