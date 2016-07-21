namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_programs
    {
        [Key]
        [StringLength(15)]
        public string ProgramID { get; set; }

        [StringLength(100)]
        public string ProgramName { get; set; }

        public bool? Disabled { get; set; }
    }
}
