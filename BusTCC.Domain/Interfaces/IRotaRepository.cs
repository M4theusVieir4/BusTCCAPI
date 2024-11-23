using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IRotaRepository
    {
        Task<Rota> Incluir(Rota Rota);
        Task<Rota> Alterar(Rota Rota);
        Task<Rota> Excluir(int id);
        Task<List<Rota>> GetRotaDetails(int id);
        Task<IEnumerable<Rota>> SelecionarTodosAsync();
    }
}
