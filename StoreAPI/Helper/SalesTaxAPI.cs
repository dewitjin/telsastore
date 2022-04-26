using StoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Taxjar;

namespace StoreAPI.Helper
{
    public class SalesTaxAPI
    {
        public static TaxjarApi Init()
        {
            var client = new TaxjarApi("03aeb1c8b89dac54eb270f5ef56607a0"); //replace with your own taxjar id
            return client;
        }

        public static decimal GetTaxRate(Models.Address address)
        {
            var client = Init();

            var result = client.RatesForLocation(address.Zip, new
            {
                city = address.City,
                state = address.State,
                country = address.Country,
            });

            return result.CombinedRate;
        }
    }
}

