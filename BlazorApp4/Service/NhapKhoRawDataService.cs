using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class NhapKhoRawDataService
    {
        private AplicationDbContext _context;
        private readonly List<Nhap_Kho_Raw_Data> tempNhapKhoRawDatas = new List<Nhap_Kho_Raw_Data>();
        private List<SanPham> sanPhams;

        public NhapKhoRawDataService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nhap_Kho_Raw_Data>> GetNhapKhoRawDataByNhapKhoIdAsync(int nhapKhoId)
        {
            return await _context.nhap_Kho_Raw_Data.Where(n => n.nhapKho.nhapkho_Auto_ID == nhapKhoId).Include(e => e.nhapKho).Include(s => s.sanPham).ToListAsync();
        }

        public async Task<List<Nhap_Kho_Raw_Data>> GetAllNhapKhoRawDataAsync()
        {
            return await _context.nhap_Kho_Raw_Data.Include(e => e.nhapKho).Include(s => s.sanPham).ToListAsync();
        }

        public async Task<List<SanPham>> GetAllSanPhamAsync()
        {
            return await _context.sanPham.ToListAsync();
        }

        public async Task<Nhap_Kho_Raw_Data> AddNhapKhoRawDataAsync(Nhap_Kho_Raw_Data nhap_Kho_Raw_Data)
        {
            _context.Add(nhap_Kho_Raw_Data);
            await _context.SaveChangesAsync();
            return nhap_Kho_Raw_Data;
        }

        public async Task<Nhap_Kho_Raw_Data> UpdateNhapKhoRawDataAsync(int id, Nhap_Kho_Raw_Data nhap_Kho_Raw_Data)
        {
            Nhap_Kho_Raw_Data _nhap_Kho_Raw = await _context.nhap_Kho_Raw_Data.Where(n => n.nhapKhoRawData_Auto_ID == id).FirstOrDefaultAsync();
            if(_nhap_Kho_Raw != null)
            {
                _nhap_Kho_Raw.nhapkho_Auto_ID = nhap_Kho_Raw_Data.nhapkho_Auto_ID;
                _nhap_Kho_Raw.sanPham_Auto_ID = nhap_Kho_Raw_Data.sanPham_Auto_ID;
                _nhap_Kho_Raw.soLuongNhap = nhap_Kho_Raw_Data.soLuongNhap;
                _nhap_Kho_Raw.donGiaNhap = nhap_Kho_Raw_Data.donGiaNhap;

                _context.Update(_nhap_Kho_Raw);
                await _context.SaveChangesAsync();
            }
            return _nhap_Kho_Raw;
        }

        public async Task<Nhap_Kho_Raw_Data> DeleteNhapKhoRawDataAsync(int id)
        {
            var nhapkho = await _context.nhap_Kho_Raw_Data.FirstOrDefaultAsync(n => n.nhapKhoRawData_Auto_ID == id);
            if (nhapkho != null)
            {
                _context.Remove(nhapkho);
                await _context.SaveChangesAsync();
            }
            return nhapkho;
        }


        public void SetSanPhams(List<SanPham> sanPhams)
        {
            this.sanPhams = sanPhams;
        }

        public List<Nhap_Kho_Raw_Data> GetTempNhapKhoRawDatas()
        {
            return tempNhapKhoRawDatas;
        }

        public void AddNhapKhoRawData(Nhap_Kho_Raw_Data newNhapKhoRawData)
        {
            if (newNhapKhoRawData != null)
            {
                newNhapKhoRawData.sanPham = sanPhams.FirstOrDefault(sp => sp.loaiSanPham_Auto_ID == newNhapKhoRawData.sanPham_Auto_ID);
                tempNhapKhoRawDatas.Add(newNhapKhoRawData);
            }
        }

        public void ClearTempNhapKhoRawDatas()
        {
            tempNhapKhoRawDatas.Clear();
        }

        public async Task<Nhap_Kho> AddNhapKhoAsync(Nhap_Kho nhapKho)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Add(nhapKho);
                    await _context.SaveChangesAsync();

                    int nhapKhoID = nhapKho.nhapkho_Auto_ID;

                    foreach (var detail in tempNhapKhoRawDatas)
                    {
                        detail.nhapkho_Auto_ID = nhapKhoID;
                        _context.nhap_Kho_Raw_Data.Add(detail);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    ClearTempNhapKhoRawDatas();

                    return nhapKho;
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
