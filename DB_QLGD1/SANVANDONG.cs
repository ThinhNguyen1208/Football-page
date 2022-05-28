namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANVANDONG")]
    public partial class SANVANDONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANVANDONG()
        {
            GIAIDAUs = new HashSet<GIAIDAU>();
        }

        [Key]
        [StringLength(6)]
        public string MASVD { get; set; }

        [StringLength(20)]
        public string TENSVD { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAIDAU> GIAIDAUs { get; set; }
    }
}
