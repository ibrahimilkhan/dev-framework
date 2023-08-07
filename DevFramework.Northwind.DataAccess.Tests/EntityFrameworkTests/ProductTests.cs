using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Get_all_products()
        {
            //Normal şartlartda Data Access katmanında birim testleri yazılmaz. Frameworkler genelde sabittirler ve testleri yapılmıştır.
            // Business ve UI'da birim testleri olmazsa olmazdır.

            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();
            Assert.IsNotNull(result);
            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList().Where(x => x.ProductName.Contains("ab")).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void Get_details()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetProductDetails();
            Assert.IsNotNull(result);
        }
    }
}
