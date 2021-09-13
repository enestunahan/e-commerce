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
    public class EfOrderDal : EfEntityRepositoryBase<Order, ShopContext>, IOrderDal
    {
        public List<Order> GetOrderDetail(string userid)
        {
            using(var context = new ShopContext())
            {
                    return context.Orders.Where(x => x.UserId == userid).
                    Include(x => x.OrderItems).
                    Include(x => x.Address).ToList();
            }
        }
    }
}
