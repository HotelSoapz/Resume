using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class Portfolio
    {
        public int ID { get; set; }

        public string Link1 { get; set; }

        public string Link2 { get; set; }

        public string Link3 { get; set; }

        public Applicant Applicant { get; set; }

        public int? ApplicantID { get; set; }
    }
}
