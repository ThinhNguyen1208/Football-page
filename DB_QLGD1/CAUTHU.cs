namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("CAUTHU")]
    public partial class CAUTHU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAUTHU()
        {
            BANTHANGs = new HashSet<BANTHANG>();
            THEPHATs = new HashSet<THEPHAT>();
        }

        [Key]
        [StringLength(6)]
        public string MATV { get; set; }

        [Required]
        [StringLength(6)]
        public string MADB { get; set; }

        [StringLength(20)]
        public string TENTV { get; set; }

        public DateTime? NGAYSINH { get; set; }

        [StringLength(3)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string ANHTHE { get; set; }

        [StringLength(20)]
        public string VITRI { get; set; }

        public int? SOAO { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANTHANG> BANTHANGs { get; set; }

        public virtual DOIBONG DOIBONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEPHAT> THEPHATs { get; set; }
    }
}
