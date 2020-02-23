using Business.Infrastructure;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICrudService<T>
    { 
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> predicat);
        Task<OperationDetailDTO> Create(T obj);
        Task<OperationDetailDTO> Update(T obj);
        Task<OperationDetailDTO> Delete(T obj);
    }
}
