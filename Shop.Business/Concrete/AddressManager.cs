using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public async Task<List<Address>>  Addresses(string userid)
        {
            return await _addressDal.GetList(filter: x => x.UserId == userid);
        }

        public Address CreateAddress(Address address)
        {
            return _addressDal.Add(address);
        }

        public void DeleteAddress(Address address)
        {
            _addressDal.Delete(address);
        }

        public Address GetAddress(int id)
        {
            return _addressDal.Get(filter: x => x.Id == id);
        }

        public void UpdateAddress(Address address)
        {
            _addressDal.Update(address);
        }
    }
}
