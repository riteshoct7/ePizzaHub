using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using UI.Helpers;
using UI.Interfaces;

namespace UI.ConfigureDependencies
{
    public class ConfigureServiceDepenedencies
    {
        #region Methods

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserAccessor, UserAccessor>();            
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemService, CartItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IPaymentDetailsService, PaymentDetailsService>();
        } 

        #endregion
    }
}
