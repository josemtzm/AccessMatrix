namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROFILE_ASSIGNMENTS
    {
        [Key]
        public int PROFILE_ASSGNMENT_ID { get; set; }

        public int PROFILE_ID { get; set; }

        [Required]
        [StringLength(70)]
        public string LOC_CD { get; set; }

        [Required]
        [StringLength(70)]
        public string JOB_CD { get; set; }

        [Required]
        [StringLength(20)]
        public string GL_CLT_CD { get; set; }

        [Required]
        [StringLength(20)]
        public string PROG_CD { get; set; }

        [Required]
        [StringLength(10)]
        public string GL_DEPT_CD { get; set; }

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

        [StringLength(500)]
        public string COMMENT { get; set; }

        [StringLength(50)]
        public string CLT_PNT_ORG_CD { get; set; }

        [StringLength(20)]
        public string PRJ_CD { get; set; }

        public virtual CLT CLT { get; set; }

        public virtual DEPT DEPT { get; set; }

        public virtual JOB JOB { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        public virtual PRJ PRJ { get; set; }

        public virtual PROFILE PROFILE { get; set; }

        public virtual PROG PROG { get; set; }
    }
}
