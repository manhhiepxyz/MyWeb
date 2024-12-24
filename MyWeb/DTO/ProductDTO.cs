using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.DTO
{
    public class ProductDTO
    {
        public string image { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal donGia { get; set; }
        public decimal thanhTien
        {
            get
            {
                return quantity * donGia;
            }
        }
    }

}