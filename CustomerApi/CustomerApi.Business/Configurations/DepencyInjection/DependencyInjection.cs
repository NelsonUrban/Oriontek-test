using CustomerApi.BusinessLogic.Services.Abstract;
using CustomerApi.BusinessLogic.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApi.BusinessLogic.Configurations.DepencyInjection
{
    public static partial class DependencyInjection
    {
        public static void ServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
