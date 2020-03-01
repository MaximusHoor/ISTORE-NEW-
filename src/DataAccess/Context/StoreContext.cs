using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{
                    Id = 1,
                    Title="Phones",
                    PreviewImage="",                    
                });



            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Country="Ukraine",
                    Description= "Description",
                    Name="Lg"
                });

            modelBuilder.Entity<Package>().HasData(
               new Package
               {
                  Id = 1,
                  CountInPackage = 6,
                  Volume = 30,
                  Weight = 40
               });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="Model",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Title",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 2,
                    RetailPrice =1000,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage=""                    
                });

            modelBuilder.Entity<GroupCharacteristic>().HasData(
               new GroupCharacteristic[]
               {
                   new GroupCharacteristic{Id = 1, ProductId = 1, Title = "Связь"},
                   new GroupCharacteristic{Id = 2, ProductId = 1, Title = "Экран"}

               }); 

            modelBuilder.Entity<Characteristic>().HasData(
              new Characteristic[]
              {
                  new Characteristic {Id = 1, GroupCharacteristicId = 1,  Title="Стандарт связи", Value = "GSM, 3G, 4G (LTE), 5G"},
                  new Characteristic {Id = 2, GroupCharacteristicId = 1,  Title="Количество sim-карт", Value ="2 SIM"},
                  new Characteristic {Id = 3, GroupCharacteristicId = 1,  Title="Формат SIM-карты", Value = "Nano-SIM" },
                  new Characteristic {Id = 4, GroupCharacteristicId = 2,  Title="Диагональ", Value = "6.9"},
                  new Characteristic {Id = 5, GroupCharacteristicId = 2,  Title="Количество цветов", Value ="16 миллионов"},
                  new Characteristic {Id = 6, GroupCharacteristicId = 2,  Title="Тип дисплея", Value = "Dynamic AMOLED" },

              }) ;

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GroupCharacteristic> GroupCharacteristics { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}