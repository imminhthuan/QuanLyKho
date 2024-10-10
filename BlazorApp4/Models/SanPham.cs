using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class SanPham
    {
        [Key]
        public int sanPham_Auto_ID { get; set; }

        [Required]
        public string maSanPham {  get; set; }

        public string tenSanpham { get; set; }
        public string? ghiChu { get; set; }
        public int loaiSanPham_Auto_ID { get; set; }
        public int donViTinh_Auto_ID { get; set; }
        public DonViTinh donViTinh { get; set; }
        public LoaiSanPham loaiSanPham { get; set; }
        public ICollection<Nhap_Kho_Raw_Data> nha_kho_raw_data { get; set; }
        public ICollection<Xuat_Kho_Raw_Data> xuat_Kho_Raw_Data { get; set; }
    }
}
