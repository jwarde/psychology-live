using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyProject.Models
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string ReportTo { get; set; }
        public string AimsAndObjectives { get; set; }
        public string Brief { get; set; }
        public string Debrief { get; set; }
        public bool Active { get; set; }
    }
}