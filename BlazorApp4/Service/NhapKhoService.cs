using BlazorApp4.Components.Details;
using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class NhapKhoService
    {
        private AplicationDbContext _context;

        public NhapKhoService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nhap_Kho>> GetAllNhapKhoAsync()
        {
            return await _context.nhapKho.Include(e => e.nhaCungCap).Include(k => k.kho).ToListAsync();
        }

        public async Task<List<NhaCungCap>> GetAllNhaCungCapAsync()
        {
            return await _context.nhaCungCap.ToListAsync();
        }

        public async Task<List<Kho>> GetAllkhoAsync()
        {
            return await _context.kho.ToListAsync();
        }


        public async Task<Nhap_Kho> UpdateNhapKhoAsync(int id, Nhap_Kho updatenhapkho)
        {
            Nhap_Kho NK = await _context.nhapKho.Where(s => s.nhapkho_Auto_ID == id).FirstOrDefaultAsync();
            if (NK != null)
            {
                NK.soPhieuNhapKho = updatenhapkho.soPhieuNhapKho;
                NK.ngayNhapKho = updatenhapkho.ngayNhapKho;
                NK.ghiChu = updatenhapkho.ghiChu;
                NK.kho_Auto_ID = updatenhapkho.kho_Auto_ID;
                NK.nhapkho_Auto_ID = updatenhapkho.nhapkho_Auto_ID;

                _context.Update(NK);
                await _context.SaveChangesAsync();
            }
            return NK;
        }

        public async Task<Nhap_Kho> DeleteNhaKhoAsync(int id)
        {
            var NK = await _context.nhapKho.FirstOrDefaultAsync(s => s.nhapkho_Auto_ID == id);
            if (NK != null)
            {
                _context.Remove(NK);
                await _context.SaveChangesAsync();
            }
            return NK;
        }
    }
}
