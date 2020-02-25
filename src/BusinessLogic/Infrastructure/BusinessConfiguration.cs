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
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));

            //services
            services.AddTransient(typeof(IDeliveryService<Delivery>), typeof(DeliveryService));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(ICommentService), typeof(CommentService));
            services.AddTransient(typeof(IGroupCharacteristicService), typeof(GroupCharacteristicService));
            services.AddTransient(typeof(IImageService), typeof(ImageService));
            services.AddTransient(typeof(IUserService), typeof(UserService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}