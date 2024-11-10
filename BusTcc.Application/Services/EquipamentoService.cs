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
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;

        public EquipamentoService(IEquipamentoRepository equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        public async Task<EquipamentoDTO> Alterar(EquipamentoDTO equipamentoDTO)
        {
            var equipamento = _mapper.Map<Equipamento>(equipamentoDTO);
            var equipamentoAlterado = await _equipamentoRepository.Alterar(equipamento);
            return _mapper.Map<EquipamentoDTO>(equipamentoAlterado);
        }

        public async Task<EquipamentoDTO> Excluir(int id)
        {
            var equipamentoExcluido = await _equipamentoRepository.Excluir(id);
            return _mapper.Map<EquipamentoDTO>(equipamentoExcluido);
        }

        public async Task<EquipamentoDTO> Incluir(EquipamentoDTO equipamentoDTO)
        {
            var equipamento = _mapper.Map<Equipamento>(equipamentoDTO);
            var equipamentoIncluido = await _equipamentoRepository.Alterar(equipamento);
            return _mapper.Map<EquipamentoDTO>(equipamentoIncluido);
        }

        public async Task<EquipamentoDTO> SelecionarAsync(int id)
        {
            var equipamento = await _equipamentoRepository.SelecionarAsync(id);
            return _mapper.Map<EquipamentoDTO>(equipamento);
        }

        public async Task<IEnumerable<EquipamentoDTO>> SelecionarTodosAsync()
        {
            var equipamentos = await _equipamentoRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<EquipamentoDTO>>(equipamentos);
        }
    }
}
