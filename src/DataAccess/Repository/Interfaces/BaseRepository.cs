using Domain.Context;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BaseRepository(StoreContext context)
        {
            _storeContext = context;
        }
        private DbSet<TEntity> _entities;
        private StoreContext _storeContext;
        protected DbSet<TEntity> Entities => this._entities ??= _storeContext.Set<TEntity>();
        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }
        public virtual  async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public virtual async Task<OperationDetail> CreateAsync(TEntity entity)
        {
            try
            {
                await Entities.AddAsync(entity).ConfigureAwait(false);
                return new OperationDetail { Message = "Created" };
            }
            catch (Exception e)     
            {
                Log.Error(e, "Create Fatal Error");
                return new OperationDetail { IsError = true, Message = "Create Fatal Error" };
            }
        }
    }
}