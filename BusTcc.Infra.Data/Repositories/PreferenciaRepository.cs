using BusTCC.Domain.Entities;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.Data.Repositories
{
    public class PreferenciaRepository : IPreferenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public PreferenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Preferencia> Alterar(Preferencia preferencia)
        {
            _context.Preferencia.Update(preferencia);
            await _context.SaveChangesAsync();
            return preferencia;
        }

        public async Task<Preferencia> Excluir(int id)
        {
            var preferencia = await _context.Preferencia.FindAsync(id);
            if (preferencia != null)
            {
                _context.Preferencia.Remove(preferencia);
                await _context.SaveChangesAsync();
                return preferencia;
            }

            return null;
        }

        public async Task<Preferencia> Incluir(Preferencia preferencia)
        {
            _context.Preferencia.Add(preferencia);
            await _context.SaveChangesAsync();
            return preferencia;
        }

        public async Task<Preferencia> SelecionarAsync(int id)
        {
            return await _context.Preferencia.AsNoTracking().FirstOrDefaultAsync(x => x.IdPreferencia == id);
        }

        public async Task<IEnumerable<Preferencia>> SelecionarTodosAsync()
        {
            return await _context.Preferencia.ToListAsync();
        }
    }
}
