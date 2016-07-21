namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_projects
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ProjectID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ProjectName { get; set; }

        public bool? Disabled { get; set; }
    }
}
