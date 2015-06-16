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
            string sql = "Select Count(ID) As Total From Product";

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public Product one(string ID)
        {
            string sql = string.Format(
                "Select product.ID, product.Name, product.Price, product.Image, product.Origin, product.Sales, " +
                        "product.Sex, product.Views, product.State, " +
                        "manufacturer.Name as Manufacturer, category.CategoryName as Category " +
                "From (Product product Join Manufacturer manufacturer On product.Manufacturer = manufacturer.ID) " +
                        "Join Category category on product.Category = category.CategoryID " +
                "Where product.ID = '{0}'", ID);

            DataTable result = this.provider.executeQuery(sql);

            if (result.Rows.Count == 0) {
                return null;
            }

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
            product.Category = row["Category"].ToString();

            return product;
        }

        public Product[] searchSimple(string name)
        {
            string sql = string.Format(
                "Select product.ID, product.Name, product.Price, product.Image From Product product " +
                "Where product.Name Like '%{0}%'", name);

            DataTable result = this.provider.executeQuery(sql);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString().Trim();
                product.Name = row["Name"].ToString();
                product.Price = Int32.Parse(row["Price"].ToString());
                product.Image = row["Image"].ToString();
                products[index] = product;
                index++;
            }

            return products;
        }

        public int count(string ID)
        {
            string sql = string.Format(
                "Select Quantity From Product Where ID = '{0}' And State = 1", ID);

            DataTable result = this.provider.executeQuery(sql);

            return Int32.Parse(result.Rows[0]["Quantity"].ToString());
        }

        public int payment(string purchaseOrder, string ID, int quantity)
        {
            string sql = string.Format("Update Product Set Quantity = Quantity - {0} Where ID = '{1}'", quantity, ID);
            this.provider.executeNonQuery(sql);
            
            sql = string.Format("Update Product Set Sales = Sales + {0} Where ID = '{1}'", quantity, ID);
            this.provider.executeNonQuery(sql);

            return this.count(ID);
        }

        public int totalResults(Product product)
        {
            string sql = string.Format(
                "Select (CEILING(Count(ID) / 20.0)) As Total From Product Where (ID = '{0}' Or Name = '{1}') And State = 1",
                product.Id, product.Name);

            DataTable result = this.provider.executeQuery(sql);

            return Int32.Parse(result.Rows[0]["Total"].ToString());
        }

        public int getTotalPageByCategory(string category)
        {
            string sql = string.Format("Select (CEILING(Count(ID) / 15.0))  As Total From Product Where State = 1 And Category = '{0}'", category);

            DataTable result = this.provider.executeQuery(sql);

            return Int32.Parse(result.Rows[0]["Total"].ToString());
        }

        public int getTotalPageByManufacturer(string manufacturer)
        {
            string sql = string.Format("Select (CEILING(Count(ID) / 15.0))  As Total From Product Where State = 1 And Manufacturer = '{0}'", manufacturer);

            DataTable result = this.provider.executeQuery(sql);

            return Int32.Parse(result.Rows[0]["Total"].ToString());
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

        public Product[] getNews()
        {
            string sql = "SELECT * FROM ( SELECT ROW_NUMBER() OVER ( ORDER BY ID ) AS RowNum, * FROM Product) AS RowConstrainedResult " +
                        "WHERE RowNum >= 1 AND RowNum < 13 And State = 1 ORDER BY Time DESC, RowNum";

            DataTable result = this.provider.executeQuery(sql);
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

        public Product[] getSales()
        {
            string sql = "SELECT * FROM ( SELECT ROW_NUMBER() OVER ( ORDER BY ID ) AS RowNum, * FROM Product) AS RowConstrainedResult " +
                        "WHERE RowNum >= 1 AND RowNum < 13 And State = 1 ORDER BY Sales DESC, RowNum";

            DataTable result = this.provider.executeQuery(sql);
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

        public Product[] getRelativeProducts(string product_ID)
        {
            string sql = string.Format(
                "Select top 5 * From Product Where State = 1 And ID != '{0}' And Category = (Select Category From Product Where ID = '{1}')", product_ID, product_ID);

            DataTable result = this.provider.executeQuery(sql);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString();
                product.Name = row["Name"].ToString();
                product.Manufacturer = row["Manufacturer"].ToString();
                product.Price = Int32.Parse(row["Price"].ToString());
                product.Image = row["Image"].ToString();
                products[index] = product;
                index++;
            }

            return products;
        }

        public Product[] getByCategory(string category, int page)
        {
            SqlCommand command = new SqlCommand("usp_getProductByCategory");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters.Add("@category", SqlDbType.VarChar);

            command.Parameters["@page"].Value = page;
            command.Parameters["@category"].Value = category;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString().Trim();
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

        public Product[] getByManufacturer(string category, int page)
        {
            SqlCommand command = new SqlCommand("usp_getProductByManufacturer");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters.Add("@manufacturer", SqlDbType.VarChar);

            command.Parameters["@page"].Value = page;
            command.Parameters["@manufacturer"].Value = category;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString().Trim();
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
        
        public Product[] searchAdvance(string category, int sex, int price)
        {
            string condition = "";
            string sql = "Select * From Product";
            
            if (category != "" && category != "all")
            {
                condition += string.Format(" Category = '{0}'", category);
            }
            
            if (sex != 2 && sex != -1)
            {
                if (condition == "")
                {
                    condition += string.Format(" Sex = {0}", sex);
                }
                else
                {
                    condition += string.Format(" Or Sex = {0}", sex);
                }
            }
            
            if (price != 3 && price != -1)
            {
                int min, max;
                
                min = 0;
                max = 0;
                
                if (price == 0)
                {
                    min = 100000;
                    max = 300000;
                }
                else if (price == 1)
                {
                    min = 300000;
                    max = 500000;    
                }
                else if (price == 2)
                {
                    min = 500000;
                    max = 1000000;    
                }
                else if (price == 3)
                {
                    min = 100000;
                    max = 1000000;    
                }
                
                if (condition == "")
                {
                    condition += string.Format(" (Price >= {0} And Price <= {1})", min, max);
                }
                else
                {
                    condition += string.Format(" Or (Price >= {0} And Price <= {1})", min, max);
                }
            }
            
            if (condition != "")
            {
                sql += " Where" + condition;
            }
            
            DataTable result = this.provider.executeQuery(sql);
            Product[] products = new Product[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product();
                product.Id = row["ID"].ToString().Trim();
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
            DateTime currentTime = DateTime.Now;
            string format = "yyyy-MM-dd";

            string sql = string.Format(
                "Insert Into Product(ID, Name, Manufacturer, Price, Origin, Views, Sales, Image, State, Time, Sex) Values ('{0}', N'{1}', '{2}', {3}, N'{4}', 0, 0, '{5}', 1, '{6}', {7})",
                product.Id, product.Name, product.Manufacturer, product.Price, product.Origin, product.Image, currentTime.ToString(format), product.Sex);

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