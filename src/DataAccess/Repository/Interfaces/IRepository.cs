using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> predicat);
        OperationDetail Create(T entity);
        OperationDetail Update(T entity);
        OperationDetail Delete(T entity);
    }
}
