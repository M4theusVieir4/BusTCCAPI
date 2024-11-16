using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Reflection;

namespace BusTCC.Domain.Entities;

public partial class Onibus
{
    public int IdOnibus { get; private set; }

    public int IdDados { get; private set; }

    public int IdRotas { get; private set; }

    public string Modelo { get; private set; } = null!;

    public string Placa { get; private set; } = null!;

    public int AnoFabricacao { get; private set; }

    public decimal TaxaOnibus { get; private set; }

    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    public virtual Comunicacao IdDadosNavigation { get; set; } = null!;

    public virtual Rota IdRotasNavigation { get; set; } = null!;

    public virtual ICollection<Rota> Rota { get; set; } = new List<Rota>();

    protected Onibus() { }
    public Onibus(int idOnibus, int idDados, int idRotas, string modelo, 
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Comunicacao idDadosNavigation, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        DomainExceptionValidation.When(idOnibus < 0, "O id do Ônibus deve ser positivo");
        IdOnibus = idOnibus;

        ValidateDomain(idDados, idRotas, modelo,
        placa, anoFabricacao, taxaOnibus, latitude,
        longitude, idDadosNavigation, idRotasNavigation, rota);
        
    }

    public void Update(int idDados, int idRotas, string modelo,
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Comunicacao idDadosNavigation, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        ValidateDomain(idDados, idRotas, modelo,
        placa, anoFabricacao, taxaOnibus, latitude,
        longitude, idDadosNavigation, idRotasNavigation, rota);
    }

    public void ValidateDomain(int idDados, int idRotas, string modelo,
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Comunicacao idDadosNavigation, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        IdDados = idDados;
        IdRotas = idRotas;
        Modelo = modelo;
        Placa = placa;
        AnoFabricacao = anoFabricacao;
        TaxaOnibus = taxaOnibus;
        Latitude = latitude;
        Longitude = longitude;
        IdDadosNavigation = idDadosNavigation;
        IdRotasNavigation = idRotasNavigation;
        Rota = rota;
    }
}
