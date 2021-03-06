﻿using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(operationResult.IsError==false)  await _unitOfWork.SaveChangesAsync();
            return operationResult;
        }

        public async Task<IReadOnlyCollection<Comment>> GetCommentsAsync()
        {
            return await _unitOfWork.CommentRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<Comment>> GetCommentsAllIncludedAsync()
        {
            return await _unitOfWork.CommentRepository.GetCommentsAllIncludedAsync();
        }
        public async Task<Comment> GetCommentAllIncludedAsync(int commentId)
        {
            var comments = await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.Id == commentId);
            return comments.ElementAtOrDefault(0);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsByUserAsync(string userId)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.UserId == userId);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsByProductAsync(int productId)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAsync(x => x.ProductId == productId);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsByProductWithAllAsync(int productId)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.ProductId == productId);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsDateFromAsync(DateTime time)
        {
            return await _unitOfWork.CommentRepository.FindByConditionAllIncludedAsync(x => x.Date > time);
        }
        public async Task UpdateCommentLikesAsync(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                await _unitOfWork.CommentRepository.UpdateCommentLikesAsync(comment.Id, comment.LikesTotal, comment.DislikesTotal);
            }
            await _unitOfWork.SaveChangesAsync();
           // var operationResult =
           //if (operationResult.IsError == false) await _unitOfWork.SaveChangesAsync();
           //return operationResult;
        }

    }
}
