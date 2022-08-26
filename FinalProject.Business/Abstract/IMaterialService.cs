using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IMaterialService
    {
        IResult Add(MaterialDto materialDto);
        IResult Update(MaterialDto materialDto);
        IResult Delete(int id);
        IDataResult<List<Material>> GetAll();
        IDataResult<Material> GetById(int id);
    }
}
