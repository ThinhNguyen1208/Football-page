namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("GIAIDAU")]
    public partial class GIAIDAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAIDAU()
        {
            KETQUAs = new HashSet<KETQUA>();
            TRANDAUs = new HashSet<TRANDAU>();
            DOIBONGs = new HashSet<DOIBONG>();
        }

        [Key]
        [StringLength(6)]
        public string MAGD { get; set; }

        [Required]
        [StringLength(6)]
        public string MASVD { get; set; }

        [Required]
        [StringLength(6)]
        public string MAND { get; set; }

        [StringLength(20)]
        public string TENGD { get; set; }

        public int? SOLUONGDOITG { get; set; }

        public int? SLTV_HT { get; set; }

        public int? TUOITOITHIEU { get; set; }

        public int? TUOITOIDA { get; set; }

        public int? SLTVTOIDA { get; set; }

        [StringLength(20)]
        public string GIAITHUONG { get; set; }

        public DateTime? TGBATDAU { get; set; }

        public int? TRANGTHAI { get; set; }

        [StringLength(50)]
        public string ANHDAIDIEN { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual SANVANDONG SANVANDONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANDAU> TRANDAUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOIBONG> DOIBONGs { get; set; }
    }
}
