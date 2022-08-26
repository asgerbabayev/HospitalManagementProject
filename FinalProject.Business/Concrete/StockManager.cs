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
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;
        private readonly IMapper _mapper;

        public StockManager(IStockDal stockDal, IMapper mapper)
        {
            _stockDal = stockDal;
            _mapper = mapper;
        }

        public IDataResult<List<Stock>> GetAll()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(), Messages.StockListed);
        }
        public IResult Add(StockDto stockDto)
        {
            _stockDal.Add(_mapper.Map<Stock>(stockDto));
            return new Result(true, Messages.StockAdded);
        }

        public IResult Update(StockDto stockDto)
        {
            _stockDal.Update(_mapper.Map<Stock>(stockDto));
            return new Result(true, Messages.StockUpdated);
        }
        public IResult Delete(int id)
        {
            Stock stock = GetById(id).Data;
            _stockDal.Delete(stock);
            return new Result(true, Messages.StockDeleted);
        }

        public IDataResult<Stock> GetById(int id)
        {
            var result = _stockDal.Get(x => x.Id == id);
            if (result == null) return new ErrorDataResult<Stock>(Messages.StockGeted);
            return new SuccessDataResult<Stock>(result);
        }

    }
}
