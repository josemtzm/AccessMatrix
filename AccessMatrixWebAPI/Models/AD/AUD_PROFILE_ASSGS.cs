namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AUD_PROFILE_ASSGS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_ASSGNMENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(70)]
        public string LOC_CD { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(70)]
        public string JOB_CD { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string CLT_PNT_ORG_CD { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string GL_CLT_CD { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string PROG_CD { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(10)]
        public string GL_DEPT_CD { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime CRT_DT { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(255)]
        public string CRT_PROC { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(255)]
        public string CRT_USR { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(1)]
        public string EVENT_TYPE { get; set; }

        [StringLength(500)]
        public string COMMENT { get; set; }

        [StringLength(20)]
        public string PRJ_CD { get; set; }
    }
}
