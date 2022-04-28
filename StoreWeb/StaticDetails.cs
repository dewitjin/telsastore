using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreWeb
{
    public static class StaticDetails
    {


        //Note: when running the dockerfile, localhost is replaced with config storeapi value. Assigned in docker compose and startup.cs
        public static string APIBaseUrl = "http://storeapi/";
        public static string CustomerUrl = $"{APIBaseUrl}api/customers/";
        public static string ItemUrl = $"{APIBaseUrl}api/items/";
        public static string OrderUrl = $"{APIBaseUrl}api/orders/";
    }
}
