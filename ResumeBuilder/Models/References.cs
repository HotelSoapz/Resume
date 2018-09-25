using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class References
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "Applicant")]
        public string RefferenceName { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        public string Relation { get; set; }

        public Applicant Applicant { get; set; }
        public int? ApplicantID { get; set; }
    }
}
