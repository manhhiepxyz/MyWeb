using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using MyWeb.DTO;
using MyWeb.Model;

namespace MyWeb
{
    public class DataUltil
    {
        SqlConnection conn;
        public void connect() { 
        }
        public DataUltil()
        {
            string sqlCon = "Data Source=MANHHIEP;Initial Catalog=BookStore;Integrated Security=True";
            conn = new SqlConnection(sqlCon);

        }
        public List<Product> listProduct()
        {
            List<Product> listProduct = new List<Product>();
            string sql = "SELECT tblproduct.id AS idProduct, tblproduct.name AS productName, tblproduct.image , price, totalpage, description , author," +
                "tblcategory.name AS categoryName, category, quantity FROM tblproduct INNER JOIN tblcategory ON tblproduct.category = tblcategory.id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.id = (int)rd["idProduct"];
                product.price = (decimal)rd["price"];
                product.name = (string)rd["productName"];
                product.description = (string)rd["description"];
                product.image = (string)rd["image"];
                product.totalpage = (int)rd["totalpage"];
                product.author = (string)rd["author"];
                product.idCategory = (int)rd["category"];
                product.quantity = (int)rd["quantity"];
                product.categoryName = (string)rd["categoryName"];
                listProduct.Add(product);
            }
            conn.Close();
            return listProduct;
        }
        public void addProduct(Product product)
        {
            conn.Open();
            string sql = "INSERT INTO tblproduct (name, image, price, totalpage, description, author, category, quantity) " +
                 "VALUES (@name, @image, @price, @totalpage, @description, @author, @category, @quantity)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@image", product.image);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@totalpage", product.totalpage);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@author", product.author);
            cmd.Parameters.AddWithValue("@category", product.idCategory);
            cmd.Parameters.AddWithValue("@quantity", product.quantity);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<OrderDTO> listOrder()
        {
            List<OrderDTO> listOrder = new List<OrderDTO>();
            string sql = "	SELECT tblorder.id as orderid, tblshipment.address as diachi, tbluser.name as username, tblshipment.fullname as nguoidat," +
                "tblshipment.date as ngaydat, tblshipment.status as trangthai " +
                "from tblorder inner join tbluser on tblorder.user_id = tbluser.id " +
                "inner join tblpayment on tblorder.payment_id = tblpayment.id " +
                "inner join tblshipment on tblorder.shipment_id = tblshipment.id ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read()) {
                OrderDTO order = new OrderDTO
                {
                    orderId = rd["orderid"] != DBNull.Value ? Convert.ToInt32(rd["orderid"]) : 0,
                    address = rd["diachi"] != DBNull.Value ? rd["diachi"].ToString() : string.Empty,
                    username = rd["username"] != DBNull.Value ? rd["username"].ToString() : string.Empty,
                    fullName = rd["nguoidat"] != DBNull.Value ? rd["nguoidat"].ToString() : string.Empty,
                    date = rd["ngaydat"] != DBNull.Value ? rd["ngaydat"].ToString() : string.Empty,
                    status = rd["trangthai"] != DBNull.Value ? rd["trangthai"].ToString() : string.Empty
                };
                listOrder.Add(order);
            }
            rd.Close();
            conn.Close( );

            return listOrder;
        }

        public List<User> listUser()
        {      
            List<User> listUser = new List<User>();
            string sql = "select tbluser.id as userid, pass, tbluser.name as username, fullname, " +
                "email, phone, address, tblrole.name as rolename " +
                " from tbluser inner join tblrole on tbluser.role= tblrole.id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read()) {
                User user = new User();
                user.id=(int)rd["userid"];
                user.pass = (string)rd["pass"];
                user.userName=(string)rd["username"];
                user.address=(string)rd["address"];
                user.email=(string)rd["email"];
                user.fullName = (string)rd["fullname"];
                user.phone = (string)rd["phone"];
                user.roleName = (string)rd["rolename"];
                listUser.Add(user);
            }
            conn.Close();
            return listUser;


        }
        public void addUser(User user)
        {
            // Kiểm tra sự tồn tại của username
            string checkSql = "SELECT COUNT(*) FROM tbluser WHERE name = @username";
            conn.Open();
            SqlCommand checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@username", user.userName);

            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
            {
                conn.Close();
                throw new Exception("Username đã tồn tại. Vui lòng chọn tên khác.");
            }

            // Nếu không tồn tại, thêm người dùng mới
            string sql = "INSERT INTO tbluser (name, pass, fullname, email, phone, address, role) " +
                         "VALUES (@username, @pass, @fullname, @email, @phone, @address, @role)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", user.userName);
            cmd.Parameters.AddWithValue("@pass", "abc123"); // Mật khẩu mặc định
            cmd.Parameters.AddWithValue("@fullname", user.fullName);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@role", user.role);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateUser(User user)
        {
            conn.Open();
            string sql = "UPDATE tbluser SET fullname = @fullname, email = @email, " +
                            "phone = @phone, address = @address, role = @role WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fullname", user.fullName);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@role", user.role);
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteUser(int userId)
        {
            conn.Open();
            string sql = "delete from tbluser where id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", userId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public User getUserById(int userId)
        {
            User user = null;
            string sql = "SELECT tbluser.id as userid, tbluser.name as username, pass, fullname, email, phone, address, role, tblrole.name as roleName FROM tbluser inner join tblrole on tbluser.role=tblrole.id WHERE tbluser.id = @id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", userId);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                user = new User();
                user.id = (int)rd["userid"];
                user.userName = (string)rd["username"];
                user.pass = (string)rd["pass"];
                user.fullName = (string)rd["fullname"];
                user.email = (string)rd["email"];
                user.phone = (string)rd["phone"];
                user.address = (string)rd["address"];
                user.role = (int)rd["role"];
                user.roleName = (string)rd["roleName"];
            }
            conn.Close();
            return user;
        }
        public OrderDTO GetOrderById(int orderId)
        {
            OrderDTO order = null;
            string sql = "SELECT tblorder.id as orderid, tblshipment.address as diachi, tbluser.name as username, tblshipment.fullname as nguoidat, " +
                         "tblshipment.date as ngaydat, tblshipment.status as trangthai " +
                         "FROM tblorder " +
                         "INNER JOIN tbluser ON tblorder.user_id = tbluser.id " +
                         "INNER JOIN tblpayment ON tblorder.payment_id = tblpayment.id " +
                         "INNER JOIN tblshipment ON tblorder.shipment_id = tblshipment.id " +
                         "WHERE tblorder.id = @idOrder";

                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idOrder", orderId);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) 
                {
                    order = new OrderDTO
                    {
                        orderId = (int)rd["orderid"],
                        username=(string)rd["username"],
                        fullName = (string)rd["nguoidat"],
                        address = (string)rd["diachi"],
                        dateShip = ((DateTime)rd["ngaydat"]).ToString("yyyy-MM-dd"),
                        status = (string)rd["trangthai"],
                    };
                }
                conn.Close();

            return order;
        }

        public List<ProductDTO> listOrderItem(int orderId)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string sql = "select tblproduct.image as imageProduct, tblproduct.name as productName, tblorderiteam.quantity as soluong, tblproduct.price as dongia " +
                "from tblorderiteam " +
                "inner join tblproduct on tblproduct.id= tblorderiteam.product_id " +
                "where order_id= @orderId";
            
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ProductDTO product = new ProductDTO();
                product.image = (string)rd["imageProduct"];
                product.productName=(string)rd["productName"];
                product.quantity = (int)rd["soluong"];
                product.donGia = (decimal)rd["dongia"];
                list.Add(product);
            }
            conn.Close();
            return list;
        }
        public List<Category> listCategory()
        {
            List<Category> listCategory = new List<Category>();
            string sql = "SELECT id, name , image FROM tblcategory";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category category = new Category();
                category.id = (int)rd["id"];
                category.name = (string)rd["name"];
                category.image= (string)rd["image"];
                listCategory.Add(category);
            }
            conn.Close();
            return listCategory;
        }
        public void addCategory(Category category)
        {
            conn.Open();
            string sql = "insert into tblcategory (image, name) values (@image, @name)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@image",category.image);
            cmd.Parameters.AddWithValue("@name",category.name);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updateCategory(Category c)
        {
            conn.Open();
            string sql = "update tblcategory set name=@name " + (string.IsNullOrEmpty(c.image) ? "" : ", image = @image") + " where id= @id";
            SqlCommand cmd= new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", c.id);
            cmd.Parameters.AddWithValue("@name", c.name);
            // Nếu có ảnh mới, thêm tham số @image
            if (!string.IsNullOrEmpty(c.image))
            {
                cmd.Parameters.AddWithValue("@image", c.image);
            }
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteCategory(int categoryId)
        {
            conn.Open();
            string sql = "delete from tblcategory where id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", categoryId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void DeleteProduct(int productId)
        {
            conn.Open(); 

            string sql = "DELETE FROM tblProduct WHERE id = @id";   
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id",productId);
            cmd.ExecuteNonQuery();
            conn.Close() ;
        }
       

        public void DeleteOrder(int orderID)
        {
            conn.Open();

            string sql = "DELETE FROM tblProduct WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", orderID);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void CapNhapDonHang(string status, int orderId)
            {
                conn.Open();
                string sql = "update tblshipment set status= @status where id= (SELECT shipment_id FROM tblorder WHERE id = @orderid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@orderid", orderId);
                cmd.ExecuteNonQuery();
                conn.Close();
        }

        public void updateProduct(Product p)
        {
            conn.Open();
            // Kiểm tra nếu không có ảnh mới thì không cần thay đổi ảnh
            string sql = "UPDATE tblproduct SET name = @name, price = @price, totalpage = @totalpage, " +
                         "description = @description, author = @author, category = @category, " +
                         "quantity = @quantity" +
                         (string.IsNullOrEmpty(p.image) ? "" : ", image = @image") + // Chỉ cập nhật trường image nếu có ảnh mới
                         " WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", p.id);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@price", p.price);
            cmd.Parameters.AddWithValue("@totalpage", p.totalpage);
            cmd.Parameters.AddWithValue("@description", p.description);
            cmd.Parameters.AddWithValue("@author", p.author);
            cmd.Parameters.AddWithValue("@category", p.idCategory);
            cmd.Parameters.AddWithValue("@quantity", p.quantity);

            // Nếu có ảnh mới, thêm tham số @image
            if (!string.IsNullOrEmpty(p.image))
            {
                cmd.Parameters.AddWithValue("@image", p.image);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Category getCategoryById(int categoryId)
        {
            Category category = null;
            string sql = "select id, name, image from tblcategory where id=@id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", categoryId);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                category = new Category();
                category.id = (int)rd["id"];
                category.name = (string)rd["name"];
                category.image = (string)rd["image"];
            }
            conn.Close();
            return category;

        }
        public Product GetProductById(int productId)
        {
            Product product = null;
            string sql = "SELECT tblproduct.id AS idProduct, tblproduct.name AS productName, tblproduct.image , price, totalpage, description , author," +
                         "tblcategory.name AS categoryName, category, quantity FROM tblproduct INNER JOIN tblcategory ON tblproduct.category = tblcategory.id WHERE tblproduct.id = @productId";

            conn.Open();  // Mở kết nối đến cơ sở dữ liệu

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@productId", productId); 

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())  // Kiểm tra nếu có dữ liệu trả về
            {
                product = new Product
                {
                    id = (int)rd["idProduct"],
                    price = (decimal)rd["price"],
                    name = (string)rd["productName"],
                    description = (string)rd["description"],
                    image = (string)rd["image"],
                    totalpage = (int)rd["totalpage"],
                    author = (string)rd["author"],
                    idCategory = (int)rd["category"],
                    quantity = (int)rd["quantity"],
                    categoryName = (string)rd["categoryName"]
                };
            }

            conn.Close();  // Đóng kết nối
            return product;  // Trả về sản phẩm hoặc null nếu không tìm thấy
        }
        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            string sql = "select id, name from tblrole";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Role role = new Role();
                role.id = (int)rd["id"];
                role.name = (string)rd["name"];
                roles.Add(role);
            }
            conn.Close();
            return roles;
        }
        public decimal GetTongDoanhThu()
        {
            decimal tongDoanhThu = 0;
            string sql = @"SELECT 
    SUM(tblorderiteam.quantity * tblproduct.price) AS TongDoanhThu
FROM 
    tblorderiteam
INNER JOIN 
    tblproduct 
ON 
    tblorderiteam.product_id = tblproduct.id
INNER JOIN 
    tblorder
ON 
    tblorderiteam.order_id = tblorder.id
INNER JOIN 
    tblshipment 
ON 
    tblorder.shipment_id = tblshipment.id
WHERE 
    tblshipment.status = N'Hoàn thành'
";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value && result != null)
            {
                tongDoanhThu = Convert.ToDecimal(result);
            }

            conn.Close();
            return tongDoanhThu;
        }

        public int GetTongDonHang()
        {
            int totalOrders = 0;
            string sql = "SELECT COUNT(*) FROM tblorder";  

            conn.Open(); 

            SqlCommand cmd = new SqlCommand(sql, conn);
            totalOrders = (int)cmd.ExecuteScalar();  // ExecuteScalar sẽ trả về giá trị đầu tiên trong kết quả (tổng số đơn hàng)

            conn.Close();  // Đóng kết nối

            return totalOrders;  // Trả về số lượng đơn hàng
        }

        public string GetSanPhamBanChayNhat()
        {
            string bestSellingProduct = string.Empty;
            string sql = "SELECT TOP 1 tblproduct.name FROM tblproduct " +
                         "INNER JOIN tblorderiteam ON tblproduct.id = tblorderiteam.product_id " +
                         "GROUP BY tblproduct.name " +
                         "ORDER BY SUM(tblorderiteam.quantity) DESC"; 

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                bestSellingProduct = rd["name"].ToString();
            }
            conn.Close();
            return bestSellingProduct;
        }
        public int GetDonHangChuaXuLy()
        {
            int pendingOrdersCount = 0;
            string sql = "SELECT COUNT(*) FROM tblshipment WHERE status = 'Chưa xử lý'";  // Assuming 'Pending' is the status for unprocessed orders
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            pendingOrdersCount = (int)cmd.ExecuteScalar();
            conn.Close();
            return pendingOrdersCount;
        }
        public List<ThongKeDTO> listThongKe()
        {
            List<ThongKeDTO> list= new List<ThongKeDTO>();
            string sql = @"SELECT p.name, 
                               SUM(od.Quantity) AS QuantitySold, 
                               SUM(od.Quantity * od.Price) AS Revenue
                        FROM tblorderiteam od
                        JOIN tblproduct p ON od.product_id = p.id
                        GROUP BY p.name
                        ORDER BY Revenue DESC";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ThongKeDTO thongKeDTO = new ThongKeDTO
                {
                    ProductName = rd["name"].ToString(),  // Lấy tên sản phẩm
                    QuantitySold = Convert.ToInt32(rd["QuantitySold"]), // Lấy số lượng bán
                    Revenue = Convert.ToDecimal(rd["Revenue"]) // Lấy doanh thu
                };
                list.Add(thongKeDTO);
            }
            conn.Close();
            return list;
        }
    }
}