using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public int totalpage { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public int quantity { get; set; }
        public int idCategory { get; set; }
        public string categoryName { get; set; }
        public Product()
        {
            
        }
        public Product(int id, string name, string image, decimal price, int totalpage, string description, string author, int quantity, int idCategory , string categoryName)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
            this.totalpage = totalpage;
            this.description = description;
            this.author = author;
            this.idCategory = idCategory;
            this.quantity = quantity;
            this.categoryName = categoryName;
        }
    }
}