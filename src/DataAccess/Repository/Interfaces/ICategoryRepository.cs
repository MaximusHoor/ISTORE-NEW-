using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyCollection<Category>> FindByConditionWithIncludeAsync(Expression<Func<Category, bool>> predicat, Expression<Func<Category, bool>> includePredicat);
    }
}
