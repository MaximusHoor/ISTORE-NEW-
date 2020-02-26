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
            services.AddTransient(typeof(AddressService));
            services.AddTransient(typeof(BrandService));
            services.AddTransient(typeof(CategoryService));
            services.AddTransient(typeof(CharacteristicService));
            services.AddTransient(typeof(IDeliveryService), typeof(DeliveryService));
            services.AddTransient(typeof(GroupCharacteristicService));
            services.AddTransient(typeof(ImageService));
            services.AddTransient(typeof(OrderService));
            services.AddTransient(typeof(OrderDetailsService));
            services.AddTransient(typeof(PackageService));
            services.AddTransient(typeof(ProductService));


            //services.AddTransient(typeof(ICommentService), typeof(CommentService));            
            //services.AddTransient(typeof(IUserService), typeof(UserService));
          
            

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}