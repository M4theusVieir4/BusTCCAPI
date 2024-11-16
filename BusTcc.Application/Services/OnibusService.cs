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
    public class OnibusService : IOnibusService
    {
        private readonly IOnibusRepository _onibusRepository;
        private readonly IMapper _mapper;

        public OnibusService(IOnibusRepository onibusRepository, IMapper mapper)
        {
            _onibusRepository = onibusRepository;
            _mapper = mapper;
        }

        public async Task<OnibusDTO> Alterar(OnibusDTO onibusDTO)
        {
            var onibus = _mapper.Map<Onibus>(onibusDTO);
            var onibusAlterado = await _onibusRepository.Alterar(onibus);
            return _mapper.Map<OnibusDTO>(onibusAlterado);
        }

        public async Task<OnibusDTO> Excluir(int id)
        {
            var onibusExcluido = await _onibusRepository.Excluir(id);
            return _mapper.Map<OnibusDTO>(onibusExcluido);
        }

        public async Task<OnibusDTO> Incluir(OnibusDTO onibusDTO)
        {
            var onibus = _mapper.Map<Onibus>(onibusDTO);
            var onibusIncluido = await _onibusRepository.Incluir(onibus);
            return _mapper.Map<OnibusDTO>(onibusIncluido);
        }

        public async Task<OnibusDTO> SelecionarAsync(int id)
        {
            var onibus = await _onibusRepository.SelecionarAsync(id);
            return _mapper.Map<OnibusDTO>(onibus);
        }

        public async Task<IEnumerable<OnibusDTO>> SelecionarTodosAsync()
        {
            var allOnibus = await _onibusRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<OnibusDTO>>(allOnibus);
        }
    }
}
