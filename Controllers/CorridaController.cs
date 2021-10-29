using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Fiap.Aula03.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Controllers
{
    public class CorridaController : Controller
    {
        private ICorridaRepository _corridaRepository;
        private IDroneRepository _droneRepository;
        private IClienteRepository _clienteRepository;
        private IDescontoRepository _descontoRepository;

        public CorridaController(IDescontoRepository descontoRepository, IClienteRepository clienteRepository, ICorridaRepository corridaRepository, IDroneRepository droneRepository)
        {
            _corridaRepository = corridaRepository;
            _droneRepository = droneRepository;
            _clienteRepository = clienteRepository;
            _descontoRepository = descontoRepository;
        }

        [HttpPost]
        public IActionResult Adicionar(Desconto item)
        {
            _descontoRepository.Cadastar(item);
            _descontoRepository.Salvar();
            TempData["msg"] = "Drone adicionado!";
            return RedirectToAction("Adicionar", new { id = item.CorridaId });
        }

        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            var pedido = _corridaRepository.BuscarPorId(id);

            var lista = _droneRepository.Listar();

            var produtosPedido = _droneRepository.BuscarPorPedido(id);

            var listaFiltrada = lista.Where(p => !produtosPedido.Any(p2 => p2.DroneId == p.DroneId));

            ViewBag.produtosSelect = new SelectList(listaFiltrada, "ProdutoId", "Nome");

            ViewBag.produtos = produtosPedido;

            return View(pedido);
        }

        private void CarregarClientes(int id)
        {
            var lista = _clienteRepository.Listar();

            ViewBag.clientes = new SelectList(lista, "ClienteId", "Nome", id);
        }

        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
            CarregarClientes(id);
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Corrida corrida)
        {
            _corridaRepository.Cadastrar(corrida);
            _corridaRepository.Salvar();
            TempData["msg"] = "Corrida registrada";
            return RedirectToAction("Adicionar", new { id = corrida.CorridaId } );
        }

        public IActionResult Index()
        {
            var pedidos = _corridaRepository.Listar();
            return View(pedidos);
        }
    }
}
