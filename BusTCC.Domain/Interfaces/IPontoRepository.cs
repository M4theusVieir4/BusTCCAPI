using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IPontoRepository
    {
        Task<Ponto> Incluir(Ponto ponto);
        Task<Ponto> Alterar(Ponto ponto);
        Task<Ponto> Excluir(int id);
        Task<Ponto> SelecionarAsync(int id);
        Task<IEnumerable<Ponto>> SelecionarTodosAsync();
    }
}
