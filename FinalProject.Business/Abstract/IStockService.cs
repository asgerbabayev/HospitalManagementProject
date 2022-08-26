using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IStockService
    {
        IResult Add(StockDto stockDto);
        IResult Update(StockDto stockDto);
        IResult Delete(int Id);
        IDataResult<List<Stock>> GetAll();
        IDataResult<Stock> GetById(int id);
    }
}
