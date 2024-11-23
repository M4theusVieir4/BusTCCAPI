using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Rota
{
    public int IdRotas { get; private set; }
    public string Nome_Rota { get; private set; }
    public virtual ICollection<OnibusRota> OnibusRotas { get; set; }
    public virtual ICollection<RotasPontos> RotasPontos { get; set; }

    protected Rota() { }


    public Rota(int idRotas, string nomeRota, ICollection<OnibusRota> onibusRotas, ICollection<RotasPontos> rotasPontos)
    {
        DomainExceptionValidation.When(idRotas < 0, "O id da Rota deve ser positivo");
        IdRotas = idRotas;

        ValidateDomain(nomeRota, onibusRotas, rotasPontos);
    }

    public void Update(string nomeRota, ICollection<OnibusRota> onibusRotas, ICollection<RotasPontos> rotasPontos)
    {
        ValidateDomain(nomeRota, onibusRotas, rotasPontos);
    }

    public void ValidateDomain(string nomeRota, ICollection<OnibusRota> onibusRotas, ICollection<RotasPontos> rotasPontos)
    {
        DomainExceptionValidation.When(nomeRota.Length > 0, "A rota precisa ser nomeada");        

        Nome_Rota = nomeRota;
        OnibusRotas = onibusRotas;
        RotasPontos = rotasPontos;
    }
}
