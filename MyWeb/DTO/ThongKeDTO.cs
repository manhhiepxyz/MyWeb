    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace MyWeb.DTO
    {
        public class ThongKeDTO
        {
            public string ProductName { get; set; } // Tên sản phẩm
            public int QuantitySold { get; set; }   // Số lượng bán
            public decimal Revenue { get; set; }    // Doanh thu
        }


    }