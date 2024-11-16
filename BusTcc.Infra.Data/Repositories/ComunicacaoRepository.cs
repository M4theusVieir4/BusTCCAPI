using BusTCC.Domain.Entities;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.Data.Repositories
{
    public class ComunicacaoRepository : IComunicacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public ComunicacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Comunicacao> Alterar(Comunicacao comunicacao)
        {
            _context.Comunicacao.Update(comunicacao);
            await _context.SaveChangesAsync();
            return comunicacao;
        }

        public async Task<Comunicacao?> Excluir(int id)
        {
            var comunicacao = await _context.Comunicacao.FindAsync(id);
            if (comunicacao != null)
            {
                _context.Comunicacao.Remove(comunicacao);
                await _context.SaveChangesAsync();
                return comunicacao;
            }

            return null;
        }

        public async Task<Comunicacao> Incluir(Comunicacao comunicacao)
        {
            _context.Comunicacao.Add(comunicacao);
            await _context.SaveChangesAsync();
            return comunicacao;
        }

        public async Task<Comunicacao> SelecionarAsync(int id)
        {
            return await _context.Comunicacao.AsNoTracking().FirstOrDefaultAsync(x => x.IdDados == id);
        }

        public async Task<IEnumerable<Comunicacao>> SelecionarTodosAsync()
        {
            return await _context.Comunicacao.ToListAsync();
        }
    }
}
