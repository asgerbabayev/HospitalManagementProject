using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System.Collections.Generic;

namespace FinalProject.Business.Abstract
{
    public interface IClinicService
    {
        IResult Add(ClinicDto clinicDto);
        IResult Update(ClinicDto clinicDto);
        IResult Delete(int Id);
        IDataResult<List<Clinic>> GetAll();
    }
}
