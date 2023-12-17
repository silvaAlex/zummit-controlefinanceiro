using Microsoft.EntityFrameworkCore;
using Zummit.Auth.Data;
using Zummit.Auth.Repository;
using Zummit.Auth.Services;

namespace Zummit.Auth.Abstractions
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository,ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ClienteDb"));

            return services;
        }
    }
}
