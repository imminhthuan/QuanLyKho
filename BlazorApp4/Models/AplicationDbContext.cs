using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<DonViTinh> donViTinh { get; set; }
        public DbSet<LoaiSanPham> loaiSanPham { get; set; }
        public DbSet<SanPham> sanPham { get; set; }
        public DbSet<NhaCungCap> nhaCungCap { get; set; }
        public DbSet<Kho> kho { get; set; }
        public DbSet<Kho_User> kho_user { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Nhap_Kho> nhapKho { get; set; }
        public DbSet<Nhap_Kho_Raw_Data> nhap_Kho_Raw_Data { get; set; }
        public DbSet<XuatKho> xuatKho { get; set; }
        public DbSet<Xuat_Kho_Raw_Data> xuat_Kho_Raw_Data { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViTinh>(entity =>
            {
                entity.HasKey(d => d.donViTinh_Auto_ID);
                entity.Property(e => e.tenDonViTinh)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.HasIndex(e => e.tenDonViTinh)
                      .IsUnique();

                entity.Property(e => e.ghiChu)
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(d => d.loaiSanPham_Auto_ID);
                entity.Property(e => e.maLoaiSanPham)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(e => e.maLoaiSanPham)
                      .IsUnique();
                entity.Property(e => e.tenLoaiSanPham)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(true);
                entity.HasIndex(e => e.tenLoaiSanPham)
                      .IsUnique();
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(d => d.sanPham_Auto_ID);
                entity.Property(e => e.maSanPham)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(e => e.maSanPham)
                      .IsUnique();
                entity.Property(e => e.tenSanpham)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(true);
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(255);
                entity.HasOne(d => d.donViTinh)
                      .WithMany(s => s.sanPham)
                      .HasForeignKey(d => d.donViTinh_Auto_ID)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_SanPham_DonViTinh");
                entity.HasOne(l => l.loaiSanPham)
                      .WithMany(s => s.sanPham)
                      .HasForeignKey(l => l.loaiSanPham_Auto_ID)
                      .HasConstraintName("FK_SanPham_LoaiSanPham");
            });
            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(d => d.nhaCungCap_Auto_ID);
                entity.Property(e => e.maNhaCungcap)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(e => e.maNhaCungcap)
                      .IsUnique();
                entity.Property(e => e.tenNhaCungcap)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(true);
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(d => d.kho_Auto_ID);
                entity.Property(e => e.tenKho)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(true);
                entity.HasIndex(e => e.tenKho)
                      .IsUnique();
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(100);
            });
            modelBuilder.Entity<Kho_User>(entity =>
            {
                entity.HasKey(d => d.khoUser_ID);
                entity.HasOne(k => k.kho)
                      .WithMany(u => u.kho_user)
                      .IsRequired()
                      .HasForeignKey(k => k.kho_Auto_ID)
                      .HasConstraintName("FK_Kho_User_Kho");
                entity.HasOne(d => d.user)
                      .WithMany(p => p.kho_user)
                      .HasForeignKey(d => d.maDangNhap)
                      .HasPrincipalKey(p => p.maDangNhap) // Tham chiếu đến MaDangNhap
                      .HasConstraintName("FK_Kho_User_User");
            });
            modelBuilder.Entity<Nhap_Kho>(entity =>
            {
                entity.HasKey(d => d.nhapkho_Auto_ID);
                entity.Property(e => e.soPhieuNhapKho)
                      .IsRequired()
                      .HasDefaultValue(0);
                entity.HasIndex(e => e.soPhieuNhapKho)
                      .IsUnique();
                entity.Property(e => e.ngayNhapKho)
                      .IsRequired();
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(100);
                entity.HasOne(k => k.kho)
                    .WithMany(nk => nk.nhapKho)
                    .HasForeignKey(n => n.kho_Auto_ID)
                    .HasConstraintName("FK_Nhap_Kho_Kho");
                entity.HasOne(s => s.nhaCungCap)
                      .WithMany(nk => nk.nhap_Kho)
                      .HasForeignKey(s => s.nhaCungCap_Auto_ID)
                      .HasConstraintName("FK_Nhap_Kho_NhaCungCap");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.user_Auto_ID);
                entity.Property(e => e.maDangNhap)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(false);
                entity.HasIndex(e => e.maDangNhap)
                     .IsUnique();
                entity.Property(e => e.matKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.hoTen)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.ghiChu)
                      .HasMaxLength(100);
            });
            modelBuilder.Entity<Nhap_Kho_Raw_Data>(entity =>
            {
                entity.HasKey(d => d.nhapKhoRawData_Auto_ID);
                entity.Property(e => e.soLuongNhap)
                      .IsRequired();
                entity.Property(e => e.donGiaNhap)
                      .IsRequired()
                      .HasPrecision(18, 2);
                entity.HasOne(n => n.nhapKho)
                      .WithMany(nk => nk.nhap_Kho_Raw_Data)
                      .HasForeignKey(n => n.nhapkho_Auto_ID)
                      .HasConstraintName("FK_Nhap_Kho_Raw_Data_Nhap_Kho");
                entity.HasOne(s => s.sanPham)
                      .WithMany(nk => nk.nha_kho_raw_data)
                      .HasForeignKey(s => s.sanPham_Auto_ID)
                      .HasConstraintName("FK_Nhap_Kho_Raw_Data_SanPham");
            });
            modelBuilder.Entity<XuatKho>(entity =>
            {
                entity.HasKey(x => x.xuatKho_Auto_ID);
                entity.Property(x => x.soPhieuXuatKho)
                      .IsRequired();
                entity.HasIndex(e => e.soPhieuXuatKho)
                      .IsUnique();
                entity.Property(x => x.ngayXuatKho)
                      .IsRequired();
                entity.Property(x => x.ghiChu)
                      .HasMaxLength(100);
                entity.HasOne(k => k.kho)
                      .WithMany(x => x.xuatKho)
                      .HasForeignKey(k => k.Kho_ID)
                      .HasConstraintName("FK_XuatKho_Kho");
            });
            modelBuilder.Entity<Xuat_Kho_Raw_Data>(entity =>
            {
                entity.HasKey(x => x.xuatKhoRawData_Auto_ID);
                entity.Property(e => e.soLuongXuat)
                   .IsRequired();
                entity.Property(e => e.donGiaXuat)
                      .IsRequired()
                      .HasPrecision(18, 2);
                entity.HasOne(n => n.xuatKho)
                    .WithMany(nk => nk.xuat_Kho_Raw_Data)
                    .HasForeignKey(n => n.xuatKho_ID)
                    .HasConstraintName("FK_Xuat_Kho_Raw_Data_XuatKho");
                entity.HasOne(s => s.sanPham)
                      .WithMany(nk => nk.xuat_Kho_Raw_Data)
                      .HasForeignKey(s => s.sanPham_ID)
                      .HasConstraintName("FK_Xuat_Kho_Raw_Data_SanPham");
            });
        }

    }
}
