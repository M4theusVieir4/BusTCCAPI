using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Rota
{
    public int IdRotas { get; set; }

    public int IdPonto { get; set; }

    public int IdOnibus { get; set; }

    public virtual Onibu IdOnibusNavigation { get; set; } = null!;

    public virtual Ponto IdPontoNavigation { get; set; } = null!;

    public virtual ICollection<Onibu> Onibus { get; set; } = new List<Onibu>();

    public virtual ICollection<Ponto> Pontos { get; set; } = new List<Ponto>();
}
