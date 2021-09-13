using Shop.Core.DataAccess.Concrete.EntityFramework;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.Context;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EfCategoryProductDal : EfEntityRepositoryBase<CategoryProduct,ShopContext> , ICategoryProductDal
    {
    }
}
