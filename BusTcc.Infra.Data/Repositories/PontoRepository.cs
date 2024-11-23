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

        public async Task<List<Ponto>> SelecionarAsync(List<string> pontos, List<int> ordens)
        {
            string origem = pontos[0];
            int ordemOrigem = ordens[0];
            string destino = pontos[1];
            int ordemDestino = ordens[1];
            

            List<Ponto> pontoOrigem = await _context.Ponto
                                        .AsNoTracking()
                                        .Where(x => x.RuaAvenida.ToUpper() == origem.ToUpper()) 
                                        .Include(p => p.RotasPontos.Where(rp => rp.Ordem == ordemOrigem))                                        
                                            .ThenInclude(rp => rp.Rota)  
                                            .ThenInclude(r => r.OnibusRotas) 
                                            .ThenInclude(or => or.Onibus)  
                                        .ToListAsync();





            List<Ponto> pontoDestino = await _context.Ponto
                                          .AsNoTracking()
                                          .Where(y => y.RuaAvenida.ToUpper() == destino.ToUpper())
                                          .Include(p => p.RotasPontos.Where(rp => rp.Ordem == ordemDestino))
                                                .ThenInclude(rp => rp.Rota)
                                                .ThenInclude(r => r.OnibusRotas)
                                                .ThenInclude(or => or.Onibus)
                                          .ToListAsync();

            List<Ponto> pontosAll = new List<Ponto>();

            pontosAll.AddRange(pontoOrigem);
            pontosAll.AddRange(pontoDestino);

            return pontosAll;
        }

        public async Task<IEnumerable<Ponto>> SelecionarTodosAsync()
        {
            return await _context.Ponto.ToListAsync();
        }
    }
}
