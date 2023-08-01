using CRUDSystem.Data;
using CRUDSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDSystem.Repository.VillageRepository
{
    public class VillageRepository:IVillageRepository
    {
        private readonly AppDbContext _context;
        public VillageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Village> GetAll()
        {
            return _context.Villages.Include(v=>v.Center).ToList();
        }
    }
}
