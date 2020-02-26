using DataAccess.Repository.Interfaces;
using Domain.Context;
using System;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(StoreContext storeContext, /*UserRepository userRepository,*/ /*CommentRepository commentRepository,*/
        CategoryRepository categoryRepository, ImageRepository imageRepository, 
        GroupCharacteristicRepository groupCharacteristicRepository, 
        CharacteristicRepository characteristicRepository, ProductRepository productRepository, 
        DeliveryRepository deliveryRepository, AddressRepository addressRepository, BrandRepository brandRepository, 
        OrderDetailsRepository orderDetailsRepository, OrderRepository orderRepository, 
        PackageRepository packageRepository)
        {
            _storeContext = storeContext;
            //UserRepository = userRepository;
            //CommentRepository = commentRepository;
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
        //public IUserRepository UserRepository { get; }
        //public ICommentRepository CommentRepository { get; }
        public CategoryRepository CategoryRepository { get; }
        public ImageRepository ImageRepository { get; }
        public GroupCharacteristicRepository GroupCharacteristicRepository { get; }
        public CharacteristicRepository CharacteristicRepository { get; }
        public ProductRepository ProductRepository { get; }
        public DeliveryRepository DeliveryRepository { get; }
        public AddressRepository AddressRepository { get; }
        public BrandRepository BrandRepository { get; }
        public OrderDetailsRepository OrderDetailsRepository { get; }
        public OrderRepository OrderRepository { get; }
        public PackageRepository PackageRepository { get; }


        public Task SaveChangesAsync()
        {
            return _storeContext.SaveChangesAsync();
        }
    }
}