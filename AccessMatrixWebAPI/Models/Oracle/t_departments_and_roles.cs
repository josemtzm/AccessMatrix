namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_departments_and_roles
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentRoleID { get; set; }

        [StringLength(10)]
        public string DepartmentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string RoleID { get; set; }
    }
}
