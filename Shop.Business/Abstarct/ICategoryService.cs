using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Abstarct
{
   public interface ICategoryService
    {
        Task<List<Category>>  GetAll();
        Category GetById(int id);
        
    }
}
