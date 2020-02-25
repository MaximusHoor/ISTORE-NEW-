using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CommentService : ICommentService
    {

        public CommentService(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        private readonly IUnitOfWork _unitOfWork;
        public async Task<OperationDetail> CreateCommentAsync(Comment comment)
        {
            var operationResult = await _unitOfWork.CommentRepository.CreateAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _unitOfWork.CommentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsAllIncludedAsync()
        {
            return await _unitOfWork.CommentRepository.GetCommentsAllIncludedAsync();
        }
        public async Task<Comment> GetCommentAllIncludedAsync(int commentId)
        {
            return await _unitOfWork.CommentRepository.GetCommentAllIncludedAsync(x => x.Id == commentId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserAsync(int userId)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByProductAsync(int productId)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.ProductId == productId);
        }
    }
}
