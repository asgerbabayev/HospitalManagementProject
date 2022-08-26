using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IRoomService
    {
        IResult Add(RoomDto roomDto);
        IResult Update(RoomDto roomDto);
        IResult Delete(int id);
        IDataResult<List<Room>> GetAll();
        IDataResult<Room> GetById(int id);
    }
}
