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
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IPrescriptionDal _prescriptionDal;
        private readonly IMapper _mapper;
        public PrescriptionManager(IPrescriptionDal prescriptionDal, IMapper mapper)
        {
            _prescriptionDal = prescriptionDal;
            _mapper = mapper;
        }

        public IResult Add(PrescriptionDto prescriptionDto)
        {
            _prescriptionDal.Add(_mapper.Map<Prescription>(prescriptionDto));
            return new Result(true, Messages.PrescriptionAdded);
        }

        public IResult Delete(int id)
        {
            Prescription prescription = GetById(id).Data;
            _prescriptionDal.Delete(prescription);
            return new Result(true, Messages.PrescriptionDeleted);
        }

        public IDataResult<Prescription> GetById(int id)
        {
            return new SuccessDataResult<Prescription>(_prescriptionDal.Get(x => x.Id == id), Messages.PrescriptionGeted);
        }

        public IDataResult<List<Prescription>> GetAll()
        {
            return new SuccessDataResult<List<Prescription>>(_prescriptionDal.GetAll(), Messages.PrescriptionListed);
        }

        public IResult Update(PrescriptionDto prescriptionDto)
        {
            _prescriptionDal.Update(_mapper.Map<Prescription>(prescriptionDto));
            return new Result(true, Messages.PrescriptionAdded);
        }
    }
}
