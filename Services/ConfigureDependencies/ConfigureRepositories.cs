using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace Services.ConfigureDependencies
{
    public class ConfigureRepositories
    {
        #region "Methods"
        public static void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("dbConnection"));
            });
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IPaymentDetailsRepository, PaymentDetailsRepository>();
        } 
        #endregion
    }
}
