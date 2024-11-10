using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; private set; }

    public int IdPreferencia { get; private set; }

    public string NomeCompleto { get; private set; } = null!;

    public int NumeroCelular { get; private set; }

    public string Email { get; private set; } = null!;

    public virtual Preferencia IdPreferenciaNavigation { get; set; } = null!;

    public Usuario(int idUsuario, int idPreferencia, string nomeCompleto, int numeroCelular,
        string email, Preferencia idPreferenciaNavigation)
    {
        DomainExceptionValidation.When(idUsuario < 0, "O id do usuário deve ser positivo");
        IdUsuario = idUsuario;

        ValidateDomain(idPreferencia, nomeCompleto, numeroCelular,
        email, idPreferenciaNavigation);
    }

    public void Update(int idPreferencia, string nomeCompleto, int numeroCelular,
        string email, Preferencia idPreferenciaNavigation)
    {
        ValidateDomain(idPreferencia, nomeCompleto, numeroCelular,
        email, idPreferenciaNavigation);
    }

    public void ValidateDomain(int idPreferencia, string nomeCompleto, int numeroCelular,
        string email, Preferencia idPreferenciaNavigation)
    {
        DomainExceptionValidation.When(IdPreferencia < 0, "O id da preferência do usuário deve ser positivo");
        DomainExceptionValidation.When(NomeCompleto.Length > 60, "O nome completo deve possuir no máximo 60 caracteres.");
        DomainExceptionValidation.When(Email.Length > 30, "O e-mail deve possuir no máximo 30 caracteres.");


        IdPreferencia = idPreferencia;
        NomeCompleto = nomeCompleto;
        NumeroCelular = numeroCelular;
        Email = email;
        IdPreferenciaNavigation = idPreferenciaNavigation;
    }
}
