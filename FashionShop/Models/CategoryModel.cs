using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;
using System.Data.SqlClient;

namespace FashionShop.Models
{
    public class CategoryModel
    {
        private Provider provider = new Provider();

        public Category[] getAll()
        {
            string sql = "Select CategoryID, CategoryName From Category Where State = 1";
            DataTable result = this.provider.executeQuery(sql);
            Category[] categories = new Category[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Category category = new Category();
                category.ID = row["CategoryID"].ToString().Trim();
                category.Name = row["CategoryName"].ToString().Trim();

                categories[index] = category;
                index++;
            }

            return categories;
        }
        
        public int total()
        {
            string sql = "Select Count(CategoryID) As Total From Category";

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public string getCategoryName(string ID)
        {
            string sql = string.Format("Select CategoryName From Category Where State = 1 And CategoryID = '{0}'", ID);

            DataTable result = this.provider.executeQuery(sql);

            return result.Rows[0]["CategoryName"].ToString();
        }
        
        public Category[] get(int page)
        {
            SqlCommand command = new SqlCommand("usp_GetAllCategories");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Category[] categories = new Category[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Category category = new Category();
                category.ID = row["CategoryID"].ToString();
                category.Name = row["CategoryName"].ToString();
                categories[index] = category;
                index++;
            }

            return categories;
        }

        public int totalResults(string keyword)
        {
            string sql = string.Format(
                "Select Count(CategoryID) As Total From Category Where CategoryID = '{0}' Or CategoryName = '{0}'",
                keyword);

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public Category[] search(string keyword, int page)
        {
            SqlCommand command = new SqlCommand("usp_searchCategories");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters.Add("@keyword", SqlDbType.VarChar);

            command.Parameters["@page"].Value = page;
            command.Parameters["@keyword"].Value = keyword;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Category[] categories = new Category[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Category category = new Category();
                category.ID = row["CategoryID"].ToString();
                category.Name = row["CategoryName"].ToString();
                categories[index] = category;
                index++;
            }

            return categories;
        }
    }
}