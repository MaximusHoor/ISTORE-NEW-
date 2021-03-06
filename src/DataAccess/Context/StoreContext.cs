﻿using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Context;

namespace Domain.Context
{

    public class StoreContext : IdentityDbContext<User>
    {
        
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>(entity => entity.HasMany(c=>c.Subcategories).WithOne().HasForeignKey(c=>c.ParentCategoryId));
            modelBuilder.Entity<Category>().HasData(
                 new Category[]
                 {
                   new Category
                   {
                     Id = 1,
                     Title = "Phones",
                     PreviewImage = "",
                    
                   },
                 });




            //new Category
            //{
            //    Id = 2,
            //    Title = "Smartphone",
            //    PreviewImage = ""
            //},
            //       new Category
            //       {
            //           Id = 3,
            //           Title = "Buttonphone",
            //           PreviewImage = ""
            //       },
            //modelBuilder.Entity<Category>().HasData(category);
            //var subcategory = new List<Category>() { new Category { Title = "Smartphone", PreviewImage = "" , ParentCategoryId = 2} };
            //modelBuilder.Entity<Category>().HasData(subcategory);








            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Country = "Ukraine",
                    Description = "Description",
                    Name = "Lg"
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
                new Product[]
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


            modelBuilder.Entity<ProductCharacteristic>().HasData(
              new ProductCharacteristic[]
              {
                  new ProductCharacteristic {Id = 1, Title="Стандарт связи", Value = "GSM, 3G, 4G (LTE), 5G", ProductId=1},
                  new ProductCharacteristic {Id = 2, Title="Количество sim-карт", Value ="2 SIM", ProductId=1},
                  new ProductCharacteristic {Id = 3, Title="Формат SIM-карты", Value = "Nano-SIM" , ProductId=1},
                  new ProductCharacteristic {Id = 4, Title="Диагональ", Value = "6.9", ProductId=1},
                  new ProductCharacteristic {Id = 5, Title="Количество цветов", Value ="16 миллионов", ProductId=1},
                  new ProductCharacteristic {Id = 6, Title="Тип дисплея", Value = "Dynamic AMOLED", ProductId=1},

              });

            modelBuilder.Entity<Image>().HasData(
              new Image[]
              {
                  new Image {Id = 1, FilePath="https://i.citrus.ua/uploads/shop/c/b/cb4178ebd5a5973686c461fd51399988.jpg", ProductId=1},
                  new Image {Id = 2, FilePath="https://hotline.ua/img/tx/212/2121482265.jpg", ProductId=1},
                  new Image {Id = 3, FilePath="https://www.ixbt.com/img/n1/news/2020/0/5/GalaxyNote10LitePR_mainFF_large.jpg", ProductId=1},
              });



            modelBuilder.Entity<Category>().ToTable("Categories");

            //modelBuilder.Entity<Order>().HasData(
            //    new Order
            //    {
            //        Id = 1,
            //        Number = "#101",
            //        Date = DateTime.Now,
            //        UserId = "1",
            //        DeliveryStatus = "",
            //        PaymentStatus = "",
            //    }
            //    );
            //modelBuilder.Entity<OrderDetails>().HasData(
            //    new OrderDetails[]
            //    {
            //    new OrderDetails { Id = 1, Count = 2, OrderId = 1, ProductId = 1 },
            //    new OrderDetails { Id = 2, Count = 3, OrderId = 1, ProductId = 2 },
            //    new OrderDetails { Id = 3, Count = 5, OrderId = 1, ProductId = 3 }
            //    }
            //    );
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "6cab4e64-cd04-4ba5-94d4-3c9b5ad2e78f"
            });
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                DislikesTotal = 2,
                LikesTotal = 1,
                Raiting = 4,
                Text = "Comment 1",
                ProductId = 1,
                UserId = "6cab4e64-cd04-4ba5-94d4-3c9b5ad2e78f",


            });
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 2,
                DislikesTotal = 1,
                LikesTotal = 1,
                Raiting = 4,
                Text = "Comment 2",
                ProductId = 1,
                UserId = "6cab4e64-cd04-4ba5-94d4-3c9b5ad2e78f",

            });


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Subscriber> Subscribes { get; set; }
        public DbSet<News> News { get; set; }
    }
}