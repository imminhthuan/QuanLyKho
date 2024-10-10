using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Models
{
    public class Xuat_Kho_Raw_Data
    {
        [Key]
        public int xuatKhoRawData_Auto_ID { get; set; }
        public int xuatKho_ID { get; set; }
        public int sanPham_ID { get; set; }
        public int soLuongXuat {  get; set; }
        public decimal donGiaXuat { get; set; }
        public XuatKho xuatKho { get; set; }
        public SanPham sanPham { get; set; }
    }
}
