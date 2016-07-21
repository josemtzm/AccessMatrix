namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_admap_reference
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string LocationName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string ClientName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
