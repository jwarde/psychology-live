using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyProject.Models
{
    public class UserTests
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Tests Tests { get; set; }

        public string ReasonForTestUsed { get; set; }
        public string TestRawData { get; set; }
        public string TestReturnedData { get; set; }

        public string Result { get; set; }
        public string Interpretation { get; set; }
    }
}