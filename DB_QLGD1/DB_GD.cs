using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DB_QLGD1
{
    public partial class DB_GD : DbContext
    {
        public DB_GD()
            : base("name=DB_GD")
        {
        }

        public virtual DbSet<BANTHANG> BANTHANGs { get; set; }
        public virtual DbSet<CAUTHU> CAUTHUs { get; set; }
        public virtual DbSet<DOIBONG> DOIBONGs { get; set; }
        public virtual DbSet<GIAIDAU> GIAIDAUs { get; set; }
        public virtual DbSet<KETQUA> KETQUAs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<SANVANDONG> SANVANDONGs { get; set; }
        public virtual DbSet<THEPHAT> THEPHATs { get; set; }
        public virtual DbSet<TRANDAU> TRANDAUs { get; set; }
        public virtual DbSet<VONGDAU> VONGDAUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANTHANG>()
                .Property(e => e.MABT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BANTHANG>()
                .Property(e => e.MATV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BANTHANG>()
                .Property(e => e.MAGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BANTHANG>()
                .Property(e => e.MATD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.MATV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.MADB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.TENTV)
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.GIOITINH)
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.ANHTHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .Property(e => e.VITRI)
                .IsUnicode(false);

            modelBuilder.Entity<CAUTHU>()
                .HasMany(e => e.BANTHANGs)
                .WithRequired(e => e.CAUTHU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUTHU>()
                .HasMany(e => e.THEPHATs)
                .WithRequired(e => e.CAUTHU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.MADB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.MAND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.TENDB)
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.KHUVUC_HD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.GIOITINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.GIOITHIEU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.ANHDAIDIEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.ANHDP1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .Property(e => e.ANHDP2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOIBONG>()
                .HasMany(e => e.CAUTHUs)
                .WithRequired(e => e.DOIBONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOIBONG>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.DOIBONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOIBONG>()
                .HasMany(e => e.TRANDAUs)
                .WithRequired(e => e.DOIBONG)
                .HasForeignKey(e => e.DOI_MADB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOIBONG>()
                .HasMany(e => e.TRANDAUs1)
                .WithRequired(e => e.DOIBONG1)
                .HasForeignKey(e => e.MADB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOIBONG>()
                .HasMany(e => e.GIAIDAUs)
                .WithMany(e => e.DOIBONGs)
                .Map(m => m.ToTable("THAMGIAGIAIDAU").MapLeftKey("MADB").MapRightKey("MAGD"));

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.MAGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.MASVD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.MAND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.TENGD)
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.GIAITHUONG)
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .Property(e => e.ANHDAIDIEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAIDAU>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.GIAIDAU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAIDAU>()
                .HasMany(e => e.TRANDAUs)
                .WithRequired(e => e.GIAIDAU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.MAGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.MADB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.TENBANGDAU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MAND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.USERNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.PASSWORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TENND)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.ANHDAIDIEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.DOIBONGs)
                .WithRequired(e => e.NGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.GIAIDAUs)
                .WithRequired(e => e.NGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANVANDONG>()
                .Property(e => e.MASVD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SANVANDONG>()
                .Property(e => e.TENSVD)
                .IsUnicode(false);

            modelBuilder.Entity<SANVANDONG>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<SANVANDONG>()
                .HasMany(e => e.GIAIDAUs)
                .WithRequired(e => e.SANVANDONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MATP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MAGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MATD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MATV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.LOAITHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .Property(e => e.MAGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .Property(e => e.MATD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .Property(e => e.MADB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .Property(e => e.DOI_MADB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .Property(e => e.MAVD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANDAU>()
                .HasMany(e => e.BANTHANGs)
                .WithRequired(e => e.TRANDAU)
                .HasForeignKey(e => new { e.MAGD, e.MATD })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANDAU>()
                .HasMany(e => e.THEPHATs)
                .WithRequired(e => e.TRANDAU)
                .HasForeignKey(e => new { e.MAGD, e.MATD })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VONGDAU>()
                .Property(e => e.MAVD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VONGDAU>()
                .Property(e => e.VONGDAU1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VONGDAU>()
                .HasMany(e => e.TRANDAUs)
                .WithRequired(e => e.VONGDAU)
                .WillCascadeOnDelete(false);
        }
    }
}
