using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;


namespace StoreAPI.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddressExists(string street)
        {
            bool value = _db.Addresses.Any(x => x.Street.ToLower().Trim() == street.ToLower().Trim());
            return value;
        }

        public bool CreateAddress(Address address)
        {
            var rate = Helper.SalesTaxAPI.GetTaxRate(address);
            address.TaxRate = rate;
            _db.Add(address);
            return Save();
        }

        public Address GetAddressById(int id)
        {
            return _db.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public Address GetAddressByStreet(string street)
        {
            return _db.Addresses.FirstOrDefault(x => x.Street.ToLower().Trim() == street.ToLower().Trim());
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
