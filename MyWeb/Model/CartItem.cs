﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class CartItem
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public CartItem() { }

        public CartItem(int id, int cartId, int productId, int quantity, double price)
        {
            this.id = id;
            this.cartId = cartId;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }
    }
}