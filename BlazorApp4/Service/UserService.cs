using BlazorApp4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Frozen;

namespace BlazorApp4.Service
{
    public class UserService
    {
        private AplicationDbContext _context;

        public UserService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUserAync()
        {
            return await _context.user.ToListAsync();
        }


        public async Task<User> AddAllUserAync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAllUserAync(int id, User user)
        {
            var users = await _context.user.Where(u => u.user_Auto_ID == id).FirstOrDefaultAsync();
            if(users != null)
            {
                users.user_Auto_ID = user.user_Auto_ID;
                users.maDangNhap = user.maDangNhap;
                users.hoTen = user.hoTen;
                users.matKhau = user.matKhau;
                users.ghiChu = user.ghiChu;

                _context.Update(users);
                await _context.SaveChangesAsync();
            }
            return users;
        } 

        public async Task<User> DeleteUserAync(int id)
        {
            var users = await _context.user.FirstOrDefaultAsync(u => u.user_Auto_ID == id);
            if(users != null)
            {
                _context.Remove(users);
                await _context.SaveChangesAsync();
            }
            return users;
        }
    }
}
