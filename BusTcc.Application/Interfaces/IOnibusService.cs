using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IOnibusService
    {
        Task<OnibusDTO> Incluir(OnibusDTO onibusDTO);
        Task<OnibusDTO> Alterar(OnibusDTO onibusDTO);
        Task<OnibusDTO> Excluir(int id);
        Task<OnibusDTO> SelecionarAsync(int id);
        Task<IEnumerable<OnibusDTO>> SelecionarTodosAsync();
    }
}
