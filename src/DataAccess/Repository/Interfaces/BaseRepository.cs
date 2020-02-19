using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Context;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Domain.Repository.Interfaces
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected BaseRepository(StoreContext context)
        {
            _storeContext = context;
        }
        private StoreContext _storeContext { get; }
        public IQueryable<T> FindAll()
        {
            return _storeContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicat)
        {
            return _storeContext.Set<T>().Where(predicat);
        }
        public OperationDetail Create(T entity)
        {
            try
            {
                _storeContext.Set<T>().Add(entity);
                return new OperationDetail {Message = "Created"};
            }
            catch (Exception e)
            {
                Log.Error(e, "Create Fatal Error");
                return new OperationDetail {IsError = true, Message = "Create Fatal Error"};
            }
        }
        public OperationDetail Update(T entity)
        {
            try
            {
                _storeContext.Set<T>().Update(entity);
                return new OperationDetail {Message = "Updated"};
            }
            catch (Exception e)
            {
                Log.Error(e, "Update Fatal Error");
                return new OperationDetail {IsError = true, Message = "Update Fatal Error"};
            }
        }
        public OperationDetail Delete(T entity)
        {
            try
            {
                _storeContext.Set<T>().Remove(entity);
                return new OperationDetail {Message = "Deleted"};
            }
            catch (Exception e)
            {
                Log.Error(e, "Deleted Fatal Error");
                return new OperationDetail {IsError = true, Message = "Deleted Fatal Error"};
            }
        }
    }
}