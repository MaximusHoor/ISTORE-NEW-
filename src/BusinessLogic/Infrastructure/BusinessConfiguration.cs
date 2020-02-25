using Business.Service;
using Business.Service.Interfaces;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services
            services.AddTransient(typeof(IDeliveryService<Delivery>), typeof(DeliveryService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}