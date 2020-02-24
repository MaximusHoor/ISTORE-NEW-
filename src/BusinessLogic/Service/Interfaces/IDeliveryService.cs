using Domain.EF_Models;
using Domain.Infrastructure;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IDeliveryService<in T> : ICrudService<Delivery>
    {
        Task<OperationDetail> CustomMethod(T obj);
    }
}
