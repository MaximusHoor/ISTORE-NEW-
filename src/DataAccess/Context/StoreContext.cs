using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;
using System;

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
                new Product []
                {
                    new Product {Id = 1,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="A51",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Samsung Galaxy",
                    Type = "Phone",
                    VendorCode="YUHNGG",
                    Rating = 20,
                    RetailPrice =8499,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/s/d/sdfhg_2_1.jpg"},

                    new Product {Id = 2,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="A50",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Samsung Galaxy",
                    Type = "Phone",
                    VendorCode="YUHNGG",
                    Rating = 2,
                    RetailPrice =8279,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/3/2/32r2388uiuu.jpg"},

                    new Product {Id = 3,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="11",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Apple iPhone",
                    Type = "Phone",
                    VendorCode="YUHNGG",
                    Rating = 12,
                    RetailPrice =22999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/i/p/iphone_11_b_2_2.jpg"},

                    new Product {Id = 4,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="XS Max",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Apple iPhone",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 14,
                    RetailPrice =25999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/a/p/apple_iphone_xs_gold_1.jpg"},

                    new Product {Id = 5,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="Moto E6 Plus",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Motorola",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 5,
                    RetailPrice =2999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/c/o/copy_of_motoe6_plus_polished_graphite_backside__1.jpg"},

                    new Product {Id = 6,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="Fold",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Samsung Galaxy",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 8,
                    RetailPrice =56999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/s/a/samsung_galaxy_fold_12_512gb_silver_images_15092010446.jpg"},

                    new Product {Id = 7,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="Redmi Note 8 Pro",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Xiaomi",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 17,
                    RetailPrice =5999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/f/i/file_1282_6.jpg"},

                    new Product {Id = 8,
                    BrandId = 1,
                    CategoryId = 1,
                    Model="Redmi Note 8T",
                    CountInStorage = 5,
                    Series ="RR",
                    Title ="Xiaomi",
                    Type = "type",
                    VendorCode="YUHNGG",
                    Rating = 9,
                    RetailPrice =4999,
                    PackageId = 1,
                    WarrantyMonth = 12,
                    Description = "Description",
                    PreviewImage="https://i.allo.ua/media/catalog/product/cache/3/image/600x415/799896e5c6c37e11608b9f8e1d047d15/f/i/file_1341_1_2.jpg"},
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

            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Number = "#101",
                    Date = DateTime.Now,
                    UserId = 1,
                    DeliveryStatus = "",
                    PaymentStatus = "",
                }
                );
            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails[]
                {
                new OrderDetails { Id = 1, Count = 2, OrderId = 1, ProductId = 1 },
                new OrderDetails { Id = 2, Count = 3, OrderId = 1, ProductId = 2 },
                new OrderDetails { Id = 3, Count = 5, OrderId = 1, ProductId = 3 }
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Some FirstName",
                    LastName = "Some LastName",
                    PhoneNumber = "Some phone",
                    Email = "Some email"
                });

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GroupCharacteristic> GroupCharacteristics { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}