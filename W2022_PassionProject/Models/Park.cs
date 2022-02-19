using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace W2022_PassionProject.Models
{
    public class Park
    {
        [Key]
        public int ParkID { get; set; }
        public string ParkName { get; set; }
        public string ParkLocation{ get; set; }
        public bool ParkSeparation { get; set; }

    }
}