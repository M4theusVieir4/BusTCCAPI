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
    public class RotaRepository : IRotaRepository
    {
        private readonly ApplicationDbContext _context;

        public RotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Rota> Alterar(Rota rota)
        {
            _context.Rotas.Update(rota);
            await _context.SaveChangesAsync();
            return rota;
        }

        public async Task<Rota?> Excluir(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                await _context.SaveChangesAsync();
                return rota;
            }

            return null;
        }

        public async Task<Rota> Incluir(Rota rota)
        {
            _context.Rotas.Add(rota);
            await _context.SaveChangesAsync();
            return rota;
        }

        public async Task<List<Rota>> GetRotaDetails(int id)
        {
            return await _context.Rotas
                .Include(r => r.OnibusRotas)
                .ThenInclude(or => or.Onibus)
                .Include(r => r.RotasPontos)
                .ThenInclude(rp => rp.Ponto)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rota>> SelecionarTodosAsync()
        {
            return await _context.Rotas.ToListAsync();
        }
    }
}
