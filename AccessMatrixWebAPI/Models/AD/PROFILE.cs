namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROFILES")]
    public partial class PROFILE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFILE()
        {
            PROFILE_ASSIGNMENTS = new HashSet<PROFILE_ASSIGNMENTS>();
            PROFILE_OU = new HashSet<PROFILE_OU>();
            PROFILE_SEC_GRP = new HashSet<PROFILE_SEC_GRP>();
        }

        [Key]
        public int PROFILE_ID { get; set; }

        public int DOMAIN_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }

        [StringLength(1000)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTV_FLG { get; set; }

        public DateTime LD_DT { get; set; }

        [Required]
        [StringLength(255)]
        public string LD_PROC { get; set; }

        [Required]
        [StringLength(255)]
        public string LD_USR { get; set; }

        public DateTime? LST_UPD_DT { get; set; }

        [StringLength(255)]
        public string LST_UPD_PROC { get; set; }

        [StringLength(255)]
        public string LST_UPD_USR { get; set; }

        [Required]
        [StringLength(1)]
        public string SHARED_FLAG { get; set; }

        [StringLength(500)]
        public string COMMENT { get; set; }

        [StringLength(500)]
        public string SMTP_DISTRO { get; set; }

        [StringLength(255)]
        public string EMAIL_TYPE { get; set; }

        [StringLength(255)]
        public string PREFERRED_SMTP { get; set; }

        [StringLength(1)]
        public string EMAIL_FWD { get; set; }

        [StringLength(1)]
        public string COMMUNICATOR { get; set; }

        [StringLength(255)]
        public string COMM_TYPE { get; set; }

        [StringLength(1)]
        public string VPN { get; set; }

        [StringLength(1)]
        public string WEBMAIL { get; set; }

        [StringLength(1000)]
        public string SHARED_DRIVE { get; set; }

        [StringLength(1)]
        public string BOX_ACCNT { get; set; }

        public virtual DOMAIN DOMAIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFILE_ASSIGNMENTS> PROFILE_ASSIGNMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFILE_OU> PROFILE_OU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFILE_SEC_GRP> PROFILE_SEC_GRP { get; set; }
    }
}
