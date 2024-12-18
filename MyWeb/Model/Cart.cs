using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Cart
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; }

        public Cart() { }

        public Cart(int id, int userId, int quantity)
        {
            this.id = id;
            this.userId = userId;
            this.quantity = quantity;
        }
    }
}