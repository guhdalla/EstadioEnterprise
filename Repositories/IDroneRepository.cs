using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public interface IDroneRepository
    {
        void Cadastrar(Drone drone);

        IList<Drone> Listar();

        IList<Drone> BuscarPorPedido(int id);

        void Salvar();
    }
}
