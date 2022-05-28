namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VONGDAU")]
    public partial class VONGDAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VONGDAU()
        {
            TRANDAUs = new HashSet<TRANDAU>();
        }

        [Key]
        [StringLength(6)]
        public string MAVD { get; set; }

        [Column("VONGDAU")]
        [StringLength(2)]
        public string VONGDAU1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANDAU> TRANDAUs { get; set; }
    }
}
