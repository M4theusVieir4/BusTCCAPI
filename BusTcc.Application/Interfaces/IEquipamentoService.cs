using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IEquipamentoService
    {
        Task<EquipamentoDTO> Incluir(EquipamentoDTO equipamentoDTO);
        Task<EquipamentoDTO> Alterar(EquipamentoDTO equipamentoDTO);
        Task<EquipamentoDTO> Excluir(int id);
        Task<EquipamentoDTO> SelecionarAsync(int id);
        Task<IEnumerable<EquipamentoDTO>> SelecionarTodosAsync();
    }
}
