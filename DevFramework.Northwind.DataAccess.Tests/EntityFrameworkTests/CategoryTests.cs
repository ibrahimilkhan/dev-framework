using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Get_all_categories()
        {
            var categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_filtered_categories()
        {
            var categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList().Where(x=>x.CategoryName.ToLower().Contains("c")).ToList();

            Assert.AreEqual(5, result.Count());
        }
    }
}
