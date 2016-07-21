namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_clients_and_projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientProjectID { get; set; }

        [StringLength(10)]
        public string ClientID { get; set; }

        [StringLength(10)]
        public string ProjectID { get; set; }
    }
}
