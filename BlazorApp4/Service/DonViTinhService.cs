using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorApp4.Service
{
    public class DonViTinhService
    {
        private AplicationDbContext _dbContext;
        public DonViTinhService(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DonViTinh>> GetAllDonViTinhAsync()
        {
            return await _dbContext.donViTinh.ToListAsync();
        }

        public  DonViTinh GetDonViTinhAsync(int id)
        {
            return _dbContext.donViTinh.FirstOrDefault(d => d.donViTinh_Auto_ID == id);
        }  

        public async Task<DonViTinh> AddDonVitinhAsync(DonViTinh donViTinh)
        {
            _dbContext.Add(donViTinh);
            await _dbContext.SaveChangesAsync();
            return donViTinh;
        }
        
        public async Task<DonViTinh> UpdateDonViTinhAsync(int id, DonViTinh updateDonViTinh)
        {
            DonViTinh DVT = await _dbContext.donViTinh.Where(d => d.donViTinh_Auto_ID == id).FirstOrDefaultAsync();
            if(DVT != null)
            {
                DVT.tenDonViTinh = updateDonViTinh.tenDonViTinh;
                DVT.ghiChu = updateDonViTinh.ghiChu;
                _dbContext.donViTinh.Update(DVT);
                await _dbContext.SaveChangesAsync();
            }
            return DVT;

        }

        public async Task<DonViTinh> DeleteDonVitinhAsync(int id)
        {
            var _donViTinh = await _dbContext.donViTinh.FirstOrDefaultAsync(d => d.donViTinh_Auto_ID == id);
            if (_donViTinh != null)
            {
                _dbContext.donViTinh.Remove(_donViTinh);
                await _dbContext.SaveChangesAsync();
            }
            return _donViTinh;
        }
    }
}
