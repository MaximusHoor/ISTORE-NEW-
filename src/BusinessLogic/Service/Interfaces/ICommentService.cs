using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICommentService
    {
        Task<IReadOnlyCollection<Comment>> GetCommentsAsync();
        Task<IReadOnlyCollection<Comment>> GetCommentsAllIncludedAsync();
        Task<Comment> GetCommentAllIncludedAsync(int commentId);
        Task<IReadOnlyCollection<Comment>> GetCommentsByUserAsync(string userId);
        Task<IReadOnlyCollection<Comment>> GetCommentsDateFromAsync(DateTime time);
        Task<IReadOnlyCollection<Comment>> GetCommentsByProductAsync(int productId);
        Task<OperationDetail> CreateCommentAsync(Comment comment);
        Task<IReadOnlyCollection<Comment>> GetCommentsByProductWithAllAsync(int productId);
    }
}
