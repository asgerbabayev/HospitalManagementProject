using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class MedicineDto : IDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string BarcodeNumber { get; set; }
        public int Count { get; set; }
    }
}
