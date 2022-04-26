using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressID { get; set; } //TODO to make a customer we will need to make an address too. But for this project all customers have been preloaded to the database with the an addressID assign to them.
    }
}
