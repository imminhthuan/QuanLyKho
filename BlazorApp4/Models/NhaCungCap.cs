using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class NhaCungCap
    {
        [Key]
        public int nhaCungCap_Auto_ID { get; set; }

        [Required]
        public string maNhaCungcap {  get; set; }

        [Required]
        public string tenNhaCungcap { get; set;}

        public string? ghiChu { get; set; }

        public ICollection<Nhap_Kho> nhap_Kho { get; set; }
    }
}
