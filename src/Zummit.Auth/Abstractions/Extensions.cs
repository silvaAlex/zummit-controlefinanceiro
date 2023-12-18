using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zummit.Auth.Data;
using Zummit.Auth.Identity.Services;
using Zummit.Auth.Identity.Services.Interfaces;
using Zummit.Auth.Identity.Models;

namespace Zummit.Auth.Abstractions
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        { 
            services.AddDbContext<IdentityDataContext>(options => options.UseInMemoryDatabase("ClienteDb"));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                // User defined password policy settings.  
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
