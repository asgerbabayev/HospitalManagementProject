using FinalProject.Core.Utilities.Results;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IDoctorService
    {
        IResult Add(DoctorDto doctorDto);
        IResult Update(DoctorDto doctorDto);
        IResult Delete(int Id);
        IDataResult<List<Doctor>> GetAll();
        IDataResult<Doctor> Login(LoginDto loginDto);
        IDataResult<AccessToken> CreateAccessToken(Doctor doctor);
        IResult CheckIsConfirmedAccount(string email);
        string ConfirmationMessage();
    }
}
