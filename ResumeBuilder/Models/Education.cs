using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderContext.Models
{
    public class Education
    {
        public int ID { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string Location { get; set; }

        
        public string Degree { get; set; }

        [Required]
        [Display(Name = "Field Of Study")]
        public string FieldOfStudy { get; set; }
         
        [Required]
        [Display(Name = "Graduation Year")]
        public string gradYear { get; set; }
        [Display(Name = "Graduation Month")]
        public string gradMonth { get; set; }

        public Applicant Applicant { get; set; }

        public int? ApplicantID { get; set; }
    }
}
