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
    public class CatracaService : ICatracaService
    {
        private readonly ICatracaRepository _catracaRepository;
        private readonly IMapper _mapper;

        public CatracaService(ICatracaRepository catracaRepository, IMapper mapper)
        {
            _catracaRepository = catracaRepository;
            _mapper = mapper;
        }

        public async Task<CatracaDTO> Alterar(CatracaDTO catracaDTO)
        {
            var catraca = _mapper.Map<Catraca>(catracaDTO);
            var catracaAlterado = await _catracaRepository.Alterar(catraca);
            return _mapper.Map<CatracaDTO>(catracaAlterado);
        }

        public async Task<CatracaDTO> Excluir(int id)
        {            
            var catracaExcluido = await _catracaRepository.Excluir(id);
            return _mapper.Map<CatracaDTO>(catracaExcluido);
        }

        public async Task<CatracaDTO> Incluir(CatracaDTO catracaDTO)
        {
            var catraca = _mapper.Map<Catraca>(catracaDTO);
            var catracaIncluido = await _catracaRepository.Incluir(catraca);
            return _mapper.Map<CatracaDTO>(catracaIncluido);
        }

        public async Task<CatracaDTO> SelecionarAsync(int id)
        {
            var catraca = await _catracaRepository.SelecionarAsync(id);
            return _mapper.Map<CatracaDTO>(catraca);
        }

        public async Task<IEnumerable<CatracaDTO>> SelecionarTodosAsync()
        {
            var catracas = await _catracaRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<CatracaDTO>>(catracas);
        }
    }
}
