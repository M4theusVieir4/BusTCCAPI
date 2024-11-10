using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IPreferenciaService
    {
        Task<PreferenciaDTO> Incluir(PreferenciaDTO preferenciaDTO);
        Task<PreferenciaDTO> Alterar(PreferenciaDTO preferenciaDTO);
        Task<PreferenciaDTO> Excluir(int id);
        Task<PreferenciaDTO> SelecionarAsync(int id);
        Task<IEnumerable<PreferenciaDTO>> SelecionarTodosAsync();
    }
}
