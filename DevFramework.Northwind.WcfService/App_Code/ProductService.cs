using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.Business.DependencyResolver.Ninject;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService : IProductService
{
    // Tüm servisi implemente ettik. Yani tüm business'ı çağırdık.

    // Arayüzümüzü istediğimizde servisten istediğimizde business'tan çıkarabiliriz. 

    // Eğer tüm servisi dış dünyaya açmak istemezsek farklı bir yaklaşım sergilemeliyiz.

    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransactionOperation(Product product1, Product product2)
    {
        _productService.TransactionOperation(product1, product2);
    }

    public Product Update(Product product)
    {
        return (_productService.Update(product));
    }
}