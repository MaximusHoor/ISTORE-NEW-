using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainTest.Repository
{
    [TestFixture]
    public class CommentRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<CommentRepository>();
        }

        private int _id;
        private DateTime _date;
        private string _text;
        private int? _userId;
        private int _productId;
        private int _like;
        private int _dislike;
        private ICommentRepository _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _date = DateTime.Now;
            _text = "Comment Text";
            _userId = 1;
            _productId = 2;
            _like = new Random().Next(0, int.MaxValue);
            _dislike = new Random().Next(0, int.MaxValue);
        }

        private async Task<(int, int, int?)> CreateAsync()
        {
            // Arrange
            var comment = new Comment
            {
                Date = _date,
                Id = _id,
                Text = _text,
                Product = new Product { Id = _id },
                //User = new User { Id = _userId.Value },
                Like = _like,
                Dislike = _dislike,
                UserId = _userId.Value
            };
            // Act
            await _repository.CreateAsync(comment);
            await ContextSingleton.GetDatabaseContext().SaveChangesAsync();

            // Assert
            Assert.AreNotEqual(0, comment.Id, "Creating new record does not return id");

            return (comment.Id, comment.ProductId, comment.UserId.Value);
        }

        private async Task GetAllAsync()
        {
            // Act
            var items = await _repository.GetAllAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByIDAsync(int id)
        {
            // Act
            var comment = await _repository.FindByConditionAsync(x => x.Id == id);
            // Assert
            Assert.IsNotNull(comment, "GetByID returned null.");
            Assert.AreEqual(id, comment.ElementAt(0).Id);
            Assert.AreEqual(_date, comment.ElementAt(0).Date);
            Assert.AreEqual(_dislike, comment.ElementAt(0).Dislike);
            Assert.AreEqual(_text, comment.ElementAt(0).Text);
            Assert.AreEqual(_userId, comment.ElementAt(0).UserId);
            Assert.AreEqual(_productId, comment.ElementAt(0).ProductId);
        }
        private async Task GetByUserIDAsync(int userId)
        {
            // Act
            var comment = await _repository.FindByConditionAllIncludedAsync(x => x.UserId == userId);
            // Assert
            Assert.IsNotNull(comment, "GetByUserID returned null.");
            Assert.AreEqual(_id, comment.ElementAt(0).Id);
            Assert.AreEqual(_date, comment.ElementAt(0).Date);
            Assert.AreEqual(_dislike, comment.ElementAt(0).Dislike);
            Assert.AreEqual(_text, comment.ElementAt(0).Text);
            Assert.AreEqual(_productId, comment.ElementAt(0).ProductId);
            Assert.AreEqual(_userId, comment.ElementAt(0).UserId);
        }
        private async Task GetByProductIDAsync(int productId)
        {
            // Act
            var comment = await _repository.FindByConditionAsync(x => x.ProductId == productId);
            // Assert
            Assert.IsNotNull(comment, "GetByUserID returned null.");
            Assert.AreEqual(_id, comment.ElementAt(0).Id);
            Assert.AreEqual(_date, comment.ElementAt(0).Date);
            Assert.AreEqual(_dislike, comment.ElementAt(0).Dislike);
            Assert.AreEqual(_text, comment.ElementAt(0).Text);
            Assert.AreEqual(_productId, comment.ElementAt(0).ProductId);
            Assert.AreEqual(_userId, comment.ElementAt(0).UserId);
        }
        private async Task UpdateAsync(int id)
        {
            // Arrange
            var comment = (await _repository.FindByConditionAsync(x => x.Id == id));
            comment.ElementAt(0).UserId = 5;
            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();
            var updatedComment = (await _repository.FindByConditionAsync(x => x.Id == id));
            // Assert
            Assert.AreEqual(5, updatedComment.ElementAtOrDefault(0).UserId, "not updated.");
        }

        [Test]
        public async Task CommentCrud()
        {
            var comment = await CreateAsync();
            await GetByIDAsync(comment.Item1);
            await GetByUserIDAsync(comment.Item3.Value);
            await GetAllAsync();
            await GetByProductIDAsync(comment.Item2);
            await UpdateAsync(comment.Item1);
        }
    }
}