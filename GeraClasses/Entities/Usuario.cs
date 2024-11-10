using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdPreferencia { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public int NumeroCelular { get; set; }

    public string Email { get; set; } = null!;

    public virtual Preferencium IdPreferenciaNavigation { get; set; } = null!;
}
