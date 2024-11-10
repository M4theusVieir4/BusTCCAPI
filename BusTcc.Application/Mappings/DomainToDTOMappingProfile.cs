using AutoMapper;
using BusTCC.Application.DTOs;
using BusTCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<Catraca, CatracaDTO>().ReverseMap();
            CreateMap<Comunicacao, ComunicacaoDTO>().ReverseMap();
            CreateMap<Equipamento, EquipamentoDTO>().ReverseMap();
            CreateMap<Onibus, OnibusDTO>().ReverseMap();
            CreateMap<Ponto, PontoDTO>().ReverseMap();
            CreateMap<Preferencia, PreferenciaDTO>().ReverseMap();
            CreateMap<Rota, RotaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
