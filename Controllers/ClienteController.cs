using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Fiap.Aula03.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _clienteRepository.Remover(id);
            _clienteRepository.Salvar();
            TempData["msg"] = "Cliente removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepository.BuscarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
            _clienteRepository.Salvar();
            TempData["msg"] = "Cliente atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
 
            _clienteRepository.Cadastrar(cliente);
           
            _clienteRepository.Salvar();
           
            TempData["msg"] = "Cliente cadastrado!";
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

       
        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {
         
            var lista = _clienteRepository.BuscarPor(c =>
               (c.Nome.Contains(nomeBusca) || nomeBusca == null)  
               && (generoBusca == c.Genero || generoBusca == null));
            return View(lista);
        }
    }
}
