using Business.Infrastructure;
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IDeliveryService<T>:ICrudService<Delivery>
    {
        Task<OperationDetailDTO> CustomMethod(T obj);
    }
}
