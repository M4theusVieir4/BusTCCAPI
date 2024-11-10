using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Comunicacao
{
    public int IdDados { get; set; }

    public int IdEquipamento { get; set; }

    public int IdCatraca { get; set; }

    public DateOnly Data { get; set; }

    public virtual ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    public virtual Catraca IdCatracaNavigation { get; set; } = null!;

    public virtual Equipamento IdEquipamentoNavigation { get; set; } = null!;

    public virtual ICollection<Onibu> Onibus { get; set; } = new List<Onibu>();
}
