using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Doctor : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Degree { get; set; }
        public string Position { get; set; }
        public string Education { get; set; }
        public string CertificateNo { get; set; }
        public int ClinicId { get; set; }
        public bool Status { get; set; }
    }
}
