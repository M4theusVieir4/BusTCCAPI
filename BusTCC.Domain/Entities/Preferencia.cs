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
    public int IdUsuario { get; private set; }
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    protected Preferencia() { }


    public Preferencia(int idPreferencia, bool deficiencia, bool notificacao, int idUsuario, Usuario idUsuarioNavigation)
    {
        DomainExceptionValidation.When(idPreferencia < 0, "O id da preferência do usuário deve ser positivo");
        IdPreferencia = idPreferencia;

        ValidateDomain(deficiencia, notificacao, idUsuario, idUsuarioNavigation);        
    }

    public void Update (bool deficiencia, bool notificacao, int idUsuario, Usuario idUsuarioNavigation)
    {        
        ValidateDomain(deficiencia, notificacao, idUsuario, idUsuarioNavigation);
    }

    public void ValidateDomain(bool deficiencia, bool notificacao, int idUsuario, Usuario idUsuarioNavigation)
    {
        DomainExceptionValidation.When(idUsuario < 0, "O id do usuário deve ser positivo");
        Deficiencia = deficiencia;
        Notificacao = notificacao;
        IdUsuario = idUsuario;
        IdUsuarioNavigation = idUsuarioNavigation;
    }
}
