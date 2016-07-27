using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrixWebAPI.Models.Oracle
{
    public class Permissions
    {
        public int ProfileID { get; set; }
        public string Description { get; set; }
        public int DomainID { get; set; }
        public string DomainName { get; set; }
        public string DomainAddress { get; set; }
        public int DomainMax { get; set; }
        public string OU { get; set; }
        public int CompanyID { get; set; }
        public int CompanyMax { get; set; }
        public string CompanyName { get; set; }
        public bool ChangePW { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LogonScript { get; set; }
        public char ProfileDrive { get; set; }
        public string ProfilePath{ get; set; }
        public string Membership { get; set; }
        public int EmailID { get; set; }
        public string EmailName { get; set; }
        public string EmailDomain { get; set; }
        public int EmailDomainMax { get; set; }
        public bool HasWebmail { get; set; }
        public bool HasActiveSync { get; set; }
        public bool HasEmailForwarding { get; set; }
        public string GroupSMTP { get; set; }
        public int ChatID { get; set; }
        public string ChatName { get; set; }
        public int ChatMax { get; set; }
        public bool HasFederation { get; set; }
        public int VpnID { get; set; }
        public string VpnName { get; set; }
        public int WorkboothID { get; set; }
        public string WorkboothName { get; set; }
        public int WorkboothMax { get; set; }
        public bool HasBoxAccount { get; set; }
        public string Remarks { get; set; }
    }
}
