using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsApp.DataAccessor.Data;

namespace NewsApp.DataAccessor
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration configuration)
        {
/*            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
*/
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));
        }
    }
}