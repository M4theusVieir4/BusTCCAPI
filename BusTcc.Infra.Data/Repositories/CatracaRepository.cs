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
    public class CatracaRepository : ICatracaRepository
    {
        private readonly ApplicationDbContext _context;

        public CatracaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Catraca> Alterar(Catraca catraca)
        {
            _context.Catraca.Update(catraca);
            await _context.SaveChangesAsync();
            return catraca;
        }

        public async Task<Catraca?> Excluir(int id)
        {
            var catraca = await _context.Catraca.FindAsync(id);
            if (catraca != null)
            {
                _context.Catraca.Remove(catraca);
                await _context.SaveChangesAsync();
                return catraca;
            }

            return null;
        }

        public async Task<Catraca> Incluir(Catraca catraca)
        {
            _context.Catraca.Add(catraca);
            await _context.SaveChangesAsync();
            return catraca;
        }

        public async Task<Catraca> SelecionarAsync(int id)
        {
            return await _context.Catraca.AsNoTracking().FirstOrDefaultAsync(x => x.IdCatraca == id);
        }

        public async Task<IEnumerable<Catraca>> SelecionarTodosAsync()
        {
            return await _context.Catraca.ToListAsync();
        }
    }
}
