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

            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Clinic, ClinicDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Medicine, MedicineDto>().ReverseMap();

            CreateMap<Stock, StockDto>().ReverseMap();

            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
