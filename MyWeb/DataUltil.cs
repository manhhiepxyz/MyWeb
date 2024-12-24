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
using MyWeb.DTO;
using MyWeb.Model;

namespace MyWeb
{
    public class DataUltil
    {
        SqlConnection conn;
        public DataUltil()
        {
            string sqlCon = "Data Source=MANHHIEP;Initial Catalog=BookStore;Integrated Security=True";
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


    }
}