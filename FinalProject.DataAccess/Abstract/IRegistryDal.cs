﻿using FinalProject.Core.DataAccess;
using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.DataAccess.Abstract
{
    public interface IRegistryDal : IEntityRepository<Registry>
    {
        List<Registry> GetAllData();
    }
}
