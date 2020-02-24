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
            _repository.Create(characteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, characteristic.Id, "Creating new record does not return id");

            return (characteristic.Id, characteristic.GroupCharacteristicId);
        }

        private void Update(int id)
        {
            // Arrange
            var characteristic = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            characteristic.Title = "New Title";

            // Act
            _repository.Update(characteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedCharacteristic = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.AreEqual("New Title", updatedCharacteristic.Title, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<Characteristic> items = _repository.FindAll().ToList();

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var characteristic = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.IsNotNull(characteristic, "GetByID returned null.");
            Assert.AreEqual(id, characteristic.Id);
            Assert.AreEqual(_title, characteristic.Title);
            Assert.AreEqual(_characteristicId, characteristic.GroupCharacteristicId);
        }

        private void Delete(int id)
        {
            // Arrange
            var characteristic = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Act
            _repository.Delete(characteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            characteristic = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.IsNull(characteristic, "Record is not deleted.");
        }

        [Test]
        public void CharacteristicCrud()
        {
            var characteristic = Create();
            _characteristicId = characteristic.Item2;
            GetByID(characteristic.Item1);
            GetAll();
            Update(characteristic.Item1);
            Delete(characteristic.Item1);
        }
    }
}
