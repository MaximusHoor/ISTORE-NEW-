using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest.Repository
{
    [TestFixture]
    public class BrandRepositoryTests
    {
        private IBrandRepository _repository;

        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<BrandRepository>();
        }

        int _id;
        string _name;
        string _country;
        string _description;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _name = "Samsung";
            _country = "China";
            _description = "SamsungDescription";
        }

        private Brand Create()
        {
            // Arrange
            var brand = new Brand
            {
                Id = _id,
                Country = _country,
                Name = _name,
                Description = _description
            };
            // Act
            _repository.CreateBrand(brand);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, brand.Id, "Creating new record does not return id");

            return brand;
        }

        private void Update(Brand brand)
        {
            // Arrange

            brand.Country = "Japan";
            brand.Description = "newDescription";
            brand.Name = "LG";

            // Act
            _repository.UpdateBrand(brand);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedBrand = _repository.FindBrandByConditionAsync(x => x.Id == brand.Id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("Japan", updatedBrand.Country, "Record is not updated.");
            Assert.AreEqual("newDescription", updatedBrand.Description, "Record is not updated.");
            Assert.AreEqual("LG", updatedBrand.Name, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<Brand> items = _repository.FindAll().ToList();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var brand = _repository.FindBrandByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(brand, "GetByID returned null.");
            Assert.AreEqual(id, brand.Id);
            Assert.AreEqual(_country, brand.Country);
            Assert.AreEqual(_description, brand.Description);
            Assert.AreEqual(_name, brand.Name);

        }

        private void Delete(int id)
        {
            // Arrange
            var brand = _repository.FindBrandByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Act
            _repository.DeleteBrand(brand);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            brand = _repository.FindBrandByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNull(brand, "Record is not deleted.");
        }

        [Test]
        public void BrandCrud()
        {
            var brand = Create();
            Delete(brand.Id);

            brand = Create();
            GetAll();

            GetByID(brand.Id);

            Update(brand);
        }
    }
}
