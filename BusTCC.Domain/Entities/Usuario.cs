using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; private set; }   

    public string NomeCompleto { get; private set; } = null!;

    public int NumeroCelular { get; private set; }

    public string Email { get; private set; } = null!;    
    public virtual ICollection<Preferencia> Preferencias { get; set; } = new List<Preferencia>();

    protected Usuario() { }

    public Usuario(int idUsuario, string nomeCompleto, int numeroCelular,
        string email, ICollection<Preferencia> preferencias )
    {
        DomainExceptionValidation.When(idUsuario < 0, "O id do usuário deve ser positivo");
        IdUsuario = idUsuario;

        ValidateDomain(nomeCompleto, numeroCelular,
        email, preferencias);
    }

    public void Update(string nomeCompleto, int numeroCelular,
        string email, ICollection<Preferencia> preferencias)
    {
        ValidateDomain( nomeCompleto, numeroCelular,
        email, preferencias);
    }

    public void ValidateDomain( string nomeCompleto, int numeroCelular,
        string email, ICollection<Preferencia> preferencias)
    {        
        DomainExceptionValidation.When(NomeCompleto.Length > 60, "O nome completo deve possuir no máximo 60 caracteres.");
        DomainExceptionValidation.When(Email.Length > 30, "O e-mail deve possuir no máximo 30 caracteres.");
                
        NomeCompleto = nomeCompleto;
        NumeroCelular = numeroCelular;
        Email = email;
        Preferencias = preferencias;
    }
}
