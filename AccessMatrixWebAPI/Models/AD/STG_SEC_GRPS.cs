namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STG_SEC_GRPS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DOMAIN_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string NAME { get; set; }

        [StringLength(1000)]
        public string DESCRIPTION { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string DN { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime LD_DT { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string LD_PROC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string LD_USR { get; set; }

        public DateTime? LST_UPD_DT { get; set; }

        [StringLength(255)]
        public string LST_UPD_PROC { get; set; }

        [StringLength(255)]
        public string LST_UPD_USR { get; set; }
    }
}
