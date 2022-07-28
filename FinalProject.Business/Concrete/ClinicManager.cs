using AutoMapper;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Core.Utilities.Results;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System.Collections.Generic;

namespace FinalProject.Business.Concrete
{
    public class ClinicManager : IClinicService
    {
        private readonly IClinicDal _clinicDal;
        private readonly IMapper _mapper;

        public ClinicManager(IClinicDal clinicDal, IMapper mapper)
        {
            _clinicDal = clinicDal;
            _mapper = mapper;
        }

        public IResult Add(ClinicDto clinicAddDto)
        {
            _clinicDal.Add(_mapper.Map<Clinic>(clinicAddDto));
            return new Result(true, Messages.ClinicAdded);
        }

        public IResult Delete(int id)
        {
            Clinic clinic = GetById(id).Data;
            _clinicDal.Delete(clinic);
            return new Result(true, Messages.ClinicDeleted);
        }
        public IDataResult<Clinic> GetById(int id)
        {
            return new SuccessDataResult<Clinic>(_clinicDal.Get(f => f.Id == id), Messages.ClinicGeted);
        }

        public IDataResult<List<Clinic>> GetAll()
        {
            return new SuccessDataResult<List<Clinic>>(_clinicDal.GetAll(), Messages.ClinicsListed);
        }

        public IResult Update(ClinicDto clinicUpdateDto)
        {
            _clinicDal.Update(_mapper.Map<Clinic>(clinicUpdateDto));
            return new Result(true, Messages.ClinicUpdated);
        }
    }
}
