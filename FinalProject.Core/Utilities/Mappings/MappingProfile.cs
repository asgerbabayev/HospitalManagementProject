using AutoMapper;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Utilities.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, LoginDto>().ReverseMap();
            CreateMap<Doctor, DoctorAddDto>().ReverseMap();
        }
    }
}
