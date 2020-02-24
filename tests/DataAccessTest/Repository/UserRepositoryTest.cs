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
    public class UserRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<UserRepository>();
        }

        private int _id;
        private string _firstName;
        private string _lastName;
        private int? _addressId;
        private string _email;
        private string _phoneNumber;
        private IRepository<User> _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _firstName = "Roma";
            _lastName = "Sidorov";
            _addressId = 1;
            _phoneNumber = "some num";
            _email = "some email";
        }

        private (int, int?) Create()
        {
            // Arrange
            var user = new User
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                Address = new Address { Id = _id },
                AddressId = _addressId,
                PhoneNumber = _phoneNumber,
                Email = _email
            };
            // Act
            _repository.Create(user);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, user.Id, "Creating new record does not return id");

            return (user.Id, user.AddressId);
        }

        private void Update(int id)
        {
            // Arrange
            var user = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            user.Email = "new email";
            user.FirstName = "new data";
            user.LastName = "new data";
            user.PhoneNumber = "new data";


            // Act
            _repository.Update(user);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedcomment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.AreEqual("new email", updatedcomment.Email, "Record is not updated.");
            Assert.AreEqual("new data", updatedcomment.PhoneNumber, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<User> items = _repository.FindAll().ToList();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var comment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Assert
            Assert.IsNotNull(comment, "GetByID returned null.");
            Assert.AreEqual(id, comment.Id);
            Assert.AreEqual(_firstName, comment.FirstName);
            Assert.AreEqual(_lastName, comment.LastName);
            Assert.AreEqual(_email, comment.Email);
            Assert.AreEqual(_phoneNumber, comment.PhoneNumber);
            Assert.AreEqual(_addressId, comment.AddressId);
        }

        private void Delete(int id)
        {
            // Arrange
            var comment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Act
            _repository.Delete(comment);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            comment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            // Assert
            Assert.IsNull(comment, "Record is not deleted.");
        }

        [Test]
        public void UserCrud()
        {
            var comment = Create();
            _addressId = comment.Item2;
            GetByID(comment.Item1);
            GetAll();
            Update(comment.Item1);
            Delete(comment.Item1);
        }
    }
}
