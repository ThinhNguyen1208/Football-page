namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string MAGD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MADB { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string TENBANGDAU { get; set; }

        public int? DIEM { get; set; }

        public virtual DOIBONG DOIBONG { get; set; }

        public virtual GIAIDAU GIAIDAU { get; set; }
    }
}
