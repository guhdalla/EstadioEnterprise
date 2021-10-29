using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private EstadioContext _context;

        public ClienteRepository(EstadioContext context)
        {
            _context = context;
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).Include(c => c.Endereco).ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.Where(c => c.ClienteId == id)
                .Include(c => c.Endereco).FirstOrDefault();
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public IList<Cliente> Listar()
        {
            return _context.Clientes.Include(c => c.Endereco).ToList();
        }

        public void Remover(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
