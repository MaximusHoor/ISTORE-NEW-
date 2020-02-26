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
    public class CategoryRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            InitialiseParameters();
            _repository = RepositoryFactory.Instance<CategoryRepository>();
        }

        private int _id;
        private string _title;
        private string _previewImage;
        private IRepository<Category> _repository;

        private void InitialiseParameters()
        {
            _id = new Random().Next(0, int.MaxValue);
            _title = "My title name";
            _previewImage = "Image";

        }

        private int Create()
        {
            // Arrange
            var category = new Category
            {

                Id = _id,
                Title = _title,
                PreviewImage = _previewImage
            };
            // Act
            _repository.CreateAsync(category);
            ContextSingleton.GetDatabaseContext().SaveChanges();

            // Assert
            Assert.AreNotEqual(0, category.Id, "Creating new category does not return id");

            return category.Id;
        }

        private async Task Update(int id)
        {
            // Arrange
            var category = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            category.Title = "Title";
            category.PreviewImage = "Preview Image";

            // Act
            ContextSingleton.GetDatabaseContext().SaveChanges();

            var updatedcategory = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            // Assert
            Assert.AreEqual("Title", updatedcategory.Title, "Record is not updated.");
            Assert.AreEqual("Preview Image", updatedcategory.PreviewImage, "Record is not updated.");
        }

        private async Task GetAll()
        {
            // Act
            IReadOnlyCollection<Category> items = await _repository.GetAllAsync();
            // Assert
            Assert.IsTrue(items.Any(), "GetAll returned no items.");
        }

        private async Task GetByID(int id)
        {
            // Act
            var category = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            // Assert
            Assert.IsNotNull(category, "GetByID returned null.");
            Assert.AreEqual(id, category.Id);
            Assert.AreEqual(_title, category.Title);
            Assert.AreEqual(_previewImage, category.PreviewImage);

        }

        [Test]
        public async Task CommentCrud()
        {
            var id = Create();
            await GetByID(id);
            await GetAll();
            await Update(id);
        }
    }
}