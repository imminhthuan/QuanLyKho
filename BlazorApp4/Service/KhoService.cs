using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class KhoService
    {
        private AplicationDbContext _context;

        public KhoService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kho>> GetKhoAllAsync()
        {
            return await _context.kho.ToListAsync();
        }

        public async Task<Kho> AddKhoAsync(Kho kho)
        {
            _context.Add(kho);
            await _context.SaveChangesAsync();
            return kho;
        }

        public async Task<Kho> UpdateKhoAsync(int id, Kho updateKho)
        {
            Kho kho = await _context.kho.Where(k => k.kho_Auto_ID == id).FirstOrDefaultAsync();
            if(kho != null)
            {
                kho.tenKho = updateKho.tenKho;
                kho.ghiChu = updateKho.ghiChu;
                _context.Update(kho);
                await _context.SaveChangesAsync();
            }
            return kho;
        }

        public async Task<Kho> DeleteKhoAsync(int id)
        {
            var kho = await _context.kho.FirstOrDefaultAsync(k => k.kho_Auto_ID == id);
            if(kho != null)
            {
                _context.Remove(kho);
                await _context.SaveChangesAsync();
            }
            return kho;
        }
    }
}
