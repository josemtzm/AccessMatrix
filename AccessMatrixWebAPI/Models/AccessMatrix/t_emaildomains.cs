namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_emaildomains
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmailID { get; set; }

        [StringLength(20)]
        public string EmailName { get; set; }

        [StringLength(50)]
        public string EmailDomain { get; set; }
    }
}
