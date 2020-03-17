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
            services.AddTransient(typeof(IAddressService), typeof(AddressService));
            services.AddTransient(typeof(IBrandService), typeof(BrandService));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(ICharacteristicService), typeof(CharacteristicService));
            services.AddTransient(typeof(IDeliveryService), typeof(DeliveryService));
            services.AddTransient(typeof(IGroupCharacteristicService), typeof(GroupCharacteristicService));
            services.AddTransient(typeof(IImageService), typeof(ImageService));
            services.AddTransient(typeof(IOrderService), typeof(OrderService));
            services.AddTransient(typeof(IOrderDetailsService), typeof(OrderDetailsService));
            services.AddTransient(typeof(IPackageService), typeof(PackageService));
            services.AddTransient(typeof(IProductService), typeof(ProductService));
            services.AddTransient(typeof(ILikeService), typeof(LikeService));

            services.AddTransient(typeof(ICommentService), typeof(CommentService));            
            services.AddTransient(typeof(IUserService), typeof(UserService));
          
            

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}