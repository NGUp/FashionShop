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
                category.Name = row["CategoryName"].ToString();

                categories[index] = category;
                index++;
            }

            return categories;
        }
    }
}