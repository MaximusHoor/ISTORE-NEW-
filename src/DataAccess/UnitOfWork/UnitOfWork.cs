using DataAccess.Repository.Interfaces;
using Domain.Context;
using System;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private StoreContext _storeContext { get; }

        public void Dispose()
        {
            _storeContext?.Dispose();
        }
        public IUserRepository UserRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IImageRepository ImageRepository { get; }
        public IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        public ICharacteristicRepository CharacteristicRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IDeliveryRepository DeliveryRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public IBrandRepository BrandRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _storeContext.SaveChangesAsync();
        }
    }
}