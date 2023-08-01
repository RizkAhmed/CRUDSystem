using CRUDSystem.Data;
using CRUDSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDSystem.Repository.CenterRepository
{
    public class CenterRepository : ICenterRepository
    {
        private readonly AppDbContext _context;
        public CenterRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Center> GetAll()
        {
            return _context.Centers.Include(c=>c.Governorate).ToList();
        }
    }
}
