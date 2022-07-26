using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class ClinicDto:IDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
