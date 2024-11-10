using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Preferencium
{
    public int IdPreferencia { get; set; }

    public string Deficiencia { get; set; } = null!;

    public string Notificacao { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
