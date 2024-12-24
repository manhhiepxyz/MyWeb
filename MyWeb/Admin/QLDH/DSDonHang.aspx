<%@ Page Title="Quản lý đơn hàng" Language="C#" MasterPageFile="~/Master/Dashboard.Master" AutoEventWireup="true" CodeBehind="DSDonHang.aspx.cs" Inherits="MyWeb.Admin.QLDH.DSDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content px-3 py-2">
        <div class="container-fluid">
            <!-- Tiêu đề -->
            <div class="mb-4">
                <h4 class="text-primary">Quản lý đơn hàng</h4>
            </div>

            <!-- Thanh tìm kiếm và bộ lọc -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <input type="text" class="form-control" placeholder="Tìm kiếm đơn hàng...">
                </div>
                <div class="col-md-3">
                    <select class="form-select">
                        <option value="">Tất cả trạng thái</option>
                        <option value="pending">Chờ xử lý</option>
                        <option value="completed">Hoàn thành</option>
                        <option value="cancelled">Đã hủy</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <button class="btn btn-primary w-100">Lọc</button>
                </div>
            </div>

            <!-- Danh sách đơn hàng -->
            <div class="row">
                <div class="col-12">
                    <asp:Repeater ID="OrdersRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-striped table-bordered">
                                <thead class="text-center table-primary">
                                    <tr>
                                        <th style="width: 5%;">STT</th>
                                        <th style="width: 25%;">Địa chỉ giao hàng</th>
                                        <th style="width: 10%;">Username</th>
                                        <th style="width: 10%;">Người đặt</th>
                                        <th style="width: 10%;">Ngày đặt</th>
                                        <th style="width: 10%;">Trạng thái</th>
                                        <th style="width: 30%;">Thao tác</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>

                       <ItemTemplate>
                            <tr>
                                <td class="text-center"><%# Container.ItemIndex + 1 %></td>
                                <td><%# Eval("address") %></td>
                                <td><%# Eval("username") %></td>
                                <td><%# Eval("fullName") %></td>
                                <td><%# Eval("date", "{0:dd/MM/yyyy}") %></td>
                                <td class="text-center">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" required="true" 
                                        SelectedValue='<%# Eval("status") %>'>
                                        <asp:ListItem Text="Chờ xử lý" Value="Chờ xử lý"></asp:ListItem>
                                        <asp:ListItem Text="Hoàn thành" Value="Hoàn thành"></asp:ListItem>
                                        <asp:ListItem Text="Đã hủy" Value="Đã hủy"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="text-center">
                                    <asp:Button ID="btnXemDonHang" runat="server" Text="Xem" 
                                        CssClass="btn btn-success btn-sm" CommandName="View" CommandArgument='<%# Eval("orderId") %>' OnClick="ViewOrder_Click"/>

                                    <asp:Button ID="btnUpdateTrangThai" runat="server" Text="Cập nhật trạng thái"
                                        CssClass="btn btn-sm btn-warning" CommandName="UpdateStatus"
                                        CommandArgument='<%# Eval("orderId") %>' OnClick="UpdateStatus_Click" />
                                    </button>
                                    <asp:Button ID="Button1" runat="server" Text="Xóa"
                                        CssClass="btn btn-sm btn-danger" CommandName="DeleteOrder"
                                        CommandArgument='<%# Eval("orderId") %>' OnClick="DeleteOrder_Click" />
                                    </button>
                                </td>
                             </tr>
                       </ItemTemplate>


                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <!-- Phân trang -->
            <div class="row mt-3">
                <div class="col-12 d-flex justify-content-center">
                    <nav>
                        <ul class="pagination">
                            <li class="page-item"><a class="page-link" href="#">Trước</a></li>
                            <li class="page-item"><a class="page-link" href="#">1</a></li>
                            <li class="page-item"><a class="page-link" href="#">2</a></li>
                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                            <li class="page-item"><a class="page-link" href="#">Tiếp</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </main>



</asp:Content>
