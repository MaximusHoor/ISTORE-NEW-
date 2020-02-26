﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IGroupCharacteristicService:ICrudService<GroupCharacteristic>
    {
        Task<IReadOnlyCollection<GroupCharacteristic>> FindByConditionWithIncludeAsync(Expression<Func<GroupCharacteristic, bool>> predicat, Expression<Func<GroupCharacteristic, bool>> includePredicat);
    }
}
