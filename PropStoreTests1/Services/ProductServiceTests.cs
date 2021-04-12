using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Services.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        ProductService productService = new ProductService();
        [TestMethod()]
        public void KeyWordEmptyTest()
        { 
            string tryString = " ";
            productService.SearchProducts(tryString);
            Assert.IsNotNull(string.Empty);
        }
        [TestMethod()]
        public void KeyWordNullTest()
        {
            string tryString = null;
            productService.SearchProducts(tryString);
            Assert.IsNull(tryString);
        }
        [TestMethod()]
        public void KeyWordIsEqualProductName()
        {
            string tryString = "hund";
            productService.SearchProducts(tryString);
            Assert.AreEqual(tryString, "hund");
        } 
        [TestMethod()]
        public void KeyWordIsEqualModel()
        {
            string tryString = "Bästa vän";
            productService.SearchProducts(tryString);
            Assert.AreEqual(tryString, "Bästa vän");
        }
        [TestMethod()]
        public void KeyWordModelFailTest()
        {
            string tryString = "Stjärna";
            productService.SearchProducts(tryString);
            Assert.Fail(tryString, "Stjärna");
        }
    }
}