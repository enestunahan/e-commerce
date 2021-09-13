using Microsoft.EntityFrameworkCore;
using Shop.Core.DataAccess.Concrete.EntityFramework;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.Context;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ShopContext>, IProductDal
    {
        public List<Product> BestSellers()
        {
            using(var context = new ShopContext())
            {
                return context.Products.
                    OrderByDescending(x => x.QuantitySold).Take(3).ToList();
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            using(var context = new ShopContext())
            {
                await context.AddAsync(product);
                context.SaveChanges();
                return product;
            }
        }

        public Product GetProductDetails(int id)
        {
           using(var context = new ShopContext())
            {
                return context.Products
                               .Where(i => i.ProductId == id).Include(x => x.CategoryProducts).
                               ThenInclude(x => x.Category).FirstOrDefault();

            }
        }

        public async Task<List<Product>>  GetProductsByCategory(int categoryid)
        {
            using (var context = new ShopContext())
            {
                return await context.Products.Include(x => x.CategoryProducts).
                    ThenInclude(x => x.Category)
                    .Where(x => x.CategoryProducts.Any(x => x.Category.CategoryId == categoryid)).ToListAsync();
            }
        }

        public override void Update(Product entity)
        {
            using (ShopContext context = new ShopContext())
            {
                context.Products.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
