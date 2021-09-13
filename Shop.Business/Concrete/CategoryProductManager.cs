using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Concrete
{
    public class CategoryProductManager : ICategoryProductService
    {
        private ICategoryProductDal _categoryProductDal;
        public CategoryProductManager(ICategoryProductDal categoryProductDal)
        {
            _categoryProductDal = categoryProductDal;
        }
        public void Add(CategoryProduct categoryProduct)
        {
            _categoryProductDal.Add(categoryProduct);
        }

        public void Delete(int id, int productid)
        {
            _categoryProductDal.Delete(Get(id, productid));
        }

        public CategoryProduct Get(int id , int productid)
        {
            return _categoryProductDal.Get(filter: x => x.CategoryId == id && x.ProdcutId == productid);
        }
    }
}
