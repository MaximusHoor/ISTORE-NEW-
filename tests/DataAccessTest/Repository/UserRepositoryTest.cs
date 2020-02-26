using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
        private int _comment1Id;
        private int _comment2Id;
        private DateTime _dateTime1;
        private IUserRepository _repository;
        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _firstName = "Roma";
            _lastName = "Sidorov";
            _addressId = 1;
            _phoneNumber = "some num";
            _email = "some email";
            _comment1Id = new Random().Next(0, int.MaxValue);
            _comment2Id = new Random().Next(0, int.MaxValue);
            _dateTime1 = new DateTime(1998, 04, 30);

        }

        private async Task<(int, int?)> CreateAsync()
        {
            // Arrange
            var user = new User
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                Address = new Address { Id = _id },
                Comments = new List<Comment> { new Comment() { Id = _comment1Id }, new Comment() { Id = _comment2Id } },
                AddressId = _addressId,
                PhoneNumber = _phoneNumber,
                Email = _email
            };
            // Act
            await _repository.CreateAsync(user);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(_id, user.Id, "Creating new record does not return id");

            return (user.Id, user.AddressId);
        }



        private async Task GetAllAsync()
        {
            // Act
            var items = await _repository.FindAllUsersAllIncludedAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByIDAsync(int id)
        {
            // Act
            var comment = await _repository.FindUserByConditionAllIncludedAsync(x => x.Id == id);
            // Assert
            Assert.IsNotNull(comment, "GetByID returned null.");
            Assert.AreEqual(id, comment);
            Assert.AreEqual(_firstName, comment.ElementAt(0).FirstName);
            Assert.AreEqual(_lastName, comment.ElementAt(0).LastName);
            Assert.AreEqual(_email, comment.ElementAt(0).Email);
            Assert.AreEqual(_phoneNumber, comment.ElementAt(0).PhoneNumber);
            Assert.AreEqual(_addressId, comment.ElementAt(0).AddressId);
        }

        [Test]
        public async Task UserCrud()
        {
            var comment = await CreateAsync();
            await GetByIDAsync(comment.Item1);
            await GetAllAsync();
        }
    }
}
