using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.DTO
{
    public class OrderDTO
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public double totalPrice { get; set; }
        public string date { get; set; }
        public int paymentId { get; set; }
        public int amount { get; set; }
        public int shipmentId { get; set; }
        public string fullName { get; set; }
        public string status { get; set; }
        public string dateShip { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int orderItemID {  get; set; }
        public int price { get; set; }
        public int productID { get; set; }
        public int priceProduct { get; set; }
        public int quantity { get; set; }
        public string image {get; set; }
        public OrderDTO() { }

        public OrderDTO(
                    int orderId, int userId, string username, double totalPrice, string date,
                    int paymentId, int amount, int shipmentId, string fullName, string status,
                    string dateShip, string phone, string address, int orderItemID, int price,
                    int productID, int priceProduct, int quantity, string image)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.username = username;
            this.totalPrice = totalPrice;
            this.date = date;
            this.paymentId = paymentId;
            this.amount = amount;
            this.shipmentId = shipmentId;
            this.fullName = fullName;
            this.status = status;
            this.dateShip = dateShip;
            this.phone = phone;
            this.address = address;
            this.orderItemID = orderItemID;
            this.price = price;
            this.productID = productID;
            this.priceProduct = priceProduct;
            this.quantity = quantity;
            this.image = image;
        }
    }
}