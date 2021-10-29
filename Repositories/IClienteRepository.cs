using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(int id);
        IList<Cliente> Listar();
        Cliente BuscarPorId(int id);
        IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro);
        void Salvar();
    }
}
