using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;

namespace FashionShop.Models
{
    public class ManufacturerModel
    {
        private Provider provider = new Provider();

        public Manufacturer[] getTopManufacturers()
        {
            string sql = "Select Top 5 * From Manufacturer";

            DataTable result = this.provider.executeQuery(sql);
            Manufacturer[] manufacturers = new Manufacturer[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.Id = row["ID"].ToString();
                manufacturer.Name = row["Name"].ToString();
                manufacturers[index] = manufacturer;
                index++;
            }

            return manufacturers;
        }
    }
}