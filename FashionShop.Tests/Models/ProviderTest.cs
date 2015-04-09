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
        [TestMethod]
        public void ConnectionString()
        {
            Provider provider = new Provider();

            Assert.AreEqual(provider.openConnection().ConnectionString, @"Server=.\SQLEXPRESS;Database=FashionShop;Integrated Security=SSPI;");
        }

        [TestMethod]
        public void TestConnection()
        {
            Provider provider = new Provider();

            SqlConnection connection = provider.openConnection();

            connection.Open();

            Assert.AreEqual(connection.State, ConnectionState.Open);

            connection.Close();
        }
    }
}
