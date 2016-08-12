namespace AccessMatrixWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AUD_PROFILES
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
        public string NAME { get; set; }

        [StringLength(1000)]
        public string DESCRIPTION { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string ACTV_FLG { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CRT_DT { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string CRT_PROC { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string CRT_USR { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(1)]
        public string EVENT_TYPE { get; set; }

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
    }
}
