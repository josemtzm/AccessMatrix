namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_clients
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ClientID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ClientName { get; set; }

        public bool? Disabled { get; set; }
    }
}
