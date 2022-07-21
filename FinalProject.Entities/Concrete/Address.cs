﻿using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public int ApartmentNumber { get; set; }
    }
}