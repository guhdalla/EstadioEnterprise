using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class CorridaRepository : ICorridaRepository
    {
        private EstadioContext _context;

        public CorridaRepository(EstadioContext context)
        {
            _context = context;
        }

        public Corrida BuscarPorId(int id)
        {
            return _context.Corridas.Where(p => p.CorridaId == id)
                .Include(p => p.Cliente).FirstOrDefault();
        }

        public void Cadastrar(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
        }

        public IList<Corrida> Listar()
        {
            return _context.Corridas.Include(c => c.Cliente).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
