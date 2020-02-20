using System;
using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;
using Domain.Context;

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

        public ICommentRepository CommentRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public IImageRepository ImageRepository { get; }

        public IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        public IDeliveryRepository DeliveryRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _storeContext.SaveChangesAsync();
        }
    }
}