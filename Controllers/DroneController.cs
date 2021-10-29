using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Fiap.Aula03.Web.Repositories;
using Fiap.Aula03.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Controllers
{
    public class DroneController : Controller
    {
        private IDroneRepository _droneRepository;

        public DroneController(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Drone drone)
        {
            _droneRepository.Cadastrar(drone);
            _droneRepository.Salvar();
            TempData["msg"] = "Drone cadastrado";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var drones = _droneRepository.Listar();
            var viewModel = new DroneViewModel()
            {
                Lista = drones
            };
            return View(viewModel);
        }
    }
}
