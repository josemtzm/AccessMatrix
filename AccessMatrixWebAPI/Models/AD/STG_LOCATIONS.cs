namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STG_LOCATIONS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(70)]
        public string LOC_CD { get; set; }

        [StringLength(255)]
        public string DESC_SHRT { get; set; }

        [StringLength(500)]
        public string DESC_LNG { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime LD_DT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string LD_PROC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string LD_USR { get; set; }

        public DateTime? LST_UPD_DT { get; set; }

        [StringLength(255)]
        public string LST_UPD_PROC { get; set; }

        [StringLength(255)]
        public string LST_UPD_USR { get; set; }
    }
}
