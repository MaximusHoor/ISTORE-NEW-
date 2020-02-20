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
        public DbSet<Image> Images { get; set; }
        public DbSet<GroupCharacteristic> GroupCharacteristics { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}