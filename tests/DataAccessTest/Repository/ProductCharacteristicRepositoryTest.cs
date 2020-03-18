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
    //[TestFixture]
    //public class ProductCharacteristicRepositoryTest
    //{
    //    [SetUp]
    //    public void Setup()
    //    {
    //        InitialiseParameters();
    //        _repository = RepositoryFactory.Instance<ProductCharacteristicRepository>();
           
    //    }

    //    private int _id;
    //    private string _title;
    //    private int _productId;
    //    private IRepository<ProductCharacteristic> _repository;

    //    private void InitialiseParameters()
    //    {
    //        _id = new Random().Next(0, int.MaxValue);
    //        _title = "Title Text";
    //        _productId = 1;
    //    }

    //    private (int, int) Create()
    //    {
    //        // Arrange
    //        var productCharacteristic = new ProductCharacteristic
    //        {
    //            Id = _id,
    //            Descriptions = _title,
    //            Product = new Product { Id = _id }
    //        };

    //        // Act
    //        _repository.CreateAsync(productCharacteristic);
    //        ContextSingleton.GetDatabaseContext().SaveChanges();

    //        // Assert
    //        Assert.AreNotEqual(0, productCharacteristic.Id, "Creating new record does not return id");

    //        return (productCharacteristic.Id, productCharacteristic.ProductId);
    //    }

    //    private async Task Update(int id)
    //    {
    //        // Arrange
    //        var productCharacteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
    //        productCharacteristic.Descriptions = "New Title";

    //        // Act
    //        ContextSingleton.GetDatabaseContext().SaveChanges();

    //        var updatedProductCharacteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

    //        // Assert
    //        Assert.AreEqual("New Title", updatedProductCharacteristic.Descriptions, "Record is not updated.");
    //    }

    //    private async Task GetAll()
    //    {
    //        // Act
    //        IReadOnlyCollection<ProductCharacteristic> items = await _repository.GetAllAsync();

    //        // Assert
    //        Assert.IsTrue(items.Any(), "GetAll returned no items.");
    //    }

    //    private async Task GetByID(int id)
    //    {
    //        // Act
    //        var productCharacteristic = (await _repository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

    //        // Assert
    //        Assert.IsNotNull(productCharacteristic, "GetByID returned null.");
    //        Assert.AreEqual(id, productCharacteristic.Id);
    //        Assert.AreEqual(_title, productCharacteristic.Descriptions);
    //        Assert.AreEqual(_productId, productCharacteristic.ProductId);
    //    }
    //    [Test]
    //    public async Task ProductCharacteristicCrud()
    //    {
    //        var productCharacteristic = Create();
    //        _productId = productCharacteristic.Item2;
    //        await GetByID(productCharacteristic.Item1);
    //        await GetAll();
    //        await Update(productCharacteristic.Item1);
    //    }
    //}
}
