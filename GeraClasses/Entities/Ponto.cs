using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Ponto
{
    public int IdPonto { get; set; }

    public int IdRotas { get; set; }

    public string RuaAvenida { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Rota IdRotasNavigation { get; set; } = null!;

    public virtual ICollection<Rota> Rota { get; set; } = new List<Rota>();
}
