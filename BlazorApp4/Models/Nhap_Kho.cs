using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Models
{
    public class Nhap_Kho
    {
        [Key]
        public int nhapkho_Auto_ID { get; set; }
        [Required]
        public string soPhieuNhapKho {  get; set; }
        [Required]
        public DateTime ngayNhapKho { get; set;}
        public string? ghiChu {  get; set; }
        [Required]
        public int kho_Auto_ID { get; set; }
        [Required]
        public int nhaCungCap_Auto_ID { get; set; }
        [Required]
        public Kho kho {  get; set; }
        [Required]
        public NhaCungCap nhaCungCap { get; set; }

        public ICollection<Nhap_Kho_Raw_Data> nhap_Kho_Raw_Data { get; set; }
    }
}
