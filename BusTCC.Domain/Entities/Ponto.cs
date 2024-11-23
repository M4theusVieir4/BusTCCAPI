using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Ponto
{
    public int IdPonto { get; private set; }    

    public string RuaAvenida { get; private set; } = null!;

    public string Bairro { get; private set; } = null!;

    public string Estado { get; private set; } = null!;

    public virtual ICollection<RotasPontos> RotasPontos { get; set; }

    protected Ponto() { }

    public Ponto(int idPonto, string ruaAvenida, string bairro,
        string estado, ICollection<RotasPontos> rotasPontos)
    {
        DomainExceptionValidation.When(idPonto < 0, "O id do Ponto de ônibus deve ser positivo");
        IdPonto = idPonto;

        ValidateDomain(ruaAvenida, bairro,
        estado, rotasPontos);         
    }

    public void Update(string ruaAvenida, string bairro,
        string estado, ICollection<RotasPontos> rotasPontos)
    {
        ValidateDomain(ruaAvenida, bairro,
        estado, rotasPontos);
    }

    public void ValidateDomain(string ruaAvenida, string bairro,
        string estado, ICollection<RotasPontos> rotasPontos)
    {       
        RuaAvenida = ruaAvenida;
        Bairro = bairro;
        Estado = estado;
        RotasPontos = rotasPontos;
    }
}
