using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderContext.Models
{
    public class Applicant
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreedAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
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
