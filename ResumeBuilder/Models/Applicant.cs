using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ResumeBuilderContext.Models
{
    public class Applicant
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First name must contain only numbers and letters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Last name must contain only numbers and letters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [RegularExpression(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$", ErrorMessage = "Address must contain only numbers and letters")]
        public string StreedAddress { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "City must contain only numbers and letters")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        [RegularExpression("[A-Z]{2}", ErrorMessage = "Please select a state.")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"\d{5}-?(\d{4})?$", ErrorMessage = "Zip code must contain only numbers and dashes")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Phone number must contain only numbers,dashes, and parentheses")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }

        [Required]
        public string Summary { get; set; }

        public List<Models.Skills> Skills { get; set; }

        public List<Models.JobHistory> JobHistory { get; set; }

        public List<Models.Education> Education { get; set; }

        public List<Models.References> References { get; set; }

        public List<Models.Portfolio> Portfolio { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

    }
}
