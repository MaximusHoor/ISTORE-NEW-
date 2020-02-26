using Business.Service.Interfaces;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ICategoryService: ICrudService<Category>
    {
        Task<IReadOnlyCollection<Category>> FindByConditionWithIncludeAsync(Expression<Func<Category, bool>> predicat, Expression<Func<Category, bool>> includePredicat);
    }
}