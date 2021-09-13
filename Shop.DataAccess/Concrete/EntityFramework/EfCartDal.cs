using Microsoft.EntityFrameworkCore;
using Shop.Core.DataAccess.Concrete.EntityFramework;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.Context;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ShopContext>, ICartDal
    {
        public Cart GetByCartId(int cartid)
        {
            using (var context = new ShopContext())
            {
                return context.Carts.Where(x => x.Id == cartid).
                    Include(x => x.CartItems).
                    ThenInclude(x => x.Product).FirstOrDefault();

            } 
        }

        public Cart GetByUserId(string userid)
        {
           using(var context = new ShopContext())
            {
                return context.Carts.Where(x => x.UserId == userid).
                    Include(x => x.CartItems).
                    ThenInclude(x => x.Product).FirstOrDefault();
            }
        }

        public int GetCartCountItem(Cart cart)
        {
            using (var context = new ShopContext())
            {
                return cart.CartItems.Sum(x => x.Quantity);
            }
        }

        public override void Update(Cart entity)
        {
            using (ShopContext context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
