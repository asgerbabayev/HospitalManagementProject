using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class RegistryDto : IDto
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PatientRegistryDate { get; set; }
        public DateTime PatientLeavingDate { get; set; }
        public bool Status { get; set; }
    }
}
