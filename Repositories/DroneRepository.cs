using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class DroneRepository : IDroneRepository
    {
        private EstadioContext _context;

        public DroneRepository(EstadioContext context)
        {
            _context = context;
        }

        public IList<Drone> BuscarPorPedido(int id)
        {
            return _context.Descontos
                .Where(i => i.CorridaId == id)
                .Select(i => i.Drone)
                .ToList();
        }

        public void Cadastrar(Drone drone)
        {
            _context.Drones.Add(drone);
        }

        public IList<Drone> Listar()
        {
            return _context.Drones.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
