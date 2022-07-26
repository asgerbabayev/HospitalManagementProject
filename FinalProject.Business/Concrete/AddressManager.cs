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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }

        public IResult Add(AddressDto addressAddDto)
        {
            _addressDal.Add(_mapper.Map<Address>(addressAddDto));
            return new Result(true, Messages.AddressAdded);
        }

        public IResult Delete(int id)
        {
            Address address = GetById(id).Data;
            _addressDal.Delete(address);
            return new Result(true, Messages.AddressDeleted);
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(), Messages.AddressListed);
        }

        public IResult Update(AddressDto addressUpdateDto)
        {
            Address address = new Address
            {
                Id = addressUpdateDto.Id,
                City = addressUpdateDto.City,
                Region = addressUpdateDto.Region,
                Street = addressUpdateDto.Street,
                ApartmentNumber = addressUpdateDto.ApartmentNumber
            };
            _addressDal.Update(address);
            return new Result(true, Messages.AddressUpdated);
        }

        public IDataResult<Address> GetById(int Id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(f => f.Id == Id), Messages.AddressGeted);
        }
    }
}
