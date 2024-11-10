using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Preferencia
{
    public int IdPreferencia { get; private set; }

    public bool Deficiencia { get; private set; }

    public bool Notificacao { get; private set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public Preferencia(int idPreferencia, bool deficiencia, bool notificacao, ICollection<Usuario> usuarios)
    {
        DomainExceptionValidation.When(idPreferencia < 0, "O id da preferência do usuário deve ser positivo");
        IdPreferencia = idPreferencia;

        ValidateDomain(deficiencia, notificacao, usuarios);        
    }

    public void Update (bool deficiencia, bool notificacao, ICollection<Usuario> usuarios)
    {
        ValidateDomain(deficiencia, notificacao, usuarios);
    }

    public void ValidateDomain(bool deficiencia, bool notificacao, ICollection<Usuario> usuarios)
    {
        Deficiencia = deficiencia;
        Notificacao = notificacao;
        Usuarios = usuarios;
    }
}
