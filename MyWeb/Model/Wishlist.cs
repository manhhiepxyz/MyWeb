using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Wishlist
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }

        public Wishlist() { }

        public Wishlist(int id, int userId, int productId)
        {
            this.id = id;
            this.userId = userId;
            this.productId = productId;
        }
    }
}