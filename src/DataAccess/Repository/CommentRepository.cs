using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private StoreContext dbContext;
        public CommentRepository(StoreContext context) : base(context) { dbContext = context; }
        public async Task<OperationDetail> CreateCommentAsync(Comment comment)
        {
            try
            {
                base.Create(comment);
                Log.Debug("created");
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
                return new OperationDetail() { IsError = true, Message = ex.Message };
            }
            return new OperationDetail() { IsError = false };

        }

        public async Task<OperationDetail> DeleteCommentAsync(Comment comment)
        {
            try
            {
                base.Delete(comment);
                await dbContext.SaveChangesAsync();
                Log.Debug("comment deleted");
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
                return new OperationDetail() { IsError = true, Message = ex.Message };
            }
            return new OperationDetail() { IsError = false };
        }

        public async Task<IEnumerable<Comment>> FindAllCommentsAsync()
        {
            try
            {
                Log.Debug("comment returned");
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message); 
            }
            return await base.FindAll().Include(x=>x.Product).Include(x=>x.User).Include(x=>x.Answers).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> FindCommentByConditionAsync(Expression<Func<Comment, bool>> predicate)
        {
            try
            {
                Log.Debug("comment returned");
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
           // return  await base.FindByCondition(predicate)
        }

        public async Task<OperationDetail> UpdateCommentAsync(Comment comment)
        {
          //Здесь упадет так как не подгружены связ сущности
            try
            {
                base.Update(comment);
                await dbContext.SaveChangesAsync();
                Log.Debug("comment deleted");
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
                return new OperationDetail() { IsError = true, Message=ex.Message };
            }
            return new OperationDetail() { IsError = false };
        }
    }
}
