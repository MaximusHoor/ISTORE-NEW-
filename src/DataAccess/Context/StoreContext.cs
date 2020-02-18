using System;
using System.Collections.Generic;
using System.Text;
using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
