using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data.SqlClient;
using System.Data;

namespace FashionShop.Models
{
    public class ProductModel
    {
        private Provider provider;

        public ProductModel()
        {
            this.provider = new Provider();
        }

        public Product[] get(int page)
        {
            SqlCommand command = new SqlCommand("usp_GetAllProducts");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString();
                product.Name = row["Name"].ToString();
                product.Manufacturer = row["Manufacturer"].ToString();
                product.Price = Int32.Parse(row["Price"].ToString());
                product.Origin = row["Origin"].ToString();
                product.Views = Int32.Parse(row["Views"].ToString());
                product.Sales = Int32.Parse(row["Sales"].ToString());
                product.Image = row["Image"].ToString();
                product.State = Int32.Parse(row["State"].ToString());
                product.Sex = Int32.Parse(row["Sex"].ToString());
                products[index] = product;
                index++;
            }

            return products;
        }

        public int total()
        {
            string sql = "Select (Count(ID) / 10 + 1) As Total From Product";

            DataTable result = this.provider.executeQuery(sql);

            return (int)result.Rows[0]["Total"];
        }
    }
}