namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THEPHAT")]
    public partial class THEPHAT
    {
        [Key]
        [StringLength(6)]
        public string MATP { get; set; }

        [Required]
        [StringLength(6)]
        public string MAGD { get; set; }

        [Required]
        [StringLength(6)]
        public string MATD { get; set; }

        [Required]
        [StringLength(6)]
        public string MATV { get; set; }

        [StringLength(1)]
        public string LOAITHE { get; set; }

        public int? PHUTNHAN { get; set; }

        public virtual CAUTHU CAUTHU { get; set; }

        public virtual TRANDAU TRANDAU { get; set; }
    }
}
