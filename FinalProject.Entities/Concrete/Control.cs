using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Control : IEntity
    {
        public int Id { get; set; }
        public int RegistryId { get; set; }
        public Registry Registry { get; set; }
        public string Complaint { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Result { get; set; }
    }
}
