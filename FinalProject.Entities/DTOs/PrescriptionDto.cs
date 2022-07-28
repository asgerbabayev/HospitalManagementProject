using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class PrescriptionDto : IDto
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int RegistryId { get; set; }
        public string Description { get; set; }
        public int DailyDose { get; set; }
    }
}
