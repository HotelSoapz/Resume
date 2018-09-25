using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class JobHistory
    {
        public int ID { get; set; }

        [Required]
        public string Employer { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Display(Name = "Start Month")]
        public string StartMonth { get; set; }

        [Required]
        [Display(Name = "Start Year")]
        public string StartYear { get; set; }
        [Display(Name = "End Month")]
        public string EndMonth { get; set; }
        [Display(Name = "End Year")]
        public string EndYear { get; set; }

        [Required]
        [Display(Name = "Currently Employed")]
        public bool CurrentlyEmployed { get; set; }

        public Applicant Applicant { get; set; }
        public int? ApplicantID { get; set; }
        public List<Models.Position> Positions { get; set; }




    }
    
}
