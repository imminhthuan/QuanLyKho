using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp4.Migrations
{
    /// <inheritdoc />
    public partial class QuanLyKho1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donViTinh",
                columns: table => new
                {
                    donViTinh_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDonViTinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donViTinh", x => x.donViTinh_Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "kho",
                columns: table => new
                {
                    kho_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kho", x => x.kho_Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "loaiSanPham",
                columns: table => new
                {
                    loaiSanPham_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maLoaiSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tenLoaiSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiSanPham", x => x.loaiSanPham_Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCap",
                columns: table => new
                {
                    nhaCungCap_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNhaCungcap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tenNhaCungcap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCap", x => x.nhaCungCap_Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maDangNhap = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    matKhau = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_Auto_ID);
                    table.UniqueConstraint("AK_user_maDangNhap", x => x.maDangNhap);
                });

            migrationBuilder.CreateTable(
                name: "xuatKho",
                columns: table => new
                {
                    xuatKho_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    soPhieuXuatKho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ngayXuatKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Kho_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuatKho", x => x.xuatKho_Auto_ID);
                    table.ForeignKey(
                        name: "FK_XuatKho_Kho",
                        column: x => x.Kho_ID,
                        principalTable: "kho",
                        principalColumn: "kho_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanPham",
                columns: table => new
                {
                    sanPham_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tenSanpham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    loaiSanPham_Auto_ID = table.Column<int>(type: "int", nullable: false),
                    donViTinh_Auto_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPham", x => x.sanPham_Auto_ID);
                    table.ForeignKey(
                        name: "FK_SanPham_DonViTinh",
                        column: x => x.donViTinh_Auto_ID,
                        principalTable: "donViTinh",
                        principalColumn: "donViTinh_Auto_ID");
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham",
                        column: x => x.loaiSanPham_Auto_ID,
                        principalTable: "loaiSanPham",
                        principalColumn: "loaiSanPham_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhapKho",
                columns: table => new
                {
                    nhapkho_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    soPhieuNhapKho = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "0"),
                    ngayNhapKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    kho_Auto_ID = table.Column<int>(type: "int", nullable: false),
                    nhaCungCap_Auto_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhapKho", x => x.nhapkho_Auto_ID);
                    table.ForeignKey(
                        name: "FK_Nhap_Kho_Kho",
                        column: x => x.kho_Auto_ID,
                        principalTable: "kho",
                        principalColumn: "kho_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhap_Kho_NhaCungCap",
                        column: x => x.nhaCungCap_Auto_ID,
                        principalTable: "nhaCungCap",
                        principalColumn: "nhaCungCap_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kho_user",
                columns: table => new
                {
                    khoUser_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maDangNhap = table.Column<string>(type: "varchar(100)", nullable: false),
                    kho_Auto_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kho_user", x => x.khoUser_ID);
                    table.ForeignKey(
                        name: "FK_Kho_User_Kho",
                        column: x => x.kho_Auto_ID,
                        principalTable: "kho",
                        principalColumn: "kho_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kho_User_User",
                        column: x => x.maDangNhap,
                        principalTable: "user",
                        principalColumn: "maDangNhap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "xuat_Kho_Raw_Data",
                columns: table => new
                {
                    xuatKhoRawData_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xuatKho_ID = table.Column<int>(type: "int", nullable: false),
                    sanPham_ID = table.Column<int>(type: "int", nullable: false),
                    soLuongXuat = table.Column<int>(type: "int", nullable: false),
                    donGiaXuat = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuat_Kho_Raw_Data", x => x.xuatKhoRawData_Auto_ID);
                    table.ForeignKey(
                        name: "FK_Xuat_Kho_Raw_Data_SanPham",
                        column: x => x.sanPham_ID,
                        principalTable: "sanPham",
                        principalColumn: "sanPham_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xuat_Kho_Raw_Data_XuatKho",
                        column: x => x.xuatKho_ID,
                        principalTable: "xuatKho",
                        principalColumn: "xuatKho_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhap_Kho_Raw_Data",
                columns: table => new
                {
                    nhapKhoRawData_Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhapkho_Auto_ID = table.Column<int>(type: "int", nullable: false),
                    sanPham_Auto_ID = table.Column<int>(type: "int", nullable: false),
                    soLuongNhap = table.Column<int>(type: "int", nullable: false),
                    donGiaNhap = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhap_Kho_Raw_Data", x => x.nhapKhoRawData_Auto_ID);
                    table.ForeignKey(
                        name: "FK_Nhap_Kho_Raw_Data_Nhap_Kho",
                        column: x => x.nhapkho_Auto_ID,
                        principalTable: "nhapKho",
                        principalColumn: "nhapkho_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhap_Kho_Raw_Data_SanPham",
                        column: x => x.sanPham_Auto_ID,
                        principalTable: "sanPham",
                        principalColumn: "sanPham_Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donViTinh_tenDonViTinh",
                table: "donViTinh",
                column: "tenDonViTinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_kho_tenKho",
                table: "kho",
                column: "tenKho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_kho_user_kho_Auto_ID",
                table: "kho_user",
                column: "kho_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_kho_user_maDangNhap",
                table: "kho_user",
                column: "maDangNhap");

            migrationBuilder.CreateIndex(
                name: "IX_loaiSanPham_maLoaiSanPham",
                table: "loaiSanPham",
                column: "maLoaiSanPham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_loaiSanPham_tenLoaiSanPham",
                table: "loaiSanPham",
                column: "tenLoaiSanPham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nhaCungCap_maNhaCungcap",
                table: "nhaCungCap",
                column: "maNhaCungcap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nhap_Kho_Raw_Data_nhapkho_Auto_ID",
                table: "nhap_Kho_Raw_Data",
                column: "nhapkho_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_Kho_Raw_Data_sanPham_Auto_ID",
                table: "nhap_Kho_Raw_Data",
                column: "sanPham_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_nhapKho_kho_Auto_ID",
                table: "nhapKho",
                column: "kho_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_nhapKho_nhaCungCap_Auto_ID",
                table: "nhapKho",
                column: "nhaCungCap_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_nhapKho_soPhieuNhapKho",
                table: "nhapKho",
                column: "soPhieuNhapKho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanPham_donViTinh_Auto_ID",
                table: "sanPham",
                column: "donViTinh_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_sanPham_loaiSanPham_Auto_ID",
                table: "sanPham",
                column: "loaiSanPham_Auto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_sanPham_maSanPham",
                table: "sanPham",
                column: "maSanPham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_maDangNhap",
                table: "user",
                column: "maDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_xuat_Kho_Raw_Data_sanPham_ID",
                table: "xuat_Kho_Raw_Data",
                column: "sanPham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_xuat_Kho_Raw_Data_xuatKho_ID",
                table: "xuat_Kho_Raw_Data",
                column: "xuatKho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_xuatKho_Kho_ID",
                table: "xuatKho",
                column: "Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_xuatKho_soPhieuXuatKho",
                table: "xuatKho",
                column: "soPhieuXuatKho",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kho_user");

            migrationBuilder.DropTable(
                name: "nhap_Kho_Raw_Data");

            migrationBuilder.DropTable(
                name: "xuat_Kho_Raw_Data");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "nhapKho");

            migrationBuilder.DropTable(
                name: "sanPham");

            migrationBuilder.DropTable(
                name: "xuatKho");

            migrationBuilder.DropTable(
                name: "nhaCungCap");

            migrationBuilder.DropTable(
                name: "donViTinh");

            migrationBuilder.DropTable(
                name: "loaiSanPham");

            migrationBuilder.DropTable(
                name: "kho");
        }
    }
}
