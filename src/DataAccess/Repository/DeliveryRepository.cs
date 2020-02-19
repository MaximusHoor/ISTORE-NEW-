using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DeliveryRepository:BaseRepository<Delivery>, IDeliveryRepository
    {
        StoreContext _context;
        public DeliveryRepository(StoreContext context):base(context)
        {
            _context = context;
           
        }

        public async Task<OperationDetail> CreateDeliveryAsync(Delivery delivery)
        {
            return this.Create(delivery);
        }

        public async Task<OperationDetail> DeleteDeliveryAsync(Delivery delivery)
        {
            return this.Delete(delivery);
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await this.FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Delivery>> GetAllByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await this.FindByCondition(predicat).ToListAsync();
        }

        public async Task<Delivery> GetByConditionAsync(Expression<Func<Delivery, bool>> predicat)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(predicat);
        }

        public async Task<OperationDetail> UpdateDeliveryAsync(Delivery delivery)
        {
            return this.Update(delivery);
        }
    }
}
