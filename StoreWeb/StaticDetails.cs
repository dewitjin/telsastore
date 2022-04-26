using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb
{
    public static class StaticDetails
    {
        public static string APIBaseUrl = "https://localhost:44316/";
        public static string CustomerUrl = $"{APIBaseUrl}api/customers/";
        public static string ItemUrl = $"{APIBaseUrl}api/items/";
        public static string OrderUrl = $"{APIBaseUrl}api/orders/";
    }
}
