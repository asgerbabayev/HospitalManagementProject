using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Material : IEntity
    {
        public int? Id { get; set; }
        public int RegistryId { get; set; }
        public Registry Registry { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int Count { get; set; }
    }
}
