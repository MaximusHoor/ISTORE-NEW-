using DataAccess.Repository.Interfaces;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessTest.Repository
{
    [TestFixture]
    public class DeliveryRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<DeliveryRepository>();

        }

        int _id;
        string _name;
        string _type;
        string _deliveryNote;
        DateTime _date;
        double _price;
        string _branchDeliveryService;
        int? _addressId;
        Address _addressDelivery;
        private IDeliveryRepository _repository;

        private void InitialiseParameters()
        {
            _id = 1;
            _name = "Novaya Pochta";
            _type = "Courier";
            _deliveryNote = "EH76897538";
            _date = DateTime.Now;
            _price = 1000;
            _branchDeliveryService = "58";
            _addressId = 22;

            _addressDelivery = new Address
            {
                Country = "Ukraine",
                City = "Dnipro",
                Street = "Karla Marksa",
                BuildingNumber = "33",
                ApartmentNumber = "5",
                Id = (int)_addressId
            };
        }


        private Delivery Create() //параметры?
        {
            // Arrange
            var delivery = new Delivery
            {
                Id = _id,
                Name = _name,
                Type = _type,
                DeliveryNote = _deliveryNote,
                Date = _date,
                Price = _price,
                BranchDeliveryService = _branchDeliveryService,
                AddressId = _addressId,
                AddressDelivery = _addressDelivery
            };

            // Act
            _repository.CreateDelivery(delivery);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, delivery.Id, "Creating new record does not return id");

            return delivery;
        }

        private void Delete(Delivery delivery)
        {
            // Act
            _repository.DeleteDelivery(delivery);

            ContextSingleton.GetDatabaseContext().SaveChanges();
            var delivery_res = _repository.FindByCondition(x => x.Id == delivery.Id).FirstOrDefault();
            // Assert
            Assert.IsNull(delivery_res, "Record is not deleted.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<Delivery> items = _repository.FindAllDeliveriesAsync().Result;
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var delivery = _repository.FindDeliveryByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(delivery, "GetByID returned null.");
            Assert.AreEqual(id, delivery.Id);
            Assert.AreEqual(_date, delivery.Date);
            Assert.AreEqual(_name, delivery.Name);
            Assert.AreEqual(_type, delivery.Type);
            Assert.AreEqual(_deliveryNote, delivery.DeliveryNote);
            Assert.AreEqual(_price, delivery.Price);
            Assert.AreEqual(_addressId, delivery.AddressId);
            Assert.AreEqual(_addressDelivery.Country, delivery.AddressDelivery.Country);
            Assert.AreEqual(_addressDelivery.City, delivery.AddressDelivery.City);
            Assert.AreEqual(_addressDelivery.Street, delivery.AddressDelivery.Street);
            Assert.AreEqual(_addressDelivery.BuildingNumber, delivery.AddressDelivery.BuildingNumber);
            Assert.AreEqual(_addressDelivery.ApartmentNumber, delivery.AddressDelivery.ApartmentNumber);
        }

        private void Update(Delivery delivery)
        {
            // Arrange

            delivery.Name = "DHL";
            delivery.Date = _date.AddDays(-40);
            delivery.Type = "To branch";

            // Act
            _repository.UpdateDelivery(delivery);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedDelivery = _repository.FindByCondition(x => x.Id == delivery.Id).FirstOrDefault();

            // Assert 
            Assert.AreEqual("DHL", updatedDelivery.Name, "Record is not updated.");
            Assert.AreEqual(_date.AddDays(-40), updatedDelivery.Date, "Record is not updated.");
            Assert.AreEqual("To branch", updatedDelivery.Type, "Record is not updated.");
        }

        [Test]
        public void DeliveryCrud()
        {
            var delivery = Create();
            Delete(delivery);
            
            delivery = Create();
            GetAll();

            GetByID(delivery.Id);

            Update(delivery);
        }
    }
}
