using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class XuatKhoRawDataService
    {
        private AplicationDbContext _context;
        private readonly List<Xuat_Kho_Raw_Data> tempXuatKhoRawDatas = new List<Xuat_Kho_Raw_Data>();
        private List<SanPham> sanPhams;

        public XuatKhoRawDataService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Xuat_Kho_Raw_Data>> GetNhapKhoRawDataByXuatKhoIdAsync(int xuatkhoID)
        {
            return await _context.xuat_Kho_Raw_Data.Where(n => n.xuatKho.xuatKho_Auto_ID == xuatkhoID).Include(e => e.xuatKho).Include(s => s.sanPham).ToListAsync();
        }

        public async Task<List<Xuat_Kho_Raw_Data>> GetAllXuatKhoAsync()
        {
            return await _context.xuat_Kho_Raw_Data.Include(e => e.xuatKho).Include(d => d.sanPham).ToListAsync();
        }

        public async Task<List<SanPham>> GetAllSanPhamAsync()
        {
            return await _context.sanPham.ToListAsync();
        }

        public void SetSanPhams(List<SanPham> sanPhams)
        {
            this.sanPhams = sanPhams;
        }

        public List<Xuat_Kho_Raw_Data> GetTempXuatKhoRawDatas()
        {
            return tempXuatKhoRawDatas;
        }

        public void AddXuatKhoRawData(Xuat_Kho_Raw_Data newXuatKhoRawData)
        {
            if (newXuatKhoRawData != null)
            {
                newXuatKhoRawData.sanPham = sanPhams.FirstOrDefault(sp => sp.loaiSanPham_Auto_ID == newXuatKhoRawData.sanPham_ID);
                tempXuatKhoRawDatas.Add(newXuatKhoRawData);
            }
        }

        public void ClearTempNhapKhoRawDatas()
        {
            tempXuatKhoRawDatas.Clear();
        }

        public async Task<XuatKho> AddNhapKhoAsync(XuatKho xuatKho)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Add(xuatKho);
                    await _context.SaveChangesAsync();

                    int xuatKhoID = xuatKho.xuatKho_Auto_ID;

                    foreach (var detail in tempXuatKhoRawDatas)
                    {
                        detail.xuatKho_ID = xuatKhoID;
                        _context.xuat_Kho_Raw_Data.Add(detail);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    ClearTempNhapKhoRawDatas();

                    return xuatKho;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }


    }
}
