using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class ControlAnalysisDto : IDto
    {
        public int Id { get; set; }
        public int ControlId { get; set; }
        public int AnalysisId { get; set; }
    }
}
