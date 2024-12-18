﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
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
        public void deleteProduct(int productId)
        {
            conn.Open();
            string sql = "Delete from tblproduct where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", productId);
            conn.Close();
            cmd.ExecuteNonQuery();
        }
        public void updateProduct(Product p)
        {
            conn.Open();
            string sql = "Update tblproduct set name=@name, image=@image , " +
                "price=@price , totalpage=@totalpage , description=@description , " +
                "author=@author , quantity=@quantity , category=@category " +
                " where id=@id";
            SqlCommand cmd= new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("name", p.name);
            cmd.Parameters.AddWithValue("image", p.image);
            cmd.Parameters.AddWithValue("price", p.price);
            cmd.Parameters.AddWithValue("totalpage", p.totalpage);
            cmd.Parameters.AddWithValue("description", p.description);
            cmd.Parameters.AddWithValue("author", p.author);
            cmd.Parameters.AddWithValue("quantity", p.quantity);
            cmd.Parameters.AddWithValue("category", p.idCategory);
            cmd.ExecuteNonQuery();
            conn.Close() ;
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