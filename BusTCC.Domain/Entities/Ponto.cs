using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Ponto
{
    public int IdPonto { get; private set; }

    public int IdRotas { get; private set; }

    public string RuaAvenida { get; private set; } = null!;

    public string Bairro { get; private set; } = null!;

    public string Estado { get; private set; } = null!;

    public virtual Rota IdRotasNavigation { get; set; } = null!;

    public virtual ICollection<Rota> Rota { get; set; } = new List<Rota>();

    public Ponto(int idPonto, int idRotas, string ruaAvenida, string bairro,
        string estado, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        DomainExceptionValidation.When(idPonto < 0, "O id do Ponto de ônibus deve ser positivo");
        IdPonto = idPonto;

        ValidateDomain(idRotas, ruaAvenida, bairro,
        estado, idRotasNavigation, rota);
        
    }

    public void Update(int idRotas, string ruaAvenida, string bairro,
        string estado, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        ValidateDomain(idRotas, ruaAvenida, bairro,
        estado, idRotasNavigation, rota);
    }

    public void ValidateDomain(int idRotas, string ruaAvenida, string bairro,
        string estado, Rota idRotasNavigation, ICollection<Rota> rota)
    {
        DomainExceptionValidation.When(idRotas < 0, "O id da Rota de ônibus deve ser positivo");
        IdRotas = idRotas;
        RuaAvenida = ruaAvenida;
        Bairro = bairro;
        Estado = estado;
        IdRotasNavigation = idRotasNavigation;
        Rota = rota;
    }
}
