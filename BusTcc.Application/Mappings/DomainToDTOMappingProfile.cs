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
            CreateMap<OnibusRota, OnibusRotaDTO>().ReverseMap();
            CreateMap<RotasPontos, RotasPontosDTO>().ReverseMap();

            CreateMap<Ponto, PontoDetailsDTO>()
            .ForMember(dest => dest.Rotas, opt => opt.MapFrom(src =>
                src.RotasPontos.Select(rp => new RotaDTO
                {
                    IdRotas = rp.Rota.IdRotas,
                    Nome_Rota = rp.Rota.Nome_Rota
                }).ToList()))
            .ForMember(dest => dest.Onibus, opt => opt.MapFrom(src =>
                src.RotasPontos.SelectMany(rp => rp.Rota.OnibusRotas)
                .Select(or => new OnibusDTO
                {
                    IdOnibus = or.Onibus.IdOnibus,
                    Modelo = or.Onibus.Modelo,
                    Placa = or.Onibus.Placa,
                    TaxaOnibus = or.Onibus.TaxaOnibus,
                }).Distinct().ToList()))
            .ForMember(dest => dest.OnibusRotas, opt => opt.MapFrom(src =>
        src.RotasPontos
            .SelectMany(rp => rp.Rota.OnibusRotas)
            .Select(or => new OnibusRotaDTO
            {
                IdRotas = or.Rota.IdRotas,                
                IdOnibus = or.Onibus.IdOnibus,                
            }).ToList()))
            .ReverseMap();


        }
    }
}
