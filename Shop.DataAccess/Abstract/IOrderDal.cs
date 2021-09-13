using Shop.Core.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Abstract
{
   public interface IOrderDal :IEntityRepository<Order>
    {
        List<Order> GetOrderDetail(string userid);
    }
}
