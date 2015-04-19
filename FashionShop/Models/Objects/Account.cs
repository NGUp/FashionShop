using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Objects
{
    public class Account
    {
        private string id;

        private string name;

        private DateTime birthday;

        private string city;

        private string username;

        private string password;

        private string state;

        private int permission;

        public Account()
        {
            permission = 1;
        }

        public int Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}