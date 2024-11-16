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
    public class PontoRepository : IPontoRepository
    {
        private readonly ApplicationDbContext _context;

        public PontoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Ponto> Alterar(Ponto ponto)
        {
            _context.Ponto.Update(ponto);
            await _context.SaveChangesAsync();
            return ponto;
        }

        public async Task<Ponto?> Excluir(int id)
        {
            var ponto = await _context.Ponto.FindAsync(id);
            if (ponto != null)
            {
                _context.Ponto.Remove(ponto);
                await _context.SaveChangesAsync();
                return ponto;
            }

            return null;
        }

        public async Task<Ponto> Incluir(Ponto ponto)
        {
            _context.Ponto.Add(ponto);
            await _context.SaveChangesAsync();
            return ponto;
        }

        public async Task<Ponto> SelecionarAsync(int id)
        {
            return await _context.Ponto.AsNoTracking().FirstOrDefaultAsync(x => x.IdPonto == id);
        }

        public async Task<IEnumerable<Ponto>> SelecionarTodosAsync()
        {
            return await _context.Ponto.ToListAsync();
        }
    }
}
