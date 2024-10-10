using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class XuatKhoService
    {
        private AplicationDbContext _context;

        public XuatKhoService(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<XuatKho>> GetAllXuatKhoAsync()
        {
            return await _context.xuatKho.Include(k => k.kho).ToListAsync();
        }

        public async Task<List<Kho>> GetAllkhoAsync()
        {
            return await _context.kho.ToListAsync();
        }
    }
}
