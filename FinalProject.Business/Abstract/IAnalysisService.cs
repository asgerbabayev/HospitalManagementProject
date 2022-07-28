using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IAnalysisService
    {
        IResult Add(AnalysisDto analysisDto);
        IResult Update(AnalysisDto analysisDto);
        IResult Delete(int id);
        IDataResult<List<Analysis>> GetAll();
    }
}
