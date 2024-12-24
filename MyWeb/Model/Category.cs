using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image {  get; set; }

        public Category() { }

        public Category(int id, string name, string image)
        {
            this.id = id;
            this.name = name;
            this.image = image;
        }
    }
}