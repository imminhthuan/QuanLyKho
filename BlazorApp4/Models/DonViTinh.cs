using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp4.Models
{
    public class DonViTinh
    {
        [Key]
        public int donViTinh_Auto_ID { get;set; }

        [Required]
        public string tenDonViTinh { get; set; }
        public string? ghiChu { get; set; }
        public ICollection<SanPham> sanPham { get; set; }
    }
}
