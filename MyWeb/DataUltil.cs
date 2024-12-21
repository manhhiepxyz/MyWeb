using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Web;
using MyWeb.DTO;
using MyWeb.Model;

namespace MyWeb
{
    public class DataUltil
    {
        SqlConnection conn;
        public DataUltil()
        {
            string sqlCon = "Data Source=MANHHIEP;Initial Catalog=mydata;Integrated Security=True";
            conn = new SqlConnection(sqlCon);

        }
        public List<Product> listProduct()
        {
            List<Product> listProduct = new List<Product>();
            string sql = "SELECT tblproduct.id AS idProduct, tblproduct.name AS productName, image , price, totalpage, description , author," +
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
            string sql = "select tblorder.id AS orderId, tblorder.user_id AS userId, tbluser.name AS username, tblorder.toltalprice AS totalPrice, tblorder.dateCreate AS date, " +
                " tblorder.payment_id AS paymentId, tblpayment.amount AS amount, tblorder.shipment_id AS shipmentId,  tblshipment.fullname AS fullName, " +
                " tblshipment.status AS status, tblshipment.date AS dateShip, tblshipment.phone AS phone, tblshipment.address AS address,  tblorderiteam.id AS orderItemID, " +
                " tblorderiteam.price AS price, tblorderiteam.product_id AS productID, tblproduct.price AS priceProduct, tblorderiteam.quantity AS quantity, " +
                " tblproduct.image AS image from tblorder inner join tbluser on tblorder.user_id= tbluser.id " +
                "inner join tblpayment on tblorder.payment_id = tblpayment.id " +
                "inner join tblshipment on tblorder.shipment_id " +
                "inner join tblorderiteam on tblorder.id= tblorderiteam.order_id " +
                "inner join tblproduct on tblorderiteam.product_id= tblproduct.id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read()) {
                OrderDTO order = new OrderDTO
                {
                    orderId = (int)rd["orderId"],
                    userId = (int)rd["userId"],
                    username = rd["username"].ToString(),
                    totalPrice = Convert.ToDouble(rd["totalPrice"]),
                    date = rd["date"].ToString(),
                    paymentId = (int)rd["paymentId"],
                    amount = (int)rd["amount"],
                    shipmentId = (int)rd["shipmentId"],
                    fullName = rd["fullName"].ToString(),
                    status = rd["status"].ToString(),
                    dateShip = rd["dateShip"].ToString(),
                    phone = rd["phone"].ToString(),
                    address = rd["address"].ToString(),
                    orderItemID = (int)rd["orderItemID"],
                    price = (int)rd["price"],
                    productID = (int)rd["productID"],
                    priceProduct = (int)rd["priceProduct"],
                    quantity = (int)rd["quantity"],
                    image = rd["image"].ToString()
                };
                listOrder.Add(order);
            }
            rd.Close();
            conn.Close( );

            return listOrder;
        }
        public List<Category> listCategory()
        {
            List<Category> listCategory = new List<Category>();
            string sql = "SELECT id, name FROM tblcategory";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category category = new Category();
                category.id = (int)rd["id"];
                category.name = (string)rd["name"];
                listCategory.Add(category);
            }
            conn.Close();
            return listCategory;
        }
        public void DeleteProduct(int productId)
        {
            // Đảm bảo sử dụng using để tự động quản lý kết nối
            using (SqlConnection conn = new SqlConnection("Data Source=MANHHIEP;Initial Catalog=mydata;Integrated Security=True")) // Chuỗi kết nối cơ sở dữ liệu
            {
                try
                {
                    conn.Open(); // Mở kết nối

                    // Câu lệnh xóa sản phẩm
                    string sql = "DELETE FROM tblProduct WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm tham số để tránh SQL injection
                        cmd.Parameters.AddWithValue("@id", productId);

                        // Thực thi câu lệnh
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi, chẳng hạn như hiển thị thông báo cho người dùng
                    Console.WriteLine("Error deleting product: " + ex.Message);
                    // Hoặc bạn có thể ghi log để dễ dàng kiểm tra lỗi
                }
            }
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
        public Product GetProductById(int productId)
        {
            Product product = null;
            string sql = "SELECT tblproduct.id AS idProduct, tblproduct.name AS productName, image , price, totalpage, description , author," +
                         "tblcategory.name AS categoryName, category, quantity FROM tblproduct INNER JOIN tblcategory ON tblproduct.category = tblcategory.id WHERE tblproduct.id = @productId";

            conn.Open();  // Mở kết nối đến cơ sở dữ liệu

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@productId", productId); // Thêm tham số để tránh SQL injection

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

        //public List<Order> listOrder()
        //{
        //    List<Order> listOrder = new List<Order>();
        //    string sql = "";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    SqlDataReader rd = cmd.ExecuteReader();

        //}

    }
}