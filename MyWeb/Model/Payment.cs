using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Payment
    {
        public int id { get; set; }
        public string method { get; set; }
        public int amount { get; set; }
        public int userId { get; set; }
        public string date { get; set; }

        public Payment() { }

        public Payment(int id, string method, int amount, int userId, string date)
        {
            this.id = id;
            this.method = method;
            this.amount = amount;
            this.userId = userId;
            this.date = date;
        }
    }
}