using AutoMapper;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Core.Utilities.Business;
using FinalProject.Core.Utilities.Results;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Business.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;
        private readonly IRegistryDal _registryDal;
        private readonly IMapper _mapper;

        public PatientManager(IPatientDal patientDal, IMapper mapper, IRegistryDal registryDal)
        {
            _patientDal = patientDal;
            _mapper = mapper;
            _registryDal = registryDal;
        }

        public IResult Add(PatientDto patientDto)
        {
            var result = BusinessRules.Run(CheckRegistryNumber(patientDto.RegistryId),
                CheckIdentificationNumber(patientDto.IdentificationNumber), CheckPhoneNumber(patientDto.PhoneNumber));
            if (!result.Success) return new ErrorResult(result.Message);
            _patientDal.Add(_mapper.Map<Patient>(patientDto));
            return new Result(true, Messages.PatientAdded);
        }

        public IResult Delete(int id)
        {
            Patient patient = GetById(id).Data;
            _patientDal.Delete(patient);
            return new Result(true, Messages.PatientDeleted);
        }

        public IDataResult<List<Patient>> GetAll()
        {
            return new SuccessDataResult<List<Patient>>(_patientDal.GetPatientsWithRegistry(), Messages.PatientListed);
        }

        public IResult Update(PatientDto patientDto)
        {
            _patientDal.Update(_mapper.Map<Patient>(patientDto));
            return new Result(true, Messages.PatientUpdated);
        }
        public IDataResult<Patient> GetById(int id)
        {
            var result = _patientDal.GetPatient(id);
            if (result == null) return new ErrorDataResult<Patient>(Messages.RoomGeted);
            return new SuccessDataResult<Patient>(result);
        }

        private IResult CheckRegistryNumber(int id)
        {
            var result = _patientDal.GetAll(idn => idn.RegistryId == id).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult("Bu qeydiyyat doludur");
        }
        private IResult CheckIdentificationNumber(string idnNumber)
        {
            var result = _patientDal.GetAll(idn => idn.IdentificationNumber == idnNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.IdentificationNumberAlreadyHave);
        }

        private IResult CheckPhoneNumber(string phoneNumber)
        {
            var result = _patientDal.GetAll(i => i.PhoneNumber == phoneNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.PhoneNumberAlreadyHave);
        }
    }
}
