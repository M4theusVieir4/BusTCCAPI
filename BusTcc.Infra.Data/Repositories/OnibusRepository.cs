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
    public class OnibusRepository : IOnibusRepository
    {
        private readonly ApplicationDbContext _context;

        public OnibusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Onibus> Alterar(Onibus onibus)
        {
            _context.Onibus.Update(onibus);
            await _context.SaveChangesAsync();
            return onibus;
        }

        public async Task<Onibus?> Excluir(int id)
        {
            var onibus = await _context.Onibus.FindAsync(id);
            if (onibus != null)
            {
                _context.Onibus.Remove(onibus);
                await _context.SaveChangesAsync();
                return onibus;
            }

            return null;
        }

        public async Task<Onibus> Incluir(Onibus onibus)
        {
            _context.Onibus.Add(onibus);
            await _context.SaveChangesAsync();
            return onibus;
        }

        public async Task<Onibus> SelecionarAsync(int id)
        {
            return await _context.Onibus.AsNoTracking().FirstOrDefaultAsync(x => x.IdOnibus == id);
        }

        public async Task<IEnumerable<Onibus>> SelecionarTodosAsync()
        {
            var teste = await _context.Onibus
                .Include(o => o.IdEquipamentoNavigation)
                .ThenInclude(e => e.Comunicacaos)
                .Include(o => o.OnibusRotas)
                .ThenInclude(or => or.Rota)
                .ThenInclude(r => r.RotasPontos)
                .ThenInclude(rp => rp.Ponto)
                .ToListAsync();
            return teste;
        }
    }
}
