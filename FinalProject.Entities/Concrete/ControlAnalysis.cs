using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.Concrete
{
    public class ControlAnalysis : IEntity
    {
        public int Id { get; set; }
        public int ControlId { get; set; }
        public Control Control { get; set; }
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }
    }
}
