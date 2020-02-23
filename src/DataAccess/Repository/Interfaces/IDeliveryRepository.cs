using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task<IEnumerable<Delivery>> FindAllCommentsAsync();
        Task<IEnumerable<Delivery>> FindCommentByConditionAsync(Expression<Func<Delivery, bool>> predicate);
        OperationDetail CreateComment(Delivery delivery);
        OperationDetail UpdateComment(Delivery delivery);
        OperationDetail DeleteComment(Delivery delivery);
    }
}
