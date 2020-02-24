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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserRepository.FindAllUsersAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserByConditionAsync(x => x.Id == id);

            user.Comments = await _unitOfWork.CommentRepository.FindCommentsByConditionAsync(x => x.UserId == user.Id);
            return user;
        }

        public async Task<OperationDetail> CreateUserAsync(User user)
        {
            var operationResult = _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<OperationDetail> UpdateUserAsync(int id, User user)
        {
            var operationResult = _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<OperationDetail> DeleteUserAsync(User user)
        {
            var operationResult = _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }
    }
}
