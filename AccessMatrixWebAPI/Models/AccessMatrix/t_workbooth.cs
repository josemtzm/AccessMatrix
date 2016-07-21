namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workbooth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkboothID { get; set; }

        [StringLength(20)]
        public string WorkboothName { get; set; }
    }
}
