using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidator(new ProductValidator(), product);
            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);

            /* Eğer [TransactipnScopeAspect] yazmasaydık aşağıdaki gibi kötü kod örneği ortaya çıkardı
             
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _productDal.Add(product1);
                    _productDal.Update(product2);
                    scope.Complete();
                }
                catch
                {
                    scope.Dispose();
                }
            }*/
        }
    }
}