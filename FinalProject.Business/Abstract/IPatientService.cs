using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IPatientService
    {
        IResult Add(PatientDto patientDto);
        IResult Update(PatientDto patientDto);
        IResult Delete(int Id);
        IDataResult<List<Patient>> GetAll();
        IDataResult<Patient> GetById(int id);
    }
}
