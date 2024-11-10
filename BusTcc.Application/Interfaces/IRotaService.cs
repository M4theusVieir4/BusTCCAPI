using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IRotaService
    {
        Task<RotaDTO> Incluir(RotaDTO RotaDTO);
        Task<RotaDTO> Alterar(RotaDTO RotaDTO);
        Task<RotaDTO> Excluir(int id);
        Task<RotaDTO> SelecionarAsync(int id);
        Task<IEnumerable<RotaDTO>> SelecionarTodosAsync();
    }
}
