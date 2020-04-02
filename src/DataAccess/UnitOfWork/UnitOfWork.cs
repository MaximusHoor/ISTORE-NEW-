using DataAccess.Repository.Interfaces;
using Domain.Context;
using System;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(StoreContext storeContext, IUserRepository userRepository, ICommentRepository commentRepository,
        CategoryRepository categoryRepository, ImageRepository imageRepository, 
        ProductCharacteristicRepository productCharacteristicRepository, 
        CharacteristicRepository characteristicRepository, ProductRepository productRepository, 
        DeliveryRepository deliveryRepository, AddressRepository addressRepository, BrandRepository brandRepository, 
        OrderDetailsRepository orderDetailsRepository, OrderRepository orderRepository, 
        PackageRepository packageRepository, ILikeRepository likeRepository, NewsRepository newsRepository,
        SubscriberRepository subscriberRepository)
        {
            _storeContext = storeContext;
            UserRepository = userRepository;
            CommentRepository = commentRepository;
            CategoryRepository = categoryRepository;
            ImageRepository = imageRepository;
            ProductCharacteristicRepository = productCharacteristicRepository;
            CharacteristicRepository = characteristicRepository;
            ProductRepository = productRepository;
            DeliveryRepository = deliveryRepository;
            AddressRepository = addressRepository;
            BrandRepository = brandRepository;
            OrderDetailsRepository = orderDetailsRepository;
            OrderRepository = orderRepository;
            PackageRepository = packageRepository;
            LikeRepository = likeRepository;
            NewsRepository = newsRepository;
            SubscriberRepository = subscriberRepository;
        }

        private StoreContext _storeContext { get; }

        public void Dispose()
        {
            _storeContext?.Dispose();
        }
        public ILikeRepository LikeRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public CategoryRepository CategoryRepository { get; }
        public ImageRepository ImageRepository { get; }
        public ProductCharacteristicRepository ProductCharacteristicRepository { get; }
        public CharacteristicRepository CharacteristicRepository { get; }
        public ProductRepository ProductRepository { get; }
        public DeliveryRepository DeliveryRepository { get; }
        public AddressRepository AddressRepository { get; }
        public BrandRepository BrandRepository { get; }
        public OrderDetailsRepository OrderDetailsRepository { get; }
        public OrderRepository OrderRepository { get; }
        public PackageRepository PackageRepository { get; }
        public NewsRepository NewsRepository { get; }
        public SubscriberRepository SubscriberRepository { get; }


        public async Task SaveChangesAsync()
        {
            try
            {
                await _storeContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                var sqlException = e.GetBaseException() as SqlException;
                //2601 is error number of unique index violation
                if (sqlException != null && sqlException.Number == 2601)
                {
                    //Unique index was violated. Show corresponding error message to user.
                }
            }


        }
    }
}