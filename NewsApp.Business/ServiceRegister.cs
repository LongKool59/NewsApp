using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using NewsApp.DataAccessor;

namespace NewsApp.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessorLayer(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
  


            /*services.AddRefitClient<IIdentityProviderService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001"));*/
        }
    }
}