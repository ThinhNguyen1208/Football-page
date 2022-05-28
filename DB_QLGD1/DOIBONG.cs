namespace DB_QLGD1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("DOIBONG")]
    public partial class DOIBONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOIBONG()
        {
            CAUTHUs = new HashSet<CAUTHU>();
            KETQUAs = new HashSet<KETQUA>();
            TRANDAUs = new HashSet<TRANDAU>();
            TRANDAUs1 = new HashSet<TRANDAU>();
            GIAIDAUs = new HashSet<GIAIDAU>();
        }

        [Key]
        [StringLength(6)]
        public string MADB { get; set; }

        [Required]
        [StringLength(6)]
        public string MAND { get; set; }

        [StringLength(20)]
        public string TENDB { get; set; }

        public int? SOLUONGTV { get; set; }

        public int? DOTUOI { get; set; }

        [StringLength(50)]
        public string KHUVUC_HD { get; set; }

        [StringLength(50)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string GIOITHIEU { get; set; }

        [StringLength(50)]
        public string ANHDAIDIEN { get; set; }

        [StringLength(50)]
        public string ANHDP1 { get; set; }

        [StringLength(50)]
        public string ANHDP2 { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload1 { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload2 { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUTHU> CAUTHUs { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANDAU> TRANDAUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANDAU> TRANDAUs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAIDAU> GIAIDAUs { get; set; }
    }
}
