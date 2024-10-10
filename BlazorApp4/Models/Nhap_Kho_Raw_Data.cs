using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class Nhap_Kho_Raw_Data
    {
        [Key]
        public int nhapKhoRawData_Auto_ID { get; set; }

        public int nhapkho_Auto_ID { get; set; }

        public int sanPham_Auto_ID { get; set; }

        public int soLuongNhap {  get; set; }
        public decimal donGiaNhap { get; set; }

        public SanPham sanPham { get; set; }
        public Nhap_Kho nhapKho { get; set; }
    }
}
