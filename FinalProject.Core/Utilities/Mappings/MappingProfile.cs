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
            CreateMap<Employee, LoginDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Clinic, ClinicDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Medicine, MedicineDto>().ReverseMap();

            CreateMap<Stock, StockDto>().ReverseMap();

            CreateMap<Room, RoomDto>().ReverseMap();

            CreateMap<Registry, RegistryDto>().ReverseMap();

            CreateMap<Patient, PatientDto>().ReverseMap();

            CreateMap<Material, MaterialDto>().ReverseMap();

            CreateMap<Prescription, PrescriptionDto>().ReverseMap();

            CreateMap<Control, ControlDto>().ReverseMap();

            CreateMap<Analysis, AnalysisDto>().ReverseMap();

            CreateMap<ControlAnalysis, ControlAnalysisDto>().ReverseMap();
        }
    }
}
