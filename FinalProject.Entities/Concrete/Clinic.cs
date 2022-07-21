using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Clinic : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string InternalPhoneNumber { get; set; }
        public double Fee { get; set; }
    }
}
