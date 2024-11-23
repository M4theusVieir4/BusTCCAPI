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

    public int IdEquipamento { get; private set; }    

    public string Modelo { get; private set; } = null!;

    public string Placa { get; private set; } = null!;

    public int AnoFabricacao { get; private set; }

    public decimal TaxaOnibus { get; private set; }

    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    public virtual Equipamento IdEquipamentoNavigation { get; set; } = null!;
    public virtual ICollection<OnibusRota> OnibusRotas { get; set; }

   

    protected Onibus() { }
    public Onibus(int idOnibus, int idEquipamento, string modelo, 
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Equipamento idEquipamentoNavigation, Rota idRotasNavigation,
        ICollection<Rota> rota, ICollection<OnibusRota> onibusRotas)
    {
        DomainExceptionValidation.When(idOnibus < 0, "O id do Ônibus deve ser positivo");
        IdOnibus = idOnibus;

        ValidateDomain(idEquipamento, modelo,
        placa, anoFabricacao, taxaOnibus, latitude,
        longitude, idEquipamentoNavigation, idRotasNavigation, rota, onibusRotas);
        
    }

    public void Update(int idEquipamento, string modelo,
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Equipamento idEquipamentoNavigation, Rota idRotasNavigation,
        ICollection<Rota> rota, ICollection<OnibusRota> onibusRotas)
    {
        ValidateDomain(idEquipamento, modelo,
        placa, anoFabricacao, taxaOnibus, latitude,
        longitude, idEquipamentoNavigation, idRotasNavigation, rota, onibusRotas);
    }

    public void ValidateDomain(int idEquipamento, string modelo,
        string placa, int anoFabricacao, decimal taxaOnibus, decimal latitude,
        decimal longitude, Equipamento idEquipamentoNavigation, Rota idRotasNavigation, ICollection<Rota> rota, ICollection<OnibusRota> onibusRotas)
    {            
        Modelo = modelo;
        Placa = placa;
        AnoFabricacao = anoFabricacao;
        TaxaOnibus = taxaOnibus;
        Latitude = latitude;
        Longitude = longitude;
        IdEquipamentoNavigation = idEquipamentoNavigation;
        OnibusRotas = onibusRotas;
        IdEquipamento = idEquipamento;
    }
}
