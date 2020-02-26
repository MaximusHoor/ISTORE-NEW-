using DataAccess.Repository;
using DataAccessTest.Repository.Factory;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _repository.CreateAsync(image);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, image.Id, "Creating new record does not return id");

            return (image.Id, image.ProductId);
        }

        private async Task Update(int id)
        {
            // Arrange
            var image = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            image.FilePath = "new file path";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedImage = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.AreEqual("new file path", updatedImage.FilePath, "Record is not updated.");
        }

        private async Task GetAll()
        {
            // Act
            IReadOnlyCollection<Image> items = await _repository.GetAllAsync();

            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByID(int id)
        {
            // Act
            var image = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.IsNotNull(image, "GetByID returned null.");
            Assert.AreEqual(id, image.Id);
            Assert.AreEqual(_filePath, image.FilePath);
            Assert.AreEqual(_productId, image.ProductId);
        }
        [Test]
        public async Task ImageCrud()
        {
            var image = Create();
            _productId = image.Item2;
            await GetByID(image.Item1);
            await GetAll();
            await Update(image.Item1);
        }
    }
}
