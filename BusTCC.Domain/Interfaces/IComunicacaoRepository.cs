using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Interfaces
{
    public interface IComunicacaoRepository
    {
        Task<Comunicacao> Incluir(Comunicacao comunicacao);
        Task<Comunicacao> Alterar(Comunicacao comunicacao);
        Task<Comunicacao> Excluir(int id);
        Task<Comunicacao> SelecionarAsync(int id);
        Task<IEnumerable<Comunicacao>> SelecionarTodosAsync();
    }
}
