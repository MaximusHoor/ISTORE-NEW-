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
    public class OrderRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<OrderRepository>();
        }
        private int _id;
        private string _number;
        private DateTime _date;
        private double _total;
        private int? _userId;
        private int? _deliveryId;
        private string _deliveryStatus;
        private string _paymentStatus;
        private IRepository<Order> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _number = "Some Number";
            _date = DateTime.Now;
            _total = new Random().Next(0, int.MaxValue) * new Random().NextDouble();
            _userId = 1;
            _deliveryId = 1;
            _deliveryStatus = "Some delivery status";
            _paymentStatus = "Some payment status";
        }
        private (int, int?, int?) Create()
        {
            // Arrange
            var order = new Order
            {
                Id = _id,
                Number = _number,
                Date = _date,
                Total = _total,
                UserId = _userId,
                User = new User() { Id = (int)_userId },
                DeliveryId = _deliveryId,
                Delivery = new Delivery() { Id = (int)_deliveryId },
                DeliveryStatus = _deliveryStatus,
                PaymentStatus = _paymentStatus
            };
            // Act
            _repository.Create(order);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            // Assert
            Assert.AreNotEqual(0, order.Id, "Creating new record does not return id");
            return (order.Id, order.UserId, order.DeliveryId);
        }

        private void Update(int id)
        {
            // Arrange
            var order = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            order.Number = "New Number";
            order.Date = _date.AddDays(20);
            order.Total = 50;
            order.DeliveryStatus = "New delivery status";
            order.PaymentStatus = "New payment status";
            // Act
            _repository.Update(order);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedOrder = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Assert
            Assert.AreEqual("New Number", updatedOrder.Number, "Record is not updated.");
            Assert.AreEqual(_date.AddDays(20), updatedOrder.Date, "Record is not updated.");
            Assert.AreEqual(50, updatedOrder.Total, "Record is not updated.");
            Assert.AreEqual("New delivery status", updatedOrder.DeliveryStatus, "Record is not updated.");
            Assert.AreEqual("New payment status", updatedOrder.PaymentStatus, "Record is not updated.");
        }
        private void GetAll()
        {
            // Act
            IEnumerable<Order> items = _repository.FindAll().ToList();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }
        private void GetById(int id)
        {
            // Arrange
            var order = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Assert
            Assert.IsNotNull(order, "GetById returned null.");
            Assert.AreEqual(id, order.Id);
            Assert.AreEqual(_number, order.Number);
            Assert.AreEqual(_date, order.Date);
            Assert.AreEqual(_total, order.Total);
            Assert.AreEqual(_userId, order.UserId);
            Assert.AreEqual(_deliveryId, order.DeliveryId);
            Assert.AreEqual(_deliveryStatus, order.DeliveryStatus);
            Assert.AreEqual(_paymentStatus, order.PaymentStatus);
        }
        private void Delete(int id)
        {
            // Arrange
            var order = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Act
            _repository.Delete(order);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            order = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Assert
            Assert.IsNull(order, "Record is not deleted.");
        }
        [Test]
        public void OrderCrud()
        {
            var orderDetails = Create();
            _userId = orderDetails.Item2;
            _deliveryId = orderDetails.Item3;
            GetAll();
            GetById(orderDetails.Item1);
            Update(orderDetails.Item1);
            Delete(orderDetails.Item1);
        }
    }
}
