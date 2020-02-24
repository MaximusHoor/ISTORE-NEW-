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
    public class ImageRepositoryTest
    {

        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<ImageRepository>();
        }

        private int _id;
        private string _filePath;
        private int _productId;
        private IRepository<Image> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _filePath = "some file path";
            _productId = 1;
        }

        private (int, int) Create()
        {
            // Arrange
            var image = new Image
            {
                Id = _id,
                FilePath = _filePath,
                Product = new Product { Id = _id }
            };

            // Act
            _repository.Create(image);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, image.Id, "Creating new record does not return id");

            return (image.Id, image.ProductId);
        }

        private void Update(int id)
        {
            // Arrange
            var image = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            image.FilePath = "new file path";

            // Act
            _repository.Update(image);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedImage = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.AreEqual("new file path", updatedImage.FilePath, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IEnumerable<Image> items = _repository.FindAll().ToList();

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            var image = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.IsNotNull(image, "GetByID returned null.");
            Assert.AreEqual(id, image.Id);
            Assert.AreEqual(_filePath, image.FilePath);
            Assert.AreEqual(_productId, image.ProductId);
        }

        private void Delete(int id)
        {
            // Arrange
            var image = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Act
            _repository.Delete(image);
            ContextSingleton.GetDatabaseContext().SaveChanges();
            image = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();

            // Assert
            Assert.IsNull(image, "Record is not deleted.");
        }

        [Test]
        public void ImnageCrud()
        {
            var image = Create();
            _productId = image.Item2;
            GetByID(image.Item1);
            GetAll();
            Update(image.Item1);
            Delete(image.Item1);
        }
    }
}
