using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class User
    {
        [Key]
        public int user_Auto_ID { get; set; }
        [Required]
        public string maDangNhap {  get; set; }
        [Required]
        public string matKhau { get; set; }
        [Required]
        public string hoTen {  get; set; }
        public string? ghiChu { get; set; } 
        public ICollection<Kho_User> kho_user { get; set; }
    }
}
