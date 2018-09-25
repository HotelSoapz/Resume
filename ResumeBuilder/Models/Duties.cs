using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilderContext.Models
{
    public class Duties
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public Position Position { get; set; }

        public int? PositionID { get; set; }

    }
}
