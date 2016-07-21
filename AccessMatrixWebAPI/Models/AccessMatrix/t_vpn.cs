namespace AccessMatrixWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_vpn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VpnID { get; set; }

        [StringLength(20)]
        public string VpnName { get; set; }
    }
}
