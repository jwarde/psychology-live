using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Owner { get; set; }

        public bool QualificationYN { get; set; }
        public string Qualification { get; set; }

        public string Overview { get; set; }

        public string AimsAndObjectives { get; set; }

        public string Location { get; set; }

        public string Methodology { get; set; }

        public string Report { get; set; }

        public string Discussion { get; set; }

        public string Conclusion { get; set; }

        public bool AimsAndObjectivesMet { get; set; }

    }
}