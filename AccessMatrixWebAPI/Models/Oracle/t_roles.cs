namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_roles
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string RoleName { get; set; }

        [StringLength(15)]
        public string JobFamily { get; set; }

        public bool? Disabled { get; set; }
    }
}
