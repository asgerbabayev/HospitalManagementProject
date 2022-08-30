using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IControlService
    {
        IResult Add(ControlDto controlDto);
        IResult Update(ControlDto controlDto);
        IResult Delete(int Id);
        IDataResult<List<Control>> GetAll();
        IDataResult<Control> GetById(int id);
    }
}
