using BusTCC.Domain.Entities;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Alterar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public Task<Usuario> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Incluir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> SelecionarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
