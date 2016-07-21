namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_access_matrix
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileID { get; set; }

        [StringLength(10)]
        public string ClientID { get; set; }

        [StringLength(100)]
        public string ClientName { get; set; }

        public int? LocationID { get; set; }

        [StringLength(100)]
        public string LocationName { get; set; }

        [StringLength(10)]
        public string ProjectID { get; set; }

        [StringLength(255)]
        public string ProjectName { get; set; }

        [StringLength(10)]
        public string DepartmentID { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string RoleID { get; set; }

        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
