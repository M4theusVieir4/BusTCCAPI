using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Rota
{
    public int IdRotas { get; private set; }

    public int IdPonto { get; private set; }

    public int IdOnibus { get; private set; }

    public virtual Onibus IdOnibusNavigation { get; set; } = null!;

    public virtual Ponto IdPontoNavigation { get; set; } = null!;

    public virtual ICollection<Onibus> Onibus { get; set; } = new List<Onibus>();

    public virtual ICollection<Ponto> Pontos { get; set; } = new List<Ponto>();

    public Rota(int idRotas, int idPonto, int idOnibus, Onibus idOnibusNavigation,
        Ponto idPontoNavigation, ICollection<Onibus> onibus, ICollection<Ponto> pontos)
    {
        DomainExceptionValidation.When(idRotas < 0, "O id da Rota deve ser positivo");
        IdRotas = idRotas;

        ValidateDomain(idPonto, idOnibus, idOnibusNavigation,
        idPontoNavigation, onibus, pontos);
    }

    public void Update(int idPonto, int idOnibus, Onibus idOnibusNavigation,
        Ponto idPontoNavigation, ICollection<Onibus> onibus, ICollection<Ponto> pontos)
    {
        ValidateDomain(idPonto, idOnibus, idOnibusNavigation,
        idPontoNavigation, onibus, pontos);
    }

    public void ValidateDomain(int idPonto, int idOnibus, Onibus idOnibusNavigation,
        Ponto idPontoNavigation, ICollection<Onibus> onibus, ICollection<Ponto> pontos)
    {
        DomainExceptionValidation.When(idPonto < 0, "O id do ponto de ônibus deve ser positivo");
        DomainExceptionValidation.When(idOnibus < 0, "O id do ônibus deve ser positivo");

        IdPonto = idPonto;
        IdOnibus = idOnibus;
        IdOnibusNavigation = idOnibusNavigation;
        IdPontoNavigation = idPontoNavigation;
        Onibus = onibus;
        Pontos = pontos;
    }
}
