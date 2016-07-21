namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_locations
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string LocationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string LocationName { get; set; }

        [StringLength(100)]
        public string LocationAddress { get; set; }

        public bool? Disabled { get; set; }
    }
}
