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
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Refference name must contain only numbers and letters")]
        public string RefferenceName { get; set; }

        [Required]
        [Display(Name = "Title")]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Title must contain only numbers and letters")]
        public string Title { get; set; }

        [Display(Name = "Company Name")]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Company name must contain only numbers and letters")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Phone number must contain only numbers,dashes, and parentheses")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }

        [Required]
        public string Relation { get; set; }

        public Applicant Applicant { get; set; }
        public int? ApplicantID { get; set; }
    }
}
