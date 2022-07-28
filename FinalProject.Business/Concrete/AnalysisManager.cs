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
    public class AnalysisManager : IAnalysisService
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;

        public AnalysisManager(IAnalysisDal analysisDal, IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }
        public IResult Add(AnalysisDto analysisDto)
        {
            _analysisDal.Add(_mapper.Map<Analysis>(analysisDto));
            return new Result(true, Messages.AnalysisAdded);
        }

        public IResult Delete(int id)
        {
            Analysis analysis = GetById(id).Data;
            _analysisDal.Delete(analysis);
            return new Result(true, Messages.AnalysisDeleted);
        }

        public IDataResult<List<Analysis>> GetAll()
        {
            return new SuccessDataResult<List<Analysis>>(_analysisDal.GetAll(), Messages.AnalysisListed);
        }

        public IResult Update(AnalysisDto analysisDto)
        {
            _analysisDal.Update(_mapper.Map<Analysis>(analysisDto));
            return new Result(true, Messages.AddressUpdated);
        }

        public IDataResult<Analysis> GetById(int Id)
        {
            return new SuccessDataResult<Analysis>(_analysisDal.Get(f => f.Id == Id), Messages.AnalysisGeted);
        }
    }
}
