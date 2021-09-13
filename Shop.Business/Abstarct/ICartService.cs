using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Abstarct
{
  public  interface ICartService
    {
        void InitializeCard(string userid);
        Cart GetByUserIdCard (string userid);
        Cart GetByCartId(int cartid);
        void AddToCard(string userid, int quantity, int productid);
        void DeleteFromCart(string userid, int prodcutid);
        int GetTheCount(Cart cart);
    }
}
