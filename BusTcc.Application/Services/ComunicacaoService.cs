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
    public class ComunicacaoService : IComunicacaoService
    {
        private readonly IComunicacaoRepository _comunicacaoRepository;
        private readonly IMapper _mapper;

        public ComunicacaoService(IComunicacaoRepository comunicacaoRepository, IMapper mapper)
        {
            _comunicacaoRepository = comunicacaoRepository;
            _mapper = mapper;
        }

        public async Task<ComunicacaoDTO> Alterar(ComunicacaoDTO comunicacaoDTO)
        {
            var comunicacao = _mapper.Map<Comunicacao>(comunicacaoDTO);
            var comunicacaoAlterado = await _comunicacaoRepository.Alterar(comunicacao);
            return _mapper.Map<ComunicacaoDTO>(comunicacaoAlterado);
        }

        public async Task<ComunicacaoDTO> Excluir(int id)
        {
            var comunicacaoExcluido = await _comunicacaoRepository.Excluir(id);
            return _mapper.Map<ComunicacaoDTO>(comunicacaoExcluido);
        }

        public async Task<ComunicacaoDTO> Incluir(ComunicacaoDTO comunicacaoDTO)
        {
            var comunicacao = _mapper.Map<Comunicacao>(comunicacaoDTO);
            var comunicacaoIncluido = await _comunicacaoRepository.Alterar(comunicacao);
            return _mapper.Map<ComunicacaoDTO>(comunicacaoIncluido);
        }

        public async Task<ComunicacaoDTO> SelecionarAsync(int id)
        {
            var comunicacao = await _comunicacaoRepository.SelecionarAsync(id);
            return _mapper.Map<ComunicacaoDTO>(comunicacao);
        }

        public async Task<IEnumerable<ComunicacaoDTO>> SelecionarTodosAsync()
        {
            var comunicacoes = await _comunicacaoRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<ComunicacaoDTO>>(comunicacoes);
        }
    }
}
