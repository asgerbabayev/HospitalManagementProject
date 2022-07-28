using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class MaterialDto : IDto
    {
        public int Id { get; set; }
        public int RegistryId { get; set; }
        public int StockId { get; set; }
        public int Count { get; set; }
    }
}
