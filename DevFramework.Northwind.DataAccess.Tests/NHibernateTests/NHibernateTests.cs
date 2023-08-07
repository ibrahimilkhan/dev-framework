using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DevFramework.Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTests
    {
        [TestMethod]
        public void Get_all()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_filtered()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList().Where(x => x.ProductName.Contains("cac")).ToList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_detailed()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetProductDetails();
            Assert.IsNotNull(result);
        }
    }
}
