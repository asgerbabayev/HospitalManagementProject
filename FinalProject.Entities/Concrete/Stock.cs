using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Stock : IEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
