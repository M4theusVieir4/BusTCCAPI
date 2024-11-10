using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Catraca
{
    public int IdCatraca { get; private set; }

    public int? IdEquipamento { get; private set; }

    public string? Local { get; private set; }

    public int? QuantidadeEntrada { get; private set; }

    public int? QuantidadeSaida { get; private set; }

    public virtual ICollection<Comunicacao> Comunicacaos { get; set; } = new List<Comunicacao>();

    public virtual Equipamento? IdEquipamentoNavigation { get; set; }

    public Catraca(int idCatraca, int? idEquipamento, string? local, int? quantidadeEntrada,
        int? quantidadeSaida, ICollection<Comunicacao> comunicacaos,
        Equipamento? idEquipamentoNavigation)
    {
        DomainExceptionValidation.When(idCatraca < 0, "O Id da catraca deve ser positivo");
        IdCatraca = idCatraca;
        ValidateDomain(idEquipamento, local, quantidadeEntrada, quantidadeSaida,
        comunicacaos, idEquipamentoNavigation);
    }

    public void Update(int? idEquipamento, string? local, int? quantidadeEntrada,
        int? quantidadeSaida, ICollection<Comunicacao> comunicacaos,
        Equipamento? idEquipamentoNavigation)
    {
        ValidateDomain(idEquipamento, local, quantidadeEntrada, quantidadeSaida,
        comunicacaos, idEquipamentoNavigation);
    }

    public void ValidateDomain(int? idEquipamento, string? local, int? quantidadeEntrada,
        int? quantidadeSaida, ICollection<Comunicacao> comunicacaos,
        Equipamento? idEquipamentoNavigation)
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O Id do equipamento deve ser positivo");
        DomainExceptionValidation.When(local.Length > 255, "O local não pode ultrapassar 255 caracteres!");
        DomainExceptionValidation.When(quantidadeEntrada < 0, "A quantidade de entrada deve ser positivo");
        DomainExceptionValidation.When(quantidadeSaida < 0, "A quantidade de saida deve ser positivo");

        IdEquipamento = idEquipamento;
        Local = local;
        QuantidadeEntrada = quantidadeEntrada;
        QuantidadeSaida = quantidadeSaida;
        Comunicacaos = comunicacaos;
        IdEquipamentoNavigation = idEquipamentoNavigation;
    }
}
