using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}