namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SEC_GRPS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEC_GRPS()
        {
            PROFILE_SEC_GRP = new HashSet<PROFILE_SEC_GRP>();
        }

        [Key]
        public int SEC_GRP_ID { get; set; }

        public int DOMAIN_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }

        [StringLength(1000)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(500)]
        public string DN { get; set; }

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

        public virtual DOMAIN DOMAIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFILE_SEC_GRP> PROFILE_SEC_GRP { get; set; }
    }
}
