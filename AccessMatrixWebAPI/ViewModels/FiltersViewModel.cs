using AccessMatrixWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.ViewModels
{
    public class FiltersViewModel
    {
        public LocationsViewModel LocFilter { get; set; }
        public ClientsViewModel CliFilter { get; set; }
        public ProgramsViewModel ProgsFilter { get; set; }
        public DepartmentsViewModel DeptosFilter { get; set; }
        public RolesViewModel RolFilter { get; set; }
    }
}
