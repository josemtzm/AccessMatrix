namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROFILE_SEC_GRP
    {
        [Key]
        public int PROFILE_SEC_GRP_ID { get; set; }

        public int PROFILE_ID { get; set; }

        public int SEC_GRP_ID { get; set; }

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

        public virtual PROFILE PROFILE { get; set; }

        public virtual SEC_GRPS SEC_GRPS { get; set; }
    }
}
