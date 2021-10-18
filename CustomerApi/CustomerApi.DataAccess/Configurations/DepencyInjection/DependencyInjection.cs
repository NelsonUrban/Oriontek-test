using CustomerApi.DataAccess.Contexts;
using CustomerApi.DataAccess.Repositories.Abstract;
using CustomerApi.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApi.DataAccess.Configurations.DepencyInjection
{
    public static partial class DependencyInjection
    {
        public static void RepositoriesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerContext>(m =>
            {
                m.UseSqlServer(configuration.GetConnectionString("Customer"));
            });

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();      

        }
    }
}
