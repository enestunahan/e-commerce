using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Abstarct
{
  public interface ICategoryProductService
    {
        void Add(CategoryProduct categoryProduct);
        CategoryProduct Get(int id,int productid);
        void Delete(int id, int productid);
    }
}
