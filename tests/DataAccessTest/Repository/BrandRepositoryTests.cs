using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        private async Task Update(int id)
        {
            // Arrange
            var brand = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            brand.Country = "Japan";
            brand.Description = "newDescription";
            brand.Name = "LG";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedBrand = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.AreEqual("Japan", updatedBrand.Country, "Record is not updated.");
            Assert.AreEqual("newDescription", updatedBrand.Description, "Record is not updated.");
            Assert.AreEqual("LG", updatedBrand.Name, "Record is not updated.");
        }

        private async Task GetAll()
        {
            // Act
            IReadOnlyCollection<Brand> items = await _repository.GetAllAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByID(int id)
        {
            // Act
            var brand = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            // Assert
            Assert.IsNotNull(brand, "GetByID returned null.");
            Assert.AreEqual(id, brand.Id);
            Assert.AreEqual(_country, brand.Country);
            Assert.AreEqual(_description, brand.Description);
            Assert.AreEqual(_name, brand.Name);

        }

        [Test]
        public async Task BrandCrud()
        {
            var id = Create();
            await GetAll();

            await GetByID(id);

            await Update(id);
        }
    }
}
