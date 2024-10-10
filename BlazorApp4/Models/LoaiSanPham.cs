using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int loaiSanPham_Auto_ID { get; set; }
        [Required]
        public string maLoaiSanPham { get; set; }
        [Required]
        public string tenLoaiSanPham { get;set; }
        public string? ghiChu {  get; set; }

        public ICollection<SanPham> sanPham { get; set; }
    }
}
