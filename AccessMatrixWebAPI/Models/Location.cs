using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrix.Models
{
    public class Location
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public bool Disabled { get; set; }
    }
}
