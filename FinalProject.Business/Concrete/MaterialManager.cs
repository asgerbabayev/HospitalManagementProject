﻿using AutoMapper;
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
    public class MaterialManager : IMaterialService
    {
        private readonly IMaterialDal _materialDal;
        private readonly IMapper _mapper;

        public MaterialManager(IMaterialDal materialDal, IMapper mapper)
        {
            _materialDal = materialDal;
            _mapper = mapper;
        }

        public IResult Add(MaterialDto materialDto)
        {
            _materialDal.Add(_mapper.Map<Material>(materialDto));
            return new Result(true, Messages.MaterialAdded);
        }

        public IResult Delete(int id)
        {
            Material material = GetById(id).Data;
            _materialDal.Delete(material);
            return new Result(true, Messages.MaterialDeleted);
        }
        public IDataResult<List<Material>> GetAll()
        {
            return new SuccessDataResult<List<Material>>(_materialDal.GetMaterials(), Messages.MaterialListed);
        }

        public IResult Update(MaterialDto materialDto)
        {
            _materialDal.Update(_mapper.Map<Material>(materialDto));
            return new Result(true, Messages.AddressUpdated);
        }

        public IDataResult<Material> GetById(int id)
        {
            var result = _materialDal.GetMaterial(id);
            if (result == null) return new ErrorDataResult<Material>(Messages.MedicineGeted);
            return new SuccessDataResult<Material>(result);
        }
    }
}
