using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
    }
}
