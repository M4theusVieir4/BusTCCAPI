using AutoMapper;
using BusTCC.Application.DTOs;
using BusTCC.Application.Interfaces;
using BusTCC.Domain.Entities;
using BusTCC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Services
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _pontoRepository;
        private readonly IMapper _mapper;

        public PontoService(IPontoRepository pontoRepository, IMapper mapper)
        {
            _pontoRepository = pontoRepository;
            _mapper = mapper;
        }

        public async Task<PontoDTO> Alterar(PontoDTO pontoDTO)
        {
            var ponto = _mapper.Map<Ponto>(pontoDTO);
            var pontoAlterado = await _pontoRepository.Alterar(ponto);
            return _mapper.Map<PontoDTO>(pontoAlterado);
        }

        public async Task<PontoDTO> Excluir(int id)
        {
            var pontoExcluido = await _pontoRepository.Excluir(id);
            return _mapper.Map<PontoDTO>(pontoExcluido);
        }

        public async Task<PontoDTO> Incluir(PontoDTO pontoDTO)
        {
            var ponto = _mapper.Map<Ponto>(pontoDTO);
            var pontoIncluido = await _pontoRepository.Incluir(ponto);
            return _mapper.Map<PontoDTO>(pontoIncluido);
        }

        public async Task<List<PontoDetailsDTO>> SelecionarAsync(List<PontoDTO> pontos)
        {
            var pontoComOrdem = pontos.Select(p => new { Ponto = p.RuaAvenida, Ordem = p.Ordem }).ToList();
            var pontosEntity = _mapper.Map<List<Ponto>>(pontos);
            List<string> avenidas = pontos.Select(p => p.RuaAvenida).ToList();
            List<int> ordens = pontos.Select(o => o.Ordem).ToList();

            var pontosEntityDetails = await _pontoRepository.SelecionarAsync(avenidas, ordens);
            var pontosDetailsDTO = _mapper.Map<List<PontoDetailsDTO>>(pontosEntityDetails);
            return pontosDetailsDTO;
        }

        public async Task<IEnumerable<PontoDTO>> SelecionarTodosAsync()
        {
            var allPonto = await _pontoRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<PontoDTO>>(allPonto);
        }
    }
}
