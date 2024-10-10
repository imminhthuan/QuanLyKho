using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class LoaiSanPhamService
    {
        private AplicationDbContext _context;

        public LoaiSanPhamService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoaiSanPham>> GetAllLoaiSanPhamAsync()
        {
            return await _context.loaiSanPham.ToListAsync();
        }

        public async Task<LoaiSanPham> AddLoaiSanPhamAsync(LoaiSanPham loaiSanPham)
        {
            _context.Add(loaiSanPham);
            await _context.SaveChangesAsync();
            return loaiSanPham;
        }

        public async Task<LoaiSanPham> UpdateLoaiSanPhamAsnc(int id, LoaiSanPham UpdateloaiSanPham)
        {
            LoaiSanPham LSP = await _context.loaiSanPham.Where(l => l.loaiSanPham_Auto_ID == id).FirstOrDefaultAsync();
            if(LSP != null)
            {
                LSP.maLoaiSanPham = UpdateloaiSanPham.maLoaiSanPham;
                LSP.tenLoaiSanPham = UpdateloaiSanPham.tenLoaiSanPham;
                LSP.ghiChu = UpdateloaiSanPham.ghiChu;
                _context.loaiSanPham.Update(LSP);
                await _context.SaveChangesAsync();
            }
            return LSP;
        }

        public async Task<LoaiSanPham> DeleteLoaiSanPhamAsync(int id)
        {
            var lSanPham = await _context.loaiSanPham.FirstOrDefaultAsync(l => l.loaiSanPham_Auto_ID == id);
            if(lSanPham != null)
            {
                _context.loaiSanPham.Remove(lSanPham);
                await _context.SaveChangesAsync();
            }
            return lSanPham;
        }
    }
}
