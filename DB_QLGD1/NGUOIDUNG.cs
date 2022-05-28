namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            DOIBONGs = new HashSet<DOIBONG>();
            GIAIDAUs = new HashSet<GIAIDAU>();
        }

        [Key]
        [StringLength(6)]
        public string MAND { get; set; }

        [StringLength(20)]
        public string USERNAME { get; set; }

        [StringLength(10)]
        public string PASSWORD { get; set; }

        [StringLength(20)]
        public string TENND { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        public DateTime? NGAYSINH { get; set; }

        [StringLength(50)]
        public string ANHDAIDIEN { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOIBONG> DOIBONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAIDAU> GIAIDAUs { get; set; }
    }
}
