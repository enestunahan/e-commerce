using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        

        public async Task<List<Category>>  GetAll()
        {
            return await _categoryDal.GetList();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(filter: x => x.CategoryId == id);
        }

        
    }
}
