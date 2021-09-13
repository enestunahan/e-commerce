using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Abstarct
{
  public interface IAddressService
    {
        Task<List<Address>> Addresses(string userid);
        Address CreateAddress(Address address);
        Address GetAddress(int id);
        void DeleteAddress(Address address);
        void UpdateAddress(Address address);
    }
}
