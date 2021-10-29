using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public interface ICorridaRepository
    {
        void Cadastrar(Corrida corrida);

        IList<Corrida> Listar();

        Corrida BuscarPorId(int id);

        void Salvar();
    }
}