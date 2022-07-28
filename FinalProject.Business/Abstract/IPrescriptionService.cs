using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IPrescriptionService
    {
        IResult Add(PrescriptionDto prescriptionDto);
        IResult Update(PrescriptionDto prescriptionDto);
        IResult Delete(int id);
        IDataResult<List<Prescription>> GetAll();
    }
}
