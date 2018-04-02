using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyProject.Models.ViewModel
{
    public class PublicProject
    {
        public List<Project> Projects { get; set; }
        public List<Documentation> Documentation { get; set; }
        public List<Experiment> Experiments { get; set; }
    }
}