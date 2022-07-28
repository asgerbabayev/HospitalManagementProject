using FinalProject.Entities.Abstract;
using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class EmployeeDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Collage { get; set; }
        public string Position { get; set; }
        public string Education { get; set; }
        public string CertificateNo { get; set; }
        public int ClinicId { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public bool EmailConfirmation { get; set; }
    }
}
