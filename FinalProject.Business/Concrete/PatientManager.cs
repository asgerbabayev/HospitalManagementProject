using AutoMapper;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Core.Utilities.Results;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;
        private readonly IMapper _mapper;

        public PatientManager(IPatientDal patientDal, IMapper mapper)
        {
            _patientDal = patientDal;
            _mapper = mapper;
        }

        public IResult Add(PatientDto patientDto)
        {
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

        
    }
}
