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
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "School name must contain only numbers and letters")]
        public string School { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Location must contain only numbers and letters")]
        public string Location { get; set; }

        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Degree must contain only numbers and letters")]
        public string Degree { get; set; }

        [Required]
        [Display(Name = "Field Of Study")]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Field of study must contain only numbers and letters")]
        public string FieldOfStudy { get; set; }

        [Required]
        [Display(Name = "Graduation Year")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Graduation year must contain only numbers")]
        public string gradYear { get; set; }

        [Display(Name = "Graduation Month")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Graduation month must contain only numbers")]
        public string gradMonth { get; set; }

        public Applicant Applicant { get; set; }

        public int? ApplicantID { get; set; }
    }
}
