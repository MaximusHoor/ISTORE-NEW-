using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}