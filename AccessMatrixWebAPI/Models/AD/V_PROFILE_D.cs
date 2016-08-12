namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_PROFILE_D
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DOMAIN_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string PROFILE_NAME { get; set; }

        [StringLength(1000)]
        public string PROFILE_DESC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string PROFILE_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string DOMAIN_NAME { get; set; }

        [StringLength(1000)]
        public string DOMAIN_DESC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string DOMAIN_DN { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string DOMAIN_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_ASSGNMENT_ID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(70)]
        public string JOB_CD { get; set; }

        [StringLength(255)]
        public string JOB_DESC { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1)]
        public string JOB_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(70)]
        public string LOC_CD { get; set; }

        [StringLength(255)]
        public string LOC_DESC { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(1)]
        public string LOC_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(20)]
        public string GL_CLT_CD { get; set; }

        [StringLength(255)]
        public string GL_CLT_DESC { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(1)]
        public string GL_CLT_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(10)]
        public string GL_DEPT_CD { get; set; }

        [StringLength(255)]
        public string GL_DEPT_DESC { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(1)]
        public string GL_DEPT_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(20)]
        public string PROG_CD { get; set; }

        [StringLength(255)]
        public string PROG_DESC { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(1)]
        public string PROG_ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(1)]
        public string SHARED_FLAG { get; set; }
    }
}
