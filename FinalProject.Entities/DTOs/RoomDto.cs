using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class RoomDto:IDto
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
    }
}
