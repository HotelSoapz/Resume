﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class Position
    {
        [Display(Name = "Position")]
        public int PositionID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Start Year")]
        public string StartYear { get; set; }

        [Display(Name = "End Year")]
        public string EndYear { get; set; }

        [Display(Name = "Current Position")]
        public bool CurrentPosition { get; set; }

        [Display(Name = "Employer")]
        public JobHistory JobHistories { get; set; }

        public List<Models.Duties> Duties { get; set; }

        public int? JobHistoryID { get; set; }







    }
}
