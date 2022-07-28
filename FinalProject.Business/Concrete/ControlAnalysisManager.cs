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
    public class ControlAnalysisManager : IControlAnalysisService
    {
        private readonly IControlAnalysisDal _controlAnalysisDal;
        private readonly IMapper _mapper;

        public ControlAnalysisManager(IControlAnalysisDal controlAnalysisDal, IMapper mapper)
        {
            _controlAnalysisDal = controlAnalysisDal;
            _mapper = mapper;
        }

        public IResult Add(ControlAnalysisDto controlAnalysisDto)
        {
            _controlAnalysisDal.Add(_mapper.Map<ControlAnalysis>(controlAnalysisDto));
            return new Result(true, Messages.ControlAnalysisAdded);
        }

        public IResult Delete(int id)
        {
            ControlAnalysis controlAnalysis = GetById(id).Data;
            _controlAnalysisDal.Delete(controlAnalysis);
            return new Result(true, Messages.ControlAnalysisDeleted);
        }

        public IDataResult<List<ControlAnalysis>> GetAll()
        {
            return new SuccessDataResult<List<ControlAnalysis>>(_controlAnalysisDal.GetAll(), Messages.ControlAnalysisListed);
        }

        public IResult Update(ControlAnalysisDto controlAnalysisDto)
        {
            _controlAnalysisDal.Update(_mapper.Map<ControlAnalysis>(controlAnalysisDto));
            return new Result(true, Messages.ControlAnalysisUpdated);
        }

        public IDataResult<ControlAnalysis> GetById(int id)
        {
            return new SuccessDataResult<ControlAnalysis>(_controlAnalysisDal.Get(x=>x.Id == id), Messages.ControlAnalysisGeted);
        }
    }
}
