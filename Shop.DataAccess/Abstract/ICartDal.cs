using Shop.Core.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Shop.DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        Cart GetByUserId(string userid);
        Cart GetByCartId(int cartid);
        int GetCartCountItem(Cart cart);
    }
}
