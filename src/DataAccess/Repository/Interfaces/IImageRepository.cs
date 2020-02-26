using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IImageRepository
    {
        Task<IReadOnlyCollection<Image>> FindByConditionWithIncludeAsync(Expression<Func<Image, bool>> predicat, Expression<Func<Image, bool>> includePredicat);
    }
}
