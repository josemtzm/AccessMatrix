namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_permissions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileID { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? DomainID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string OU { get; set; }

        public int? CompanyID { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool ChangePW { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        public string LogonScript { get; set; }

        [StringLength(1)]
        public string ProfileDrive { get; set; }

        [StringLength(200)]
        public string ProfilePath { get; set; }

        [Column(TypeName = "text")]
        public string Membership { get; set; }

        public int? EmailID { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool HasWebmail { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool HasActiveSync { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool HasEmailForwarding { get; set; }

        [Column(TypeName = "text")]
        public string GroupSMTP { get; set; }

        public int? ChatID { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool HasFederation { get; set; }

        public int? VpnID { get; set; }

        public int? WorkboothID { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool HasBoxAccount { get; set; }

        [Column(TypeName = "text")]
        public string Remarks { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string ApprovalStatus { get; set; }

        [StringLength(50)]
        public string ApprovedBy { get; set; }
    }
}
