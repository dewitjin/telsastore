using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository;
using StoreAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreAPI.Helper
{

    public static class PrepDB
    {
        // For simplicity, the backend service seeds the database with hardcoded customer and item information when it first starts.
        public static void Initialize(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>(), serviceScope.ServiceProvider.GetService<AddressRepository>());
            }
        }

        public static void SeedData(ApplicationDbContext _db, IAddressRepository _aRepo)
        {
            Console.WriteLine("Applying Migrations...");

            try
            {
                _db.Database.Migrate();

                if (!_db.Items.Any())
                {
                    Console.WriteLine("Seeding items.");

                    _db.Items.AddRange(
                        new Item() { Name = "Model X", UnitPrice = 10 },
                        new Item() { Name = "Cyber Truck", UnitPrice = 20 }
                        );
                }
                else
                {
                    Console.WriteLine("Already have items data, not seeding");
                }

                if (!_db.Addresses.Any())
                {
                    Console.WriteLine("Seeding addresses.");

                    _db.Addresses.AddRange(
                       new Address() { Street = "123 Test Street", City = "Burnaby", Zip = "V5E3N1", State = "BC", Country = "CA" },
                       new Address() { Street = "777 Test Street", City = "Vancouver", Zip = "V5N3C8", State = "BC", Country = "CA" }
                       );
                }
                else
                {
                    Console.WriteLine("Already have addresses data, not seeding");
                }

                if (!_db.Customers.Any())
                {
                    Console.WriteLine("Seeding customers.");

                    var addressID1 = _aRepo.GetAddressByStreet("123 Test Street");
                    var addressID2 = _aRepo.GetAddressByStreet("111 Test Street");

                    //Get Id from here to set up web side
                    _db.Customers.AddRange(
                     new Customer() { Name = "Jamese Bond", AddressId = addressID1.Id },
                     new Customer() { Name = "Gail Windsor", AddressId = addressID2.Id }
                     );
                }
                else
                {
                    Console.WriteLine("Already have customers data, not seeding");
                }

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}