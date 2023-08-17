using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                ProductId = 1,
                CategoryId = 1,
                ProductName = "Test product",
                UnitPrice = 400,
                QuantityPerUnit = "5 in a box"
            });

            return "Added";
        }

        public string GetById()
        {
            _productService.GetById(1);
            return "Got";
        }

        public string AddUpdate() 
        {
            _productService.TransactionOperation(
                new Product { ProductId = 1,CategoryId = 2,UnitPrice=400,QuantityPerUnit="1"},
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Test", UnitPrice = 10, QuantityPerUnit = "1" });

            return "Success";
        }
    }
}
