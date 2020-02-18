using System;
using System.Collections.Generic;
using System.Text;
using Domain.Context;
using Domain.Repository;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Infrastructure
{
    public static class  DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddDbContext<StoreContext>(option=>option.UseSqlServer(configuration.GetConnectionString("myconn")));
        }
    }
}
