using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Context;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.Interfaces
{
   public abstract class BaseRepository<T>:IRepository<T> where T:class
   {
       private StoreContext _StoreContext { get; set; }
        public BaseRepository(StoreContext context)
        {
            _StoreContext = context;
        }

      
        public IQueryable<T> FindAll()
        {
            return _StoreContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicat)
        {
            return  _StoreContext.Set<T>().Where(predicat);
        }

        public OperationDetail Create(T entity)
        {
            _StoreContext.Set<T>().Add(entity);
            return  new OperationDetail(){Message = "Created"};
        }

        public OperationDetail Update(T entity)
        {
            _StoreContext.Set<T>().Update(entity);
            return new OperationDetail() { Message = "Updated" };
        }

        public OperationDetail Delete(T entity)
        {
            _StoreContext.Set<T>().Remove(entity);
            return new OperationDetail() { Message = "Deleted" };
        }
    }
}
