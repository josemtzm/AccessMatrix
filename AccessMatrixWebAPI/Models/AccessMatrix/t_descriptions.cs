namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_descriptions
    {
        [Key]
        [StringLength(200)]
        public string DescriptionID { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
