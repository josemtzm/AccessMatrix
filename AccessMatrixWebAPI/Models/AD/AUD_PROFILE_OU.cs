namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AUD_PROFILE_OU
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_OU_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PROFILE_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OU_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CRT_DT { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string CRT_PROC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string CRT_USR { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string EVENT_TYPE { get; set; }
    }
}
