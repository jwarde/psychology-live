using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyProject.Models
{
    public class Documentation
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string Description { get; set; }

        public int DocumentTypeId { get; set; }
        public DocumentationType DocumentType { get; set; }

        public string VersionId { get; set; }
        public string DocumentationFor { get; set; }
        public bool Complete { get; set; }
        public bool AnonymousAccess { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public string DocumentText { get; set; }

    }
}