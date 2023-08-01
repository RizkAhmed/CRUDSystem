using CRUDSystem.Data;
using CRUDSystem.Models;

namespace CRUDSystem.Repository.GovernorateRepository
{
    public class GovernorateRepository: IGovernorateRepository
    {
        private readonly AppDbContext _context;
        public GovernorateRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Governorate> GetAll()
        {
            return _context.Governorates.ToList();
        }
    }
}
