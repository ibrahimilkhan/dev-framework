using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation;
using Moq;
using System;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mockProductDal = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mockProductDal.Object);

            productManager.Add(new Product());
        }
    }
}
