using DataAccess.Repository.Interfaces;
using Domain.Context;
using System;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(StoreContext storeContext, IUserRepository userRepository, ICommentRepository commentRepository, CategoryRepository categoryRepository, IImageRepository imageRepository, IGroupCharacteristicRepository groupCharacteristicRepository, ICharacteristicRepository characteristicRepository, IProductRepository productRepository, IDeliveryRepository deliveryRepository, AddressRepository addressRepository, IBrandRepository brandRepository, IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository, IPackageRepository packageRepository)
        {
            _storeContext = storeContext;
            UserRepository = userRepository;
            CommentRepository = commentRepository;
            CategoryRepository = categoryRepository;
            ImageRepository = imageRepository;
            GroupCharacteristicRepository = groupCharacteristicRepository;
            CharacteristicRepository = characteristicRepository;
            ProductRepository = productRepository;
            DeliveryRepository = deliveryRepository;
            AddressRepository = addressRepository;
            BrandRepository = brandRepository;
            OrderDetailsRepository = orderDetailsRepository;
            OrderRepository = orderRepository;
            PackageRepository = packageRepository;
        }

        private StoreContext _storeContext { get; }

        public void Dispose()
        {
            _storeContext?.Dispose();
        }
        public IUserRepository UserRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public CategoryRepository CategoryRepository { get; }
        public IImageRepository ImageRepository { get; }
        public IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        public ICharacteristicRepository CharacteristicRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IDeliveryRepository DeliveryRepository { get; }
        public AddressRepository AddressRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public IOrderDetailsRepository OrderDetailsRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IPackageRepository PackageRepository { get; }
        public Task SaveChangesAsync()
        {
            return _storeContext.SaveChangesAsync();
        }
    }
}