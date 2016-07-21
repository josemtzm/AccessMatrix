namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChatID { get; set; }

        [StringLength(50)]
        public string ChatName { get; set; }
    }
}
