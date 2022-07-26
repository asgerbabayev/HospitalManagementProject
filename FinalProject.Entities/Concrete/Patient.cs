using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Patient : IEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int TaxNo { get; set; }
        public int RegistryId { get; set; }
        public Registry Registry { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
