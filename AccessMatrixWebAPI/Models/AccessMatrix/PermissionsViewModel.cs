using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models.AccessMatrix
{
    public class PermissionsViewModel
    {
        public int profileid { get; set; }
        public string description { get; set; }
        public int domainid { get; set; }
        public int ou { get; set; }
        public string logonscript { get; set; }
        public char profiledrive { get; set; }
        public string profilepath { get; set; }
        public string membership { get; set; }
        public bool changepw { get; set; }
        public int emaildid { get; set; }
        public string groupsmtp { get; set; }
        public bool hasemailforwarding { get; set; }
        public bool haswebmail { get; set; }
        public bool hasactivesync { get; set; }
        public int workboothid { get; set; }
        public int vpnid { get; set; }
        public int chatid { get; set; }
        public bool hasfederation { get; set; }
        public bool hasboxaccount { get; set; }
        public string remarks { get; set; }
    }
}
