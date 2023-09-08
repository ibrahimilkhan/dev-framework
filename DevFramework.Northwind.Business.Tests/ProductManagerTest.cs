using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using FluentValidation;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IProductDal> productDal = new Mock<IProductDal>();

            //ProductManager productService = new ProductManager(productDal.Object);

            //productService.Add(new Product());
        }
    }
}
