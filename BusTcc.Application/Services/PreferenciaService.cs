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
    public class PreferenciaService : IPreferenciaService
    {
        private readonly IPreferenciaRepository _preferenciaRepository;
        private readonly IMapper _mapper;

        public PreferenciaService(IPreferenciaRepository preferenciaRepository, IMapper mapper)
        {
            _preferenciaRepository = preferenciaRepository;
            _mapper = mapper;
        }

        public async Task<PreferenciaDTO> Alterar(PreferenciaDTO preferenciaDTO)
        {
            var preferencia = _mapper.Map<Preferencia>(preferenciaDTO);
            var preferenciaAlterado = await _preferenciaRepository.Alterar(preferencia);
            return _mapper.Map<PreferenciaDTO>(preferenciaAlterado);
        }

        public async Task<PreferenciaDTO> Excluir(int id)
        {
            var preferenciaExcluido = await _preferenciaRepository.Excluir(id);
            return _mapper.Map<PreferenciaDTO>(preferenciaExcluido);
        }

        public async Task<PreferenciaDTO> Incluir(PreferenciaDTO preferenciaDTO)
        {
            var preferencia = _mapper.Map<Preferencia>(preferenciaDTO);
            var preferenciaIncluido = await _preferenciaRepository.Incluir(preferencia);
            return _mapper.Map<PreferenciaDTO>(preferenciaIncluido);
        }

        public async Task<PreferenciaDTO> SelecionarAsync(int id)
        {
            var preferencia = await _preferenciaRepository.SelecionarAsync(id);
            return _mapper.Map<PreferenciaDTO>(preferencia);
        }

        public async Task<IEnumerable<PreferenciaDTO>> SelecionarTodosAsync()
        {
            var allPreferencia = await _preferenciaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<PreferenciaDTO>>(allPreferencia);
        }
    }
}
