using BlazorApp4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Service
{
    public class SanPhamService
    {
        private AplicationDbContext _context;

        public SanPhamService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetAllSanPhamAsync()
        {
            return await _context.sanPham.Include(e => e.loaiSanPham).Include(d => d.donViTinh).ToListAsync();
        }

        public async Task<List<LoaiSanPham>> GetAllLoaiSanPhamAsync()
        {
            return await _context.loaiSanPham.ToListAsync();
        }
        public async Task<List<DonViTinh>> GetAllDonViTinhAsync()
        {
            return await _context.donViTinh.ToListAsync();
        }

        public async Task<SanPham> AddSanPhamAsync(SanPham sanPham)
        {
            try
            {
                _context.sanPham.Add(sanPham);
                await _context.SaveChangesAsync();
                return sanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding SanPham: {ex.Message}");
                throw;
            }
        }

        public async Task<SanPham> UpdateSanPhamAsync(int id, SanPham updateSanPham)
        {
            SanPham SP = await _context.sanPham.Where(s => s.sanPham_Auto_ID == id).FirstOrDefaultAsync();
            if (SP != null)
            {
                SP.maSanPham = updateSanPham.maSanPham;
                SP.tenSanpham = updateSanPham.tenSanpham;
                SP.loaiSanPham_Auto_ID = updateSanPham.loaiSanPham_Auto_ID;
                SP.donViTinh_Auto_ID = updateSanPham.donViTinh_Auto_ID;
                SP.ghiChu = updateSanPham.ghiChu;

                _context.Update(SP);
                await _context.SaveChangesAsync();
            }
            return SP;
        }

        public async Task<SanPham> DeleteSanPhamAsync(int id)
        {
            var sanpham = await _context.sanPham.FirstOrDefaultAsync(s => s.sanPham_Auto_ID == id);
            if(sanpham != null)
            {
                _context.Remove(sanpham);
                await _context.SaveChangesAsync();
            }
            return sanpham;
        }
    }
}
