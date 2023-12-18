using Microsoft.EntityFrameworkCore;
using Zummit.Conta.Data;
using Zummit.Conta.Repositories;
using Zummit.Conta.Services;

namespace Zummit.Conta.Abstractions
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        { 
            services.AddDbContext<ContaDbContext>(options => options.UseInMemoryDatabase("ClienteDb"));
            services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
            services.AddScoped<IContaBancariaService, ContaBancariaService>();

            return services;
        }
    }
}
