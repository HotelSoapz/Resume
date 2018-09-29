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
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Employer name must contain only numbers and letters")]
        public string Employer { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "City must contain only numbers and letters")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        [RegularExpression("[A-Z]{2}", ErrorMessage = "Please select a state.")]
        public string State { get; set; }

        [Display(Name = "Start Month")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Start month must contain only numbers")]
        public string StartMonth { get; set; }

        [Required]
        [Display(Name = "Start Year")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Start year must contain only numbers")]
        public string StartYear { get; set; }

        [Display(Name = "End Month")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "End month must contain only numbers")]
        public string EndMonth { get; set; }

        [Display(Name = "End Year")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "End year must contain only numbers")]
        public string EndYear { get; set; }

        [Required]
        [Display(Name = "Currently Employed")]
        public bool CurrentlyEmployed { get; set; }

        public Applicant Applicant { get; set; }
        public int? ApplicantID { get; set; }
        public List<Models.Position> Positions { get; set; }




    }
    
}
