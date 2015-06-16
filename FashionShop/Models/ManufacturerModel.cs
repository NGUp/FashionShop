using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;
using System.Data.SqlClient;

namespace FashionShop.Models
{
    public class ManufacturerModel
    {
        private Provider provider = new Provider();

        public Manufacturer[] getTopManufacturers()
        {
            string sql = "Select Top 5 * From Manufacturer Where State = 1";

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

        public Manufacturer[] getAll()
        {
            string sql = "Select * From Manufacturer Where State = 1";

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

        public string getManufacturerName(string ID)
        {
            string sql = string.Format("Select Name From Manufacturer Where State = 1 And ID = '{0}'", ID);

            DataTable result = this.provider.executeQuery(sql);

            return result.Rows[0]["Name"].ToString();
        }

        public int total()
        {
            string sql = "Select Count(ID) As Total From Manufacturer Where State = 1";

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public int totalResults(string keyword)
        {
            string sql = string.Format(
                "Select Count(ID) As Total From Manufacturer Where State = 1 And (ID Like '%{0}%' Or Name Like N'%{0}%')",
                keyword);

            DataTable result = this.provider.executeQuery(sql);

            int total = (int)result.Rows[0]["Total"];

            total = (int)Math.Ceiling(total * 1f / 20);

            return total;
        }

        public Manufacturer[] get(int page)
        {
            SqlCommand command = new SqlCommand("usp_GetAllManufacturers");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
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

        public Manufacturer[] search(string keyword, int page)
        {
            SqlCommand command = new SqlCommand("usp_searchManufacturers");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters.Add("@keyword", SqlDbType.NVarChar);

            command.Parameters["@page"].Value = page;
            command.Parameters["@keyword"].Value = keyword;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
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

        public bool insert(Manufacturer manufacturer)
        {
            string sql = string.Format(
                "Insert Into Manufacturer(ID, Name, State) Values('{0}', N'{1}', 1)",
                manufacturer.Id, manufacturer.Name
                );

            return this.provider.executeNonQuery(sql);
        }

        public bool update(Manufacturer manufacturer)
        {
            string sql = string.Format(
                "Update Manufacturer Set Name = N'{0}' Where ID = '{1}'",
                    manufacturer.Name, manufacturer.Id
                );

            return this.provider.executeNonQuery(sql);
        }

        public bool delete(Manufacturer manufacturer)
        {
            bool result = false;

            string sql = string.Format("Update Manufacturer Set State = 0 Where ID = '{0}'", manufacturer.Id);
           
            result =  this.provider.executeNonQuery(sql);

            sql = string.Format("Update Product Set State = 0 Where Manufacturer = '{0}'", manufacturer.Id);

            result = this.provider.executeNonQuery(sql);

            return result;
        }
    }
}