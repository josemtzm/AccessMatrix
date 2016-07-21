namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_domains
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DomainID { get; set; }

        [StringLength(20)]
        public string DomainName { get; set; }

        [StringLength(50)]
        public string DomainAddress { get; set; }
    }
}
