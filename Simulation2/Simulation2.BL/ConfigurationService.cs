using Microsoft.Extensions.DependencyInjection;
using Simulation2.BL.Services.Abstractions;
using Simulation2.BL.Services.Implementations;
using System.Reflection;

namespace Simulation2.BL
{
    public static class ConfigurationService
    {
        public static void AddBLService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());    
            services.AddScoped<ITechnicianService, TechnicianService>();    
        }
    }
}
