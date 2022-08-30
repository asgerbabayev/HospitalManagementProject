using AutoMapper;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
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
    public class RegistryManager : IRegistryService
    {
        private readonly IRegistryDal _registryDal;
        private readonly IRoomDal _roomDal;
        private readonly IMapper _mapper;

        public RegistryManager(IRegistryDal registryDal, IMapper mapper, IRoomDal roomDal)
        {
            _registryDal = registryDal;
            _mapper = mapper;
            _roomDal = roomDal;
        }

        public IResult Add(RegistryDto registryDto)
        {
            var result = CheckRoomCapacity(registryDto.RoomId);
            if (!result.Success) return new ErrorResult(result.Message);
            registryDto.PatientRegistryDate = DateTime.UtcNow;
            string guid = Guid.NewGuid().ToString("N");
            registryDto.Number = guid.Substring(0, 10);
            _registryDal.Add(_mapper.Map<Registry>(registryDto));
            return new Result(true, Messages.RegistryAdded);
        }
        private IResult CheckRoomCapacity(int id)
        {
            var capacity = _roomDal.Get(a => a.Id == id).Capacity;
            var result = _registryDal.GetAll(a => a.RoomId == id).Count;
            if (result < capacity) return new SuccessResult();
            return new ErrorResult("Otaqda boş palata yoxdur");
        }
        public IResult Delete(int id)
        {
            Registry registry = GetById(id).Data;
            _registryDal.Delete(registry);
            return new Result(true, Messages.RegistryDeleted);
        }
        public IDataResult<Registry> GetById(int id)
        {
            return new SuccessDataResult<Registry>(_registryDal.Get(f => f.Id == id), Messages.RegistryGeted);
        }

        public IDataResult<List<Registry>> GetAll()
        {
            return new SuccessDataResult<List<Registry>>(_registryDal.GetAll(), Messages.RegistryListed);
        }

        public IResult Update(RegistryDto registryDto)
        {
            var result = CheckRoomCapacity(registryDto.RoomId);
            if (!result.Success) return new ErrorResult(result.Message);
            var data = GetById(registryDto.Id);
            registryDto.Number = data.Data.Number;
            registryDto.PatientRegistryDate = data.Data.PatientRegistryDate;
            _registryDal.Update(_mapper.Map<Registry>(registryDto));
            return new Result(true, Messages.RegistryUpdated);
        }

        public IDataResult<List<Registry>> GetAllData()
        {
            return new SuccessDataResult<List<Registry>>(_registryDal.GetAllData(), Messages.RegistryListed);
        }

        public IResult LeavePatient(int id)
        {
            var result = _registryDal.Get(x => x.Id == id);
            if (result == null) return new ErrorResult();
            result.PatientLeavingDate = DateTime.UtcNow;
            result.Status = true;
            _registryDal.Update(result);
            return new SuccessResult("Xəstə çıxışı edildi");
        }


    }
}
