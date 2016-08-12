using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models.AD
{
    public class SecurityGroups
    {
        public int SEC_GRP_ID { get; set; }
        public int DOMAIN_ID { get; set; }
        public string SEC_GROUP_NAME { get; set; }
        public string SEC_GROUP_DESC { get; set; }
        public string SEC_GROUP_DN { get; set; }
        public string DOMAIN_NAME { get; set; }
        public string DOMAIN_DESC { get; set; }
        public string DOMAIN_DN { get; set; }
    }
}
