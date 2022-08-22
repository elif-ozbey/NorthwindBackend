using Business.Abstract;
using Business.Constants;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categorydal.Add(category);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Category category)
        {
            _categorydal.Delete(category);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categorydal.Get(filter: p => p.CategoryId == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categorydal.GetList().ToList());
        }

       

        public IResult Update(Category category)
        {
            _categorydal.Update(category);
            return new SuccessResult(Messages.ProductUpdated);
                }
    }
}