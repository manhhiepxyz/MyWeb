using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Shipment
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int userId { get; set; }
        public string status { get; set; }
        public string date { get; set; }

        public Shipment() { }

        public Shipment(int id, string fullName, string phone, string address, int userId, string status, string date)
        {
            this.id = id;
            this.fullName = fullName;
            this.phone = phone;
            this.address = address;
            this.userId = userId;
            this.status = status;
            this.date = date;
        }
    }
}