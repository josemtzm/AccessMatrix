namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STG_PROGS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CLT_PNT_ORG_CD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string GL_CLT_CD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string PROG_CD { get; set; }

        [StringLength(255)]
        public string DESC_SHRT { get; set; }

        [StringLength(500)]
        public string DESC_LNG { get; set; }

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
