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

        public async Task<List<Ponto>> SelecionarAsync(List<string> pontos, List<int?> ordens)
        {
            string origem = pontos[0].ToUpper();
            string destino = pontos[1].ToUpper();
            int? ordemOrigem = ordens[0];
            int? ordemDestino = ordens[1];


            var rotasComunsIds = await _context.Ponto
                .Where(p => p.RuaAvenida.ToUpper() == origem.ToUpper() || p.RuaAvenida.ToUpper() == destino.ToUpper())
                .SelectMany(p => p.RotasPontos)
                .GroupBy(rp => rp.Rota.IdRotas)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToListAsync();
            

            var pontosComRotasComuns = await _context.Ponto
                .Where(p => p.RuaAvenida.ToUpper() == origem.ToUpper() || p.RuaAvenida.ToUpper() == destino.ToUpper())
                .Include(p => p.RotasPontos.Where(rp => rotasComunsIds.Contains(rp.Rota.IdRotas)))
                    .ThenInclude(rp => rp.Rota)
                    .ThenInclude(r => r.OnibusRotas)
                    .ThenInclude(or => or.Onibus)
                .ToListAsync();
            

           


            //var pontoOrigem = pontosData.Where(p => p.RuaAvenida.ToUpper() == origem).ToList();
            //var pontoDestino = pontosData.Where(p => p.RuaAvenida.ToUpper() == destino).ToList();


            //if (ordemOrigem.HasValue)
            //{
            //    pontoOrigem = pontoOrigem
            //        .Where(p => p.RotasPontos.Any(rp => rp.Ordem == ordemOrigem))
            //        .ToList();
            //}

            //if (ordemDestino.HasValue)
            //{
            //    pontoDestino = pontoDestino
            //        .Where(p => p.RotasPontos.Any(rp => rp.Ordem == ordemDestino))
            //        .ToList();
            //}            


            return pontosComRotasComuns;
        }

        public async Task<IEnumerable<Ponto>> SelecionarTodosAsync()
        {
            return await _context.Ponto.ToListAsync();
        }
    }
}
