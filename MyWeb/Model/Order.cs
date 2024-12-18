using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public double totalPrice { get; set; }
        public int paymentId { get; set; }
        public int shipmentId { get; set; }
        public Order() { }

        public Order(int id, int userId, double totalPrice, int paymentId, int shipmentId)
        {
            this.id = id;
            this.userId = userId;
            this.totalPrice = totalPrice;
            this.paymentId = paymentId;
            this.shipmentId = shipmentId;
        }
    }
}