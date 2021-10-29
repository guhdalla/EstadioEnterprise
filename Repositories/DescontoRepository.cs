using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class DescontoRepository : IDescontoRepository
    {
        private EstadioContext _context;

        public DescontoRepository(EstadioContext context)
        {
            _context = context;
        }

        public void Cadastar(Desconto desconto)
        {
            _context.Descontos.Add(desconto);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
