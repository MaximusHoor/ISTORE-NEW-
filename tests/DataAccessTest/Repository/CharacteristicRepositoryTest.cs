using DataAccess.Repository;
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
                GroupCharacteristicId = _characteristicId,
                GroupCharacteristic = new GroupCharacteristic { Id = _id }
            };

            // Act
            _repository.CreateAsync(characteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, characteristic.Id, "Creating new record does not return id");

            return (characteristic.Id, characteristic.GroupCharacteristicId);
        }

        private void Update(int id)
        {
            // Arrange
            var characteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            characteristic.Title = "New Title";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedCharacteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("New Title", updatedCharacteristic.Title, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IReadOnlyCollection<Characteristic> items = _repository.GetAllAsync().Result;

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var characteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.IsNotNull(characteristic, "GetByID returned null.");
            Assert.AreEqual(id, characteristic.Id);
            Assert.AreEqual(_title, characteristic.Title);
            Assert.AreEqual(_characteristicId, characteristic.GroupCharacteristicId);
        }

        [Test]
        public void CharacteristicCrud()
        {
            var characteristic = Create();
            _characteristicId = characteristic.Item2;
            GetByID(characteristic.Item1);
            GetAll();
            Update(characteristic.Item1);
        }
    }
}
