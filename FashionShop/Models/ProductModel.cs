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

        public Product one(string ID)
        {
            string sql = string.Format("Select * From Product Where ID = '{0}'", ID);
            DataTable result = this.provider.executeQuery(sql);
            DataRow row = result.Rows[0];

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

            return product;
        }

        public int totalResults(Product product)
        {
            string sql = string.Format(
                "Select (Count(ID) / 10 + 1) As Total From Product Where ID = '{0}' Or Name = '{1}'",
                product.Id, product.Name);

            DataTable result = this.provider.executeQuery(sql);

            return (int)result.Rows[0]["Total"];
        }

        public Product[] search(Product product, int page)
        {
            SqlCommand command = new SqlCommand("usp_searchProducts");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters.Add("@id", SqlDbType.VarChar);
            command.Parameters.Add("@name", SqlDbType.NVarChar);

            command.Parameters["@page"].Value = page;
            command.Parameters["@id"].Value = product.Id;
            command.Parameters["@name"].Value = product.Name;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                product = new Product();
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

        public bool insert(Product product)
        {
            DateTime currentDate = new DateTime();

            string sql = string.Format(
                "Insert Into Product(ID, Name, Manufacturer, Price, Origin, Views, Sales, Image, State, Time, Sex) Values ('{0}', N'{1}', '{2}', {3}, N'{4}', 0, 0, '{5}', 1, '{6}', {7})",
                product.Id, product.Name, product.Manufacturer, product.Price, product.Origin, product.Image, currentDate.ToLocalTime() , product.Sex);

            return this.provider.executeNonQuery(sql);
        }

        public bool update(Product product)
        {
            string sql = string.Format(
                "Update Product Set Name = N'{0}', Manufacturer = N'{1}', Price = {2}, Origin = N'{3}', Sex = {4}, Image = '{5}' Where ID = '{6}'",
                product.Name, product.Manufacturer, product.Price, product.Origin, product.Sex, product.Image, product.Id);

            return this.provider.executeNonQuery(sql);
        }

        public bool delete(Product product)
        {
            string sql = string.Format("Update Product Set State = 0 Where ID = '{0}'", product.Id);

            return this.provider.executeNonQuery(sql);
        }
    }
}