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
        private DateTime _dateTime2;
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
            _dateTime1 = new DateTime(2020, 04, 30);
            _dateTime2 = new DateTime(2019, 04, 30);
        }

        private async Task<(string, int?)> CreateAsync()
        {
            // Arrange
            var user = new User
            {
         
                FirstName = _firstName,
                LastName = _lastName,
                Address = new Address { Id = _addressId.Value },
                Comments = new List<Comment> { new Comment() { Id = _comment1Id,Date=_dateTime1 }, new Comment() { Id = _comment2Id,Date=_dateTime2 } },
                AddressId = _addressId,
                PhoneNumber = _phoneNumber,
                Email = _email
            };
            // Act
            await _repository.CreateAsync(user);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, user.Id, "Creating new record does not return id");

            return (user.Id, user.AddressId);
        }



        private async Task GetAllAsync()
        {
            // Act
            var items = await _repository.FindAllUsersAllIncludedAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByIDAsync(string id)
        {
            // Act
            var user = await _repository.GetUserAllIncludedAsync(x => x.Id == id);
            // Assert
            Assert.IsNotNull(user, "GetByID returned null.");
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(_firstName, user.FirstName);
            Assert.AreEqual(_lastName, user.LastName);
            Assert.AreEqual(_email, user.Email);
            Assert.AreEqual(_phoneNumber, user.PhoneNumber);
            Assert.AreEqual(_addressId, user.AddressId);
        }
        private async Task GetUserByCondition(string email)
        {
            // Act
            var user = await _repository.FindByConditionAsync(x => x.Email == email);
            // Assert
            Assert.IsNotNull(user, "GetByID returned null.");
            Assert.AreEqual(_id, user.ElementAt(0).Id);
            Assert.AreEqual(_firstName, user.ElementAt(0).FirstName);
            Assert.AreEqual(_lastName, user.ElementAt(0).LastName);
            Assert.AreEqual(_email, user.ElementAt(0).Email);
            Assert.AreEqual(_phoneNumber, user.ElementAt(0).PhoneNumber);
            Assert.AreEqual(_addressId, user.ElementAt(0).AddressId);
        }
        private async Task UpdateAsync(int id)
        {
            // Arrange
            var user = (await _repository.GetUserAllIncludedAsync(x => x.Id == id));
            user.Email = "new email";
            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedUser = (await _repository.GetUserAllIncludedAsync(x => x.Id == id));
            // Assert
            Assert.AreEqual("new email", updatedUser.Email, "not updated.");
        }

        [Test]
        public async Task UserCrud()
        {
            var comment = await CreateAsync();
            //await GetByIDAsync(comment.Item1);
            await GetAllAsync();
            await GetByIDAsync(user.Item1);
            await GetUserByCondition(_email);
            await UpdateAsync(user.Item1);
        }
    }
}
