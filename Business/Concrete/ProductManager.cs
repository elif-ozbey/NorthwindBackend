using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCutingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager (IProductDal productDal)
        {
            _productDal = productDal;
        }

     [ValidationAspect(typeof(ProductValidator),Priority =1)]
     [CacheRemoveAspect(pattern:"IProductService.Get")]
        public IResult Add(Product product)
        {
           
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductId == p.productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }
        [CasheAspects(duration:1)]
       public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

        [TransactionScopeAspect] //Basarili olma durumunda islemi yapack basarisiz olursa islemi geri alacak
        public IResult TransactionalOperation(Product product)
        {//Transactionsppce aspectin icinde invocation dedigimiz asagidaki kod, bu kod blogunu calistiriyor basarili olursa complete' basarisiz olursa dispose yapiyor
            _productDal.Add(product);

            _productDal.Update(product);
            
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
