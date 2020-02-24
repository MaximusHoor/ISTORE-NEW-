using DataAccess.Repository;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private IRepository<Comment> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _date = DateTime.Now;
            _text = "Comment Text";
            _userId = 1;
            _productId = 1;
            _like = new Random().Next(0, int.MaxValue);
            _dislike = new Random().Next(0, int.MaxValue);
        }

        private (int, int, int?) Create()
        {
            // Arrange
            var comment = new Comment
            {
                Date = _date,
                Id = _id,
                Text = _text,
                Product = new Product { Id = _id },
                User = new User { Id = _userId.Value },
                Like = _like,
                Dislike = _dislike,
                UserId = _userId
            };
            // Act
            _repository.Create(comment);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, comment.Id, "Creating new record does not return id");

            return (comment.Id, comment.ProductId, comment.UserId);
        }

        private void Update(int id)
        {
            // Arrange
            var comment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            comment.Like = 50;
            comment.Date = _date.AddDays(-40);
            comment.Text = "Hello";

            // Act
            _repository.Update(comment);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedcomment = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.AreEqual(50, updatedcomment.Like, "Record is not updated.");
            Assert.AreEqual(_date.AddDays(-40), updatedcomment.Date, "Record is not updated.");
            Assert.AreEqual("Hello", updatedcomment.Text, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<Comment> items = _repository.FindAll().ToList();
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
            Assert.AreEqual(_date, comment.Date);
            Assert.AreEqual(_dislike, comment.Dislike);
            Assert.AreEqual(_text, comment.Text);
            Assert.AreEqual(_userId, comment.UserId);
            Assert.AreEqual(_productId, comment.ProductId);
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
        public void CommentCrud()
        {
            var comment = Create();
            _productId = comment.Item2;
            _userId = comment.Item3;
            GetByID(comment.Item1);
            GetAll();
            Update(comment.Item1);
            Delete(comment.Item1);
        }
    }
}