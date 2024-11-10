using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Equipamento
{
    public int IdEquipamento { get; private set; }

    public int IdDados { get; private set; }

    public string NumeroSerie { get; private set; } = null!;

    public string Modelo { get; private set; } = null!;

    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    public virtual ICollection<Catraca> Catracas { get; set; } = new List<Catraca>();

    public virtual ICollection<Comunicacao> Comunicacaos { get; set; } = new List<Comunicacao>();

    public virtual Comunicacao IdDadosNavigation { get; set; } = null!;

    public Equipamento(int idEquipamento, int idDados, string numeroSerie, string modelo,
        decimal latitude, decimal longitude, ICollection<Catraca> catracas,
        ICollection<Comunicacao> comunicacaos, Comunicacao idDadosNavigation)
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O id do equipamento precisa ser positivo");
        IdEquipamento = idEquipamento;

        ValidateDomain(idDados, numeroSerie, modelo,
        latitude, longitude, catracas,
        comunicacaos, idDadosNavigation);
    }

    public void Update(int idDados, string numeroSerie, string modelo,
        decimal latitude, decimal longitude, ICollection<Catraca> catracas,
        ICollection<Comunicacao> comunicacaos, Comunicacao idDadosNavigation)
    {
        ValidateDomain(idDados, numeroSerie, modelo,
        latitude, longitude, catracas,
        comunicacaos, idDadosNavigation);
    }

    public void ValidateDomain(int idDados, string numeroSerie, string modelo,
        decimal latitude, decimal longitude, ICollection<Catraca> catracas,
        ICollection<Comunicacao> comunicacaos, Comunicacao idDadosNavigation)
    {
        DomainExceptionValidation.When(idDados < 0, "O id da comunicação precisa ser positivo");
        DomainExceptionValidation.When(NumeroSerie.Length < 40, "O número de série deve possuir no máximo 40 caracteres");
        DomainExceptionValidation.When(Modelo.Length < 20, "O modelo deve possuir no máximo 20 caracteres");

        IdDados = idDados;
        NumeroSerie = numeroSerie;
        Modelo = modelo;
        Latitude = latitude;
        Longitude = longitude;
        Catracas = catracas;
        Comunicacaos = comunicacaos;
        IdDadosNavigation = idDadosNavigation;
    }
}
