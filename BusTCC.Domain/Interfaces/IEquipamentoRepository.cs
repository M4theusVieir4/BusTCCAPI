using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IEquipamentoRepository
    {
        Task<Equipamento> Incluir(Equipamento equipamento);
        Task<Equipamento> Alterar(Equipamento equipamento);
        Task<Equipamento> Excluir(int id);
        Task<Equipamento> SelecionarAsync(int id);
        Task<IEnumerable<Equipamento>> SelecionarTodosAsync();
    }
}
