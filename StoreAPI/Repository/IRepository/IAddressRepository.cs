using StoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository.IRepository
{
    public interface IAddressRepository
    {
        bool AddressExists(string street);
        Address GetAddressById(int id);
        Address GetAddressByStreet(string street); 
        bool CreateAddress(Address address);//Need to seed the db
        bool Save();
    }
}
