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
    public class OrderDetailsRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<OrderDetailsRepository>();
        }
        private int _id;
        private int _orderId;
        private int _productId;
        private int _count;
        private IRepository<OrderDetails> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _orderId = 1;
            _productId = 1;
            _count = new Random().Next(0, int.MaxValue);
        }
        private (int, int, int) Create()
        {
            // Arrange
            var orderDetails = new OrderDetails
            {
                Id = _id,
                OrderId = _orderId + 1,
                Order = new Order() { Id = _orderId + 1 },
                ProductId = _productId + 1,
                Product = new Product() { Id = _productId + 1 },
                Count = _count
            };
            // Act
            _repository.CreateAsync(orderDetails);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            // Assert
            Assert.AreNotEqual(0, orderDetails.Id, "Creating new record does not return id");
            return (orderDetails.Id, orderDetails.OrderId, orderDetails.ProductId);
        }

        private void Update(int id)
        {
            // Arrange
            var orderDetails = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            orderDetails.Count = 20;
            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedOrderDetails = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.AreEqual(20, updatedOrderDetails.Count, "Record is not updated.");
        }
        private void GetAll()
        {
            // Act
            IReadOnlyCollection<OrderDetails> items = _repository.GetAllAsync().Result;
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }
        private void GetById(int id)
        {
            // Arrange
            var orderDetails = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(orderDetails, "GetById returned null.");
            Assert.AreEqual(id, orderDetails.Id);
            Assert.AreEqual(_orderId, orderDetails.OrderId);
            Assert.AreEqual(_productId, orderDetails.ProductId);
            Assert.AreEqual(_count, orderDetails.Count);
        }
       
        [Test]
        public void OrderDetailsCrud()
        {
            var orderDetails = Create();
            _orderId = orderDetails.Item2;
            _productId = orderDetails.Item3;
            GetAll();
            GetById(orderDetails.Item1);
            Update(orderDetails.Item1);
        }
    }
}
