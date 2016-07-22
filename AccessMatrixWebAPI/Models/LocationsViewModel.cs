using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models
{
    public class LocationsViewModel
    {
        [Display(Name = "Name")]
        public IEnumerable<t_locations> Locations { get; set; }
    }
}
