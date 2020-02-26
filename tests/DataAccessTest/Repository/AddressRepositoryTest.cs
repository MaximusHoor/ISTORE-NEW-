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
    class AddressRepositoryTest
    {

        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<AddressRepository>();
        }

        int _id;
        string _country;
        string _city;
        string _street;
        string _buildingNumber;
        string _apartmentNumber;
        private IRepository<Address> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _country = "Ukraine";
            _city = "Dnipro";
            _street = "Karla Marksa";
            _buildingNumber = "6";
            _apartmentNumber = "44";
        }

        private int Create()
        {
            // Arrange
            var address = new Address
            {
                Id = _id,
                Country = _country,
                City = _city,
                Street = _street,
                BuildingNumber = _buildingNumber,
                ApartmentNumber = _apartmentNumber
            };
            // Act
            _repository.CreateAsync(address);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, address.Id, "Creating new record does not return id");

            return address.Id;
        }

        private void Update(int id)
        {
            // Arrange
            var address = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            address.City = "Lvov";
            address.ApartmentNumber = "10";
            address.Street = "Ivanova";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedAddress = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();

            // Assert
            Assert.AreEqual("Lvov", updatedAddress.City, "Record is not updated.");
            Assert.AreEqual("10", updatedAddress.ApartmentNumber, "Record is not updated.");
            Assert.AreEqual("Ivanova", updatedAddress.Street, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IReadOnlyCollection<Address> items = _repository.GetAllAsync().Result;
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var address = _repository.FindByConditionAsync(x => x.Id == id).Result.FirstOrDefault();
            // Assert
            Assert.IsNotNull(address, "GetByID returned null.");
            Assert.AreEqual(id, address.Id);
            Assert.AreEqual(_country, address.Country);
            Assert.AreEqual(_city, address.City);
            Assert.AreEqual(_street, address.Street);
            Assert.AreEqual(_buildingNumber, address.BuildingNumber);
            Assert.AreEqual(_apartmentNumber, address.ApartmentNumber);
        }

        [Test]
        public void AddressCrud()
        {
            var id = Create();
            GetAll();

            GetByID(id);

            Update(id);
        }
    }
}
