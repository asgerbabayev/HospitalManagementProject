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
        IResult Add(DoctorAddDto doctorAddDto);
        IResult Update(DoctorAddDto doctorAddDto);
        IResult Delete(int Id);
        public IDataResult<Doctor> Login(LoginDto loginDto);
        public IDataResult<AccessToken> CreateAccessToken(Doctor doctor);
        public IResult CheckIsConfirmedAccount(string email);
        public string ConfirmationMessage();
    }
}
