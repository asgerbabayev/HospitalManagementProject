using FinalProject.Core.Utilities.Results;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IControlAnalysisService
    {
        IResult Add(ControlAnalysisDto controlAnalysisDto);
        IResult Update(ControlAnalysisDto controlAnalysisDto);
        IResult Delete(int id);
        IDataResult<List<ControlAnalysis>> GetAll();
    }
}
