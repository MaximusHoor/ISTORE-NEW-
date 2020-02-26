﻿using DataAccess.Repository;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest.Repository
{

    [TestFixture]
    public class ProductRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<ProductRepository>();
        }

        private int _id;
        private string _Title;
        private string _Type;
        private string _VendorCode;
        private string _Description;
        private int? _BrandId;
        private double _RetailPrice;
        private string _PreviewImage;
        private int _CategoryId;
        private int _PackageId;
        private int _CountInStorage;
        private int _Rating;
        private int _WarrantyMonth;
        private string _Series;
        private string _Model;
        private IRepository<Product> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _Title = "Title";
            _Type = "Type";
            _VendorCode = "VendorCode";
            _Description = "Descrip";
            _RetailPrice = new Random().Next(0, int.MaxValue) * new Random().NextDouble();
            _PreviewImage = "Image path";
            _BrandId = 1;
            _CategoryId = 1;
            _PackageId = 1;
            _CountInStorage = new Random().Next(0, int.MaxValue);
            _Rating = new Random().Next(0, int.MaxValue);
            _Series = "Series";
            _WarrantyMonth = new Random().Next(0, int.MaxValue);
            _Model = "Model";

        }

        private (int, int?, int, int) Create()
        {
            // Arrange
            var product = new Product
            {
                Id = _id,
                Title = _Title,
                Type = _Type,
                VendorCode = _VendorCode,
                Description = _Description,
                RetailPrice = _RetailPrice,
                PreviewImage = _PreviewImage,
                CountInStorage = _CountInStorage,
                Rating = _Rating,
                Series = _Series,
                WarrantyMonth = _WarrantyMonth,
                Model = _Model,
                Brand = new Brand { Id = (int)_BrandId + 1 },
                BrandId = _BrandId + 1,
                Category = new Category { Id = _CategoryId + 1 },
                CategoryId = _CategoryId + 1,
                Package = new Package { Id = _PackageId + 1 },
                PackageId = _PackageId + 1
            };
            // Act
            _repository.CreateAsync(product);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, product.Id, "Creating new record does not return id");

            return (product.Id, product.BrandId, product.CategoryId, product.PackageId);
        }

        private void Update(int id)
        {
            // Arrange
            var product = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            product.VendorCode = "1234567890";
            product.Model = "qwerty-333";
            product.Rating = 5;

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedproduct = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("1234567890", updatedproduct.VendorCode, "Record is not updated.");
            Assert.AreEqual(5, updatedproduct.Rating, "Record is not updated.");
            Assert.AreEqual("qwerty-333", updatedproduct.Model, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IReadOnlyCollection<Product> items = _repository.GetAllAsync().Result;
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var product = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(product, "GetByID returned null.");
            Assert.AreEqual(id, product.Id);
            Assert.AreEqual(_Title, product.Title);
            Assert.AreEqual(_Type, product.Type);
            Assert.AreEqual(_VendorCode, product.VendorCode);
            Assert.AreEqual(_Description, product.Description);
            Assert.AreEqual(_RetailPrice, product.RetailPrice);
            Assert.AreEqual(_CountInStorage, product.CountInStorage);
            Assert.AreEqual(_Rating, product.Rating);
            Assert.AreEqual(_Series, product.Series);
            Assert.AreEqual(_WarrantyMonth, product.WarrantyMonth);
            Assert.AreEqual(_Model, product.Model);
            Assert.AreEqual(_BrandId, product.BrandId);
            Assert.AreEqual(_PackageId, product.PackageId);
            Assert.AreEqual(_CategoryId, product.CategoryId);


        }
        [Test]
        public void ProductCrud()
        {
            var product = Create();
            _BrandId = product.Item2;
            _CategoryId = product.Item3;
            _PackageId = product.Item4;
            GetByID(product.Item1);
            GetAll();
            Update(product.Item1);
        }
    }
}
