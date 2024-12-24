using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Model
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int role { get; set; }
        public string roleName {  get; set; }

        public User() { }

        public User(int id, string userName, string pass, string fullName, string email, string phone, string address, int role , string roleName)
        {
            this.id = id;
            this.userName = userName;
            this.pass = pass;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.role = role;
            this.roleName = roleName;
        }
    }
}