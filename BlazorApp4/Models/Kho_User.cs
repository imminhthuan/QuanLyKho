using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class Kho_User
    {
        [Key]
        public int khoUser_ID { get; set; }
        [Required]
        public string maDangNhap { get; set; }
        [Required]
        public int kho_Auto_ID { get; set; }
        public Kho kho {  get; set; }

        [ForeignKey("maDangNhap")]
        public User user { get; set; }
    }
}
