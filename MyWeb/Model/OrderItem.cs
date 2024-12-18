using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class OrderItem
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public OrderItem() { }

        public OrderItem(int id, int orderId, int productId, int quantity, double price)
        {
            this.id = id;
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            this.price-=price;
        }
    }
}