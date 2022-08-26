using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Registry : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PatientRegistryDate { get; set; }
        public DateTime PatientLeavingDate { get; set; }
        public bool Status { get; set; }
    }
}
