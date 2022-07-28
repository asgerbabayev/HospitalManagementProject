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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;
        private readonly IMapper _mapper;

        public RoomManager(IRoomDal roomDal, IMapper mapper)
        {
            _roomDal = roomDal;
            _mapper = mapper;
        }

        public IResult Add(RoomDto roomDto)
        {
            _roomDal.Add(_mapper.Map<Room>(roomDto));
            return new Result(true, Messages.RoomAdded);
        }

        public IResult Delete(int id)
        {
            Room room = GetById(id).Data;
            _roomDal.Delete(room);
            return new Result(true, Messages.RoomDeleted);
        }

        public IDataResult<List<Room>> GetAll()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(), Messages.RoomListed);
        }

        public IResult Update(RoomDto roomDto)
        {
            _roomDal.Update(_mapper.Map<Room>(roomDto));
            return new Result(true, Messages.RoomUpdated);
        }

        public IDataResult<Room> GetById(int id)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(x => x.Id == id), Messages.RoomGeted);
        }
    }
}
