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
    public class CharacteristicRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<CharacteristicRepository>();
        }

        private int _id;
        private string _title;
        public string _value;
        private int _characteristicId;
        private IRepository<Characteristic> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _title = "Title Text";
            _characteristicId = 1;
        }

        private (int, int) Create()
        {
            // Arrange
            var characteristic = new Characteristic
            {
                Id = _id,
                Title = _title,
                ProductCharacteristicId = _characteristicId,
                ProductCharacteristic = new ProductCharacteristic { Id = _id }
            };

            // Act
            _repository.CreateAsync(characteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, characteristic.Id, "Creating new record does not return id");

            return (characteristic.Id, characteristic.ProductCharacteristicId);
        }

        private async Task Update(int id)
        {
            // Arrange
            var characteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            characteristic.Title = "New Title";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedCharacteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.AreEqual("New Title", updatedCharacteristic.Title, "Record is not updated.");
        }

        private async Task GetAll()
        {
            // Act
            IReadOnlyCollection<Characteristic> items = await _repository.GetAllAsync();

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByID(int id)
        {
            // Act
            var characteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.IsNotNull(characteristic, "GetByID returned null.");
            Assert.AreEqual(id, characteristic.Id);
            Assert.AreEqual(_title, characteristic.Title);
            Assert.AreEqual(_characteristicId, characteristic.ProductCharacteristicId);
        }

        [Test]
        public async Task CharacteristicCrud()
        {
            var characteristic = Create();
            _characteristicId = characteristic.Item2;
            await GetByID(characteristic.Item1);
            await GetAll();
            await Update(characteristic.Item1);
        }
    }
}
