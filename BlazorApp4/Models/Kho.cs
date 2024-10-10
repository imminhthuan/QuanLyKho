using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class Kho
    {
        [Key]
        public int kho_Auto_ID { get; set; }

        [Required]
        public string tenKho { get; set; }
        public string? ghiChu { get; set; }
        public ICollection<Nhap_Kho> nhapKho { get; set; }       
        public ICollection<Kho_User> kho_user {  get; set; }
        public ICollection<XuatKho> xuatKho { get; set; }
    }
}
