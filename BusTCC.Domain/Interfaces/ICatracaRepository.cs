using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface ICatracaRepository
    {
        Task<Catraca> Incluir(Catraca catraca);
        Task<Catraca> Alterar(Catraca catraca);
        Task<Catraca> Excluir(int id);
        Task<Catraca> SelecionarAsync(int id);
        Task<IEnumerable<Catraca>> SelecionarTodosAsync();
    }
}
