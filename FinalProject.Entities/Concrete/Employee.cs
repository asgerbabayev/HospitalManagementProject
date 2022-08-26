using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FinalProject.Entities.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public bool EmailConfirmation { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
