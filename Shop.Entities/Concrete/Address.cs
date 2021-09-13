using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities.Concrete
{
   public class Address :IEntity
    {
        public int Id { get; set; }
        //public User User { get; set; }
        public string UserId { get; set; }
        public string AddressTitle { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
        public Order Order { get; set; }
    }
}
