﻿using BusTCC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Interfaces
{
    public interface IPontoService
    {
        Task<PontoDTO> Incluir(PontoDTO pontoDTO);
        Task<PontoDTO> Alterar(PontoDTO pontoDTO);
        Task<PontoDTO> Excluir(int id);
        Task<List<PontoDetailsDTO>> SelecionarAsync(List<PontoDTO> pontos);
        Task<IEnumerable<PontoDTO>> SelecionarTodosAsync();
    }
}
