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
    public class PedidoController : Controller
    {
        private IPedidoRepository _pedidoRepository;
        private IDroneRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private IITemPedidoRepository _itemPedidoRepository;

        public PedidoController(IITemPedidoRepository iTemPedidoRepository, IClienteRepository clienteRepository, IPedidoRepository pedidoRepository, IDroneRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _itemPedidoRepository = iTemPedidoRepository;
        }

        [HttpPost]
        public IActionResult Adicionar(ItemPedido item)
        {
            _itemPedidoRepository.Cadastar(item);
            _itemPedidoRepository.Salvar();
            TempData["msg"] = "Produto adicionado!";
            return RedirectToAction("Adicionar", new { id = item.PedidoId }); //Enviar o id para a action Adicionar
        }

        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            //Pesquisa o pedido 
            var pedido = _pedidoRepository.BuscarPorId(id);

            //Pesquisar todos os produtos
            var lista = _produtoRepository.Listar();

            //Pesquisar os produtos relacionados com o pedido
            var produtosPedido = _produtoRepository.BuscarPorPedido(id);

            //Filtrar a lista de produtos, retirando os produtos relacionados com o pedido
            var listaFiltrada = lista.Where(p => !produtosPedido.Any(p2 => p2.ProdutoId == p.ProdutoId));

            //Enviar os produtos para as opções do select
            ViewBag.produtosSelect = new SelectList(listaFiltrada, "ProdutoId", "Nome");

            //Enviar a lista de produtos associados ao pedido (para popular a tabela)
            ViewBag.produtos = produtosPedido;

            return View(pedido);
        }

        private void CarregarClientes(int id)
        {
            var lista = _clienteRepository.Listar();
            //Envia a lista de clientes para as opções do select
            ViewBag.clientes = new SelectList(lista, "ClienteId", "Nome", id);
        }

        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
            CarregarClientes(id);
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            _pedidoRepository.Cadastrar(pedido);
            _pedidoRepository.Salvar();
            TempData["msg"] = "Pedido registrado";
            return RedirectToAction("Adicionar", new { id = pedido.PedidoId } );
        }

        public IActionResult Index()
        {
            var pedidos = _pedidoRepository.Listar();
            return View(pedidos);
        }
    }
}
