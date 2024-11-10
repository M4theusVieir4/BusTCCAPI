using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface ICatracaService
    {
        Task<CatracaDTO> Incluir(CatracaDTO catracaDTO);
        Task<CatracaDTO> Alterar(CatracaDTO catracaDTO);
        Task<CatracaDTO> Excluir(int id);
        Task<CatracaDTO> SelecionarAsync(int id);
        Task<IEnumerable<CatracaDTO>> SelecionarTodosAsync();
    }
}
