using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Models
{
    public class XuatKho
    {
        [Key]
        public int xuatKho_Auto_ID { get; set; }

        [Required]
        public string soPhieuXuatKho { get; set; }
        [Required]
        public DateTime ngayXuatKho { get; set; }
        public string? ghiChu { get; set; }
        public int Kho_ID { get; set; }
        [Required]
        public Kho kho {  get; set; }
        public ICollection<Xuat_Kho_Raw_Data> xuat_Kho_Raw_Data { get; set; }
    }
}
