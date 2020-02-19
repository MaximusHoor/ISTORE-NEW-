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
            services.AddTransient(typeof(IGroupCharacteristicRepository), typeof(GroupCharacteristicRepository));
            services.AddDbContext<StoreContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("myconn")));
        }
    }
}