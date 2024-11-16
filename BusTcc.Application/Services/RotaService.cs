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
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;

        public RotaService(IRotaRepository rotaRepository, IMapper mapper)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
        }

        public async Task<RotaDTO> Alterar(RotaDTO rotaDTO)
        {
            var rota = _mapper.Map<Rota>(rotaDTO);
            var rotaAlterado = await _rotaRepository.Alterar(rota);
            return _mapper.Map<RotaDTO>(rotaAlterado);
        }

        public async Task<RotaDTO> Excluir(int id)
        {
            var rotaExcluido = await _rotaRepository.Excluir(id);
            return _mapper.Map<RotaDTO>(rotaExcluido);
        }

        public async Task<RotaDTO> Incluir(RotaDTO rotaDTO)
        {
            var rota = _mapper.Map<Rota>(rotaDTO);
            var rotaIncluido = await _rotaRepository.Incluir(rota);
            return _mapper.Map<RotaDTO>(rotaIncluido);
        }

        public async Task<RotaDTO> SelecionarAsync(int id)
        {
            var rota = await _rotaRepository.SelecionarAsync(id);
            return _mapper.Map<RotaDTO>(rota);
        }

        public async Task<IEnumerable<RotaDTO>> SelecionarTodosAsync()
        {
            var allRota = await _rotaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<RotaDTO>>(allRota);
        }
    }
}
