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
    public class MedicineManager : IMedicineService
    {
        private readonly IMedicineDal _medicineDal;
        private readonly IMapper _mapper;

        public MedicineManager(IMedicineDal medicineDal, IMapper mapper)
        {
            _medicineDal = medicineDal;
            _mapper = mapper;
        }

        public IResult Add(MedicineDto medicineDto)
        {
            _medicineDal.Add(_mapper.Map<Medicine>(medicineDto));
            return new Result(true, Messages.MedicineAdded);
        }

        public IResult Delete(int id)
        {
            Medicine medicine = GetById(id).Data;
            _medicineDal.Delete(medicine);
            return new Result(true, Messages.MedicineDeleted);
        }

        public IDataResult<List<Medicine>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(MedicineDto medicineDto)
        {
            Medicine medicine = new Medicine
            {
                Id = medicineDto.Id,
                Name = medicineDto.Name,
                BarcodeNumber = medicineDto.BarcodeNumber,
                Type = medicineDto.Type,
                Count = medicineDto.Count
            };
            _medicineDal.Update(medicine);
            return new Result(true, Messages.MedicineUpdated);
        }

        public IDataResult<Medicine> GetById(int id)
        {
            return new SuccessDataResult<Medicine>(_medicineDal.Get(f => f.Id == id), Messages.MedicineGeted);
        }
    }
}
