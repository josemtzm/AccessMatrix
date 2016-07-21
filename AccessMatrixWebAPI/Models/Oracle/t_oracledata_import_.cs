namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_oracledata(import)")]
    public partial class t_oracledata_import_
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfileID { get; set; }

        [StringLength(2)]
        public string Region { get; set; }

        public int? SiteID { get; set; }

        [StringLength(100)]
        public string SiteLocation { get; set; }

        [StringLength(100)]
        public string SiteName { get; set; }

        [StringLength(20)]
        public string ClientID { get; set; }

        [StringLength(100)]
        public string ClientName { get; set; }

        [StringLength(20)]
        public string ProgramID { get; set; }

        [StringLength(100)]
        public string ProgramName { get; set; }

        [StringLength(20)]
        public string ProjectID { get; set; }

        [StringLength(100)]
        public string ProjectName { get; set; }

        [StringLength(20)]
        public string DepartmentID { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(20)]
        public string RoleID { get; set; }

        [StringLength(100)]
        public string RoleName { get; set; }

        [StringLength(15)]
        public string JobFamily { get; set; }

        [StringLength(15)]
        public string Company { get; set; }
    }
}
