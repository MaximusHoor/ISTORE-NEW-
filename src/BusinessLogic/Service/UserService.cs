using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public class UserService : IUserService
    {
        public UserService(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        private readonly IUnitOfWork _unitOfWork;

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetUsersAllIncludedAsync()
        {
            return await _unitOfWork.UserRepository.FindAllUsersAllIncludedAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _unitOfWork.UserRepository.GetUserAllIncludedAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyCollection<User>> GetUserAllIncludedAsync(string id)
        {
            return await _unitOfWork.UserRepository.FindUserByConditionAllIncludedAsync(x => x.Id == id);
        }

        public async Task<OperationDetail> CreateUserAsync(User user)
        {
            var operationResult = await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }
    }
}
