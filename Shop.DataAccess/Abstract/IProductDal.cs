using Shop.Core.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Abstract
{
   public interface IProductDal : IEntityRepository<Product>
    {
        Product GetProductDetails(int id);
        Task<List<Product>>  GetProductsByCategory(int categoryid);
        List<Product>  BestSellers();
        Task<Product> CreateProductAsync(Product product); 
    }
}
