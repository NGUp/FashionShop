using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FashionShop.Models.Objects;

namespace FashionShop.Models
{
    public class OrderModel
    {
        private Provider provider = new Provider();

        public int total()
        {
            string sql = "Select Count(PurchaseOrder) As Total From PurchaseOrder Where State != 0";

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public Order[] get(int page)
        {
            SqlCommand command = new SqlCommand("usp_GetAllOrders");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Order[] orders = new Order[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Order order = new Order();
                order.Customer = row["Customer"].ToString();
                order.CustomerName = row["Name"].ToString();
                order.Time = (DateTime)row["Time"];
                order.PurchaseOrder = row["PurchaseOrder"].ToString();
                orders[index] = order;
                index++;
            }

            return orders;
        }
    }
}