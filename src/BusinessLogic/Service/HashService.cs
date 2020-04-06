using DataAccess.UnitOfWork;
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class HashService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HashService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<ulong> GetProductsHashByUserLogin(string login)
        {
            var order = (await _unitOfWork.OrderRepository.FindByConditionAsync(x => x.User.Email == login)).LastOrDefault();
            ulong res = 0;
            foreach (var item in order.Products)
            {
                var hash = Math.Pow(item.ProductId, item.Count) + item.ProductId * 5;
                res += (ulong)hash;
            }
            return res;
        }
    }
}
