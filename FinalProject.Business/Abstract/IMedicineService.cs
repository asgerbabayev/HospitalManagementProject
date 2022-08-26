using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IMedicineService
    {
        IResult Add(MedicineDto medicineDto);
        IResult Update(MedicineDto medicineDto);
        IResult Delete(int id);
        IDataResult<List<Medicine>> GetAll();
        IDataResult<Medicine> GetById(int id);
    }
}
