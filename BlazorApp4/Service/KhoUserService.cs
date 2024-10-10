using BlazorApp4.Models;

namespace BlazorApp4.Service
{
    public class KhoUserService
    {
        private AplicationDbContext _context;

        public KhoUserService(AplicationDbContext context)
        {
            _context = context;
        }


    }
}
