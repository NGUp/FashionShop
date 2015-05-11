using FashionShop.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections;

namespace FashionShop.Tests
{
    
    
    /// <summary>
    ///This is a test class for AnalyzeTest and is intended
    ///to contain all AnalyzeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnalyzeTest
    {
        private Analyze analyze;

        public AnalyzeTest()
        {
            this.analyze = new Analyze();
        }

        [TestMethod]
        public void testAnalyzeKeyValue()
        {
            string data = "user=isdjasd&id=askdaldk";
            Hashtable pair = this.analyze.analyzeIdAndUser(data);

            Assert.AreEqual("askdaldk", pair["Username"]);
            Assert.AreEqual("isdjasd", pair["ID"]);
        }

        [TestMethod]
        public void testAnalyzeKeyValueProduct()
        {
            string data = "id=131210.8.3&name=Áo dạ kẻ-MT Đỏ tím";
            Hashtable pair = this.analyze.analyzeProductIdAndName(data);

            Assert.AreEqual("131210.8.3", pair["ProductID"]);
            Assert.AreEqual("Áo dạ kẻ-MT Đỏ tím", pair["ProductName"]);
        }
    }
}
