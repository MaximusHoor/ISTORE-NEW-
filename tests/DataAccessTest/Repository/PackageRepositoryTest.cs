using DataAccess.Repository;
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
    public class PackageRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<PackageRepository>();
        }
        private int _id;
        private int _countInPackage;
        private double _volume;
        private double _weight;
        private IRepository<Package> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _countInPackage = new Random().Next(0, int.MaxValue);
            _volume = new Random().Next(0, int.MaxValue) * new Random().NextDouble();
            _weight = new Random().Next(0, int.MaxValue) * new Random().NextDouble();
        }
        private int Create()
        {
            // Arrange
            var package = new Package
            {
                Id = _id,
                CountInPackage = _countInPackage,
                Volume = _volume,
                Weight = _weight
            };
            // Act
            _repository.CreateAsync(package);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            // Assert
            Assert.AreNotEqual(0, package.Id, "Creating new record does not return id");
            return package.Id;
        }

        private async Task Update(int id)
        {
            // Arrange
            var package = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            package.CountInPackage = 20;
            package.Volume = 15.15;
            package.Weight = 33.33;
            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedPackage = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            // Assert
            Assert.AreEqual(20, updatedPackage.CountInPackage, "Record is not updated.");
            Assert.AreEqual(15.15, updatedPackage.Volume, "Record is not updated.");
            Assert.AreEqual(33.33, updatedPackage.Weight, "Record is not updated.");
        }
        private async Task GetAll()
        {
            // Act
            IReadOnlyCollection<Package> items = await _repository.GetAllAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }
        private async Task GetById(int id)
        {
            // Arrange
            var package = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            // Assert
            Assert.IsNotNull(package, "GetById returned null.");
            Assert.AreEqual(id, package.Id);
            Assert.AreEqual(_countInPackage, package.CountInPackage);
            Assert.AreEqual(_volume, package.Volume);
            Assert.AreEqual(_weight, package.Weight);
        }

        [Test]
        public async Task PackageCrud()
        {
            var package = Create();
            await GetAll();
            await GetById(package);
            await Update(package);
        }
    }
}
