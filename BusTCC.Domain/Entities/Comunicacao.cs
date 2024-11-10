using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Comunicacao
{
    public int IdDados { get; private set; }

    public int IdEquipamento { get; private set; }

    public int IdCatraca { get; private set; }

    public DateOnly Data { get; private set; }

    public virtual ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    public virtual Catraca IdCatracaNavigation { get; set; } = null!;

    public virtual Equipamento IdEquipamentoNavigation { get; set; } = null!;

    public virtual ICollection<Onibus> Onibus { get; set; } = new List<Onibus>();

    public Comunicacao(int idDados, int idEquipamento, int idCatraca, DateOnly data, ICollection<Equipamento> equipamentos,
        Catraca idCatracaNavigation, Equipamento idEquipamentoNavigation, ICollection<Onibus> onibus)
    {
        DomainExceptionValidation.When(idDados < 0, "O Id da comunicação deve ser positivo");
        IdDados = idDados;
        ValidateDomain(idEquipamento, idCatraca, data, equipamentos,
        idCatracaNavigation, idEquipamentoNavigation, onibus);
    }

    public void Update(int idEquipamento, int idCatraca, DateOnly data, ICollection<Equipamento> equipamentos,
        Catraca idCatracaNavigation, Equipamento idEquipamentoNavigation, ICollection<Onibus> onibus)
    {
        ValidateDomain(idEquipamento, idCatraca, data, equipamentos,
        idCatracaNavigation, idEquipamentoNavigation, onibus);
    }

    public void ValidateDomain(int idEquipamento, int idCatraca, DateOnly data, ICollection<Equipamento> equipamentos,
        Catraca idCatracaNavigation, Equipamento idEquipamentoNavigation, ICollection<Onibus> onibus)
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O Id do equipamento deve ser positivo");
        DomainExceptionValidation.When(idCatraca < 0, "O Id da catraca deve ser positivo");

        IdEquipamento = idEquipamento;
        IdCatraca = idCatraca;
        Data = data;
        Equipamentos = equipamentos;
        IdCatracaNavigation = idCatracaNavigation;
        IdEquipamentoNavigation = idEquipamentoNavigation;
        Onibus = onibus;
    }
}
