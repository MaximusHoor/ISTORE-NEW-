﻿using Business.Service.Interfaces;
using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IImageService:ICrudService<Image>
    {
        Task<IReadOnlyCollection<Image>> FindByConditionWithIncludeAsync(Expression<Func<Image, bool>> predicat, Expression<Func<Image, bool>> includePredicat);
    }
}