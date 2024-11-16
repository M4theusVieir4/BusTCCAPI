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
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Equipamento> Alterar(Equipamento equipamento)
        {
            _context.Equipamento.Update(equipamento);
            await _context.SaveChangesAsync();
            return equipamento;
        }

        public async Task<Equipamento?> Excluir(int id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            if (equipamento != null)
            {
                _context.Equipamento.Remove(equipamento);
                await _context.SaveChangesAsync();
                return equipamento;
            }

            return null;
        }

        public async Task<Equipamento> Incluir(Equipamento equipamento)
        {
            _context.Equipamento.Add(equipamento);
            await _context.SaveChangesAsync();
            return equipamento;
        }

        public async Task<Equipamento> SelecionarAsync(int id)
        {
            return await _context.Equipamento.AsNoTracking().FirstOrDefaultAsync(x => x.IdEquipamento == id);
        }

        public async Task<IEnumerable<Equipamento>> SelecionarTodosAsync()
        {
            return await _context.Equipamento.ToListAsync();
        }
    }
}
