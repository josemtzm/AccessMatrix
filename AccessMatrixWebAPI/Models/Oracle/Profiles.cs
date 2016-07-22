using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models.Oracle
{
    public class Profiles
    {
        public int ProfileID { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
