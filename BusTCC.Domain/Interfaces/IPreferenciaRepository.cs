using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IPreferenciaRepository
    {
        Task<Preferencia> Incluir(Preferencia preferencia);
        Task<Preferencia> Alterar(Preferencia preferencia);
        Task<Preferencia> Excluir(int id);
        Task<Preferencia> SelecionarAsync(int id);
        Task<IEnumerable<Preferencia>> SelecionarTodosAsync();
    }
}
