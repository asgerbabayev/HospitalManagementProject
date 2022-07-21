using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Registry : IEntity
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PatientRegistryDate { get; set; }
        public DateTime PatientLeavingDate { get; set; }

    }
}
