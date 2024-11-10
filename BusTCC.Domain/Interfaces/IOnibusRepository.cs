using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IOnibusRepository
    {
        Task<Onibus> Incluir(Onibus onibus);
        Task<Onibus> Alterar(Onibus onibus);
        Task<Onibus> Excluir(int id);
        Task<Onibus> SelecionarAsync(int id);
        Task<IEnumerable<Onibus>> SelecionarTodosAsync();
    }
}
