namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANTHANG")]
    public partial class BANTHANG
    {
        [Key]
        [StringLength(6)]
        public string MABT { get; set; }

        [Required]
        [StringLength(6)]
        public string MATV { get; set; }

        [Required]
        [StringLength(6)]
        public string MAGD { get; set; }

        [Required]
        [StringLength(6)]
        public string MATD { get; set; }

        public int? PHUTGHI { get; set; }

        public virtual CAUTHU CAUTHU { get; set; }

        public virtual TRANDAU TRANDAU { get; set; }
    }
}
