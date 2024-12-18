﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }

        public Role() { }

        public Role(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}