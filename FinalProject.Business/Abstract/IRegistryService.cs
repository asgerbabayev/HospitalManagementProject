using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IRegistryService
    {
        IResult Add(RegistryDto registryDto);
        IResult Update(RegistryDto registryDto);
        IResult Delete(int Id);
        IDataResult<List<Registry>> GetAll();
    }
}
