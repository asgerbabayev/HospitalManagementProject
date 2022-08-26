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
    public class RegistryManager : IRegistryService
    {
        private readonly IRegistryDal _registryDal;
        private readonly IMapper _mapper;

        public RegistryManager(IRegistryDal registryDal, IMapper mapper)
        {
            _registryDal = registryDal;
            _mapper = mapper;
        }

        public IResult Add(RegistryDto registryDto)
        {
            registryDto.PatientRegistryDate = DateTime.UtcNow;
            string guid = Guid.NewGuid().ToString("N");
            registryDto.Number = guid.Substring(0,10);
            _registryDal.Add(_mapper.Map<Registry>(registryDto));
            return new Result(true, Messages.RegistryAdded);
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
    }
}
