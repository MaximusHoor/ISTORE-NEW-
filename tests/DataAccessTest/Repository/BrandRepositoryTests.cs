using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
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
    public class BrandRepositoryTests
    {

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
        private IRepository<Brand> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _name = "Samsung";
            _country = "China";
            _description = "SamsungDescription";
        }

        private int Create()
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
            _repository.CreateAsync(brand);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, brand.Id, "Creating new record does not return id");

            return brand.Id;
        }

        private void Update(int id)
        {
            // Arrange
            var brand = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            brand.Country = "Japan";
            brand.Description = "newDescription";
            brand.Name = "LG";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedBrand = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("Japan", updatedBrand.Country, "Record is not updated.");
            Assert.AreEqual("newDescription", updatedBrand.Description, "Record is not updated.");
            Assert.AreEqual("LG", updatedBrand.Name, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IReadOnlyCollection<Brand> items = _repository.GetAllAsync().Result;
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var brand = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(brand, "GetByID returned null.");
            Assert.AreEqual(id, brand.Id);
            Assert.AreEqual(_country, brand.Country);
            Assert.AreEqual(_description, brand.Description);
            Assert.AreEqual(_name, brand.Name);

        }

        [Test]
        public void BrandCrud()
        {
            var id = Create();
            GetAll();

            GetByID(id);

            Update(id);
        }
    }
}
