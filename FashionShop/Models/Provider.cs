using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace FashionShop.Models
{
    public class Provider
    {
        private SqlConnection connection;

        public SqlConnection openConnection()
        {
            if (this.connection == null)
            {
                this.connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=FashionShop;Integrated Security=SSPI;");
            }

            return this.connection;
        }
    }
}