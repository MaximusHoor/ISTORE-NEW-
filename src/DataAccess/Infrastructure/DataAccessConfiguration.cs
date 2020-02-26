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
            
            //services.AddTransient(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddTransient(typeof(ImageRepository));
            services.AddTransient(typeof(DeliveryRepository));
            services.AddTransient(typeof(GroupCharacteristicRepository));
            services.AddTransient(typeof(CharacteristicRepository));
            services.AddTransient(typeof(PackageRepository));
            services.AddTransient(typeof(OrderRepository));
            services.AddTransient(typeof(OrderDetailsRepository));
            services.AddTransient(typeof(AddressRepository));
            services.AddTransient(typeof(BrandRepository));
            //services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(CategoryRepository));
            services.AddTransient(typeof(ProductRepository));           

            services.AddDbContext<StoreContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("myconn")));

        }
    }
}