namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRANDAU")]
    public partial class TRANDAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANDAU()
        {
            BANTHANGs = new HashSet<BANTHANG>();
            THEPHATs = new HashSet<THEPHAT>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string MAGD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MATD { get; set; }

        [Required]
        [StringLength(6)]
        public string MADB { get; set; }

        [Required]
        [StringLength(6)]
        public string DOI_MADB { get; set; }

        [Required]
        [StringLength(6)]
        public string MAVD { get; set; }

        public int? SOBAND1 { get; set; }

        public int? SOBAND2 { get; set; }

        public int? SOTHEPHAT { get; set; }

        public DateTime? THOIGIAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANTHANG> BANTHANGs { get; set; }

        public virtual DOIBONG DOIBONG { get; set; }

        public virtual DOIBONG DOIBONG1 { get; set; }

        public virtual GIAIDAU GIAIDAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEPHAT> THEPHATs { get; set; }

        public virtual VONGDAU VONGDAU { get; set; }
    }
}
