using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Prescription : IEntity
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int RegistryId { get; set; }
        public Registry Registry { get; set; }
        public string UsageTime { get; set; }
        public int DailyDose { get; set; }
    }
}
