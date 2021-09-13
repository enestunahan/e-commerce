using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Abstarct
{
   public interface ICartItemService
    {
        void DeleteFromCart(int cartid, int productid);      
    }
}
