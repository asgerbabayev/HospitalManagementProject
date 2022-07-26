using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(AddressDto addressDto);
        IResult Update(AddressDto addressDto);
        IResult Delete(int Id);
        IDataResult<List<Address>> GetAll();
    }
}
