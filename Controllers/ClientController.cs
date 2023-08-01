using CRUDSystem.Data;
using CRUDSystem.Models;
using CRUDSystem.Repository.CenterRepository;
using CRUDSystem.Repository.ClientRepository;
using CRUDSystem.Repository.GovernorateRepository;
using CRUDSystem.Repository.VillageRepository;
using CRUDSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace CRUDSystem.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepo;
        private readonly IGovernorateRepository _governorateRepo;
        private readonly ICenterRepository _centerRepo;
        private readonly IVillageRepository _villageRepo;

        public ClientController(
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

        public IActionResult Index()
        {
            var clients = _clientRepo.GetAll();
            return View(clients);
        }
        [Authorize(Roles = "DataEntry")]
        public IActionResult Create()
        {
            ClientViewModel model = new ClientViewModel
            {
                Governorates = _governorateRepo.GetAll(),
                Centers = _centerRepo.GetAll(),
                Villages = _villageRepo.GetAll()
            };
            return View(model);
        }

        [Authorize(Roles = "DataEntry")]
        [HttpPost]
        public IActionResult Create(ClientViewModel model)
        {
            model.Governorates = _governorateRepo.GetAll();
            model.Centers = _centerRepo.GetAll();
            model.Villages = _villageRepo.GetAll();

            if (!ModelState.IsValid)
                return View(model);

            var uniqueNationalID = _clientRepo.GetAll().Where(c => c.NationalID == model.NationalID).FirstOrDefault();
            if (uniqueNationalID is not null)
            {
                ModelState.AddModelError("NationalID", "الرقم القومى موجود مسبقاً");
                return View(model);
            }
            Client client = new Client
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                NationalID = model.NationalID,
                GovernorateID = model.GovernorateID,
                CenterID = model.CenterID,
                VillageID = model.VillageID,
                Gender = model.Gender,
            };
            _clientRepo.Add(client);
            _clientRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "DataEntry")]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var client = _clientRepo.GetById(id);
            if (client is null)
                return NotFound();
            var model = new ClientViewModel
            {
                ClientID = client.ClientID,
                FirstName = client.FirstName,
                LastName = client.LastName,
                NationalID = client.NationalID,
                GovernorateID = client.GovernorateID,
                CenterID = client.CenterID,
                VillageID = client.VillageID,
                Gender = client.Gender,

                Governorates = _governorateRepo.GetAll(),
                Centers = _centerRepo.GetAll(),
                Villages = _villageRepo.GetAll()
            };
            return View(model);
        }

        [Authorize(Roles = "DataEntry")]
        [HttpPost]
        public IActionResult Edit(ClientViewModel model)
        {
            model.Governorates = _governorateRepo.GetAll();
            model.Centers = _centerRepo.GetAll();
            model.Villages = _villageRepo.GetAll();
            if (!ModelState.IsValid)
                return View(model);

            var uniqueNationalID = _clientRepo.GetAll().Where(c => c.NationalID == model.NationalID).FirstOrDefault();
            if (uniqueNationalID is not null && uniqueNationalID.ClientID!=model.ClientID)
            {
                ModelState.AddModelError("NationalID", "الرقم القومى موجود مسبقاً");
                return View(model);
            }
            var client = _clientRepo.GetById(model.ClientID);

            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.NationalID = model.NationalID;
            client.GovernorateID = model.GovernorateID;
            client.CenterID = model.CenterID;
            client.VillageID = model.VillageID;
            client.Gender = model.Gender;
            _clientRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "DataEntry")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var client = _clientRepo.GetById(id);
            if (client is null)
                return NotFound();

            _clientRepo.Delete(id);
            _clientRepo.Save();
            return Ok();
        }
        public IActionResult GetCenters(int? govId)
        {
            if (govId is null)
                return BadRequest();

            var centers = _centerRepo.GetAll().Where(c => c.GovernorateID == govId).ToList();
            return Json(centers);
        }
        public IActionResult GetVillages(int? centerId)
        {
            if (centerId is null)
                return BadRequest();

            var villages = _villageRepo.GetAll().Where(c => c.CenterID == centerId).ToList();
            return Json(villages);
        }
    }
}
