﻿using BusTCC.Domain.Entities;
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

        public async Task<Usuario?> Excluir(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if(usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }

            return null;
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            return await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
    }
}
