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
    public class ControlManager : IControlService
    {
        private readonly IControlDal _controlDal;

        private readonly IMapper _mapper;
        public ControlManager(IControlDal controlDal, IMapper mapper)
        {
            _controlDal = controlDal;
            _mapper = mapper;
        }

        public IResult Add(ControlDto controlDto)
        {
            _controlDal.Add(_mapper.Map<Control>(controlDto));
            return new Result(true, Messages.ControlAdded);
        }

        public IResult Delete(int id)
        {
            Control control = GetById(id).Data;
            _controlDal.Delete(control);
            return new Result(true, Messages.ControlDeleted);
        }

        public IDataResult<Control> GetById(int id)
        {
            return new SuccessDataResult<Control>(_controlDal.Get(x => x.Id == id), Messages.ControlGeted);
        }

        public IDataResult<List<Control>> GetAll()
        {
            return new SuccessDataResult<List<Control>>(_controlDal.GetAll(), Messages.ControlListed);
        }

        public IResult Update(ControlDto controlDto)
        {
            _controlDal.Update(_mapper.Map<Control>(controlDto));
            return new Result(true, Messages.ControlUpdated);
        }
    }
}
