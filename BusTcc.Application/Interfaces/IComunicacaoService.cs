using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IComunicacaoService
    {
        Task<ComunicacaoDTO> Incluir(ComunicacaoDTO comunicacaoDTO);
        Task<ComunicacaoDTO> Alterar(ComunicacaoDTO comunicacaoDTO);
        Task<ComunicacaoDTO> Excluir(int id);
        Task<ComunicacaoDTO> SelecionarAsync(int id);
        Task<IEnumerable<ComunicacaoDTO>> SelecionarTodosAsync();
    }
}
