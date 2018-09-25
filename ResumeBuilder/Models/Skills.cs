using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class Skills
    {

        public int ID { get; set; }

        public string Skill { get; set; }

        public Applicant Applicant { get; set; }

        public int? ApplicantID { get; set; }

    }
}
