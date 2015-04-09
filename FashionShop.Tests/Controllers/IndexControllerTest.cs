using FashionShop.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace FashionShop.Tests
{
    [TestClass()]
    public class IndexControllerTest
    {
        [TestMethod]
        public void indexIndex()
        {
            IndexController controller = new IndexController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
