using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class NhaCungCapService
    {
        private AplicationDbContext _context;

        public NhaCungCapService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NhaCungCap>> GetAllNhaCungCap()
        {
            return await _context.nhaCungCap.ToListAsync();
        }

        public async Task<NhaCungCap> AddNhaCungCapAsync(NhaCungCap AddNhaCungCap)
        {
            _context.Add(AddNhaCungCap);
            await _context.SaveChangesAsync();
            return AddNhaCungCap;
        }

        public async Task<NhaCungCap> UpdateNhaCungCapAsync(int id, NhaCungCap UpdateNhaCungCap)
        {
            NhaCungCap NCC = await _context.nhaCungCap.Where(n => n.nhaCungCap_Auto_ID == id).FirstOrDefaultAsync();
            if(NCC != null)
            {
                NCC.maNhaCungcap = UpdateNhaCungCap.maNhaCungcap;
                NCC.tenNhaCungcap = UpdateNhaCungCap.tenNhaCungcap;
                NCC.ghiChu = UpdateNhaCungCap.ghiChu;
                _context.Update(NCC);
                await _context.SaveChangesAsync();
            }
            return NCC;
        }

        public async Task<NhaCungCap> DeleteNhaCungCapAsync(int id)
        {
            var NCC = await _context.nhaCungCap.FirstOrDefaultAsync(n => n.nhaCungCap_Auto_ID == id);
            if(NCC != null)
            {
                _context.Remove(NCC);
                await _context.SaveChangesAsync();
            }
            return NCC;
        }
    }
}
