using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Equipamento
{
    public int IdEquipamento { get; private set; }   

    public string NumeroSerie { get; private set; } = null!;

    public string Modelo { get; private set; } = null!;

    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    public virtual Catraca Catraca { get; set; }

    public virtual Onibus Onibus { get; set; }

    public virtual ICollection<Comunicacao> Comunicacaos { get; set; } = new List<Comunicacao>();    

    protected Equipamento() { }
    public Equipamento(int idEquipamento, string numeroSerie, string modelo,
        decimal latitude, decimal longitude, Catraca catraca, 
        ICollection<Comunicacao> comunicacaos, Onibus onibus)
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O id do equipamento precisa ser positivo");
        IdEquipamento = idEquipamento;

        ValidateDomain(numeroSerie, modelo,
        latitude, longitude, catraca, comunicacaos, onibus);
        
    }

    public void Update(string numeroSerie, string modelo,
        decimal latitude, decimal longitude, Catraca catraca,
        ICollection<Comunicacao> comunicacaos, Onibus onibus)
    {
        ValidateDomain(numeroSerie, modelo,
        latitude, longitude, catraca,
        comunicacaos, onibus);
    }

    public void ValidateDomain(string numeroSerie, string modelo,
        decimal latitude, decimal longitude, Catraca catraca,
        ICollection<Comunicacao> comunicacaos, Onibus onibus)
    {        
        DomainExceptionValidation.When(NumeroSerie.Length < 40, "O número de série deve possuir no máximo 40 caracteres");
        DomainExceptionValidation.When(Modelo.Length < 20, "O modelo deve possuir no máximo 20 caracteres");
                
        NumeroSerie = numeroSerie;
        Modelo = modelo;
        Latitude = latitude;
        Longitude = longitude;
        Catraca = catraca;
        Comunicacaos = comunicacaos;        
        Onibus = onibus;
    }
}
