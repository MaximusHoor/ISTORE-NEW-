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
    public class GroupCharacteristicRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<GroupCharacteristicRepository>();
        }

        private int _id;
        private string _title;
        private int _productId;
        private IRepository<GroupCharacteristic> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _title = "Title Text";
            _productId = 1;
        }

        private (int, int) Create()
        {
            // Arrange
            var groupCharacteristic = new GroupCharacteristic
            {
                Id = _id,
                Title = _title,
                Product = new Product { Id = _id }
            };

            // Act
            _repository.CreateAsync(groupCharacteristic);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, groupCharacteristic.Id, "Creating new record does not return id");

            return (groupCharacteristic.Id, groupCharacteristic.ProductId);
        }

        private void Update(int id)
        {
            // Arrange
            var groupCharacteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            groupCharacteristic.Title = "New Title";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedGroupCharacteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("New Title", updatedGroupCharacteristic.Title, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IReadOnlyCollection<GroupCharacteristic> items = _repository.GetAllAsync().Result;

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var groupCharacteristic = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.IsNotNull(groupCharacteristic, "GetByID returned null.");
            Assert.AreEqual(id, groupCharacteristic.Id);
            Assert.AreEqual(_title, groupCharacteristic.Title);
            Assert.AreEqual(_productId, groupCharacteristic.ProductId);
        }
        [Test]
        public void GroupCharacteristicCrud()
        {
            var groupCharacteristic = Create();
            _productId = groupCharacteristic.Item2;
            GetByID(groupCharacteristic.Item1);
            GetAll();
            Update(groupCharacteristic.Item1);
        }
    }
}
