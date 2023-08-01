using CRUDSystem.Repository.CenterRepository;
using CRUDSystem.Repository.ClientRepository;
using CRUDSystem.Repository.GovernorateRepository;
using CRUDSystem.Repository.VillageRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSystem.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IClientRepository _clientRepo;
        private readonly IGovernorateRepository _governorateRepo;
        private readonly ICenterRepository _centerRepo;
        private readonly IVillageRepository _villageRepo; 
        public ReportController(
            IClientRepository clientRepository,
            IGovernorateRepository governorateRepo,
            ICenterRepository centerRepo,
            IVillageRepository villageRepo)
        {
            _clientRepo = clientRepository;
            _governorateRepo = governorateRepo;
            _centerRepo = centerRepo;
            _villageRepo = villageRepo;
        }
        [Authorize(Roles = "Reporter")]
        public IActionResult Index(int? govId,int? centerId,int? villageId)
        {
            var clients = _clientRepo.GetAll();
            if (govId is not null)
                clients = clients.Where(c => c.GovernorateID == govId).ToList();
            if(centerId is not null)
                clients = clients.Where(c => c.CenterID == centerId).ToList();
            if (villageId is not null)
                clients = clients.Where(c => c.VillageID == villageId).ToList();
            ViewBag.govs = _governorateRepo.GetAll();
            return View(clients);
        }
    }
}
