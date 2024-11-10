using BusTCC.Domain.Entities;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
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
        public async Task<Preferencia> Alterar(Preferencia usuario)
        {
            _context.Preferencia.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public Task<Preferencia> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Preferencia> Incluir(Preferencia usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Preferencia> SelecionarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Preferencia>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
