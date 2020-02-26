﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICharacteristicService: ICrudService<Characteristic>
    {
        Task<IReadOnlyCollection<Characteristic>> FindByConditionWithIncludeAsync(Expression<Func<Characteristic, bool>> predicat, Expression<Func<Characteristic, bool>> includePredicat);
    }
}
