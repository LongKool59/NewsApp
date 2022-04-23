using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using NewsApp.DataAccessor;
using NewsApp.Business.Services;
using NewsApp.Business.Interfaces;

namespace NewsApp.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessorLayer(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICommentService, CommentsService>();

            /*services.AddRefitClient<IIdentityProviderService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001"));*/
        }
    }
}