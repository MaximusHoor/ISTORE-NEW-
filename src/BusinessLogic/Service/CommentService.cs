using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CommentService : ICommentService
    {

        public CommentService(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        private readonly IUnitOfWork _unitOfWork;
        public async Task<OperationDetail> CreateCommentAsync(Comment comment)
        {
            var operationResult= _unitOfWork.CommentRepository.Create(comment);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<OperationDetail> DeleteCommentAsync(Comment comment)
        {
            var operationResult = _unitOfWork.CommentRepository.Delete(comment.);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<IEnumerable<Comment>> FindAllCommentsAsync()
        {
            return await _unitOfWork.CommentRepository.FindAllCommentsAsync(); 
        }

        public async Task<Comment> FindCommentAsync(int id)
        {
            return await _unitOfWork.CommentRepository.FindCommentByConditionAsync(x => x.Id == id); 
        }

        public async Task<OperationDetail> UpdateCommentAsync(Comment comment)
        {
            var operationResult = _unitOfWork.CommentRepository.Update(comment);
            await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }
    }
}
