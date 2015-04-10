using FashionShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace FashionShop.Tests
{
    [TestClass()]
    public class ProviderTest
    {
        //[TestMethod]
        //public void ConnectionString()
        //{
        //    Provider provider = new Provider();

        //    Assert.AreEqual(provider.openConnection().ConnectionString, @"Server=.\SQLEXPRESS;Database=FashionShop;Integrated Security=SSPI;");
        //}

        //[TestMethod]
        //public void TestConnection()
        //{
        //    Provider provider = new Provider();

        //    SqlConnection connection = provider.openConnection();

        //    connection.Open();

        //    Assert.AreEqual(connection.State, ConnectionState.Open);

        //    connection.Close();
        //}

        [TestMethod]
        public void TestExecuteNonQuery()
        {
            Provider provider = new Provider();

            String sql = "Insert Into Manufacturer(ID, Name) Values ('abcxyz', 'OMO')";

            bool result = provider.executeNonQuery(sql);

            Assert.AreEqual(result, true);

            if (result == true)
            {
                sql = "Delete from Manufacturer Where ID = 'abcxyz'";
                provider.executeNonQuery(sql);
            }
        }

        [TestMethod]
        public void TestExecuteQuery()
        {
            Provider provider = new Provider();

            String sql = "Insert Into Manufacturer(ID, Name) Values ('abcxyz', 'OMO')";
            provider.executeNonQuery(sql);

            sql = "Select * From Manufacturer Where ID = 'abcxyz'";

            DataTable table = provider.executeQuery(sql);
            int result = table.Rows.Count;

            Assert.AreEqual(result, 1);

            if (result > 0)
            {
                sql = "Delete from Manufacturer Where ID = 'abcxyz'";
                provider.executeNonQuery(sql);
            }
        }

        [TestMethod]
        public void TestGetData()
        {
            Provider provider = new Provider();

            String sql = "Insert Into Manufacturer(ID, Name) Values ('abcxyz0123', 'OMO')";
            provider.executeNonQuery(sql);

            sql = "Select * From Manufacturer Where ID = 'abcxyz0123'";

            DataTable table = provider.executeQuery(sql);
            DataRow row = table.Rows[0];

            Assert.AreEqual(row.Field<string>(0), "abcxyz0123");

            Assert.AreEqual(row.Field<string>(1), "OMO");

            if (table.Rows.Count > 0)
            {
                sql = "Delete from Manufacturer Where ID = 'abcxyz'";
                provider.executeNonQuery(sql);
            }
        }
    }
}
