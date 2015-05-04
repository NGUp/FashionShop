using FashionShop.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace FashionShop.Tests
{
    /// <summary>
    ///This is a test class for SecurityTest and is intended
    ///to contain all SecurityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SecurityTest
    {
        private Security security;

        public SecurityTest()
        {
            this.security = new Security();
        }

        [TestMethod]
        public void testMd5Encode()
        {
            string plainText = "Hello World";

            Assert.AreEqual(this.security.encodeMD5(plainText), "b10a8db164e0754105b7a99be72e3fe5");
        }

        [TestMethod]
        public void testSha1Encode()
        {
            string plainText = "Hello World";

            Assert.AreEqual(this.security.encodeSHA1(plainText), "0a4d55a8d778e5022fab701977c5d840bbc486d0");
        }

        [TestMethod]
        public void testBase64Decode()
        {
            string cipherText = "dXNlcj1pc2RqYXNkJmlkPWFza2RhbGRr";

            Assert.AreEqual(this.security.decodeBase64(cipherText), "user=isdjasd&id=askdaldk");
        }
    }
}
