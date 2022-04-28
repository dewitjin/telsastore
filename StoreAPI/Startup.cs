using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreAPI.Data;
using StoreAPI.Helper;
using StoreAPI.Repository;
using StoreAPI.Repository.IRepository;
using StoreAPI.StoreMapper;
using System;

namespace StoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "localhost"; 
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Ilovetelsa1212";//change password later
            var database = Configuration["Database"] ?? "Store";

            try
            {
                var conn = $"Server={server},{port};Initial Catalog={database};Persist Security Info=True;User ID ={user};Password={password}";

                //Note: use the connection string below for local computer server - testing
                //var conn = $"Server=ENTER_LOCAL_SERVER_NAME;Initial Catalog={database};Trusted_Connection=True;MultipleActiveResultSets=true";

                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            services.AddAutoMapper(typeof(StoreMappings));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddControllers();

            //Use if we can use local server and provide connection string in appsettings
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            PrepDB.Initialize(app); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
