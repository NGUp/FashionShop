using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;

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
                category.ID = row["CategoryID"].ToString();
                category.Name = row["CategoryName"].ToString().Trim();

                categories[index] = category;
                index++;
            }

            return categories;
        }

        public string getCategoryName(string ID)
        {
            string sql = string.Format("Select CategoryName From Category Where State = 1 And CategoryID = '{0}'", ID);

            DataTable result = this.provider.executeQuery(sql);

            return result.Rows[0]["CategoryName"].ToString();
        }
    }
}