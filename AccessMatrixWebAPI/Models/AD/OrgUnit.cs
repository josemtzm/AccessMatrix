using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models.AD
{
    public class OrgUnit
    {
        public int OU_ID { get; set; }
        public int DOMAIN_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string DN { get; set; }
    }
}
