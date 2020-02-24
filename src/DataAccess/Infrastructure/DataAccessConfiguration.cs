using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Infrastructure
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddTransient(typeof(IImageRepository), typeof(ImageRepository));
            services.AddTransient(typeof(IDeliveryRepository), typeof(DeliveryRepository));
            services.AddTransient(typeof(IGroupCharacteristicRepository), typeof(GroupCharacteristicRepository));
            services.AddTransient(typeof(ICharacteristicRepository), typeof(CharacteristicRepository));

            services.AddTransient(typeof(IPackageRepository), typeof(PackageRepository));
            services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddTransient(typeof(IOrderDetailsRepository), typeof(OrderDetailsRepository));

            services.AddTransient(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddTransient(typeof(IBrandRepository), typeof(BrandRepository));


            services.AddDbContext<StoreContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("myconn")));
        }
    }
}